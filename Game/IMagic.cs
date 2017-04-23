using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testC
{
    interface IMagic
    {
        void DoMagic();
        void DoMagic(Hero h,int strength);
    }

    abstract class Spell : IMagic
    {
        private uint minMana;
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

        public uint MinMana
        {
            get
            {
                return minMana;
            }

            set
            {
                minMana = value;
            }
        }

        abstract public void DoMagic();
        abstract public void DoMagic(Hero h, int strength);
    }
}
