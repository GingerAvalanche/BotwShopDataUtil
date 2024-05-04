using System.Buffers.Binary;
using System.Runtime.InteropServices;

namespace EveryFileExplorer
{
    public unsafe class Yaz0
    {
        public const uint MAGIC = 0x307A6159;

        public static unsafe byte[] Compress(byte[] Data, int level = 3, UInt32 reserved1 = 0, UInt32 reserved2 = 0)
        {
            int maxBackLevel = (int)(0x10e0 * (level / 9.0) - 0x0e0);

            byte* dataptr = (byte*)Marshal.UnsafeAddrOfPinnedArrayElement(Data, 0);

            byte[] result = new byte[Data.Length + Data.Length / 8 + 0x10];
            byte* resultptr = (byte*)Marshal.UnsafeAddrOfPinnedArrayElement(result, 0);
            *resultptr++ = (byte)'Y';
            *resultptr++ = (byte)'a';
            *resultptr++ = (byte)'z';
            *resultptr++ = (byte)'0';
            *resultptr++ = (byte)((Data.Length >> 24) & 0xFF);
            *resultptr++ = (byte)((Data.Length >> 16) & 0xFF);
            *resultptr++ = (byte)((Data.Length >> 8) & 0xFF);
            *resultptr++ = (byte)((Data.Length >> 0) & 0xFF);
            {
                var res1 = BitConverter.GetBytes(reserved1);
                var res2 = BitConverter.GetBytes(reserved2);
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(res1);
                    Array.Reverse(res2);
                }
                *resultptr++ = res1[0];
                *resultptr++ = res1[1];
                *resultptr++ = res1[2];
                *resultptr++ = res1[3];
                *resultptr++ = res2[0];
                *resultptr++ = res2[1];
                *resultptr++ = res2[2];
                *resultptr++ = res2[3];
            }
            int length = Data.Length;
            int dstoffs = 16;
            int Offs = 0;
            while (true)
            {
                int headeroffs = dstoffs++;
                resultptr++;
                byte header = 0;
                for (int i = 0; i < 8; i++)
                {
                    int comp = 0;
                    int back = 1;
                    int nr = 2;
                    {
                        byte* ptr = dataptr - 1;
                        int maxnum = 0x111;
                        if (length - Offs < maxnum) maxnum = length - Offs;
                        int maxback = maxBackLevel;
                        if (Offs < maxback) maxback = Offs;
                        maxback = (int)dataptr - maxback;
                        int tmpnr;
                        while (maxback <= (int)ptr)
                        {
                            if (*(ushort*)ptr == *(ushort*)dataptr && ptr[2] == dataptr[2])
                            {
                                tmpnr = 3;
                                while (tmpnr < maxnum && ptr[tmpnr] == dataptr[tmpnr]) tmpnr++;
                                if (tmpnr > nr)
                                {
                                    if (Offs + tmpnr > length)
                                    {
                                        nr = length - Offs;
                                        back = (int)(dataptr - ptr);
                                        break;
                                    }
                                    nr = tmpnr;
                                    back = (int)(dataptr - ptr);
                                    if (nr == maxnum) break;
                                }
                            }
                            --ptr;
                        }
                    }
                    if (nr > 2)
                    {
                        Offs += nr;
                        dataptr += nr;
                        if (nr >= 0x12)
                        {
                            *resultptr++ = (byte)(((back - 1) >> 8) & 0xF);
                            *resultptr++ = (byte)((back - 1) & 0xFF);
                            *resultptr++ = (byte)((nr - 0x12) & 0xFF);
                            dstoffs += 3;
                        }
                        else
                        {
                            *resultptr++ = (byte)((((back - 1) >> 8) & 0xF) | (((nr - 2) & 0xF) << 4));
                            *resultptr++ = (byte)((back - 1) & 0xFF);
                            dstoffs += 2;
                        }
                        comp = 1;
                    }
                    else
                    {
                        *resultptr++ = *dataptr++;
                        dstoffs++;
                        Offs++;
                    }
                    header = (byte)((header << 1) | ((comp == 1) ? 0 : 1));
                    if (Offs >= length)
                    {
                        header = (byte)(header << (7 - i));
                        break;
                    }
                }
                result[headeroffs] = header;
                if (Offs >= length) break;
            }
            while ((dstoffs % 4) != 0) dstoffs++;
            byte[] realresult = new byte[dstoffs];
            Array.Copy(result, realresult, dstoffs);
            return realresult;
        }

        public static int GetDecompressedSize(ReadOnlySpan<byte> data)
        {
            return BinaryPrimitives.ReverseEndianness(MemoryMarshal.Read<int>(data[4..8]));
        }

        public static byte[] Decompress(ReadOnlySpan<byte> data)
        {
            byte[] result = new byte[GetDecompressedSize(data)];
            Decompress(data, result);
            return result;
        }

        public static void Decompress(ReadOnlySpan<byte> src, Span<byte> dst)
        {
            if (MemoryMarshal.Cast<byte, uint>(src[0..4])[0] != MAGIC)
            {
                throw new InvalidOperationException("""
                Invalid Yaz0 magic
                """);
            }

            int src_it = 16;
            int dst_it = 0;

            while (dst_it < dst.Length)
            {
                byte header = src[src_it++];
                for (int i = 0; i < 8 && dst_it < dst.Length; i++)
                {
                    if ((header & 0x80) != 0)
                    {
                        dst[dst_it++] = src[src_it++];
                    }
                    else
                    {
                        byte pair = src[src_it++];
                        int distance = (((pair & 0xF) << 8) | src[src_it++]) + 1;
                        int length = (pair >> 4) + 2;

                        if (length == 2)
                        {
                            length = src[src_it++] + 18;
                        }

                        if (distance <= dst_it)
                        {
                            for (int j = 0; j < length; j++)
                            {
                                dst[dst_it] = dst[dst_it - distance];
                                dst_it++;
                            }
                        }
                    }

                    header <<= 1;
                }
            }
        }
    }
}
