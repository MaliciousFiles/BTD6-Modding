﻿using Assets.Scripts.Models.Profile;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using BTD_Mod_Helper;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

[assembly: MelonInfo(typeof(UnlockAllMaps.Main), "UnlockDoubleCash", "1.0.0", "MaliciousFiles")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace UnlockAllMaps
{
    public class Main : BloonsTD6Mod
    {
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            MelonLogger.Msg("Mod has finished loading");
        }

        [HarmonyPatch(typeof(MainMenu), "Open")]
        public class TitleScreen_Patch {
            [HarmonyPostfix]
            public static void Postfix()
            {
                Game.instance.playerService.Player.Data.purchase.purchasedDoubleCashMode = true;
            }
        }
    }
}
