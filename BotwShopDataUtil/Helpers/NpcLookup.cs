﻿namespace BotwShopDataUtil.Helpers
{
    internal class NpcLookup
    {
        public static readonly Dictionary<string, List<int[]>> Areas = new() {
            { "Npc_Attacked_007", [[0, 6]] },
            { "Npc_MamonoShop", [[0, 6], [1, 1], [6, 5], [7, 7], [8, 0], [8, 3], [8, 5], [9, 2]] },
            { "Npc_Attacked_002", [[0, 6]] },
            { "Npc_oasis032", [[0, 6], [1, 6]] },
            { "Npc_GerudoDesert004", [[0, 7], [1, 5], [1, 6]] },
            { "Npc_DressFairy_03", [[0, 7]] },
            { "Npc_ValleyVillage010", [[1, 1], [1, 2]] },
            { "Npc_Assassin_009", [[1, 1], [5, 5]] },
            { "Npc_Musician_008", [[1, 2]] },
            { "Npc_RitoHatago003", [[1, 2]] },
            { "Npc_Musician_AoC_HeroRito", [[1, 2]] },
            { "Npc_RitoHatago002", [[1, 2]] },
            { "Npc_ValleyVillage031", [[1, 2]] },
            { "Npc_TripMaster_07", [[1, 2]] },
            { "Npc_RitoHatago004", [[1, 2]] },
            { "Npc_Musician_AoC_HeroRitoRelief", [[1, 2]] },
            { "Npc_Musician_006", [[1, 2]] },
            { "Npc_RitoHatago001", [[1, 2]] },
            { "Npc_DressFairy_02", [[1, 3]] },
            { "Npc_MiniGame_Golf", [[1, 3]] },
            { "Npc_Attacked_006_DLC2nd", [[1, 5]] },
            { "Npc_Musician_003", [[1, 5]] },
            { "Npc_Attacked_011_DLC2nd", [[1, 5]] },
            { "Npc_oasis024", [[1, 6]] },
            { "Npc_oasis020", [[1, 6]] },
            { "Npc_SmallOasis010", [[1, 6]] },
            { "Npc_oasis009", [[1, 6]] },
            { "Npc_oasis007", [[1, 6]] },
            { "Npc_oasis011", [[1, 6]] },
            { "Npc_Gerudo_FruitMelon_A_Trash", [[1, 6]] },
            { "Npc_OasisStudent_C", [[1, 6]] },
            { "Npc_SmallOasis002", [[1, 6]] },
            { "Npc_OasisMilk_E", [[1, 6]] },
            { "Npc_TripMaster_15", [[1, 6]] },
            { "Npc_SmallOasis009", [[1, 6]] },
            { "Npc_oasis037", [[1, 6], [2, 7]] },
            { "Npc_OasisStep_B", [[1, 6]] },
            { "Npc_OasisStudent_B", [[1, 6]] },
            { "Npc_SmallOasis001", [[1, 6]] },
            { "Npc_oasis010", [[1, 6]] },
            { "Npc_oasis006", [[1, 6]] },
            { "Npc_oasis041", [[1, 6]] },
            { "Npc_OasisStep_A", [[1, 6]] },
            { "Npc_oasis003", [[1, 6], [1, 7]] },
            { "Npc_OasisMilk_D", [[1, 6]] },
            { "Npc_oasis051", [[1, 6]] },
            { "Npc_oasis021", [[1, 6]] },
            { "Npc_oasis025", [[1, 6]] },
            { "Npc_SmallOasis012", [[1, 6]] },
            { "Npc_OasisMilk_B", [[1, 6]] },
            { "Npc_oasis012", [[1, 6]] },
            { "Npc_OasisHylia_001", [[1, 6]] },
            { "Npc_oasis023", [[1, 6]] },
            { "Npc_oasis029", [[1, 6]] },
            { "Npc_oasis013", [[1, 6]] },
            { "Npc_oasis042", [[1, 6]] },
            { "Npc_oasis008", [[1, 6]] },
            { "Npc_oasis017", [[1, 6]] },
            { "Npc_oasis043", [[1, 6]] },
            { "Npc_oasis027", [[1, 6]] },
            { "Npc_oasis019", [[1, 6]] },
            { "Npc_oasis047", [[1, 6]] },
            { "Npc_GerudoDesert003", [[1, 6]] },
            { "Npc_oasis015", [[1, 6]] },
            { "Npc_SmallOasis008", [[1, 6]] },
            { "Npc_SmallOasis006", [[1, 6]] },
            { "Npc_oasis050", [[1, 6], [8, 2]] },
            { "Npc_SmallOasis011", [[1, 6]] },
            { "Npc_OasisGoddess", [[1, 6]] },
            { "Npc_oasis014", [[1, 6]] },
            { "Npc_oasis002", [[1, 6]] },
            { "Npc_oasis045", [[1, 6]] },
            { "Npc_oasis046", [[1, 6]] },
            { "Npc_OasisHighMountain_001", [[1, 6]] },
            { "Npc_OasisMilk_A", [[1, 6]] },
            { "Npc_SmallOasis003", [[1, 6]] },
            { "Npc_OasisSoldier_C", [[1, 6]] },
            { "Npc_OasisHylia_003", [[1, 6]] },
            { "Npc_OasisMilk_C", [[1, 6]] },
            { "Npc_oasis044", [[1, 6]] },
            { "Npc_OasisGoron_001", [[1, 6]] },
            { "Npc_OasisTeacher", [[1, 6]] },
            { "Npc_SmallOasis004", [[1, 6]] },
            { "Npc_Gerudo_FruitMelon_A_Trash_Drift", [[1, 6]] },
            { "Npc_SmallOasis007", [[1, 6]] },
            { "Npc_OasisWaterChannel", [[1, 6]] },
            { "Npc_oasis018", [[1, 6]] },
            { "Npc_oasis026", [[1, 6]] },
            { "Npc_oasis016", [[1, 6]] },
            { "Npc_oasis022", [[1, 6]] },
            { "Npc_OasisSoldier_B", [[1, 6]] },
            { "Npc_OasisSoldier_A", [[1, 6]] },
            { "Npc_oasis028", [[1, 6]] },
            { "Npc_SmallOasis005", [[1, 6]] },
            { "Npc_OasisHylia_002", [[1, 6]] },
            { "Npc_oasis001", [[1, 6]] },
            { "Npc_oasis036", [[1, 6]] },
            { "Npc_oasis005", [[1, 6]] },
            { "Npc_OasisStudent_A", [[1, 6]] },
            { "Npc_GerudoDesert002", [[1, 6], [2, 7]] },
            { "Npc_oasis040", [[1, 6]] },
            { "Npc_oasis033", [[1, 7]] },
            { "NPC_oasis070", [[1, 7]] },
            { "NPC_oasis062", [[1, 6], [1, 7]] },
            { "NPC_oasis064", [[1, 6], [1, 7]] },
            { "NPC_oasis068", [[1, 6]] },
            { "NPC_oasis061", [[1, 7]] },
            { "NPC_oasis069", [[1, 7]] },
            { "Npc_GerudoDesert001", [[1, 7]] },
            { "NPC_oasis067", [[1, 6]] },
            { "NPC_oasis063", [[1, 7]] },
            { "Npc_oasis038", [[1, 7]] },
            { "NPC_oasis065", [[1, 7]] },
            { "Npc_oasis039", [[1, 7]] },
            { "Npc_IceVillage011", [[2, 0]] },
            { "Npc_MiniGame_Crosscountry", [[2, 2]] },
            { "Npc_TabantaBridgeHatago006", [[2, 3]] },
            { "NPC_artist_002", [[2, 3]] },
            { "Npc_TabantaBridgeHatago003", [[2, 3]] },
            { "Npc_TabantaBridgeHatago005", [[2, 3]] },
            { "Npc_Assassin_010", [[2, 3], [3, 1]] },
            { "Npc_TripMaster_04", [[2, 3]] },
            { "Npc_TabantaBridgeHatago001", [[2, 3]] },
            { "Npc_TabantaBridgeHatago002", [[2, 3]] },
            { "Npc_TabantaBridgeHatago004", [[2, 3]] },
            { "Npc_Musician_012", [[2, 4]] },
            { "NPC_oasis004_fr02", [[2, 5], [2, 6]] },
            { "NPC_oasis004_fr03", [[2, 5], [2, 6]] },
            { "Npc_Gaman01", [[2, 5]] },
            { "Npc_Gaman03", [[2, 5]] },
            { "NPC_oasis004_fr04", [[2, 5], [2, 6]] },
            { "Npc_Gaman02", [[2, 5]] },
            { "NPC_oasis004_fr01", [[2, 5], [2, 6]] },
            { "Npc_GerudoCanyonHatago001", [[2, 6]] },
            { "Npc_Musician_AoC_HeroGerudo", [[2, 6]] },
            { "Npc_gerudovalley001", [[2, 6]] },
            { "NPC_oasis004", [[2, 6]] },
            { "Npc_Musician_009", [[2, 6]] },
            { "NPC_artist_003", [[2, 6]] },
            { "Npc_TripMaster_02", [[2, 6]] },
            { "Npc_Bowling", [[2, 1]] },
            { "Npc_TabantaHatago002", [[3, 1]] },
            { "Npc_TabantaHatago003", [[3, 1]] },
            { "Npc_TabantaHatago004", [[3, 1]] },
            { "Npc_TripMaster_13", [[3, 1]] },
            { "Npc_TabantaHatago001", [[3, 1]] },
            { "Npc_Attacked_005", [[3, 2], [3, 3], [8, 1], [8, 2]] },
            { "Npc_TripMaster_05", [[3, 2]] },
            { "NPC_artist_005", [[3, 2]] },
            { "Npc_Minigame_BirdMan001", [[3, 3]] },
            { "Npc_Musician_001", [[3, 4]] },
            { "Npc_King_Parasail005", [[3, 5], [4, 5], [4, 6]] },
            { "Npc_FirstColony004", [[3, 5]] },
            { "Npc_King_Parasail004", [[3, 5], [4, 5], [4, 6]] },
            { "Npc_Attacked_003", [[3, 5], [4, 5], [7, 7]] },
            { "Npc_TripMaster_10", [[3, 5]] },
            { "Npc_Musician_AoC_BalladOfHeroes_Last", [[3, 5]] },
            { "NPC_artist_006", [[3, 5]] },
            { "Npc_King_Vagrant003", [[3, 6]] },
            { "Npc_Musician_AoC_BalladOfHeroes", [[3, 6], [4, 5], [4, 6]] },
            { "Npc_Assassin_007", [[3, 6], [6, 4]] },
            { "Npc_Musician_AoC_HeroGerudoRelief", [[3, 6]] },
            { "Npc_Strange_Beacon", [[3, 7]] },
            { "Npc_Attacked_006", [[4, 4], [4, 5], [5, 2]] },
            { "Npc_Attacked_011", [[4, 4], [4, 5], [5, 2]] },
            { "Npc_King_Vagrant006", [[4, 5]] },
            { "Npc_King_Parasail002", [[4, 5]] },
            { "Npc_King_Vagrant007", [[4, 5]] },
            { "Npc_Assassin_008", [[4, 5], [9, 1]] },
            { "Npc_King_Vagrant001", [[4, 5]] },
            { "Npc_King_Vagrant005", [[4, 5]] },
            { "Npc_Assassin_004", [[4, 5], [7, 5]] },
            { "Npc_King_Vagrant004", [[4, 6]] },
            { "Npc_Zora010", [[4, 6], [8, 3]] },
            { "Npc_FaronWoods008", [[4, 7]] },
            { "Npc_FaronWoods009", [[4, 7]] },
            { "Npc_kokiri003", [[5, 1]] },
            { "Npc_kokiri005", [[5, 1]] },
            { "Npc_kokiri009", [[5, 1]] },
            { "Npc_kokiri002", [[5, 1]] },
            { "Npc_Kokiri011", [[5, 1]] },
            { "Npc_OldKorok", [[5, 1]] },
            { "Npc_kokiri012", [[5, 1]] },
            { "Npc_kokiri004", [[5, 1]] },
            { "Npc_kokiri001", [[5, 1]] },
            { "Npc_Kokiri008", [[5, 1]] },
            { "Npc_Kokiri007", [[5, 1]] },
            { "Npc_kokiri006", [[5, 1]] },
            { "Npc_Kokiri010", [[5, 2]] },
            { "Npc_NorthHatelHatago001", [[5, 4]] },
            { "NPC_artist_010", [[5, 4]] },
            { "Npc_NorthHatelHatago006", [[5, 4]] },
            { "Npc_NorthHateru_around001", [[5, 4]] },
            { "Npc_NorthHatelHatago002", [[5, 4]] },
            { "Npc_Attacked_001", [[5, 4], [6, 3]] },
            { "Npc_NorthHateru003", [[5, 4]] },
            { "Npc_NorthHateru005", [[5, 4]] },
            { "Npc_TripMaster_12", [[5, 4]] },
            { "Npc_Musician_011", [[5, 4]] },
            { "Npc_OldKorok_WetLand", [[5, 4]] },
            { "Npc_Challenge093Lady", [[5, 4]] },
            { "Npc_TripMaster_08", [[5, 5]] },
            { "Npc_FaronWoods006", [[5, 5]] },
            { "Npc_FaronWoods007", [[5, 5]] },
            { "Npc_RiverSideHatago003", [[5, 5]] },
            { "Npc_RiverSideHatago001", [[5, 5]] },
            { "Npc_OldKorok_Rvs", [[5, 5]] },
            { "NPC_artist_001", [[5, 5]] },
            { "Npc_RiverSideHatago002", [[5, 5]] },
            { "Npc_Attacked_010", [[5, 6], [6, 4], [6, 7]] },
            { "Npc_Attacked_004", [[5, 6], [6, 4], [6, 7]] },
            { "Npc_Road_Firone002", [[5, 7]] },
            { "Npc_Musician_002", [[5, 7]] },
            { "Npc_TripMaster_14", [[5, 7]] },
            { "NPC_artist_007", [[5, 7]] },
            { "Npc_FaronWoods001", [[5, 7]] },
            { "Npc_Remains_Fancier001", [[5, 7]] },
            { "Npc_FaronWoods010", [[5, 7]] },
            { "Npc_FaronHatago_001", [[5, 7]] },
            { "Npc_goron001", [[6, 1]] },
            { "Npc_Goron032", [[6, 1]] },
            { "Npc_Goron011", [[6, 1]] },
            { "Npc_Goron030", [[6, 1]] },
            { "NPC_artist_004", [[6, 1]] },
            { "Npc_Goron031", [[6, 1]] },
            { "Npc_goron003", [[6, 1]] },
            { "Npc_Goron010", [[6, 1], [7, 1]] },
            { "Npc_goron004", [[6, 1]] },
            { "Npc_Goron022", [[6, 1], [7, 0]] },
            { "Npc_goron026", [[6, 1]] },
            { "Npc_Goron033", [[6, 1]] },
            { "Npc_Goron020_2", [[6, 1]] },
            { "Npc_Goron109", [[6, 1]] },
            { "Npc_Goron021", [[6, 1]] },
            { "Npc_Musician_AoC_HeroGoronRelief", [[6, 1]] },
            { "Npc_Goron016", [[6, 1]] },
            { "Npc_Goron020", [[6, 1], [7, 1]] },
            { "Npc_Goron005", [[6, 1]] },
            { "Npc_Goron018", [[6, 1]] },
            { "Npc_Goron006", [[6, 1]] },
            { "Npc_Goron017", [[6, 1]] },
            { "Npc_Goron110", [[6, 1]] },
            { "Npc_goron002", [[6, 1]] },
            { "Npc_Goron025", [[6, 2], [8, 2]] },
            { "Npc_Goron013", [[6, 2]] },
            { "Npc_Goron012", [[6, 2]] },
            { "Npc_DeathWestHatago_002", [[6, 2]] },
            { "Npc_Goron014", [[6, 2]] },
            { "Npc_Goron023", [[6, 2], [8, 2]] },
            { "Npc_Goron015", [[6, 2]] },
            { "Npc_TripMaster_11", [[6, 2]] },
            { "Npc_DeathEastHatago_002", [[6, 2]] },
            { "NPC_artist_000", [[6, 2]] },
            { "Npc_OldKorok_Forest", [[6, 2]] },
            { "Npc_Assassin_005", [[6, 3], [7, 7]] },
            { "Npc_Zora013", [[6, 3], [8, 3]] },
            { "NPC_Lanayru001", [[6, 3]] },
            { "Npc_Zora001", [[6, 3], [8, 3], [9, 3]] },
            { "NPC_Lanayru002", [[6, 3]] },
            { "Npc_Bottle_Mes001", [[6, 3], [8, 3]] },
            { "Npc_Zora025", [[6, 4], [8, 3]] },
            { "Npc_DressFairy_00", [[6, 4]] },
            { "Npc_Zora028", [[6, 4], [8, 3]] },
            { "Npc_Kakariko010", [[6, 5]] },
            { "Npc_Kakariko014", [[6, 5]] },
            { "Npc_Kakariko012", [[6, 4]] },
            { "Npc_TripMaster_00", [[6, 5]] },
            { "Npc_Kakariko011", [[6, 5]] },
            { "Npc_Kakariko004", [[6, 4]] },
            { "Npc_Kakariko002", [[6, 4]] },
            { "Npc_Kakariko006", [[6, 4]] },
            { "Npc_SouthHateru007", [[6, 5]] },
            { "Npc_Kakariko008", [[6, 4]] },
            { "Npc_SouthHateru005", [[6, 5]] },
            { "Npc_Kakariko001", [[6, 4]] },
            { "Npc_Kakariko003", [[6, 4]] },
            { "Npc_Kakariko013", [[6, 5]] },
            { "Npc_SouthHateru006", [[6, 5]] },
            { "Npc_Kakariko007", [[7, 4]] },
            { "Npc_Kakariko016", [[6, 4]] },
            { "Npc_Kakariko005", [[6, 4]] },
            { "Npc_Kakariko015", [[6, 5]] },
            { "NPC_artist_009", [[6, 4]] },
            { "Npc_Assassin_003", [[6, 5], [7, 4]] },
            { "Npc_LakeSideHatago006", [[6, 7]] },
            { "Npc_Attacked_008", [[6, 7], [7, 3], [8, 6]] },
            { "Npc_TripMaster_09", [[6, 7]] },
            { "Npc_LakeSideHatago004", [[6, 7]] },
            { "Npc_LakeSideHatago005", [[6, 7]] },
            { "Npc_FaronWoods003", [[6, 7]] },
            { "Npc_Attacked_009", [[6, 7], [7, 3], [8, 6]] },
            { "Npc_Goron_Camp003", [[7, 0]] },
            { "Npc_Goron_Camp001", [[7, 0]] },
            { "Npc_Goron_Camp002", [[7, 0]] },
            { "Npc_Gaman03_DLC2nd", [[7, 1]] },
            { "Npc_Gaman01_DLC2nd", [[7, 1]] },
            { "Npc_Musician_AoC_HeroGoron", [[7, 1]] },
            { "Npc_FollowGoron", [[7, 1]] },
            { "Npc_Gaman02_DLC2nd", [[7, 1]] },
            { "Npc_Goron009", [[7, 1]] },
            { "Npc_DeathEastHatago_001", [[7, 2]] },
            { "Npc_DeathMt001", [[7, 2]] },
            { "Npc_Musician_010", [[7, 2]] },
            { "Npc_DeathEastHatago_003", [[7, 2]] },
            { "Npc_TripMaster_01", [[7, 2]] },
            { "Npc_Lanayru003", [[7, 3], [8, 3]] },
            { "Npc_Zora029", [[7, 3], [8, 3]] },
            { "Npc_ZoraB001", [[7, 3], [7, 4], [8, 3]] },
            { "Npc_Zora026", [[7, 3]] },
            { "Npc_Zora036", [[7, 3], [8, 3]] },
            { "Npc_Assassin_006", [[7, 3], [8, 6]] },
            { "Npc_Musician_014", [[7, 4]] },
            { "Npc_Lanayru004", [[7, 4]] },
            { "Npc_OldKorok_Help", [[7, 5]] },
            { "Npc_SouthernVillageGambler", [[7, 7]] },
            { "Npc_SouthernVillage015", [[7, 7]] },
            { "Npc_SouthernVillage007", [[7, 7]] },
            { "Npc_SouthernVillage006", [[7, 7]] },
            { "Npc_SouthernVillage016", [[7, 7]] },
            { "Npc_SouthernVillage012", [[7, 7]] },
            { "Npc_SouthernVillage013", [[7, 7]] },
            { "Npc_SouthernVillage008", [[7, 7]] },
            { "Npc_SouthernVillage001", [[7, 7]] },
            { "Npc_SouthernVillage005", [[7, 7]] },
            { "Npc_Musician_005", [[7, 7]] },
            { "Npc_SouthernVillage010", [[7, 7]] },
            { "NPC_artist_011", [[7, 7]] },
            { "Npc_SouthernVillage004", [[7, 7]] },
            { "Npc_TamourPlainHatago_001", [[8, 2]] },
            { "Npc_Attacked_012", [[8, 2]] },
            { "Npc_UMiiVillage009", [[8, 2]] },
            { "Npc_UMiiVillage030", [[8, 2]] },
            { "Npc_UMiiVillage010", [[8, 2]] },
            { "Npc_UMiiVillage008", [[8, 2]] },
            { "Npc_UMiiVillage007", [[8, 2]] },
            { "Npc_TamourPlainHatago_002", [[8, 2]] },
            { "Npc_UMiiVillage031", [[8, 2]] },
            { "Npc_UMiiVillage003", [[8, 2]] },
            { "Npc_TamourPlainHatago_003", [[8, 2]] },
            { "Npc_TamourPlainHatago_004", [[8, 2]] },
            { "Npc_UMiiVillage032", [[8, 2]] },
            { "Npc_oasis050_2", [[8, 2]] },
            { "Npc_TripMaster_06", [[8, 2]] },
            { "Npc_TamourHatago2_001", [[8, 2]] },
            { "Npc_UMiiVillage031_2", [[8, 2]] },
            { "Npc_Zora005", [[8, 2], [8, 3]] },
            { "Npc_AncientAssistant003", [[8, 2]] },
            { "Npc_Zora014", [[8, 3]] },
            { "Npc_Zora007", [[8, 3]] },
            { "Npc_Zora015", [[8, 3]] },
            { "Npc_Zora126", [[8, 3]] },
            { "Npc_Zora034", [[8, 3]] },
            { "Npc_Zora020", [[8, 3]] },
            { "Npc_Zora031", [[8, 3]] },
            { "Npc_Zora012", [[8, 3]] },
            { "Npc_Zora009", [[8, 3]] },
            { "Npc_Zora035", [[8, 3]] },
            { "Npc_Zora037", [[8, 3]] },
            { "Npc_Zora032", [[8, 3]] },
            { "Npc_Zora030", [[8, 3]] },
            { "Npc_Zora008", [[8, 3]] },
            { "Npc_Zora003", [[8, 3]] },
            { "Npc_Zora006", [[8, 3]] },
            { "Npc_Zora002", [[8, 3]] },
            { "Npc_ZoraGoron_001", [[8, 3]] },
            { "Npc_Zora027", [[8, 3]] },
            { "Npc_Zora004", [[8, 3], [9, 3]] },
            { "Npc_Zora033", [[8, 3]] },
            { "Npc_Zora011", [[8, 3]] },
            { "Npc_Musician_AoC_HeroZora", [[7, 4]] },
            { "Npc_Musician_AoC_HeroZoraRelief", [[8, 4]] },
            { "Npc_Musician_007", [[8, 6]] },
            { "Npc_AncientAssistant001", [[8, 6]] },
            { "Npc_AncientDoctor", [[8, 6]] },
            { "Npc_SouthernVillage009", [[8, 7]] },
            { "Npc_SouthernVillage014", [[8, 7]] },
            { "Npc_AncientDoctor_Hateno", [[9, 0]] },
            { "Npc_AncientAssistant004", [[9, 0]] },
            { "Npc_TamourHatago001", [[9, 1]] },
            { "Npc_TamourHatago003", [[9, 1]] },
            { "Npc_TripMaster_03", [[9, 1]] },
            { "Npc_TamourHatago005", [[9, 1]] },
            { "Npc_TamourHatago002", [[9, 1]] },
            { "NPC_artist_008", [[9, 1]] },
            { "Npc_TamourHatago004", [[9, 1]] },
            { "Npc_DressFairy_01", [[9, 2]] },
            { "Npc_Musician_015", [[9, 4]] },
            { "Npc_FarthestIsland002", [[9, 7]] },
            { "Npc_NakedIslandPriest", [[9, 7]] },
        };
    }
}
