// See https://aka.ms/new-console-template for more information
using BotwShopDataUtil.Helpers;
using BotwShopDataUtil.ShopGameData;
using CsYaz0;
using SarcLibrary;
using BotwShopDataUtil;

string exe_path = AppContext.BaseDirectory;
Settings settings = Settings.Load();
if (Directory.Exists(Path.Combine(exe_path, "romfs")))
{
    settings.WiiU = false;
}

if ((settings.WiiU && !Directory.Exists(Path.Combine(exe_path, "content"))) ||
    (!settings.WiiU && !Directory.Exists(Path.Combine(exe_path, "01007EF00011E000", "romfs"))))
{
    Console.WriteLine("This tool must be run from a mod's root folder (the folder that contains the 'content' or '01007EF00011E000' folder)\nPlease put the exe in your mod's root folder and run it again.");
    Console.Write("Press any key to close...");
    Console.ReadKey();
    return;
}

EnumerationOptions options = new() { RecurseSubdirectories = true };
Dictionary<string, List<int[]>> npcAreas = [];
Dictionary<NintendoHash, (ShopAreaInfoEntry, NintendoHash[])> saleItemEntries = [];
HashSet<string> filesUsed = [];

string fieldPath;

if (settings.WiiU)
{
    fieldPath = Path.Combine(exe_path, "aoc", "0010", "Map", "MainField");
}
else
{
    fieldPath = Path.Combine(exe_path, "01007EF00011F001", "romfs", "Map", "MainField");
}

if (Directory.Exists(fieldPath))
{
    Console.WriteLine($"Generating ShopAreaInfo and SoldOut entries from map files...");
    HelperFunctions.AddNpcAreasAndSaleItemEntriesFromMapFiles(fieldPath, npcAreas, saleItemEntries, filesUsed);
    Console.WriteLine($"\nAdding ShopAreaInfo and SoldOut entries from vanilla map files...");
    string vanillaFieldPath;
    if (settings.WiiU)
    {
        vanillaFieldPath = Path.Combine(settings.dlcDir, "Map", "MainField");
    }
    else
    {
        vanillaFieldPath = Path.Combine(settings.dlcDirNx, "Map", "MainField");
    }
    HelperFunctions.AddNpcAreasAndSaleItemEntriesFromMapFiles(vanillaFieldPath, npcAreas, saleItemEntries, filesUsed);
}

string bootupPath;
string backupPath;
string vanillaBootupPath;

if (settings.WiiU)
{
    vanillaBootupPath = Path.Combine(settings.gameDir, "Pack", "Bootup.pack");
    bootupPath = Path.Combine(exe_path, "content", "Pack", "Bootup.pack");
    backupPath = Path.Combine(exe_path, "content", "Pack", "Bootup.pack.bak");
}
else
{
    vanillaBootupPath = Path.Combine(settings.gameDirNx, "Pack", "Bootup.pack");
    bootupPath = Path.Combine(exe_path, "01007EF00011E000", "romfs", "Pack", "Bootup.pack");
    backupPath = Path.Combine(exe_path, "01007EF00011E000", "romfs", "Pack", "Bootup.pack.bak");
}
if (!File.Exists(bootupPath))
{
    Directory.CreateDirectory(Directory.GetParent(bootupPath)!.FullName);
    File.Copy(vanillaBootupPath, bootupPath);
}
if (File.Exists(backupPath))
{
    File.Delete(backupPath);
}
File.Copy(bootupPath, backupPath);

Sarc bootup = Sarc.FromBinary(File.ReadAllBytes(bootupPath));
Info shopGameDataInfo = new();
string actorPath;

if (settings.WiiU)
{
    actorPath = Path.Combine(exe_path, "content", "Actor", "Pack");
}
else
{
    actorPath = Path.Combine(exe_path, "01007EF00011E000", "romfs", "Actor", "Pack");
}

if (Directory.Exists(actorPath))
{
    Console.WriteLine("\nGenerating ShopAreaInfo entries from actors...");
    HelperFunctions.AddShopInfoEntriesFromActors(shopGameDataInfo, actorPath, npcAreas, filesUsed);
    Console.WriteLine("\nAdding ShopAreaInfo entries from vanilla actors...");
    string vanillaActorPath;
    if (settings.WiiU)
    {
        vanillaActorPath = Path.Combine(settings.updateDir, "Actor", "Pack");
    }
    else
    {
        vanillaActorPath = Path.Combine(settings.gameDirNx, "Actor", "Pack");
    }
    HelperFunctions.AddShopInfoEntriesFromActors(shopGameDataInfo, vanillaActorPath, npcAreas, filesUsed);
}

if (saleItemEntries.Count > 0)
{
    Console.WriteLine($"\nAdding ShopAreaInfo and SoldOutInfo for on-display shop items...");

    int currentEntry = 0;
    int totalEntries = saleItemEntries.Count;
    HelperFunctions.SetUpProgressLine(totalEntries);
    foreach (var (hash, (shopAreaInfoEntry, soldOutFlags)) in saleItemEntries)
    {
        HelperFunctions.UpdateProgressLine(++currentEntry, totalEntries);
        if (!shopGameDataInfo.ShopInfo.Entries.ContainsKey(hash))
        {
            shopAreaInfoEntry.Areas ??= npcAreas[shopAreaInfoEntry.Dealer];
            shopGameDataInfo.ShopInfo.Entries[hash] = shopAreaInfoEntry;
        }
        if (soldOutFlags.Any(h => h.uvalue != 0))
        {
            if (shopGameDataInfo.SoldInfo.Entries.TryGetValue(hash, out SoldOutInfoEntry? entry))
            {
                entry.SoldOutFlags.UnionWith(soldOutFlags.Where(h => h.uvalue != 0));
            }
            else
            {
                shopGameDataInfo.SoldInfo.Entries[hash] = new([.. soldOutFlags]);
            }
        }
    }
}

bootup["GameData/ShopGameDataInfo.sbyml"] = Yaz0.Compress(shopGameDataInfo.ToByml().ToBinary(bootup.Endianness, 2)).ToArray();
using (MemoryStream ms = new())
{
    bootup.Write(ms);
    bootupPath = Path.Combine(exe_path, "content", "Pack", "Bootup.pack");
    File.WriteAllBytes(bootupPath, ms.ToArray());
}

// Wait for the user to respond before closing.
Console.Write("\nDone! Press any key to close...");
Console.ReadKey();