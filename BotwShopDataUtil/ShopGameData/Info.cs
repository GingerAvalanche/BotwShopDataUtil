using BymlLibrary.Nodes.Containers;
using BymlLibrary;

namespace BotwShopDataUtil.ShopGameData
{
    internal class Info
    {
        public ShopAreaSection ShopInfo;
        public SoldOutInfo SoldInfo;

        public Info()
        {
            ShopInfo = new();
            SoldInfo = new();
        }

        public Info(Byml byml)
        {
            BymlMap map = byml.GetMap();
            ShopInfo = new(map["ShopAreaInfo"]);
            SoldInfo = new(map["SoldOutInfo"]);
        }

        public Byml ToByml()
        {
            return new Byml(new BymlMap()
            {
                ["ShopAreaInfo"] = ShopInfo.ToByml(),
                ["SoldOutInfo"] = SoldInfo.ToByml()
            });
        }
    }
}
