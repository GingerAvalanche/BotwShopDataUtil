using BotwShopDataUtil.ShopGameData;
using BymlLibrary.Nodes.Immutable.Containers;
using BymlLibrary;
using CsYaz0;
using Revrs;
using Aamp.Security.Cryptography;
using BymlLibrary.Extensions;
using Nintendo.Aamp;
using SarcLibrary;
using SharpYaml.Tokens;

namespace BotwShopDataUtil.Helpers
{
    internal class HelperFunctions
    {
        public static readonly string[] SkipActorStems = ["DressFairy", "AncientOven", "HorseAssociationCustum", "Npc_HatenoVillage001", "Npc_AncientAssistant001"];
        public static List<int[]> GetNpcAreas(string npcName, Dictionary<string, List<int[]>> modAreas)
        {
            if (modAreas.TryGetValue(npcName, out List<int[]>? areas))
            {
                return areas;
            }
            areas = [];
            Console.WriteLine();
            Console.WriteLine($"Location not found for actor. Please enter the coordinates for {npcName}.");
            Console.WriteLine("Coordinates can be found in the smubin file where the actor is located.");
            Console.WriteLine("Looks like this: 'Translate: [X, Y, Z]'");
            bool cont = true;
            while (cont)
            {
                Console.WriteLine("Type the X value, then hit Enter");
                float xVal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Type the Z value, then hit Enter");
                float zVal = Convert.ToSingle(Console.ReadLine());
                areas.Add([
                    Math.Clamp(((int)xVal + 5000) / 1000, 0, 9),
                    Math.Clamp(((int)zVal + 4000) / 1000, 0, 7),
                ]);

                string r = "";
                while (r != "y" && r != "n")
                {
                    Console.WriteLine("Is this actor placed at another location, also? (y/n)");
                    string? response = Console.ReadLine();
                    if (response != null)
                    {
                        r = response;
                    }
                }
                if (r == "n")
                {
                    cont = false;
                }
            }
            return areas;
        }

        public static int CompareAreas(int[] a, int[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return a[i] - b[i];
                }
            }
            return 0;
        }

