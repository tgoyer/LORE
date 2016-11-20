using System;

namespace LORE.Entities.Misc
{
    public class Money
    {
        private static uint _platConversion     = 1000000;
        private static uint _goldConversion       = 10000;
        private static uint _silverConversion       = 100;
        public uint _copper;
        public Money() : this(0) { }
        public Money(uint value = 0) 
        {
            _copper = value;
        }
        public Money(uint platinum = 0, uint gold = 0, uint silver = 0, uint copper = 0) : this(ConvertToCopper(platinum, gold, silver, copper))
        {}

        public static uint ConvertToCopper(uint platinum = 0, uint gold = 0, uint silver = 0, uint copper = 0)
        {
            uint val = (platinum * _platConversion);
            val += (gold * _goldConversion);
            val += (silver * _silverConversion);
            val += copper;
            return val;
        }

        public void AddMoney(uint platinum = 0, uint gold = 0, uint silver = 0, uint copper = 0)
        {
            {
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

        public uint Value
        {
            get
            {
                return Convert.ToUInt32(_copper);
            }
        }

            
        public uint Platinum
        {
            get
            {
                return Convert.ToUInt32(_copper / _platConversion);
            }
        }

        public uint Gold
        {
            get
            {
                return Convert.ToUInt32((_copper / _goldConversion) % 100);
            }
        }

        public uint Silver
        {
            get
            {
                return Convert.ToUInt32((_copper / _silverConversion) % 100);
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
