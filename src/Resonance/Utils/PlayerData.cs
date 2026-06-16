using System;
using System.Reflection;
using UnityEngine;
using Resonance;

namespace Resonance.Utils
{
    public static class GameData
    {
        private static readonly Type pdType = typeof(global::PlayerData);
        private static object Instance => global::PlayerData.instance;

        public static T Get<T>(string field) => (T)pdType.GetField(field, BindingFlags.Public | BindingFlags.Instance)?.GetValue(Instance);
        public static void Set<T>(string field, T value) => pdType.GetField(field, BindingFlags.Public | BindingFlags.Instance)?.SetValue(Instance, value);

        public static void Call(string method, params object[] args)
        {
            pdType.GetMethod(method, BindingFlags.Public | BindingFlags.Instance)?.Invoke(Instance, args);
        }

        public static TResult Call<TResult>(string method, params object[] args)
        {
            var m = pdType.GetMethod(method, BindingFlags.Public | BindingFlags.Instance);
            return m != null ? (TResult)m.Invoke(Instance, args) : default;
        }

        // Fields as properties
        public static string version { get => Get<string>("version"); set => Set("version", value); }
        public static bool awardAllAchievements { get => Get<bool>("awardAllAchievements"); set => Set("awardAllAchievements", value); }
        public static int profileID { get => Get<int>("profileID"); set => Set("profileID", value); }
        public static float playTime { get => Get<float>("playTime"); set => Set("playTime", value); }
        public static float completionPercent { get => Get<float>("completionPercent"); set => Set("completionPercent", value); }
        public static bool openingCreditsPlayed { get => Get<bool>("openingCreditsPlayed"); set => Set("openingCreditsPlayed", value); }
        public static int permadeathMode { get => Get<int>("permadeathMode"); set => Set("permadeathMode", value); }
        public static int health { get => Get<int>("health"); set => Set("health", value); }
        public static int maxHealth { get => Get<int>("maxHealth"); set => Set("maxHealth", value); }
        public static int maxHealthBase { get => Get<int>("maxHealthBase"); set => Set("maxHealthBase", value); }
        public static int healthBlue { get => Get<int>("healthBlue"); set => Set("healthBlue", value); }
        public static int joniHealthBlue { get => Get<int>("joniHealthBlue"); set => Set("joniHealthBlue", value); }
        public static bool damagedBlue { get => Get<bool>("damagedBlue"); set => Set("damagedBlue", value); }
        public static int heartPieces { get => Get<int>("heartPieces"); set => Set("heartPieces", value); }
        public static bool heartPieceCollected { get => Get<bool>("heartPieceCollected"); set => Set("heartPieceCollected", value); }
        public static int maxHealthCap { get => Get<int>("maxHealthCap"); set => Set("maxHealthCap", value); }
        public static bool heartPieceMax { get => Get<bool>("heartPieceMax"); set => Set("heartPieceMax", value); }
        public static int prevHealth { get => Get<int>("prevHealth"); set => Set("prevHealth", value); }
        public static int blockerHits { get => Get<int>("blockerHits"); set => Set("blockerHits", value); }
        public static bool firstGeo { get => Get<bool>("firstGeo"); set => Set("firstGeo", value); }
        public static int geo { get => Get<int>("geo"); set => Set("geo", value); }
        public static int maxMP { get => Get<int>("maxMP"); set => Set("maxMP", value); }
        public static int MPCharge { get => Get<int>("MPCharge"); set => Set("MPCharge", value); }
        public static int MPReserve { get => Get<int>("MPReserve"); set => Set("MPReserve", value); }
        public static int MPReserveMax { get => Get<int>("MPReserveMax"); set => Set("MPReserveMax", value); }
        public static bool soulLimited { get => Get<bool>("soulLimited"); set => Set("soulLimited", value); }
        public static int vesselFragments { get => Get<int>("vesselFragments"); set => Set("vesselFragments", value); }
        public static bool vesselFragmentCollected { get => Get<bool>("vesselFragmentCollected"); set => Set("vesselFragmentCollected", value); }
        public static int MPReserveCap { get => Get<int>("MPReserveCap"); set => Set("MPReserveCap", value); }
        public static bool vesselFragmentMax { get => Get<bool>("vesselFragmentMax"); set => Set("vesselFragmentMax", value); }
        public static int focusMP_amount { get => Get<int>("focusMP_amount"); set => Set("focusMP_amount", value); }
        public static bool atBench { get => Get<bool>("atBench"); set => Set("atBench", value); }
        public static string respawnScene { get => Get<string>("respawnScene"); set => Set("respawnScene", value); }
        public static string mapZone { get => Get<string>("mapZone"); set => Set("mapZone", value); }
        public static string respawnMarkerName { get => Get<string>("respawnMarkerName"); set => Set("respawnMarkerName", value); }
        public static int respawnType { get => Get<int>("respawnType"); set => Set("respawnType", value); }
        public static bool respawnFacingRight { get => Get<bool>("respawnFacingRight"); set => Set("respawnFacingRight", value); }
        public static Vector3 hazardRespawnLocation { get => Get<Vector3>("hazardRespawnLocation"); set => Set("hazardRespawnLocation", value); }
        public static bool hazardRespawnFacingRight { get => Get<bool>("hazardRespawnFacingRight"); set => Set("hazardRespawnFacingRight", value); }
        public static string shadeScene { get => Get<string>("shadeScene"); set => Set("shadeScene", value); }
        public static string shadeMapZone { get => Get<string>("shadeMapZone"); set => Set("shadeMapZone", value); }
        public static float shadePositionX { get => Get<float>("shadePositionX"); set => Set("shadePositionX", value); }
        public static float shadePositionY { get => Get<float>("shadePositionY"); set => Set("shadePositionY", value); }
        public static int shadeHealth { get => Get<int>("shadeHealth"); set => Set("shadeHealth", value); }
        public static int shadeMP { get => Get<int>("shadeMP"); set => Set("shadeMP", value); }
        public static int shadeFireballLevel { get => Get<int>("shadeFireballLevel"); set => Set("shadeFireballLevel", value); }
        public static int shadeQuakeLevel { get => Get<int>("shadeQuakeLevel"); set => Set("shadeQuakeLevel", value); }
        public static int shadeScreamLevel { get => Get<int>("shadeScreamLevel"); set => Set("shadeScreamLevel", value); }
        public static int shadeSpecialType { get => Get<int>("shadeSpecialType"); set => Set("shadeSpecialType", value); }
        public static Vector3 shadeMapPos { get => Get<Vector3>("shadeMapPos"); set => Set("shadeMapPos", value); }
        public static Vector3 dreamgateMapPos { get => Get<Vector3>("dreamgateMapPos"); set => Set("dreamgateMapPos", value); }
        public static int geoPool { get => Get<int>("geoPool"); set => Set("geoPool", value); }
        public static int nailDamage { get => Get<int>("nailDamage"); set => Set("nailDamage", value); }
        public static float nailRange { get => Get<float>("nailRange"); set => Set("nailRange", value); }
        public static int beamDamage { get => Get<int>("beamDamage"); set => Set("beamDamage", value); }
        public static bool canDash { get => Get<bool>("canDash"); set => Set("canDash", value); }
        public static bool canBackDash { get => Get<bool>("canBackDash"); set => Set("canBackDash", value); }
        public static bool canWallJump { get => Get<bool>("canWallJump"); set => Set("canWallJump", value); }
        public static bool canSuperDash { get => Get<bool>("canSuperDash"); set => Set("canSuperDash", value); }
        public static bool canShadowDash { get => Get<bool>("canShadowDash"); set => Set("canShadowDash", value); }
        public static bool hasSpell { get => Get<bool>("hasSpell"); set => Set("hasSpell", value); }
        public static int fireballLevel { get => Get<int>("fireballLevel"); set => Set("fireballLevel", value); }
        public static int quakeLevel { get => Get<int>("quakeLevel"); set => Set("quakeLevel", value); }
        public static int screamLevel { get => Get<int>("screamLevel"); set => Set("screamLevel", value); }
        public static bool hasNailArt { get => Get<bool>("hasNailArt"); set => Set("hasNailArt", value); }
        public static bool hasCyclone { get => Get<bool>("hasCyclone"); set => Set("hasCyclone", value); }
        public static bool hasDashSlash { get => Get<bool>("hasDashSlash"); set => Set("hasDashSlash", value); }
        public static bool hasUpwardSlash { get => Get<bool>("hasUpwardSlash"); set => Set("hasUpwardSlash", value); }
        public static bool hasAllNailArts { get => Get<bool>("hasAllNailArts"); set => Set("hasAllNailArts", value); }
        public static bool hasDreamNail { get => Get<bool>("hasDreamNail"); set => Set("hasDreamNail", value); }
        public static bool hasDreamGate { get => Get<bool>("hasDreamGate"); set => Set("hasDreamGate", value); }
        public static bool dreamNailUpgraded { get => Get<bool>("dreamNailUpgraded"); set => Set("dreamNailUpgraded", value); }
        public static int dreamOrbs { get => Get<int>("dreamOrbs"); set => Set("dreamOrbs", value); }
        public static int dreamOrbsSpent { get => Get<int>("dreamOrbsSpent"); set => Set("dreamOrbsSpent", value); }
        public static string dreamGateScene { get => Get<string>("dreamGateScene"); set => Set("dreamGateScene", value); }
        public static float dreamGateX { get => Get<float>("dreamGateX"); set => Set("dreamGateX", value); }
        public static float dreamGateY { get => Get<float>("dreamGateY"); set => Set("dreamGateY", value); }
        public static bool hasDash { get => Get<bool>("hasDash"); set => Set("hasDash", value); }
        public static bool hasWalljump { get => Get<bool>("hasWalljump"); set => Set("hasWalljump", value); }
        public static bool hasSuperDash { get => Get<bool>("hasSuperDash"); set => Set("hasSuperDash", value); }
        public static bool hasShadowDash { get => Get<bool>("hasShadowDash"); set => Set("hasShadowDash", value); }
        public static bool hasAcidArmour { get => Get<bool>("hasAcidArmour"); set => Set("hasAcidArmour", value); }
        public static bool hasDoubleJump { get => Get<bool>("hasDoubleJump"); set => Set("hasDoubleJump", value); }
        public static bool hasLantern { get => Get<bool>("hasLantern"); set => Set("hasLantern", value); }
        public static bool hasTramPass { get => Get<bool>("hasTramPass"); set => Set("hasTramPass", value); }
        public static bool hasQuill { get => Get<bool>("hasQuill"); set => Set("hasQuill", value); }
        public static bool hasCityKey { get => Get<bool>("hasCityKey"); set => Set("hasCityKey", value); }
        public static bool hasSlykey { get => Get<bool>("hasSlykey"); set => Set("hasSlykey", value); }
        public static bool gaveSlykey { get => Get<bool>("gaveSlykey"); set => Set("gaveSlykey", value); }
        public static bool hasWhiteKey { get => Get<bool>("hasWhiteKey"); set => Set("hasWhiteKey", value); }
        public static bool usedWhiteKey { get => Get<bool>("usedWhiteKey"); set => Set("usedWhiteKey", value); }
        public static bool hasMenderKey { get => Get<bool>("hasMenderKey"); set => Set("hasMenderKey", value); }
        public static bool hasWaterwaysKey { get => Get<bool>("hasWaterwaysKey"); set => Set("hasWaterwaysKey", value); }
        public static bool hasSpaKey { get => Get<bool>("hasSpaKey"); set => Set("hasSpaKey", value); }
        public static bool hasLoveKey { get => Get<bool>("hasLoveKey"); set => Set("hasLoveKey", value); }
        public static bool hasKingsBrand { get => Get<bool>("hasKingsBrand"); set => Set("hasKingsBrand", value); }
        public static bool hasXunFlower { get => Get<bool>("hasXunFlower"); set => Set("hasXunFlower", value); }
        public static int ghostCoins { get => Get<int>("ghostCoins"); set => Set("ghostCoins", value); }
        public static int ore { get => Get<int>("ore"); set => Set("ore", value); }
        public static bool foundGhostCoin { get => Get<bool>("foundGhostCoin"); set => Set("foundGhostCoin", value); }
        public static int trinket1 { get => Get<int>("trinket1"); set => Set("trinket1", value); }
        public static bool foundTrinket1 { get => Get<bool>("foundTrinket1"); set => Set("foundTrinket1", value); }
        public static int trinket2 { get => Get<int>("trinket2"); set => Set("trinket2", value); }
        public static bool foundTrinket2 { get => Get<bool>("foundTrinket2"); set => Set("foundTrinket2", value); }
        public static int trinket3 { get => Get<int>("trinket3"); set => Set("trinket3", value); }
        public static bool foundTrinket3 { get => Get<bool>("foundTrinket3"); set => Set("foundTrinket3", value); }
        public static int trinket4 { get => Get<int>("trinket4"); set => Set("trinket4", value); }
        public static bool foundTrinket4 { get => Get<bool>("foundTrinket4"); set => Set("foundTrinket4", value); }
        public static bool noTrinket1 { get => Get<bool>("noTrinket1"); set => Set("noTrinket1", value); }
        public static bool noTrinket2 { get => Get<bool>("noTrinket2"); set => Set("noTrinket2", value); }
        public static bool noTrinket3 { get => Get<bool>("noTrinket3"); set => Set("noTrinket3", value); }
        public static bool noTrinket4 { get => Get<bool>("noTrinket4"); set => Set("noTrinket4", value); }
        public static int soldTrinket1 { get => Get<int>("soldTrinket1"); set => Set("soldTrinket1", value); }
        public static int soldTrinket2 { get => Get<int>("soldTrinket2"); set => Set("soldTrinket2", value); }
        public static int soldTrinket3 { get => Get<int>("soldTrinket3"); set => Set("soldTrinket3", value); }
        public static int soldTrinket4 { get => Get<int>("soldTrinket4"); set => Set("soldTrinket4", value); }
        public static int simpleKeys { get => Get<int>("simpleKeys"); set => Set("simpleKeys", value); }
        public static int rancidEggs { get => Get<int>("rancidEggs"); set => Set("rancidEggs", value); }
        public static bool notchShroomOgres { get => Get<bool>("notchShroomOgres"); set => Set("notchShroomOgres", value); }
        public static bool notchFogCanyon { get => Get<bool>("notchFogCanyon"); set => Set("notchFogCanyon", value); }
        public static bool gotLurkerKey { get => Get<bool>("gotLurkerKey"); set => Set("gotLurkerKey", value); }
        public static float gMap_doorX { get => Get<float>("gMap_doorX"); set => Set("gMap_doorX", value); }
        public static float gMap_doorY { get => Get<float>("gMap_doorY"); set => Set("gMap_doorY", value); }
        public static string gMap_doorScene { get => Get<string>("gMap_doorScene"); set => Set("gMap_doorScene", value); }
        public static string gMap_doorMapZone { get => Get<string>("gMap_doorMapZone"); set => Set("gMap_doorMapZone", value); }
        public static float gMap_doorOriginOffsetX { get => Get<float>("gMap_doorOriginOffsetX"); set => Set("gMap_doorOriginOffsetX", value); }
        public static float gMap_doorOriginOffsetY { get => Get<float>("gMap_doorOriginOffsetY"); set => Set("gMap_doorOriginOffsetY", value); }
        public static float gMap_doorSceneWidth { get => Get<float>("gMap_doorSceneWidth"); set => Set("gMap_doorSceneWidth", value); }
        public static float gMap_doorSceneHeight { get => Get<float>("gMap_doorSceneHeight"); set => Set("gMap_doorSceneHeight", value); }
        public static int guardiansDefeated { get => Get<int>("guardiansDefeated"); set => Set("guardiansDefeated", value); }
        public static bool lurienDefeated { get => Get<bool>("lurienDefeated"); set => Set("lurienDefeated", value); }
        public static bool hegemolDefeated { get => Get<bool>("hegemolDefeated"); set => Set("hegemolDefeated", value); }
        public static bool monomonDefeated { get => Get<bool>("monomonDefeated"); set => Set("monomonDefeated", value); }
        public static bool maskBrokenLurien { get => Get<bool>("maskBrokenLurien"); set => Set("maskBrokenLurien", value); }
        public static bool maskBrokenHegemol { get => Get<bool>("maskBrokenHegemol"); set => Set("maskBrokenHegemol", value); }
        public static bool maskBrokenMonomon { get => Get<bool>("maskBrokenMonomon"); set => Set("maskBrokenMonomon", value); }
        public static int maskToBreak { get => Get<int>("maskToBreak"); set => Set("maskToBreak", value); }
        public static int elderbug { get => Get<int>("elderbug"); set => Set("elderbug", value); }
        public static bool metElderbug { get => Get<bool>("metElderbug"); set => Set("metElderbug", value); }
        public static bool elderbugReintro { get => Get<bool>("elderbugReintro"); set => Set("elderbugReintro", value); }
        public static int elderbugHistory { get => Get<int>("elderbugHistory"); set => Set("elderbugHistory", value); }
        public static bool elderbugHistory1 { get => Get<bool>("elderbugHistory1"); set => Set("elderbugHistory1", value); }
        public static bool elderbugHistory2 { get => Get<bool>("elderbugHistory2"); set => Set("elderbugHistory2", value); }
        public static bool elderbugHistory3 { get => Get<bool>("elderbugHistory3"); set => Set("elderbugHistory3", value); }
        public static bool elderbugSpeechSly { get => Get<bool>("elderbugSpeechSly"); set => Set("elderbugSpeechSly", value); }
        public static bool elderbugSpeechStation { get => Get<bool>("elderbugSpeechStation"); set => Set("elderbugSpeechStation", value); }
        public static bool elderbugSpeechEggTemple { get => Get<bool>("elderbugSpeechEggTemple"); set => Set("elderbugSpeechEggTemple", value); }
        public static bool elderbugSpeechMapShop { get => Get<bool>("elderbugSpeechMapShop"); set => Set("elderbugSpeechMapShop", value); }
        public static bool elderbugSpeechBretta { get => Get<bool>("elderbugSpeechBretta"); set => Set("elderbugSpeechBretta", value); }
        public static bool elderbugSpeechJiji { get => Get<bool>("elderbugSpeechJiji"); set => Set("elderbugSpeechJiji", value); }
        public static bool elderbugSpeechMinesLift { get => Get<bool>("elderbugSpeechMinesLift"); set => Set("elderbugSpeechMinesLift", value); }
        public static bool elderbugSpeechKingsPass { get => Get<bool>("elderbugSpeechKingsPass"); set => Set("elderbugSpeechKingsPass", value); }
        public static bool elderbugSpeechInfectedCrossroads { get => Get<bool>("elderbugSpeechInfectedCrossroads"); set => Set("elderbugSpeechInfectedCrossroads", value); }
        public static bool elderbugSpeechFinalBossDoor { get => Get<bool>("elderbugSpeechFinalBossDoor"); set => Set("elderbugSpeechFinalBossDoor", value); }
        public static bool elderbugRequestedFlower { get => Get<bool>("elderbugRequestedFlower"); set => Set("elderbugRequestedFlower", value); }
        public static bool elderbugGaveFlower { get => Get<bool>("elderbugGaveFlower"); set => Set("elderbugGaveFlower", value); }
        public static bool elderbugFirstCall { get => Get<bool>("elderbugFirstCall"); set => Set("elderbugFirstCall", value); }
        public static bool metQuirrel { get => Get<bool>("metQuirrel"); set => Set("metQuirrel", value); }
        public static int quirrelEggTemple { get => Get<int>("quirrelEggTemple"); set => Set("quirrelEggTemple", value); }
        public static int quirrelSlugShrine { get => Get<int>("quirrelSlugShrine"); set => Set("quirrelSlugShrine", value); }
        public static int quirrelRuins { get => Get<int>("quirrelRuins"); set => Set("quirrelRuins", value); }
        public static int quirrelMines { get => Get<int>("quirrelMines"); set => Set("quirrelMines", value); }
        public static bool quirrelLeftStation { get => Get<bool>("quirrelLeftStation"); set => Set("quirrelLeftStation", value); }
        public static bool quirrelLeftEggTemple { get => Get<bool>("quirrelLeftEggTemple"); set => Set("quirrelLeftEggTemple", value); }
        public static bool quirrelCityEncountered { get => Get<bool>("quirrelCityEncountered"); set => Set("quirrelCityEncountered", value); }
        public static bool quirrelCityLeft { get => Get<bool>("quirrelCityLeft"); set => Set("quirrelCityLeft", value); }
        public static bool quirrelMinesEncountered { get => Get<bool>("quirrelMinesEncountered"); set => Set("quirrelMinesEncountered", value); }
        public static bool quirrelMinesLeft { get => Get<bool>("quirrelMinesLeft"); set => Set("quirrelMinesLeft", value); }
        public static bool quirrelMantisEncountered { get => Get<bool>("quirrelMantisEncountered"); set => Set("quirrelMantisEncountered", value); }
        public static bool enteredMantisLordArea { get => Get<bool>("enteredMantisLordArea"); set => Set("enteredMantisLordArea", value); }
        public static bool visitedDeepnestSpa { get => Get<bool>("visitedDeepnestSpa"); set => Set("visitedDeepnestSpa", value); }
        public static bool quirrelSpaReady { get => Get<bool>("quirrelSpaReady"); set => Set("quirrelSpaReady", value); }
        public static bool quirrelSpaEncountered { get => Get<bool>("quirrelSpaEncountered"); set => Set("quirrelSpaEncountered", value); }
        public static bool quirrelArchiveEncountered { get => Get<bool>("quirrelArchiveEncountered"); set => Set("quirrelArchiveEncountered", value); }
        public static bool quirrelEpilogueCompleted { get => Get<bool>("quirrelEpilogueCompleted"); set => Set("quirrelEpilogueCompleted", value); }
        public static bool metRelicDealer { get => Get<bool>("metRelicDealer"); set => Set("metRelicDealer", value); }
        public static bool metRelicDealerShop { get => Get<bool>("metRelicDealerShop"); set => Set("metRelicDealerShop", value); }
        public static bool marmOutside { get => Get<bool>("marmOutside"); set => Set("marmOutside", value); }
        public static bool marmOutsideConvo { get => Get<bool>("marmOutsideConvo"); set => Set("marmOutsideConvo", value); }
        public static bool marmConvo1 { get => Get<bool>("marmConvo1"); set => Set("marmConvo1", value); }
        public static bool marmConvo2 { get => Get<bool>("marmConvo2"); set => Set("marmConvo2", value); }
        public static bool marmConvo3 { get => Get<bool>("marmConvo3"); set => Set("marmConvo3", value); }
        public static bool marmConvoNailsmith { get => Get<bool>("marmConvoNailsmith"); set => Set("marmConvoNailsmith", value); }
        public static int cornifer { get => Get<int>("cornifer"); set => Set("cornifer", value); }
        public static bool metCornifer { get => Get<bool>("metCornifer"); set => Set("metCornifer", value); }
        public static bool corniferIntroduced { get => Get<bool>("corniferIntroduced"); set => Set("corniferIntroduced", value); }
        public static bool corniferAtHome { get => Get<bool>("corniferAtHome"); set => Set("corniferAtHome", value); }
        public static bool corn_crossroadsEncountered { get => Get<bool>("corn_crossroadsEncountered"); set => Set("corn_crossroadsEncountered", value); }
        public static bool corn_crossroadsLeft { get => Get<bool>("corn_crossroadsLeft"); set => Set("corn_crossroadsLeft", value); }
        public static bool corn_greenpathEncountered { get => Get<bool>("corn_greenpathEncountered"); set => Set("corn_greenpathEncountered", value); }
        public static bool corn_greenpathLeft { get => Get<bool>("corn_greenpathLeft"); set => Set("corn_greenpathLeft", value); }
        public static bool corn_fogCanyonEncountered { get => Get<bool>("corn_fogCanyonEncountered"); set => Set("corn_fogCanyonEncountered", value); }
        public static bool corn_fogCanyonLeft { get => Get<bool>("corn_fogCanyonLeft"); set => Set("corn_fogCanyonLeft", value); }
        public static bool corn_fungalWastesEncountered { get => Get<bool>("corn_fungalWastesEncountered"); set => Set("corn_fungalWastesEncountered", value); }
        public static bool corn_fungalWastesLeft { get => Get<bool>("corn_fungalWastesLeft"); set => Set("corn_fungalWastesLeft", value); }
        public static bool corn_cityEncountered { get => Get<bool>("corn_cityEncountered"); set => Set("corn_cityEncountered", value); }
        public static bool corn_cityLeft { get => Get<bool>("corn_cityLeft"); set => Set("corn_cityLeft", value); }
        public static bool corn_waterwaysEncountered { get => Get<bool>("corn_waterwaysEncountered"); set => Set("corn_waterwaysEncountered", value); }
        public static bool corn_waterwaysLeft { get => Get<bool>("corn_waterwaysLeft"); set => Set("corn_waterwaysLeft", value); }
        public static bool corn_minesEncountered { get => Get<bool>("corn_minesEncountered"); set => Set("corn_minesEncountered", value); }
        public static bool corn_minesLeft { get => Get<bool>("corn_minesLeft"); set => Set("corn_minesLeft", value); }
        public static bool corn_cliffsEncountered { get => Get<bool>("corn_cliffsEncountered"); set => Set("corn_cliffsEncountered", value); }
        public static bool corn_cliffsLeft { get => Get<bool>("corn_cliffsLeft"); set => Set("corn_cliffsLeft", value); }
        public static bool corn_deepnestEncountered { get => Get<bool>("corn_deepnestEncountered"); set => Set("corn_deepnestEncountered", value); }
        public static bool corn_deepnestLeft { get => Get<bool>("corn_deepnestLeft"); set => Set("corn_deepnestLeft", value); }
        public static bool corn_deepnestMet1 { get => Get<bool>("corn_deepnestMet1"); set => Set("corn_deepnestMet1", value); }
        public static bool corn_deepnestMet2 { get => Get<bool>("corn_deepnestMet2"); set => Set("corn_deepnestMet2", value); }
        public static bool corn_outskirtsEncountered { get => Get<bool>("corn_outskirtsEncountered"); set => Set("corn_outskirtsEncountered", value); }
        public static bool corn_outskirtsLeft { get => Get<bool>("corn_outskirtsLeft"); set => Set("corn_outskirtsLeft", value); }
        public static bool corn_royalGardensEncountered { get => Get<bool>("corn_royalGardensEncountered"); set => Set("corn_royalGardensEncountered", value); }
        public static bool corn_royalGardensLeft { get => Get<bool>("corn_royalGardensLeft"); set => Set("corn_royalGardensLeft", value); }
        public static bool corn_abyssEncountered { get => Get<bool>("corn_abyssEncountered"); set => Set("corn_abyssEncountered", value); }
        public static bool corn_abyssLeft { get => Get<bool>("corn_abyssLeft"); set => Set("corn_abyssLeft", value); }
        public static bool metIselda { get => Get<bool>("metIselda"); set => Set("metIselda", value); }
        public static bool iseldaCorniferHomeConvo { get => Get<bool>("iseldaCorniferHomeConvo"); set => Set("iseldaCorniferHomeConvo", value); }
        public static bool iseldaConvo1 { get => Get<bool>("iseldaConvo1"); set => Set("iseldaConvo1", value); }
        public static bool brettaRescued { get => Get<bool>("brettaRescued"); set => Set("brettaRescued", value); }
        public static int brettaPosition { get => Get<int>("brettaPosition"); set => Set("brettaPosition", value); }
        public static int brettaState { get => Get<int>("brettaState"); set => Set("brettaState", value); }
        public static bool brettaSeenBench { get => Get<bool>("brettaSeenBench"); set => Set("brettaSeenBench", value); }
        public static bool brettaSeenBed { get => Get<bool>("brettaSeenBed"); set => Set("brettaSeenBed", value); }
        public static bool brettaSeenBenchDiary { get => Get<bool>("brettaSeenBenchDiary"); set => Set("brettaSeenBenchDiary", value); }
        public static bool brettaSeenBedDiary { get => Get<bool>("brettaSeenBedDiary"); set => Set("brettaSeenBedDiary", value); }
        public static bool brettaLeftTown { get => Get<bool>("brettaLeftTown"); set => Set("brettaLeftTown", value); }
        public static bool slyRescued { get => Get<bool>("slyRescued"); set => Set("slyRescued", value); }
        public static bool slyBeta { get => Get<bool>("slyBeta"); set => Set("slyBeta", value); }
        public static bool metSlyShop { get => Get<bool>("metSlyShop"); set => Set("metSlyShop", value); }
        public static bool gotSlyCharm { get => Get<bool>("gotSlyCharm"); set => Set("gotSlyCharm", value); }
        public static bool slyShellFrag1 { get => Get<bool>("slyShellFrag1"); set => Set("slyShellFrag1", value); }
        public static bool slyShellFrag2 { get => Get<bool>("slyShellFrag2"); set => Set("slyShellFrag2", value); }
        public static bool slyShellFrag3 { get => Get<bool>("slyShellFrag3"); set => Set("slyShellFrag3", value); }
        public static bool slyShellFrag4 { get => Get<bool>("slyShellFrag4"); set => Set("slyShellFrag4", value); }
        public static bool slyVesselFrag1 { get => Get<bool>("slyVesselFrag1"); set => Set("slyVesselFrag1", value); }
        public static bool slyVesselFrag2 { get => Get<bool>("slyVesselFrag2"); set => Set("slyVesselFrag2", value); }
        public static bool slyVesselFrag3 { get => Get<bool>("slyVesselFrag3"); set => Set("slyVesselFrag3", value); }
        public static bool slyVesselFrag4 { get => Get<bool>("slyVesselFrag4"); set => Set("slyVesselFrag4", value); }
        public static bool slyNotch1 { get => Get<bool>("slyNotch1"); set => Set("slyNotch1", value); }
        public static bool slyNotch2 { get => Get<bool>("slyNotch2"); set => Set("slyNotch2", value); }
        public static bool slySimpleKey { get => Get<bool>("slySimpleKey"); set => Set("slySimpleKey", value); }
        public static bool slyRancidEgg { get => Get<bool>("slyRancidEgg"); set => Set("slyRancidEgg", value); }
        public static bool slyConvoNailArt { get => Get<bool>("slyConvoNailArt"); set => Set("slyConvoNailArt", value); }
        public static bool slyConvoMapper { get => Get<bool>("slyConvoMapper"); set => Set("slyConvoMapper", value); }
        public static bool slyConvoNailHoned { get => Get<bool>("slyConvoNailHoned"); set => Set("slyConvoNailHoned", value); }
        public static bool jijiDoorUnlocked { get => Get<bool>("jijiDoorUnlocked"); set => Set("jijiDoorUnlocked", value); }
        public static bool jijiMet { get => Get<bool>("jijiMet"); set => Set("jijiMet", value); }
        public static bool jijiShadeOffered { get => Get<bool>("jijiShadeOffered"); set => Set("jijiShadeOffered", value); }
        public static bool jijiShadeCharmConvo { get => Get<bool>("jijiShadeCharmConvo"); set => Set("jijiShadeCharmConvo", value); }
        public static bool metJinn { get => Get<bool>("metJinn"); set => Set("metJinn", value); }
        public static bool jinnConvo1 { get => Get<bool>("jinnConvo1"); set => Set("jinnConvo1", value); }
        public static bool jinnConvo2 { get => Get<bool>("jinnConvo2"); set => Set("jinnConvo2", value); }
        public static bool jinnConvo3 { get => Get<bool>("jinnConvo3"); set => Set("jinnConvo3", value); }
        public static bool jinnConvoKingBrand { get => Get<bool>("jinnConvoKingBrand"); set => Set("jinnConvoKingBrand", value); }
        public static bool jinnConvoShadeCharm { get => Get<bool>("jinnConvoShadeCharm"); set => Set("jinnConvoShadeCharm", value); }
        public static int jinnEggsSold { get => Get<int>("jinnEggsSold"); set => Set("jinnEggsSold", value); }
        public static int zote { get => Get<int>("zote"); set => Set("zote", value); }
        public static bool zoteRescuedBuzzer { get => Get<bool>("zoteRescuedBuzzer"); set => Set("zoteRescuedBuzzer", value); }
        public static bool zoteDead { get => Get<bool>("zoteDead"); set => Set("zoteDead", value); }
        public static int zoteDeathPos { get => Get<int>("zoteDeathPos"); set => Set("zoteDeathPos", value); }
        public static bool zoteSpokenCity { get => Get<bool>("zoteSpokenCity"); set => Set("zoteSpokenCity", value); }
        public static bool zoteLeftCity { get => Get<bool>("zoteLeftCity"); set => Set("zoteLeftCity", value); }
        public static bool zoteTrappedDeepnest { get => Get<bool>("zoteTrappedDeepnest"); set => Set("zoteTrappedDeepnest", value); }
        public static bool zoteRescuedDeepnest { get => Get<bool>("zoteRescuedDeepnest"); set => Set("zoteRescuedDeepnest", value); }
        public static bool zoteDefeated { get => Get<bool>("zoteDefeated"); set => Set("zoteDefeated", value); }
        public static bool zoteSpokenColosseum { get => Get<bool>("zoteSpokenColosseum"); set => Set("zoteSpokenColosseum", value); }
        public static int zotePrecept { get => Get<int>("zotePrecept"); set => Set("zotePrecept", value); }
        public static int zoteTownConvo { get => Get<int>("zoteTownConvo"); set => Set("zoteTownConvo", value); }
        public static int shaman { get => Get<int>("shaman"); set => Set("shaman", value); }
        public static bool shamanScreamConvo { get => Get<bool>("shamanScreamConvo"); set => Set("shamanScreamConvo", value); }
        public static bool shamanQuakeConvo { get => Get<bool>("shamanQuakeConvo"); set => Set("shamanQuakeConvo", value); }
        public static bool shamanFireball2Convo { get => Get<bool>("shamanFireball2Convo"); set => Set("shamanFireball2Convo", value); }
        public static bool shamanScream2Convo { get => Get<bool>("shamanScream2Convo"); set => Set("shamanScream2Convo", value); }
        public static bool shamanQuake2Convo { get => Get<bool>("shamanQuake2Convo"); set => Set("shamanQuake2Convo", value); }
        public static bool metMiner { get => Get<bool>("metMiner"); set => Set("metMiner", value); }
        public static int miner { get => Get<int>("miner"); set => Set("miner", value); }
        public static int minerEarly { get => Get<int>("minerEarly"); set => Set("minerEarly", value); }
        public static int hornetGreenpath { get => Get<int>("hornetGreenpath"); set => Set("hornetGreenpath", value); }
        public static int hornetFung { get => Get<int>("hornetFung"); set => Set("hornetFung", value); }
        public static bool hornet_f19 { get => Get<bool>("hornet_f19"); set => Set("hornet_f19", value); }
        public static bool hornetFountainEncounter { get => Get<bool>("hornetFountainEncounter"); set => Set("hornetFountainEncounter", value); }
        public static bool hornetCityBridge_ready { get => Get<bool>("hornetCityBridge_ready"); set => Set("hornetCityBridge_ready", value); }
        public static bool hornetCityBridge_completed { get => Get<bool>("hornetCityBridge_completed"); set => Set("hornetCityBridge_completed", value); }
        public static bool hornetAbyssEncounter { get => Get<bool>("hornetAbyssEncounter"); set => Set("hornetAbyssEncounter", value); }
        public static bool hornetDenEncounter { get => Get<bool>("hornetDenEncounter"); set => Set("hornetDenEncounter", value); }
        public static bool metMoth { get => Get<bool>("metMoth"); set => Set("metMoth", value); }
        public static bool ignoredMoth { get => Get<bool>("ignoredMoth"); set => Set("ignoredMoth", value); }
        public static bool gladeDoorOpened { get => Get<bool>("gladeDoorOpened"); set => Set("gladeDoorOpened", value); }
        public static bool mothDeparted { get => Get<bool>("mothDeparted"); set => Set("mothDeparted", value); }
        public static bool completedRGDreamPlant { get => Get<bool>("completedRGDreamPlant"); set => Set("completedRGDreamPlant", value); }
        public static bool dreamReward1 { get => Get<bool>("dreamReward1"); set => Set("dreamReward1", value); }
        public static bool dreamReward2 { get => Get<bool>("dreamReward2"); set => Set("dreamReward2", value); }
        public static bool dreamReward3 { get => Get<bool>("dreamReward3"); set => Set("dreamReward3", value); }
        public static bool dreamReward4 { get => Get<bool>("dreamReward4"); set => Set("dreamReward4", value); }
        public static bool dreamReward5 { get => Get<bool>("dreamReward5"); set => Set("dreamReward5", value); }
        public static bool dreamReward5b { get => Get<bool>("dreamReward5b"); set => Set("dreamReward5b", value); }
        public static bool dreamReward6 { get => Get<bool>("dreamReward6"); set => Set("dreamReward6", value); }
        public static bool dreamReward7 { get => Get<bool>("dreamReward7"); set => Set("dreamReward7", value); }
        public static bool dreamReward8 { get => Get<bool>("dreamReward8"); set => Set("dreamReward8", value); }
        public static bool dreamReward9 { get => Get<bool>("dreamReward9"); set => Set("dreamReward9", value); }
        public static bool dreamMothConvo1 { get => Get<bool>("dreamMothConvo1"); set => Set("dreamMothConvo1", value); }
        public static bool bankerAccountPurchased { get => Get<bool>("bankerAccountPurchased"); set => Set("bankerAccountPurchased", value); }
        public static bool metBanker { get => Get<bool>("metBanker"); set => Set("metBanker", value); }
        public static int bankerBalance { get => Get<int>("bankerBalance"); set => Set("bankerBalance", value); }
        public static bool bankerDeclined { get => Get<bool>("bankerDeclined"); set => Set("bankerDeclined", value); }
        public static bool bankerTheftCheck { get => Get<bool>("bankerTheftCheck"); set => Set("bankerTheftCheck", value); }
        public static int bankerTheft { get => Get<int>("bankerTheft"); set => Set("bankerTheft", value); }
        public static bool bankerSpaMet { get => Get<bool>("bankerSpaMet"); set => Set("bankerSpaMet", value); }
        public static bool metGiraffe { get => Get<bool>("metGiraffe"); set => Set("metGiraffe", value); }
        public static bool metCharmSlug { get => Get<bool>("metCharmSlug"); set => Set("metCharmSlug", value); }
        public static bool salubraNotch1 { get => Get<bool>("salubraNotch1"); set => Set("salubraNotch1", value); }
        public static bool salubraNotch2 { get => Get<bool>("salubraNotch2"); set => Set("salubraNotch2", value); }
        public static bool salubraNotch3 { get => Get<bool>("salubraNotch3"); set => Set("salubraNotch3", value); }
        public static bool salubraNotch4 { get => Get<bool>("salubraNotch4"); set => Set("salubraNotch4", value); }
        public static bool salubraBlessing { get => Get<bool>("salubraBlessing"); set => Set("salubraBlessing", value); }
        public static bool salubraConvoCombo { get => Get<bool>("salubraConvoCombo"); set => Set("salubraConvoCombo", value); }
        public static bool salubraConvoOvercharm { get => Get<bool>("salubraConvoOvercharm"); set => Set("salubraConvoOvercharm", value); }
        public static bool salubraConvoTruth { get => Get<bool>("salubraConvoTruth"); set => Set("salubraConvoTruth", value); }
        public static bool cultistTransformed { get => Get<bool>("cultistTransformed"); set => Set("cultistTransformed", value); }
        public static bool metNailsmith { get => Get<bool>("metNailsmith"); set => Set("metNailsmith", value); }
        public static int nailSmithUpgrades { get => Get<int>("nailSmithUpgrades"); set => Set("nailSmithUpgrades", value); }
        public static bool honedNail { get => Get<bool>("honedNail"); set => Set("honedNail", value); }
        public static bool nailsmithCliff { get => Get<bool>("nailsmithCliff"); set => Set("nailsmithCliff", value); }
        public static bool nailsmithKilled { get => Get<bool>("nailsmithKilled"); set => Set("nailsmithKilled", value); }
        public static bool nailsmithSpared { get => Get<bool>("nailsmithSpared"); set => Set("nailsmithSpared", value); }
        public static bool nailsmithKillSpeech { get => Get<bool>("nailsmithKillSpeech"); set => Set("nailsmithKillSpeech", value); }
        public static bool nailsmithSheo { get => Get<bool>("nailsmithSheo"); set => Set("nailsmithSheo", value); }
        public static bool nailsmithConvoArt { get => Get<bool>("nailsmithConvoArt"); set => Set("nailsmithConvoArt", value); }
        public static bool metNailmasterMato { get => Get<bool>("metNailmasterMato"); set => Set("metNailmasterMato", value); }
        public static bool metNailmasterSheo { get => Get<bool>("metNailmasterSheo"); set => Set("metNailmasterSheo", value); }
        public static bool metNailmasterOro { get => Get<bool>("metNailmasterOro"); set => Set("metNailmasterOro", value); }
        public static bool matoConvoSheo { get => Get<bool>("matoConvoSheo"); set => Set("matoConvoSheo", value); }
        public static bool matoConvoOro { get => Get<bool>("matoConvoOro"); set => Set("matoConvoOro", value); }
        public static bool matoConvoSly { get => Get<bool>("matoConvoSly"); set => Set("matoConvoSly", value); }
        public static bool sheoConvoMato { get => Get<bool>("sheoConvoMato"); set => Set("sheoConvoMato", value); }
        public static bool sheoConvoOro { get => Get<bool>("sheoConvoOro"); set => Set("sheoConvoOro", value); }
        public static bool sheoConvoSly { get => Get<bool>("sheoConvoSly"); set => Set("sheoConvoSly", value); }
        public static bool sheoConvoNailsmith { get => Get<bool>("sheoConvoNailsmith"); set => Set("sheoConvoNailsmith", value); }
        public static bool oroConvoSheo { get => Get<bool>("oroConvoSheo"); set => Set("oroConvoSheo", value); }
        public static bool oroConvoMato { get => Get<bool>("oroConvoMato"); set => Set("oroConvoMato", value); }
        public static bool oroConvoSly { get => Get<bool>("oroConvoSly"); set => Set("oroConvoSly", value); }
        public static bool hunterRoared { get => Get<bool>("hunterRoared"); set => Set("hunterRoared", value); }
        public static bool metHunter { get => Get<bool>("metHunter"); set => Set("metHunter", value); }
        public static bool hunterRewardOffered { get => Get<bool>("hunterRewardOffered"); set => Set("hunterRewardOffered", value); }
        public static bool huntersMarkOffered { get => Get<bool>("huntersMarkOffered"); set => Set("huntersMarkOffered", value); }
        public static bool hasHuntersMark { get => Get<bool>("hasHuntersMark"); set => Set("hasHuntersMark", value); }
        public static bool metLegEater { get => Get<bool>("metLegEater"); set => Set("metLegEater", value); }
        public static bool paidLegEater { get => Get<bool>("paidLegEater"); set => Set("paidLegEater", value); }
        public static bool refusedLegEater { get => Get<bool>("refusedLegEater"); set => Set("refusedLegEater", value); }
        public static bool legEaterConvo1 { get => Get<bool>("legEaterConvo1"); set => Set("legEaterConvo1", value); }
        public static bool legEaterConvo2 { get => Get<bool>("legEaterConvo2"); set => Set("legEaterConvo2", value); }
        public static bool legEaterConvo3 { get => Get<bool>("legEaterConvo3"); set => Set("legEaterConvo3", value); }
        public static bool legEaterBrokenConvo { get => Get<bool>("legEaterBrokenConvo"); set => Set("legEaterBrokenConvo", value); }
        public static bool legEaterDungConvo { get => Get<bool>("legEaterDungConvo"); set => Set("legEaterDungConvo", value); }
        public static bool legEaterInfectedCrossroadConvo { get => Get<bool>("legEaterInfectedCrossroadConvo"); set => Set("legEaterInfectedCrossroadConvo", value); }
        public static bool legEaterBoughtConvo { get => Get<bool>("legEaterBoughtConvo"); set => Set("legEaterBoughtConvo", value); }
        public static bool legEaterGoldConvo { get => Get<bool>("legEaterGoldConvo"); set => Set("legEaterGoldConvo", value); }
        public static bool legEaterLeft { get => Get<bool>("legEaterLeft"); set => Set("legEaterLeft", value); }
        public static bool tukMet { get => Get<bool>("tukMet"); set => Set("tukMet", value); }
        public static int tukEggPrice { get => Get<int>("tukEggPrice"); set => Set("tukEggPrice", value); }
        public static bool tukDungEgg { get => Get<bool>("tukDungEgg"); set => Set("tukDungEgg", value); }
        public static bool metEmilitia { get => Get<bool>("metEmilitia"); set => Set("metEmilitia", value); }
        public static bool emilitiaKingsBrandConvo { get => Get<bool>("emilitiaKingsBrandConvo"); set => Set("emilitiaKingsBrandConvo", value); }
        public static bool metCloth { get => Get<bool>("metCloth"); set => Set("metCloth", value); }
        public static bool clothEnteredTramRoom { get => Get<bool>("clothEnteredTramRoom"); set => Set("clothEnteredTramRoom", value); }
        public static bool savedCloth { get => Get<bool>("savedCloth"); set => Set("savedCloth", value); }
        public static bool clothEncounteredQueensGarden { get => Get<bool>("clothEncounteredQueensGarden"); set => Set("clothEncounteredQueensGarden", value); }
        public static bool clothKilled { get => Get<bool>("clothKilled"); set => Set("clothKilled", value); }
        public static bool clothInTown { get => Get<bool>("clothInTown"); set => Set("clothInTown", value); }
        public static bool clothLeftTown { get => Get<bool>("clothLeftTown"); set => Set("clothLeftTown", value); }
        public static bool clothGhostSpoken { get => Get<bool>("clothGhostSpoken"); set => Set("clothGhostSpoken", value); }
        public static bool bigCatHitTail { get => Get<bool>("bigCatHitTail"); set => Set("bigCatHitTail", value); }
        public static bool bigCatHitTailConvo { get => Get<bool>("bigCatHitTailConvo"); set => Set("bigCatHitTailConvo", value); }
        public static bool bigCatMeet { get => Get<bool>("bigCatMeet"); set => Set("bigCatMeet", value); }
        public static bool bigCatTalk1 { get => Get<bool>("bigCatTalk1"); set => Set("bigCatTalk1", value); }
        public static bool bigCatTalk2 { get => Get<bool>("bigCatTalk2"); set => Set("bigCatTalk2", value); }
        public static bool bigCatTalk3 { get => Get<bool>("bigCatTalk3"); set => Set("bigCatTalk3", value); }
        public static bool bigCatKingsBrandConvo { get => Get<bool>("bigCatKingsBrandConvo"); set => Set("bigCatKingsBrandConvo", value); }
        public static bool bigCatShadeConvo { get => Get<bool>("bigCatShadeConvo"); set => Set("bigCatShadeConvo", value); }
        public static bool tisoEncounteredTown { get => Get<bool>("tisoEncounteredTown"); set => Set("tisoEncounteredTown", value); }
        public static bool tisoEncounteredBench { get => Get<bool>("tisoEncounteredBench"); set => Set("tisoEncounteredBench", value); }
        public static bool tisoEncounteredLake { get => Get<bool>("tisoEncounteredLake"); set => Set("tisoEncounteredLake", value); }
        public static bool tisoEncounteredColosseum { get => Get<bool>("tisoEncounteredColosseum"); set => Set("tisoEncounteredColosseum", value); }
        public static bool tisoDead { get => Get<bool>("tisoDead"); set => Set("tisoDead", value); }
        public static bool tisoShieldConvo { get => Get<bool>("tisoShieldConvo"); set => Set("tisoShieldConvo", value); }
        public static int mossCultist { get => Get<int>("mossCultist"); set => Set("mossCultist", value); }
        public static bool maskmakerMet { get => Get<bool>("maskmakerMet"); set => Set("maskmakerMet", value); }
        public static bool maskmakerConvo1 { get => Get<bool>("maskmakerConvo1"); set => Set("maskmakerConvo1", value); }
        public static bool maskmakerConvo2 { get => Get<bool>("maskmakerConvo2"); set => Set("maskmakerConvo2", value); }
        public static bool maskmakerUnmasked1 { get => Get<bool>("maskmakerUnmasked1"); set => Set("maskmakerUnmasked1", value); }
        public static bool maskmakerUnmasked2 { get => Get<bool>("maskmakerUnmasked2"); set => Set("maskmakerUnmasked2", value); }
        public static bool maskmakerShadowDash { get => Get<bool>("maskmakerShadowDash"); set => Set("maskmakerShadowDash", value); }
        public static bool maskmakerKingsBrand { get => Get<bool>("maskmakerKingsBrand"); set => Set("maskmakerKingsBrand", value); }
        public static bool dungDefenderConvo1 { get => Get<bool>("dungDefenderConvo1"); set => Set("dungDefenderConvo1", value); }
        public static bool dungDefenderConvo2 { get => Get<bool>("dungDefenderConvo2"); set => Set("dungDefenderConvo2", value); }
        public static bool dungDefenderConvo3 { get => Get<bool>("dungDefenderConvo3"); set => Set("dungDefenderConvo3", value); }
        public static bool dungDefenderCharmConvo { get => Get<bool>("dungDefenderCharmConvo"); set => Set("dungDefenderCharmConvo", value); }
        public static bool dungDefenderIsmaConvo { get => Get<bool>("dungDefenderIsmaConvo"); set => Set("dungDefenderIsmaConvo", value); }
        public static bool dungDefenderAwoken { get => Get<bool>("dungDefenderAwoken"); set => Set("dungDefenderAwoken", value); }
        public static bool dungDefenderLeft { get => Get<bool>("dungDefenderLeft"); set => Set("dungDefenderLeft", value); }
        public static bool dungDefenderAwakeConvo { get => Get<bool>("dungDefenderAwakeConvo"); set => Set("dungDefenderAwakeConvo", value); }
        public static bool midwifeMet { get => Get<bool>("midwifeMet"); set => Set("midwifeMet", value); }
        public static bool midwifeConvo1 { get => Get<bool>("midwifeConvo1"); set => Set("midwifeConvo1", value); }
        public static bool midwifeConvo2 { get => Get<bool>("midwifeConvo2"); set => Set("midwifeConvo2", value); }
        public static bool metQueen { get => Get<bool>("metQueen"); set => Set("metQueen", value); }
        public static bool queenTalk1 { get => Get<bool>("queenTalk1"); set => Set("queenTalk1", value); }
        public static bool queenTalk2 { get => Get<bool>("queenTalk2"); set => Set("queenTalk2", value); }
        public static bool queenDung1 { get => Get<bool>("queenDung1"); set => Set("queenDung1", value); }
        public static bool queenDung2 { get => Get<bool>("queenDung2"); set => Set("queenDung2", value); }
        public static bool queenHornet { get => Get<bool>("queenHornet"); set => Set("queenHornet", value); }
        public static bool queenTalkExtra { get => Get<bool>("queenTalkExtra"); set => Set("queenTalkExtra", value); }
        public static bool gotQueenFragment { get => Get<bool>("gotQueenFragment"); set => Set("gotQueenFragment", value); }
        public static bool queenConvo_grimm1 { get => Get<bool>("queenConvo_grimm1"); set => Set("queenConvo_grimm1", value); }
        public static bool queenConvo_grimm2 { get => Get<bool>("queenConvo_grimm2"); set => Set("queenConvo_grimm2", value); }
        public static bool gotKingFragment { get => Get<bool>("gotKingFragment"); set => Set("gotKingFragment", value); }
        public static bool metXun { get => Get<bool>("metXun"); set => Set("metXun", value); }
        public static bool xunFailedConvo1 { get => Get<bool>("xunFailedConvo1"); set => Set("xunFailedConvo1", value); }
        public static bool xunFailedConvo2 { get => Get<bool>("xunFailedConvo2"); set => Set("xunFailedConvo2", value); }
        public static bool xunFlowerBroken { get => Get<bool>("xunFlowerBroken"); set => Set("xunFlowerBroken", value); }
        public static int xunFlowerBrokeTimes { get => Get<int>("xunFlowerBrokeTimes"); set => Set("xunFlowerBrokeTimes", value); }
        public static bool xunFlowerGiven { get => Get<bool>("xunFlowerGiven"); set => Set("xunFlowerGiven", value); }
        public static bool xunRewardGiven { get => Get<bool>("xunRewardGiven"); set => Set("xunRewardGiven", value); }
        public static int menderState { get => Get<int>("menderState"); set => Set("menderState", value); }
        public static bool menderSignBroken { get => Get<bool>("menderSignBroken"); set => Set("menderSignBroken", value); }
        public static bool allBelieverTabletsDestroyed { get => Get<bool>("allBelieverTabletsDestroyed"); set => Set("allBelieverTabletsDestroyed", value); }
        public static int mrMushroomState { get => Get<int>("mrMushroomState"); set => Set("mrMushroomState", value); }
        public static bool openedMapperShop { get => Get<bool>("openedMapperShop"); set => Set("openedMapperShop", value); }
        public static bool openedSlyShop { get => Get<bool>("openedSlyShop"); set => Set("openedSlyShop", value); }
        public static bool metStag { get => Get<bool>("metStag"); set => Set("metStag", value); }
        public static bool travelling { get => Get<bool>("travelling"); set => Set("travelling", value); }
        public static int stagPosition { get => Get<int>("stagPosition"); set => Set("stagPosition", value); }
        public static int stationsOpened { get => Get<int>("stationsOpened"); set => Set("stationsOpened", value); }
        public static bool stagConvoTram { get => Get<bool>("stagConvoTram"); set => Set("stagConvoTram", value); }
        public static bool stagConvoTiso { get => Get<bool>("stagConvoTiso"); set => Set("stagConvoTiso", value); }
        public static bool stagRemember1 { get => Get<bool>("stagRemember1"); set => Set("stagRemember1", value); }
        public static bool stagRemember2 { get => Get<bool>("stagRemember2"); set => Set("stagRemember2", value); }
        public static bool stagRemember3 { get => Get<bool>("stagRemember3"); set => Set("stagRemember3", value); }
        public static bool stagEggInspected { get => Get<bool>("stagEggInspected"); set => Set("stagEggInspected", value); }
        public static bool stagHopeConvo { get => Get<bool>("stagHopeConvo"); set => Set("stagHopeConvo", value); }
        public static string nextScene { get => Get<string>("nextScene"); set => Set("nextScene", value); }
        public static bool littleFoolMet { get => Get<bool>("littleFoolMet"); set => Set("littleFoolMet", value); }
        public static bool ranAway { get => Get<bool>("ranAway"); set => Set("ranAway", value); }
        public static bool seenColosseumTitle { get => Get<bool>("seenColosseumTitle"); set => Set("seenColosseumTitle", value); }
        public static bool colosseumBronzeOpened { get => Get<bool>("colosseumBronzeOpened"); set => Set("colosseumBronzeOpened", value); }
        public static bool colosseumBronzeCompleted { get => Get<bool>("colosseumBronzeCompleted"); set => Set("colosseumBronzeCompleted", value); }
        public static bool colosseumSilverOpened { get => Get<bool>("colosseumSilverOpened"); set => Set("colosseumSilverOpened", value); }
        public static bool colosseumSilverCompleted { get => Get<bool>("colosseumSilverCompleted"); set => Set("colosseumSilverCompleted", value); }
        public static bool colosseumGoldOpened { get => Get<bool>("colosseumGoldOpened"); set => Set("colosseumGoldOpened", value); }
        public static bool colosseumGoldCompleted { get => Get<bool>("colosseumGoldCompleted"); set => Set("colosseumGoldCompleted", value); }
        public static bool openedTown { get => Get<bool>("openedTown"); set => Set("openedTown", value); }
        public static bool openedTownBuilding { get => Get<bool>("openedTownBuilding"); set => Set("openedTownBuilding", value); }
        public static bool openedCrossroads { get => Get<bool>("openedCrossroads"); set => Set("openedCrossroads", value); }
        public static bool openedGreenpath { get => Get<bool>("openedGreenpath"); set => Set("openedGreenpath", value); }
        public static bool openedRuins1 { get => Get<bool>("openedRuins1"); set => Set("openedRuins1", value); }
        public static bool openedRuins2 { get => Get<bool>("openedRuins2"); set => Set("openedRuins2", value); }
        public static bool openedFungalWastes { get => Get<bool>("openedFungalWastes"); set => Set("openedFungalWastes", value); }
        public static bool openedRoyalGardens { get => Get<bool>("openedRoyalGardens"); set => Set("openedRoyalGardens", value); }
        public static bool openedRestingGrounds { get => Get<bool>("openedRestingGrounds"); set => Set("openedRestingGrounds", value); }
        public static bool openedDeepnest { get => Get<bool>("openedDeepnest"); set => Set("openedDeepnest", value); }
        public static bool openedStagNest { get => Get<bool>("openedStagNest"); set => Set("openedStagNest", value); }
        public static bool openedHiddenStation { get => Get<bool>("openedHiddenStation"); set => Set("openedHiddenStation", value); }
        public static string dreamReturnScene { get => Get<string>("dreamReturnScene"); set => Set("dreamReturnScene", value); }
        public static int charmSlots { get => Get<int>("charmSlots"); set => Set("charmSlots", value); }
        public static int charmSlotsFilled { get => Get<int>("charmSlotsFilled"); set => Set("charmSlotsFilled", value); }
        public static bool hasCharm { get => Get<bool>("hasCharm"); set => Set("hasCharm", value); }
        public static System.Collections.Generic.List<int> equippedCharms { get => Get<System.Collections.Generic.List<int>>("equippedCharms"); set => Set("equippedCharms", value); }
        public static bool charmBenchMsg { get => Get<bool>("charmBenchMsg"); set => Set("charmBenchMsg", value); }
        public static int charmsOwned { get => Get<int>("charmsOwned"); set => Set("charmsOwned", value); }
        public static bool canOvercharm { get => Get<bool>("canOvercharm"); set => Set("canOvercharm", value); }
        public static bool overcharmed { get => Get<bool>("overcharmed"); set => Set("overcharmed", value); }