        public static void AddNpcAreasAndSaleItemEntriesFromMapFiles(
            string fieldPath,
            Dictionary<string, List<int[]>> npcAreas,
            Dictionary<NintendoHash, (ShopAreaInfoEntry, NintendoHash[])> saleItemEntries,
            HashSet<string> filesUsed
        )
        {
            EnumerationOptions options = new() { RecurseSubdirectories = true };
            int currentFile = 0;
            int fileCount = Directory.EnumerateFiles(fieldPath, "?-?_*.smubin", options).Count();
            SetUpProgressLine(fileCount);
            foreach (string path in Directory.GetFiles(fieldPath, "?-?_*.smubin", options))
            {
                UpdateProgressLine(++currentFile, fileCount);
                if (filesUsed.Contains(Path.GetFileName(path)))
                {
                    continue;
                }
                filesUsed.Add(Path.GetFileName(path));

                RevrsReader revrsReader = new(Yaz0.Decompress(File.ReadAllBytes(path)));
                ImmutableByml mubin = new(ref revrsReader);
                Dictionary<string, List<int[]>> nodeData = [];
                Dictionary<NintendoHash, string> npcLookup = [];
                Dictionary<NintendoHash, (string, NintendoHash, HashSet<NintendoHash>)> saleItems = [];
                Dictionary<NintendoHash, NintendoHash> soldOutLinkTags = [];
                Dictionary<NintendoHash, NintendoHash> linkTagBasicSigs = [];

                foreach (var (rootKey, rootValue) in mubin.GetMap())
                {
                    if (mubin.KeyTable[rootKey].ToManaged() == "Objs")
                    {
                        foreach (var actorInstance in rootValue.GetArray())
                        {
                            ImmutableBymlMap actorMap = actorInstance.GetMap();
                            NintendoHash hashId = new(actorMap.GetValue(mubin.KeyTable, "HashId"));
                            int foundDealer = 0;
                            string actorName = string.Empty;
                            int[] area = new int[2];
                            if (actorMap.TryGetValue(mubin.KeyTable, "UnitConfigName", out ImmutableByml value))
                            {
                                Span<byte> actorNameSpan = mubin.StringTable[value.GetStringIndex()];
                                actorName = value.GetString(mubin.StringTable);
                                if (actorName.Contains("Obj_Head"))
                                {
                                    continue;
                                }
                                if (actorName.StartsWith("NPC_", StringComparison.OrdinalIgnoreCase) &&
                                    !actorName.Contains("HiddenKorok"))
                                {
                                    ++foundDealer;
                                }
                                else if (actorName.Contains("LinkTag"))
                                {
                                    if (actorMap.TryGetValue(mubin.KeyTable, "!Parameters", out ImmutableByml bParams) &&
                                        bParams.GetMap().TryGetValue(mubin.KeyTable, "SaveFlag", out ImmutableByml linkSaveFlag))
                                    {
                                        soldOutLinkTags[hashId] = new(Crc32.Compute(linkSaveFlag.GetString(mubin.StringTable)));
                                    }
                                    else if (actorMap.TryGetValue(mubin.KeyTable, "LinksToObj", out ImmutableByml links))
                                    {
                                        foreach (ImmutableByml link in links.GetArray())
                                        {
                                            ImmutableBymlMap linkMap = link.GetMap();
                                            if (linkMap.TryGetValue(mubin.KeyTable, "DefinitionName", out ImmutableByml defName) &&
                                                defName.GetString(mubin.StringTable) == "BasicSig")
                                            {
                                                linkTagBasicSigs[hashId] = new(linkMap.GetValue(mubin.KeyTable, "DestUnitHashId"));
                                            }
                                        }
                                    }
                                }
                            }
                            if (actorMap.TryGetValue(mubin.KeyTable, "Translate", out value))
                            {
                                ImmutableBymlArray translate = value.GetArray();
                                area[0] = Math.Clamp(((int)translate[0].GetFloat() + 5000) / 1000, 0, 9);
                                area[1] = Math.Clamp(((int)translate[2].GetFloat() + 4000) / 1000, 0, 7);
                                ++foundDealer;
                            }
                            if (foundDealer == 2)
                            {
                                npcLookup[hashId] = actorName;
                                if (nodeData.TryGetValue(actorName, out List<int[]>? actorAreas))
                                {
                                    if (!actorAreas.Any(a => a.SequenceEqual(area)))
                                    {
                                        actorAreas.Add(area);
                                    }
                                }
                                else
                                {
                                    nodeData[actorName] = [area];
                                }
                            }
                            if (actorMap.TryGetValue(mubin.KeyTable, "LinksToObj", out value))
                            {
                                bool foundDealerLink = false;
                                NintendoHash forSale = default;
                                HashSet<NintendoHash> deadUp = [];
                                foreach (ImmutableByml link in value.GetArray())
                                {
                                    ImmutableBymlMap linkMap = link.GetMap();
                                    if (linkMap.TryGetValue(mubin.KeyTable, "DefinitionName", out ImmutableByml linkValue))
                                    {
                                        string defName = linkValue.GetString(mubin.StringTable);
                                        if (defName == "ForSale")
                                        {
                                            forSale = new(linkMap.GetValue(mubin.KeyTable, "DestUnitHashId"));
                                            foundDealerLink = true;
                                        }
                                        else if (defName == "DeadUp")
                                        {
                                            deadUp.Add(new(linkMap.GetValue(mubin.KeyTable, "DestUnitHashId")));
                                        }
                                    }
                                }
                                if (foundDealerLink)
                                {
                                    NintendoHash flagHash = new(Crc32.Compute($"MainField_{actorName}_{hashId.uvalue}"));
                                    saleItems[flagHash] = (actorName, forSale, deadUp);
                                }
                            }
                        }
                    }
                }

                foreach (var (actorName, areas) in nodeData)
                {
                    if (!npcAreas.TryGetValue(actorName, out List<int[]>? value))
                    {
                        npcAreas[actorName] = [];
                        value = npcAreas[actorName];
                    }
                    value.AddRange(areas.Where(a => !value.Any(b => a.SequenceEqual(b))));
                }

                foreach (var (flagHash, (itemName, forSale, deadUp)) in saleItems)
                {
                    List<NintendoHash> soldOutFlags = [];
                    foreach (NintendoHash deadLink in deadUp)
                    {
                        if (soldOutLinkTags.TryGetValue(deadLink, out NintendoHash hash))
                        {
                            soldOutFlags.Add(hash);
                        }
                        else
                        {
                            NintendoHash searchHash = deadLink;
                            while (linkTagBasicSigs.TryGetValue(searchHash, out NintendoHash foundHash))
                            {
                                if (soldOutLinkTags.TryGetValue(foundHash, out hash))
                                {
                                    soldOutFlags.Add(hash);
                                    break;
                                }
                            }
                        }
                    }
                    soldOutFlags.Sort();
                    saleItemEntries[flagHash] = (new(npcLookup[forSale], itemName, nodeData[npcLookup[forSale]]), [.. soldOutFlags]);
                }
            }
        }

