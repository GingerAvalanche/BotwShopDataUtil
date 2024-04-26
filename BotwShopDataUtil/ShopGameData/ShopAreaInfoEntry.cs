using BotwShopDataUtil.Helpers;
using BymlLibrary;
using BymlLibrary.Nodes.Containers;

namespace BotwShopDataUtil.ShopGameData
{
    internal class ShopAreaInfoEntry
    {
        public List<int[]>? Areas;
        public string Dealer;
        public string Item;

        public ShopAreaInfoEntry(Byml byml)
        {
            BymlMap map = byml.GetMap();
            if (map.TryGetValue("Areas", out Byml? value))
            {
                Areas = value.GetArray().Select(b => b.GetArray().Select(i => i.GetInt()).ToArray()).ToList();
            }
            Dealer = map["Dealer"].GetString();
            Item = map["Item"].GetString();
        }

        public ShopAreaInfoEntry(string dealer, string item)
        {
            Dealer = dealer;
            Item = item;
        }

        public ShopAreaInfoEntry(string dealer, string item, List<int[]> areas)
        {
            Areas = areas;
            Dealer = dealer;
            Item = item;
        }

        public Byml ToByml()
        {
            BymlMap map = [];
            if (Areas != null)
            {
                Areas.Sort(HelperFunctions.CompareAreas);
                map["Areas"] = new Byml(new BymlArray(Areas.Select(a => a.ToByml())));
            }
            map["Dealer"] = new Byml(Dealer);
            map["Item"] = new Byml(Item);
            return new Byml(map);
        }

        public override string ToString()
        {
            if (Areas != null)
            {
                string areas = string.Join("\n", Areas.Select(i => $"    - [{i[0]}, {i[1]}]"));
                return $"- Areas:\n{areas}\n  Dealer: {Dealer}\n  Item: {Item}";
            }
            return $"- Dealer: {Dealer}\n  Item: {Item}";
        }
    }
}