        // Charm Expansion
        public static bool gotCharm_1 { get => Get<bool>("gotCharm_1"); set => Set("gotCharm_1", value); }
        public static bool equippedCharm_1 { get => Get<bool>("equippedCharm_1"); set => Set("equippedCharm_1", value); }
        public static int charmCost_1 { get => Get<int>("charmCost_1"); set => Set("charmCost_1", value); }
        public static bool newCharm_1 { get => Get<bool>("newCharm_1"); set => Set("newCharm_1", value); }
        public static bool gotCharm_2 { get => Get<bool>("gotCharm_2"); set => Set("gotCharm_2", value); }
        public static bool equippedCharm_2 { get => Get<bool>("equippedCharm_2"); set => Set("equippedCharm_2", value); }
        public static int charmCost_2 { get => Get<int>("charmCost_2"); set => Set("charmCost_2", value); }
        public static bool newCharm_2 { get => Get<bool>("newCharm_2"); set => Set("newCharm_2", value); }
        public static bool gotCharm_3 { get => Get<bool>("gotCharm_3"); set => Set("gotCharm_3", value); }
        public static bool equippedCharm_3 { get => Get<bool>("equippedCharm_3"); set => Set("equippedCharm_3", value); }
        public static int charmCost_3 { get => Get<int>("charmCost_3"); set => Set("charmCost_3", value); }
        public static bool newCharm_3 { get => Get<bool>("newCharm_3"); set => Set("newCharm_3", value); }
        public static bool gotCharm_4 { get => Get<bool>("gotCharm_4"); set => Set("gotCharm_4", value); }
        public static bool equippedCharm_4 { get => Get<bool>("equippedCharm_4"); set => Set("equippedCharm_4", value); }
        public static int charmCost_4 { get => Get<int>("charmCost_4"); set => Set("charmCost_4", value); }
        public static bool newCharm_4 { get => Get<bool>("newCharm_4"); set => Set("newCharm_4", value); }
        public static bool gotCharm_5 { get => Get<bool>("gotCharm_5"); set => Set("gotCharm_5", value); }
        public static bool equippedCharm_5 { get => Get<bool>("equippedCharm_5"); set => Set("equippedCharm_5", value); }
        public static int charmCost_5 { get => Get<int>("charmCost_5"); set => Set("charmCost_5", value); }
        public static bool newCharm_5 { get => Get<bool>("newCharm_5"); set => Set("newCharm_5", value); }
        public static bool gotCharm_6 { get => Get<bool>("gotCharm_6"); set => Set("gotCharm_6", value); }
        public static bool equippedCharm_6 { get => Get<bool>("equippedCharm_6"); set => Set("equippedCharm_6", value); }
        public static int charmCost_6 { get => Get<int>("charmCost_6"); set => Set("charmCost_6", value); }
        public static bool newCharm_6 { get => Get<bool>("newCharm_6"); set => Set("newCharm_6", value); }
        public static bool gotCharm_7 { get => Get<bool>("gotCharm_7"); set => Set("gotCharm_7", value); }
        public static bool equippedCharm_7 { get => Get<bool>("equippedCharm_7"); set => Set("equippedCharm_7", value); }
        public static int charmCost_7 { get => Get<int>("charmCost_7"); set => Set("charmCost_7", value); }
        public static bool newCharm_7 { get => Get<bool>("newCharm_7"); set => Set("newCharm_7", value); }
        public static bool gotCharm_8 { get => Get<bool>("gotCharm_8"); set => Set("gotCharm_8", value); }
        public static bool equippedCharm_8 { get => Get<bool>("equippedCharm_8"); set => Set("equippedCharm_8", value); }
        public static int charmCost_8 { get => Get<int>("charmCost_8"); set => Set("charmCost_8", value); }
        public static bool newCharm_8 { get => Get<bool>("newCharm_8"); set => Set("newCharm_8", value); }
        public static bool gotCharm_9 { get => Get<bool>("gotCharm_9"); set => Set("gotCharm_9", value); }
        public static bool equippedCharm_9 { get => Get<bool>("equippedCharm_9"); set => Set("equippedCharm_9", value); }
        public static int charmCost_9 { get => Get<int>("charmCost_9"); set => Set("charmCost_9", value); }
        public static bool newCharm_9 { get => Get<bool>("newCharm_9"); set => Set("newCharm_9", value); }
        public static bool gotCharm_10 { get => Get<bool>("gotCharm_10"); set => Set("gotCharm_10", value); }
        public static bool equippedCharm_10 { get => Get<bool>("equippedCharm_10"); set => Set("equippedCharm_10", value); }
        public static int charmCost_10 { get => Get<int>("charmCost_10"); set => Set("charmCost_10", value); }
        public static bool newCharm_10 { get => Get<bool>("newCharm_10"); set => Set("newCharm_10", value); }
        public static bool gotCharm_11 { get => Get<bool>("gotCharm_11"); set => Set("gotCharm_11", value); }
        public static bool equippedCharm_11 { get => Get<bool>("equippedCharm_11"); set => Set("equippedCharm_11", value); }
        public static int charmCost_11 { get => Get<int>("charmCost_11"); set => Set("charmCost_11", value); }
        public static bool newCharm_11 { get => Get<bool>("newCharm_11"); set => Set("newCharm_11", value); }
        public static bool gotCharm_12 { get => Get<bool>("gotCharm_12"); set => Set("gotCharm_12", value); }
        public static bool equippedCharm_12 { get => Get<bool>("equippedCharm_12"); set => Set("equippedCharm_12", value); }
        public static int charmCost_12 { get => Get<int>("charmCost_12"); set => Set("charmCost_12", value); }
        public static bool newCharm_12 { get => Get<bool>("newCharm_12"); set => Set("newCharm_12", value); }
        public static bool gotCharm_13 { get => Get<bool>("gotCharm_13"); set => Set("gotCharm_13", value); }
        public static bool equippedCharm_13 { get => Get<bool>("equippedCharm_13"); set => Set("equippedCharm_13", value); }
        public static int charmCost_13 { get => Get<int>("charmCost_13"); set => Set("charmCost_13", value); }
        public static bool newCharm_13 { get => Get<bool>("newCharm_13"); set => Set("newCharm_13", value); }
        public static bool gotCharm_14 { get => Get<bool>("gotCharm_14"); set => Set("gotCharm_14", value); }
        public static bool equippedCharm_14 { get => Get<bool>("equippedCharm_14"); set => Set("equippedCharm_14", value); }
        public static int charmCost_14 { get => Get<int>("charmCost_14"); set => Set("charmCost_14", value); }
        public static bool newCharm_14 { get => Get<bool>("newCharm_14"); set => Set("newCharm_14", value); }
        public static bool gotCharm_15 { get => Get<bool>("gotCharm_15"); set => Set("gotCharm_15", value); }
        public static bool equippedCharm_15 { get => Get<bool>("equippedCharm_15"); set => Set("equippedCharm_15", value); }
        public static int charmCost_15 { get => Get<int>("charmCost_15"); set => Set("charmCost_15", value); }
        public static bool newCharm_15 { get => Get<bool>("newCharm_15"); set => Set("newCharm_15", value); }
        public static bool gotCharm_16 { get => Get<bool>("gotCharm_16"); set => Set("gotCharm_16", value); }
        public static bool equippedCharm_16 { get => Get<bool>("equippedCharm_16"); set => Set("equippedCharm_16", value); }
        public static int charmCost_16 { get => Get<int>("charmCost_16"); set => Set("charmCost_16", value); }
        public static bool newCharm_16 { get => Get<bool>("newCharm_16"); set => Set("newCharm_16", value); }
        public static bool gotCharm_17 { get => Get<bool>("gotCharm_17"); set => Set("gotCharm_17", value); }
        public static bool equippedCharm_17 { get => Get<bool>("equippedCharm_17"); set => Set("equippedCharm_17", value); }
        public static int charmCost_17 { get => Get<int>("charmCost_17"); set => Set("charmCost_17", value); }
        public static bool newCharm_17 { get => Get<bool>("newCharm_17"); set => Set("newCharm_17", value); }
        public static bool gotCharm_18 { get => Get<bool>("gotCharm_18"); set => Set("gotCharm_18", value); }
        public static bool equippedCharm_18 { get => Get<bool>("equippedCharm_18"); set => Set("equippedCharm_18", value); }
        public static int charmCost_18 { get => Get<int>("charmCost_18"); set => Set("charmCost_18", value); }
        public static bool newCharm_18 { get => Get<bool>("newCharm_18"); set => Set("newCharm_18", value); }
        public static bool gotCharm_19 { get => Get<bool>("gotCharm_19"); set => Set("gotCharm_19", value); }
        public static bool equippedCharm_19 { get => Get<bool>("equippedCharm_19"); set => Set("equippedCharm_19", value); }
        public static int charmCost_19 { get => Get<int>("charmCost_19"); set => Set("charmCost_19", value); }
        public static bool newCharm_19 { get => Get<bool>("newCharm_19"); set => Set("newCharm_19", value); }
        public static bool gotCharm_20 { get => Get<bool>("gotCharm_20"); set => Set("gotCharm_20", value); }
        public static bool equippedCharm_20 { get => Get<bool>("equippedCharm_20"); set => Set("equippedCharm_20", value); }
        public static int charmCost_20 { get => Get<int>("charmCost_20"); set => Set("charmCost_20", value); }
        public static bool newCharm_20 { get => Get<bool>("newCharm_20"); set => Set("newCharm_20", value); }
        public static bool gotCharm_21 { get => Get<bool>("gotCharm_21"); set => Set("gotCharm_21", value); }
        public static bool equippedCharm_21 { get => Get<bool>("equippedCharm_21"); set => Set("equippedCharm_21", value); }
        public static int charmCost_21 { get => Get<int>("charmCost_21"); set => Set("charmCost_21", value); }
        public static bool newCharm_21 { get => Get<bool>("newCharm_21"); set => Set("newCharm_21", value); }
        public static bool gotCharm_22 { get => Get<bool>("gotCharm_22"); set => Set("gotCharm_22", value); }
        public static bool equippedCharm_22 { get => Get<bool>("equippedCharm_22"); set => Set("equippedCharm_22", value); }
        public static int charmCost_22 { get => Get<int>("charmCost_22"); set => Set("charmCost_22", value); }
        public static bool newCharm_22 { get => Get<bool>("newCharm_22"); set => Set("newCharm_22", value); }
        public static bool gotCharm_23 { get => Get<bool>("gotCharm_23"); set => Set("gotCharm_23", value); }
        public static bool equippedCharm_23 { get => Get<bool>("equippedCharm_23"); set => Set("equippedCharm_23", value); }
        public static int charmCost_23 { get => Get<int>("charmCost_23"); set => Set("charmCost_23", value); }
        public static bool newCharm_23 { get => Get<bool>("newCharm_23"); set => Set("newCharm_23", value); }
        public static bool gotCharm_24 { get => Get<bool>("gotCharm_24"); set => Set("gotCharm_24", value); }
        public static bool equippedCharm_24 { get => Get<bool>("equippedCharm_24"); set => Set("equippedCharm_24", value); }
        public static int charmCost_24 { get => Get<int>("charmCost_24"); set => Set("charmCost_24", value); }
        public static bool newCharm_24 { get => Get<bool>("newCharm_24"); set => Set("newCharm_24", value); }
        public static bool gotCharm_25 { get => Get<bool>("gotCharm_25"); set => Set("gotCharm_25", value); }
        public static bool equippedCharm_25 { get => Get<bool>("equippedCharm_25"); set => Set("equippedCharm_25", value); }
        public static int charmCost_25 { get => Get<int>("charmCost_25"); set => Set("charmCost_25", value); }
        public static bool newCharm_25 { get => Get<bool>("newCharm_25"); set => Set("newCharm_25", value); }
        public static bool gotCharm_26 { get => Get<bool>("gotCharm_26"); set => Set("gotCharm_26", value); }
        public static bool equippedCharm_26 { get => Get<bool>("equippedCharm_26"); set => Set("equippedCharm_26", value); }
        public static int charmCost_26 { get => Get<int>("charmCost_26"); set => Set("charmCost_26", value); }
        public static bool newCharm_26 { get => Get<bool>("newCharm_26"); set => Set("newCharm_26", value); }
        public static bool gotCharm_27 { get => Get<bool>("gotCharm_27"); set => Set("gotCharm_27", value); }
        public static bool equippedCharm_27 { get => Get<bool>("equippedCharm_27"); set => Set("equippedCharm_27", value); }
        public static int charmCost_27 { get => Get<int>("charmCost_27"); set => Set("charmCost_27", value); }
        public static bool newCharm_27 { get => Get<bool>("newCharm_27"); set => Set("newCharm_27", value); }
        public static bool gotCharm_28 { get => Get<bool>("gotCharm_28"); set => Set("gotCharm_28", value); }
        public static bool equippedCharm_28 { get => Get<bool>("equippedCharm_28"); set => Set("equippedCharm_28", value); }
        public static int charmCost_28 { get => Get<int>("charmCost_28"); set => Set("charmCost_28", value); }
        public static bool newCharm_28 { get => Get<bool>("newCharm_28"); set => Set("newCharm_28", value); }
        public static bool gotCharm_29 { get => Get<bool>("gotCharm_29"); set => Set("gotCharm_29", value); }
        public static bool equippedCharm_29 { get => Get<bool>("equippedCharm_29"); set => Set("equippedCharm_29", value); }
        public static int charmCost_29 { get => Get<int>("charmCost_29"); set => Set("charmCost_29", value); }
        public static bool newCharm_29 { get => Get<bool>("newCharm_29"); set => Set("newCharm_29", value); }
        public static bool gotCharm_30 { get => Get<bool>("gotCharm_30"); set => Set("gotCharm_30", value); }
        public static bool equippedCharm_30 { get => Get<bool>("equippedCharm_30"); set => Set("equippedCharm_30", value); }
        public static int charmCost_30 { get => Get<int>("charmCost_30"); set => Set("charmCost_30", value); }
        public static bool newCharm_30 { get => Get<bool>("newCharm_30"); set => Set("newCharm_30", value); }
        public static bool gotCharm_31 { get => Get<bool>("gotCharm_31"); set => Set("gotCharm_31", value); }
        public static bool equippedCharm_31 { get => Get<bool>("equippedCharm_31"); set => Set("equippedCharm_31", value); }
        public static int charmCost_31 { get => Get<int>("charmCost_31"); set => Set("charmCost_31", value); }
        public static bool newCharm_31 { get => Get<bool>("newCharm_31"); set => Set("newCharm_31", value); }
        public static bool gotCharm_32 { get => Get<bool>("gotCharm_32"); set => Set("gotCharm_32", value); }
        public static bool equippedCharm_32 { get => Get<bool>("equippedCharm_32"); set => Set("equippedCharm_32", value); }
        public static int charmCost_32 { get => Get<int>("charmCost_32"); set => Set("charmCost_32", value); }
        public static bool newCharm_32 { get => Get<bool>("newCharm_32"); set => Set("newCharm_32", value); }
        public static bool gotCharm_33 { get => Get<bool>("gotCharm_33"); set => Set("gotCharm_33", value); }
        public static bool equippedCharm_33 { get => Get<bool>("equippedCharm_33"); set => Set("equippedCharm_33", value); }
        public static int charmCost_33 { get => Get<int>("charmCost_33"); set => Set("charmCost_33", value); }
        public static bool newCharm_33 { get => Get<bool>("newCharm_33"); set => Set("newCharm_33", value); }
        public static bool gotCharm_34 { get => Get<bool>("gotCharm_34"); set => Set("gotCharm_34", value); }
        public static bool equippedCharm_34 { get => Get<bool>("equippedCharm_34"); set => Set("equippedCharm_34", value); }
        public static int charmCost_34 { get => Get<int>("charmCost_34"); set => Set("charmCost_34", value); }
        public static bool newCharm_34 { get => Get<bool>("newCharm_34"); set => Set("newCharm_34", value); }
        public static bool gotCharm_35 { get => Get<bool>("gotCharm_35"); set => Set("gotCharm_35", value); }
        public static bool equippedCharm_35 { get => Get<bool>("equippedCharm_35"); set => Set("equippedCharm_35", value); }
        public static int charmCost_35 { get => Get<int>("charmCost_35"); set => Set("charmCost_35", value); }
        public static bool newCharm_35 { get => Get<bool>("newCharm_35"); set => Set("newCharm_35", value); }
        public static bool gotCharm_36 { get => Get<bool>("gotCharm_36"); set => Set("gotCharm_36", value); }
        public static bool equippedCharm_36 { get => Get<bool>("equippedCharm_36"); set => Set("equippedCharm_36", value); }
        public static int charmCost_36 { get => Get<int>("charmCost_36"); set => Set("charmCost_36", value); }
        public static bool newCharm_36 { get => Get<bool>("newCharm_36"); set => Set("newCharm_36", value); }
        public static bool gotCharm_37 { get => Get<bool>("gotCharm_37"); set => Set("gotCharm_37", value); }
        public static bool equippedCharm_37 { get => Get<bool>("equippedCharm_37"); set => Set("equippedCharm_37", value); }
        public static int charmCost_37 { get => Get<int>("charmCost_37"); set => Set("charmCost_37", value); }
        public static bool newCharm_37 { get => Get<bool>("newCharm_37"); set => Set("newCharm_37", value); }
        public static bool gotCharm_38 { get => Get<bool>("gotCharm_38"); set => Set("gotCharm_38", value); }
        public static bool equippedCharm_38 { get => Get<bool>("equippedCharm_38"); set => Set("equippedCharm_38", value); }
        public static int charmCost_38 { get => Get<int>("charmCost_38"); set => Set("charmCost_38", value); }
        public static bool newCharm_38 { get => Get<bool>("newCharm_38"); set => Set("newCharm_38", value); }
        public static bool gotCharm_39 { get => Get<bool>("gotCharm_39"); set => Set("gotCharm_39", value); }
        public static bool equippedCharm_39 { get => Get<bool>("equippedCharm_39"); set => Set("equippedCharm_39", value); }
        public static int charmCost_39 { get => Get<int>("charmCost_39"); set => Set("charmCost_39", value); }
        public static bool newCharm_39 { get => Get<bool>("newCharm_39"); set => Set("newCharm_39", value); }
        public static bool gotCharm_40 { get => Get<bool>("gotCharm_40"); set => Set("gotCharm_40", value); }
        public static bool equippedCharm_40 { get => Get<bool>("equippedCharm_40"); set => Set("equippedCharm_40", value); }
        public static int charmCost_40 { get => Get<int>("charmCost_40"); set => Set("charmCost_40", value); }
        public static bool newCharm_40 { get => Get<bool>("newCharm_40"); set => Set("newCharm_40", value); }

