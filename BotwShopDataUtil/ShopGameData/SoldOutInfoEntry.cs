using BotwShopDataUtil.Helpers;
using BymlLibrary;
using BymlLibrary.Nodes.Containers;

namespace BotwShopDataUtil.ShopGameData
{
    internal class SoldOutInfoEntry
    {
        public HashSet<NintendoHash> SoldOutFlags;

        public SoldOutInfoEntry(Byml byml)
        {
            SoldOutFlags = byml.GetMap()["SoldOutFlags"].GetArray().Select(b => new NintendoHash(b)).ToHashSet();
        }

        public SoldOutInfoEntry(HashSet<NintendoHash> hashes)
        {
            SoldOutFlags = hashes;
        }

        public Byml ToByml()
        {
            return new Byml(new BymlMap() { ["SoldOutFlags"] = new Byml(new BymlArray(SoldOutFlags.Select(h => h.ToHash()))) });
        }

        public override string ToString()
        {
            string flagString = string.Join(", ", SoldOutFlags);
            return $"- SoldOutFlags: [{flagString}]";
        }
    }
}
