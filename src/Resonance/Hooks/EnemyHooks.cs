using System;
using HarmonyLib;

namespace Resonance.Hooks
{
    public static class EnemyHooks
    {
        public static event Action<global::HealthManager, global::HitInstance, global::AttackTypes> OnEnvironmentHitEnemy;
        public static event Action<global::HealthManager, global::HitInstance> OnSlashBeamHitEnemy;
        public static event Action<global::HealthManager, global::HitInstance> OnSlashHitEnemy;
        public static event Action<global::HealthManager, global::HitInstance> OnSpellHitEnemy;
        public static event Action<global::HealthManager, global::HitInstance> OnSharpShadowHitEnemy;

        [HarmonyPatch(typeof(global::HealthManager), nameof(global::HealthManager.Hit))]
        private static class OnHitEnemyPatch
        {
            [HarmonyPostfix]
            internal static void Postfix(global::HealthManager __instance, global::HitInstance hitInstance)
            {
                switch (hitInstance.AttackType)
                {
                    case AttackTypes.Nail:
                        OnSlashHitEnemy.Invoke(__instance, hitInstance);
                        break;
                    case AttackTypes.Spell:
                        OnSpellHitEnemy.Invoke(__instance, hitInstance);
                        break;
                    case AttackTypes.NailBeam:
                        OnSlashBeamHitEnemy.Invoke(__instance, hitInstance);
                        break;
                    case AttackTypes.SharpShadow:
                        OnSharpShadowHitEnemy.Invoke(__instance, hitInstance);
                        break;
                    case AttackTypes.Splatter:
                    case AttackTypes.Generic:
                    case AttackTypes.RuinsWater:
                    case AttackTypes.Acid:
                        OnEnvironmentHitEnemy.Invoke(__instance, hitInstance, hitInstance.AttackType);
                        break;
                }
            }
        }
    }
}