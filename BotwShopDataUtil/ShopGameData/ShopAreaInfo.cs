using BotwShopDataUtil.Helpers;
using BymlLibrary;
using BymlLibrary.Nodes.Containers;

namespace BotwShopDataUtil.ShopGameData
{
    internal class ShopAreaSection
    {
        public SortedDictionary<NintendoHash, ShopAreaInfoEntry> Entries;

        public ShopAreaSection()
        {
            Entries = [];
        }

        public ShopAreaSection(Byml byml)
        {
            BymlMap map = byml.GetMap();
            BymlArray hashes = map["Hashes"].GetArray();
            BymlArray entries = map["Values"].GetArray();
            Entries = [];
            for (int i = 0; i < hashes.Count; ++i)
            {
                Entries[new NintendoHash(hashes[i])] = new(entries[i]);
            }
        }

        public Byml ToByml()
        {
            return new Byml(new BymlMap()
            {
                ["Hashes"] = new BymlArray(Entries.Keys.Select(k => k.ToHash())),
                ["Values"] = new BymlArray(Entries.Values.Select(v => v.ToByml()))
            });
        }
    }
}
