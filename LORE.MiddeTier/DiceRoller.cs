using System;

namespace LORE.MiddeTier
{
    public class DiceRoller
    {
        readonly Random rnd = new Random(Guid.NewGuid().GetHashCode());
        public int D20(int rolls)
        {
            return GetRandom(20, rolls);
        }

        public int D12(int rolls)
        {
            return GetRandom(12, rolls);
        }

        public int D10(int rolls)
        {
            return GetRandom(10, rolls);
        }

        public int D8(int rolls)
        {
            return GetRandom(8, rolls);
        }

        public int D6(int rolls)
        {
            return GetRandom(6, rolls);
        }

        public int D4(int rolls)
        {
            return GetRandom(4, rolls);
        }

        private int GetRandom(int upper, int rolls)
        {
            var roll = 0;
            for (var x = 0; x < rolls; x++)
            {
                roll += rnd.Next(1, upper);
            }
            return roll;
        }
    }
}
