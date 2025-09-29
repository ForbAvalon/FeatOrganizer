using System;
using HarmonyLib;
using UniRx;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Root.Strings;
using Kingmaker.UnitLogic.Class.LevelUp;
using Kingmaker.UI.MVVM._VM.CharGen.Phases.FeatureSelector;
using FeatOrganizer.Components; // Tu componente AggregateMemberRecommendations

namespace FeatOrganizer.Patches
{
    /// <summary>
    /// 1) Asegura que las carpetas de FeatOrganizer siempre reporten HasNesting = true,
    ///    para que la UI permita expandir incluso cuando no haya hijos "elegibles".
    /// </summary>
    [HarmonyPatch(typeof(CharGenFeatureSelectorItemVM), "HasNesting", MethodType.Getter)]
    internal static class Patch_OurFolder_HasNesting_True
    {
        static void Postfix(CharGenFeatureSelectorItemVM __instance, ref bool __result)
        {
            var bp = __instance?.Feature?.Feature as BlueprintFeatureBase;
            if (bp == null) return;

            // Si es una de nuestras "carpetas", forzamos nesting
            if (bp.GetComponent<AggregateMemberRecommendations>() != null)
                __result = true;
        }
    }

    /// <summary>
    /// 2) Evita que se oculten feats "Forbidden" (no elegibles) cuando están dentro de nuestras carpetas.
    ///    Así pueden verse y consultarse sus requisitos (tooltips, etiquetas).
    /// </summary>
    [HarmonyPatch(typeof(CharGenFeatureSelectorItemVM), "ShouldBeHidden")]
    internal static class Patch_OurFolder_ShowForbiddenChildren
    {
        // FieldRef a m_FeatureParent para subir hasta la raíz del subárbol
        private static readonly AccessTools.FieldRef<CharGenFeatureSelectorItemVM, CharGenFeatureSelectorItemVM>
            _parentRef = AccessTools.FieldRefAccess<CharGenFeatureSelectorItemVM, CharGenFeatureSelectorItemVM>("m_FeatureParent");

        static void Postfix(CharGenFeatureSelectorItemVM __instance, ref bool __result)
        {
            // Si YA es visible, no tocamos nada
            if (!__result) return;

            // Si este item está bajo una carpeta nuestra, no lo ocultes
            if (IsUnderOurFolder(__instance))
            {
                __result = false;

                // Aclarar estado visual: mostrar que está bloqueado por requisitos
                __instance.SelectState = FeatureSelectionViewState.SelectState.Forbidden;
                if (__instance.NotAvailableLabel != null)
                    __instance.NotAvailableLabel.Value = UIStrings.Instance.Tooltips.Prerequisites;

                // Asegura que se trate como "mostrable" en la lista aunque no sea seleccionable
                __instance.SetAvailableState(true);
            }
        }

        private static bool IsUnderOurFolder(CharGenFeatureSelectorItemVM vm)
        {
            if (vm == null) return false;

            // Subimos al "root" del bloque anidado
            var root = vm;
            while (true)
            {
                var p = GetParent(root);
                if (p == null) break;
                root = p;
            }

            var bp = root?.Feature?.Feature as BlueprintFeatureBase;
            if (bp == null) return false;

            // Detectamos carpeta propia por el componente de FeatOrganizer
            return bp.GetComponent<AggregateMemberRecommendations>() != null;
        }

        private static CharGenFeatureSelectorItemVM GetParent(CharGenFeatureSelectorItemVM vm)
        {
            try { return _parentRef(vm); }
            catch { return null; }
        }
    }
}
