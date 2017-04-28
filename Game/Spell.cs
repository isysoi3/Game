using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    abstract class Spell : IMagic
    {
        private uint _minMana;
        private bool needToPronounce;
        private bool needToMotion;

        public bool NeedToMotion
        {
            get
            {
                return needToMotion;
            }

            set
            {
                needToMotion = value;
            }
        }

        public bool NeedToPronounce
        {
            get
            {
                return needToPronounce;
            }

            set
            {
                needToPronounce = value;
            }
        }

        public uint minMana
        {
            get
            {
                return _minMana;
            }
            set { _minMana = value; }
        }

        abstract public bool DoMagic();
        abstract public bool DoMagic(Hero h, uint _strength = 0);
    }
}
