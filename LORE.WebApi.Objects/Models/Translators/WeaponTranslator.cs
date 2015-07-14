using LORE.Entities.Items;

namespace LORE.WebApi.Objects.Models.Translators
{
    public static class WeaponTranslator
    {
        public static WeaponModel ToModel(this WeaponBase weapon)
        {
            return new WeaponModel();



        }
    }
}
