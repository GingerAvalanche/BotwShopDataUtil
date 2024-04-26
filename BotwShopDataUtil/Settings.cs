using Newtonsoft.Json;

namespace BotwShopDataUtil
{
    internal class Settings(string game, string update, string dlc, string gameNx, string dlcNx)
    {
        public bool WiiU = true;
        public string gameDir = game;
        public string gameDirNx = gameNx;
        public string updateDir = update;
        public string dlcDir = dlc;
        public string dlcDirNx = dlcNx;

        public static Settings Load()
        {
            Settings value;
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (File.Exists(Path.Combine(appdata, "botw_tools", "settings.json")))
            {
                value = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(Path.Combine(appdata, "botw_tools", "settings.json")))!;
                if (Validate(value))
                {
                    return value;
                }
            }

            if (File.Exists(Path.Combine(appdata, "bcml", "settings.json")))
            {
                Dictionary<string, dynamic> bcmlSettings = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(File.ReadAllText(Path.Combine(appdata, "bcml", "settings.json")))!;
                value = new(bcmlSettings["game_dir"], bcmlSettings["update_dir"], bcmlSettings["dlc_dir"], bcmlSettings["game_dir_nx"], bcmlSettings["dlc_dir_nx"]);
                if (Validate(value))
                {
                    Directory.CreateDirectory(Path.Combine(appdata, "botw_tools"));
                    File.WriteAllText(Path.Combine(appdata, "botw_tools", "settings.json"), JsonConvert.SerializeObject(value, Formatting.Indented));
                    return value;
                }
            }
            do
            {
                Console.WriteLine("Dump paths not found/validated. You will now be asked for your dump locations. Press enter after reading each line to continue.");
                Console.ReadKey();
                Console.WriteLine("Please enter the following dump locations for WiiU. If you don't have a WiiU dump, simply press enter to skip to Switch.");
                Console.Write("Game dump (ends in 'content'):");
                string game = Console.ReadLine()!;
                Console.Write("Update dump (ends in 'content'):");
                string update = Console.ReadLine()!;
                Console.Write("DLC dump (ends in '0010'):");
                string dlc = Console.ReadLine()!;
                Console.WriteLine("Please enter the following dump locations for Switch. If you don't have a Switch dump, simply press enter to skip.");
                Console.Write("Game dump (ends in '01007EF00011E800/romfs'):");
                string gameNx = Console.ReadLine()!;
                Console.Write("DLC dump (ends in '01007EF00011F001/romfs'):");
                string dlcNx = Console.ReadLine()!;

                value = new(game, update, dlc, gameNx, dlcNx);
            } while (!Validate(value));

            if (!Directory.Exists(Path.Combine(appdata, "botw_tools")))
            {
                Directory.CreateDirectory(Path.Combine(Path.Combine(appdata, "botw_tools")));
            }
            File.WriteAllText(Path.Combine(appdata, "botw_tools", "settings.json"), JsonConvert.SerializeObject(value));
            return value;
        }

        public static bool Validate(Settings value)
        {
            if (value == null || (value.gameDir == "" && value.gameDirNx == ""))
            {
                Console.WriteLine("Must have game dumps for at least one of the consoles.");
                return false;
            }
            if (value.gameDir != "")
            {
                if (!File.Exists(Path.Combine(value.gameDir, "Pack", "Dungeon000.pack")))
                {
                    Console.WriteLine("WiiU game dump failed to validate.");
                    return false;
                }
                if (!File.Exists(Path.Combine(value.updateDir, "Actor", "Pack", "FldObj_MountainSnow_A_M_02.sbactorpack")))
                {
                    Console.WriteLine(Path.Combine(value.updateDir, "Actor", "Pack", "FldObj_MountainSnow_A_M_02.sbactorpack"));
                    Console.WriteLine("WiiU update dump failed to validate.");
                    return false;
                }
                if (!File.Exists(Path.Combine(value.dlcDir, "Pack", "AocMainField.pack")))
                {
                    Console.WriteLine("WiiU DLC dump failed to validate.");
                    return false;
                }
            }
            if (value.gameDirNx != "")
            {
                if (!File.Exists(Path.Combine(value.gameDirNx, "Pack", "Dungeon000.pack")))
                {
                    Console.WriteLine("Switch game dump failed to validate.");
                    return false;
                }
                if (!File.Exists(Path.Combine(value.dlcDirNx, "Pack", "AocMainField.pack")))
                {
                    Console.WriteLine("WiiU DLC dump failed to validate.");
                    return false;
                }
            }

            return true;
        }
    }
}