        // Broken & Fragile Charms & Quest Items
        public static bool brokenCharm_23 { get => Get<bool>("brokenCharm_23"); set => Set("brokenCharm_23", value); }
        public static bool brokenCharm_24 { get => Get<bool>("brokenCharm_24"); set => Set("brokenCharm_24", value); }
        public static bool brokenCharm_25 { get => Get<bool>("brokenCharm_25"); set => Set("brokenCharm_25", value); }
        public static bool fragileHealth_unbreakable { get => Get<bool>("fragileHealth_unbreakable"); set => Set("fragileHealth_unbreakable", value); }
        public static bool fragileGreed_unbreakable { get => Get<bool>("fragileGreed_unbreakable"); set => Set("fragileGreed_unbreakable", value); }
        public static bool fragileStrength_unbreakable { get => Get<bool>("fragileStrength_unbreakable"); set => Set("fragileStrength_unbreakable", value); }
        public static int royalCharmState { get => Get<int>("royalCharmState"); set => Set("royalCharmState", value); }
        public static int grimmChildLevel { get => Get<int>("grimmChildLevel"); set => Set("grimmChildLevel", value); }
        public static int flamesCollected { get => Get<int>("flamesCollected"); set => Set("flamesCollected", value); }

        // Journal and World Items
        public static bool hasJournal { get => Get<bool>("hasJournal"); set => Set("hasJournal", value); }
        public static int lastJournalItem { get => Get<int>("lastJournalItem"); set => Set("lastJournalItem", value); }
        public static bool seenJournalMsg { get => Get<bool>("seenJournalMsg"); set => Set("seenJournalMsg", value); }
        public static bool seenHunterMsg { get => Get<bool>("seenHunterMsg"); set => Set("seenHunterMsg", value); }
        public static bool hasGodfinder { get => Get<bool>("hasGodfinder"); set => Set("hasGodfinder", value); }
        public static int fountainGeo { get => Get<int>("fountainGeo"); set => Set("fountainGeo", value); }
        public static bool hasMap { get => Get<bool>("hasMap"); set => Set("hasMap", value); }

