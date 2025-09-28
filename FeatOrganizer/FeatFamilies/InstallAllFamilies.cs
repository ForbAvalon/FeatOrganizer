namespace FeatOrganizer.FeatFamilies
{
    internal static class InstallAllFamilies
    {
        public static void Configure()
        {
            MeleeFeatFamily.Configure();
            // RangedFeatFamily.Configure();
            // TwoHandedFeatFamily.Configure();
            // … las que vayas creando
        }
    }
}
