namespace LORE.Entities.Mechanics.Rules
{
    public class AbilityScore
    {
        public AbilityScore(int modifier, string name, string description)
        {
            Modifier = modifier;
            Name = name;
            Description = description;
        }

        public int Modifier { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