        // Map Pins
        public static bool hasPinBench { get => Get<bool>("hasPinBench"); set => Set("hasPinBench", value); }
        public static bool hasPinCocoon { get => Get<bool>("hasPinCocoon"); set => Set("hasPinCocoon", value); }
        public static bool hasPinDreamPlant { get => Get<bool>("hasPinDreamPlant"); set => Set("hasPinDreamPlant", value); }
        public static bool hasPinGhost { get => Get<bool>("hasPinGhost"); set => Set("hasPinGhost", value); }
        public static bool hasPinShop { get => Get<bool>("hasPinShop"); set => Set("hasPinShop", value); }
        public static bool hasPinSpa { get => Get<bool>("hasPinSpa"); set => Set("hasPinSpa", value); }
        public static bool hasPinStag { get => Get<bool>("hasPinStag"); set => Set("hasPinStag", value); }
        public static bool hasPinTram { get => Get<bool>("hasPinTram"); set => Set("hasPinTram", value); }
        public static bool hasMarker { get => Get<bool>("hasMarker"); set => Set("hasMarker", value); }

        // Methods
        public static void PrintStory() => Call("PrintStory");
        public static void Reset() => Call("Reset");
        public static bool UpdateGameMap() => Call<bool>("UpdateGameMap");
        public static void CheckAllMaps() => Call("CheckAllMaps");
        public static void SetBool(string boolName, bool value) => Call("SetBool", boolName, value);
        public static void SetInt(string intName, int value) => Call("SetInt", intName, value);
        public static void IncrementInt(string intName) => Call("IncrementInt", intName);
        public static void IntAdd(string intName, int amount) => Call("IntAdd", intName, amount);
        public static void SetFloat(string floatName, float value) => Call("SetFloat", floatName, value);
        public static void DecrementInt(string intName) => Call("DecrementInt", intName);
        public static bool GetBool(string boolName) => Call<bool>("GetBool", boolName);
        public static int GetInt(string intName) => Call<int>("GetInt", intName);
        public static float GetFloat(string floatName) => Call<float>("GetFloat", floatName);
        public static string GetString(string stringName) => Call<string>("GetString", stringName);
        public static void SetString(string stringName, string value) => Call("SetString", stringName, value);
        public static void SetVector3(string vectorName, Vector3 value) => Call("SetVector3", vectorName, value);
        public static Vector3 GetVector3(string vectorName) => Call<Vector3>("GetVector3", vectorName);
        public static void SetVariable<T>(string fieldName, T value) => Call("SetVariable", fieldName, value);
        public static T GetVariable<T>(string fieldName) => Call<T>("GetVariable", fieldName);
        public static void AddHealth(int amount) => Call("AddHealth", amount);
        public static void TakeHealth(int amount) => Call("TakeHealth", amount);
        public static void MaxHealth() => Call("MaxHealth");
        public static void ActivateTestingCheats() => Call("ActivateTestingCheats");
        public static void GetAllPowerups() => Call("GetAllPowerups");
        public static void AddToMaxHealth(int amount) => Call("AddToMaxHealth", amount);
        public static void UpdateBlueHealth() => Call("UpdateBlueHealth");
        public static void AddGeo(int amount) => Call("AddGeo", amount);
        public static void TakeGeo(int amount) => Call("TakeGeo", amount);
        public static bool WouldDie(int damage) => Call<bool>("WouldDie", damage);
        public static bool AddMPCharge(int amount) => Call<bool>("AddMPCharge", amount);
        public static void TakeMP(int amount) => Call("TakeMP", amount);
        public static void TakeReserveMP(int amount) => Call("TakeReserveMP", amount);
        public static void ClearMP() => Call("ClearMP");
        public static void AddToMaxMPReserve(int amount) => Call("AddToMaxMPReserve", amount);
        public static void StartSoulLimiter() => Call("StartSoulLimiter");
        public static void EndSoulLimiter() => Call("EndSoulLimiter");
        public static void EquipCharm(int charmNum) => Call("EquipCharm", charmNum);
        public static void UnequipCharm(int charmNum) => Call("UnequipCharm", charmNum);
        public static void CalculateNotchesUsed() => Call("CalculateNotchesUsed");
        public static void SetBenchRespawn(string spawnMarker, string sceneName, int spawnType, bool facingRight) => Call("SetBenchRespawn", spawnMarker, sceneName, spawnType, facingRight);
        public static void SetHazardRespawn(Vector3 position, bool facingRight) => Call("SetHazardRespawn", position, facingRight);
        public static void CountGameCompletion() => Call("CountGameCompletion");
        public static void CountCharms() => Call("CountCharms");
        public static void CountJournalEntries() => Call("CountJournalEntries");
        public static void AddGGPlayerDataOverrides() => Call("AddGGPlayerDataOverrides");
    }
}