using Assets.Scripts.Models.Profile;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

[assembly: MelonInfo(typeof(UnlockAllMaps.Main), "UnlockAllMaps", "1.0.0", "MaliciousFiles")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace UnlockAllMaps
{
    public class Main : MelonMod
    {
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            MelonLogger.Msg("UnlockAllMaps has finished loading");
        }

        [HarmonyPatch(typeof(MainMenu), "Open")]
        public class TitleScreen_Patch {
            [HarmonyPostfix]
            public static void Postfix()
            {
                foreach (KeyValuePair<string, MapInfo> entry in Game.instance.playerService.Player.Data.mapInfo.maps)
                {
                    Game.instance.playerService.Player.Data.mapInfo.SeenNewMapDifficulty(entry.key);
                    Game.instance.playerService.Player.Data.mapInfo.UnlockMap(entry.key);
                    Game.instance.playerService.Player.Data.mapInfo.SeenNewMap(entry.key);
                }
            }
        }
    }
}
