using LORE.Entities.Misc;

namespace LORE.WebApi.Objects.Models
{
    public class WeaponModel
    {
        public string Name { get; set; }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int HitModifier { get; set; }
        public int CriticalModifier { get; set; }
        public Money Value { get; private set; }

        public WeaponModel() 
        {
            Value = new Money();
        }
    }
}