        public static void AddShopInfoEntriesFromActors(
            Info shopGameDataInfo,
            string actorPath,
            Dictionary<string, List<int[]>> npcAreas,
            HashSet<string> filesUsed
        )
        {
            EnumerationOptions options = new() { RecurseSubdirectories = true };
            int currentFile = 0;
            int fileCount = Directory.EnumerateFiles(actorPath, "*.sbactorpack", options).Count();
            SetUpProgressLine(fileCount);
            foreach (string path in Directory.GetFiles(actorPath, "*.sbactorpack", options))
            {
                UpdateProgressLine(++currentFile, fileCount);
                if (filesUsed.Contains(Path.GetFileName(path)))
                {
                    continue;
                }
                filesUsed.Add(Path.GetFileName(path));

                string actorName = Path.GetFileNameWithoutExtension(path);
                foreach (string stem in SkipActorStems)
                {
                    if (actorName.Contains(stem))
                    {
                        goto next;
                    }
                }
                Sarc sarc = Sarc.FromBinary(Yaz0.Decompress(File.ReadAllBytes(path)));
                AampFile link = new(sarc[$"Actor/ActorLink/{actorName}.bxml"].ToArray());
                string shopName = link.RootNode.Objects("LinkTarget")!.Params("ShopDataUser")!.Value.ToString()!;
                Dictionary<string, NintendoHash> flags = [];
                bool traveler = link.RootNode.Objects(1115720914)?.ParamEntries.Any(p => p.Value.ToString() == "Traveler") ?? false;
                bool attackedNpc = link.RootNode.Objects("Tags")?.ParamEntries.Any(p => p.Value.ToString() == "AttackedNPC") ?? false;
                bool horseReceptionist = actorName.Contains("HorseAssociationCustum");
                bool ancientOven = actorName.Contains("AncientOven");

                if (shopName != "Dummy")
                {
                    AampFile shop = new(sarc[$"Actor/ShopData/{shopName}.bshop"].ToArray());
                    int tableNum = (int)shop.RootNode.Objects("Header")!.Params("TableNum")!.Value;
                    for (int i = 1; i <= tableNum; ++i)
                    {
                        string tableName = shop.RootNode.Objects("Header")!.Params($"Table{i:D2}")!.Value.ToString()!;
                        int itemNum = (int)shop.RootNode.Objects(tableName)!.Params("ColumnNum")!.Value;

                        int fails = 0;
                        int j = 1;
                        for (int found = 0; found < itemNum;)
                        {
                            ParamEntry? tryParam = shop.RootNode.Objects(tableName)!.Params($"ItemName{j:D3}");
                            if (tryParam != null)
                            {
                                ++found;
                                if ((int)shop.RootNode.Objects(tableName)!.Params($"ItemNum{j:D3}")!.Value != 0)
                                {
                                    string itemName = tryParam.Value.ToString()!;
                                    flags[itemName] = new(Crc32.Compute($"{actorName}_{itemName}"));
                                }
                            }
                            else
                            {
                                ++fails;
                                if (fails > 500)
                                {
                                    throw new InvalidDataException($"{actorName}'s {shopName}.bshop's {tableName} malformed!");
                                }
                            }
                            ++j;
                        }
                    }

                    foreach ((string itemName, NintendoHash flagHash) in flags)
                    {

                        if (!shopGameDataInfo.ShopInfo.Entries.ContainsKey(flagHash))
                        {
                            //Console.WriteLine($"Adding entry for {actorName}_{itemName} (hash: {flagHash.uvalue})...");

                            ShopAreaInfoEntry entry;
                            if (traveler && !attackedNpc)
                            {
                                entry = new(actorName, itemName);
                            }
                            else
                            {
                                entry = new(actorName, itemName, GetNpcAreas(actorName, npcAreas));
                            }
                            shopGameDataInfo.ShopInfo.Entries[flagHash] = entry;
                        }
                    }
                }
                next:;
            }
        }

        internal static void SetUpProgressLine(int maximum)
        {
            if (Console.IsOutputRedirected)
            {
                return;
            }
            Console.Write($"[                     ]    0 / {maximum}");
        }

        internal static void UpdateProgressLine(int current, int maximum)
        {
            if (Console.IsOutputRedirected)
            {
                return;
            }
            int currentCell = (int)((float)current / (float)maximum * 20 + 1);
            if (maximum >= 20)
            {
                Console.SetCursorPosition(currentCell, Console.CursorTop);
                Console.Write('-');
            }
            else
            {
                Console.SetCursorPosition(1, Console.CursorTop);
                for (int i = 0; i < currentCell; ++i)
                {
                    Console.Write('-');
                }
            }
            Console.SetCursorPosition(24, Console.CursorTop);
            Console.Write($"{current,4}");
            Console.SetCursorPosition(35, Console.CursorTop);
        }
    }
}
