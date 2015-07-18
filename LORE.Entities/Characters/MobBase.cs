namespace LORE.Entities.Characters
{
    public abstract class MobBase : CharacterBase
    {
        public MobBase(string name) : base(name) { }

        public bool IsAggressive { get; set; }
        public bool IsVendor { get; set; }
    }
}
