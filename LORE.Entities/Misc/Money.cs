using System;

namespace LORE.Entities.Misc
{
    public class Money
    {
        uint _copper;
        public Money() : this(0) { }
        public Money(uint value = 0) 
        {
            _copper = value;
        }
        public Money(uint platinum = 0, uint gold = 0, uint silver = 0, uint copper = 0) : this(ConvertToCopper(platinum, gold, silver, copper))
        {}

        public static uint ConvertToCopper(uint platinum = 0, uint gold = 0, uint silver = 0, uint copper = 0)
        {
            uint val = (platinum * 1000000);
            val += (gold * 10000);
            val += (silver * 100);
            val += copper;
            return val;
        }

        public void AddMoney(uint platinum = 0, uint gold = 0, uint silver = 0, uint copper = 0)
        {
            {
                if (_copper == 4294967295 || _copper > 4294967295)
                {
                    _copper = 4294967295;
                    System.Console.WriteLine("you are at max money.");
                    System.Console.ReadLine();
                }
                else
                {
                    _copper += ConvertToCopper(platinum, gold, silver, copper);
                }
                
            }
        }

        public void SubtractMoney(uint platinum = 0, uint gold = 0, uint silver = 0, uint copper = 0)
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
                return Convert.ToInt32(_copper);
            }
        }

            
        public uint Platinum
        {
            get
            {
                return Convert.ToUInt32(_copper / 1000000);
            }
        }

        public uint Gold
        {
            get
            {
                return Convert.ToUInt32((_copper / 10000) % 100);
            }
        }

        public uint Silver
        {
            get
            {
                return Convert.ToUInt32((_copper / 100) % 100);
            }
        }

        public uint Copper
        {
            get
            {
                return (_copper % 100);
            }
        }

    }
}
