using System.Runtime.InteropServices;
using BymlLibrary;

namespace BotwShopDataUtil.Helpers
{
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    internal struct NintendoHash : IComparable<NintendoHash>
    {
        [FieldOffset(0)]
        public int ivalue;
        [FieldOffset(0)]
        public uint uvalue;

        public NintendoHash(Byml byml)
        {
            if (byml.Type == BymlNodeType.Int)
            {
                ivalue = byml.GetInt();
            }
            else
            {
                uvalue = byml.GetUInt32();
            }
        }

        public NintendoHash(ImmutableByml ibyml)
        {
            if (ibyml.Type == BymlNodeType.Int)
            {
                ivalue = ibyml.GetInt();
            }
            else
            {
                uvalue = ibyml.GetUInt32();
            }
        }

        public NintendoHash(int val)
        {
            ivalue = val;
        }

        public NintendoHash(uint val)
        {
            uvalue = val;
        }

        public readonly Byml ToHash()
        {
            if (ivalue < 0)
            {
                return new Byml(uvalue);
            }
            return new Byml(ivalue);
        }

        public override readonly string ToString()
        {
            if (ivalue < 0)
            {
                return $"!u 0x{uvalue:X8}";
            }
            return ivalue.ToString();
        }

        public readonly int CompareTo(NintendoHash other)
        {
            return uvalue.CompareTo(other.uvalue);
        }
    }
}
