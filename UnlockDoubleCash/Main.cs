using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using HarmonyLib;
using MelonLoader;

[assembly: MelonInfo(typeof(UnlockDoubleCash.Main), "UnlockDoubleCash", "1.0.0", "MaliciousFiles")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace UnlockDoubleCash
{
    public class Main : MelonMod
    {
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            MelonLogger.Msg("UnlockDoubleCash has finished loading");
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
