using System;

namespace LORE.Entities.Misc
{
    public class Money
    {
        int _copper;
        public Money() : this(0) { }
        public Money(int value = 0) 
        {
            _copper = value;
        }
        public Money(int platinum = 0, int gold = 0, int silver = 0, int copper = 0) : this(ConvertToCopper(platinum, gold, silver, copper))
        {}

        public static int ConvertToCopper(int platinum = 0, int gold = 0, int silver = 0, int copper = 0)
        {
            int val = (platinum * 100000);
            val += (gold * 10000);
            val += (silver * 100);
            val += copper;
            return val;
        }

        public void AddMoney(int platinum = 0, int gold = 0, int silver = 0, int copper = 0)
        {
            {
            _copper += ConvertToCopper(platinum, gold, silver, copper);
            }
        }

        public void SubtractMoney(int platinum = 0, int gold = 0, int silver = 0, int copper = 0)
        {
            var val = ConvertToCopper(platinum, gold, silver, copper);

            if (val > _copper)
            {
                throw new Exception("You do not have enough money for this.");
            }
            else
            {
                _copper = _copper - val;
            }
        }

        public int Value
        {
            get
            {
                return _copper;
            }
        }

            
        public int Platinum
        {
            get
            {
                return Convert.ToInt32(_copper / 1000000);
            }
        }

        public int Gold
        {
            get
            {
                return Convert.ToInt32((_copper / 10000) % 100);
            }
        }

        public int Silver
        {
            get
            {
                return Convert.ToInt32((_copper / 100) % 100);
            }
        }

        public int Copper
        {
            get
            {
                return (_copper % 100);
            }
        }

    }
}
