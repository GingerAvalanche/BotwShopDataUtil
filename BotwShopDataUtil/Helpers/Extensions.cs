using BymlLibrary;
using BymlLibrary.Extensions;
using BymlLibrary.Nodes.Containers;
using BymlLibrary.Nodes.Immutable.Containers;

namespace BotwShopDataUtil.Helpers
{
    internal static class Extensions
    {
        internal static bool TryGetValue(this ImmutableBymlMap map, ImmutableBymlStringTable table, string key, out ImmutableByml value)
        {
            foreach (var (mapKeyIdx, mapValue) in map)
            {
                Span<byte> mapKeySpan = table[mapKeyIdx];
                if (mapKeySpan.Length == key.Length + 1 && mapKeySpan.ToManaged() == key)
                {
                    value = mapValue;
                    return true;
                }
            }
            value = default;
            return false;
        }

        internal static ImmutableByml GetValue(this ImmutableBymlMap map, ImmutableBymlStringTable table, string key)
        {
            foreach (var (mapKeyIdx, mapValue) in map)
            {
                Span<byte> mapKeySpan = table[mapKeyIdx];
                if (mapKeySpan.Length == key.Length + 1 && mapKeySpan.ToManaged() == key)
                {
                    return mapValue;
                }
            }
            throw new KeyNotFoundException(key);
        }

        internal static string GetString(this ImmutableByml byml, ImmutableBymlStringTable table) => table[byml.GetStringIndex()].ToManaged();

        internal static Byml ToByml(this int[] array)
        {
            return new Byml(new BymlArray(array.Select(i => new Byml(i)).ToList()));
        }

        internal static int[] ToIntArray(this BymlArray array)
        {
            return array.Select(b => (int)b.Value!).ToArray();
        }

        internal static void SortAreas(this Byml byml)
        {
            byml.GetArray().Sort((a, b) => Comparer<int[]>.Default.Compare(a.GetArray().ToIntArray(), b.GetArray().ToIntArray()));
        }
    }
}
