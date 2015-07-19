namespace LORE.Entities.Mechanics.Rules
{
    public class AttackResult
    {
        private AttackResult(bool hit, int damage)
        {
            Hit = hit;
            Damage = damage;
        }

        public bool Hit { get; private set; }
        public int Damage { get; private set; }

        public static AttackResult GetResult()
        {
            // TODO:  Figure out AttackResult process.
            return new AttackResult(false, 0);
        }
    }
}
