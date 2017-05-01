using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Animate : Spell
    {
        public Animate()
        {
            minMana = 150;
        }

        public override bool DoMagic()
        {
            //нужно с этими перегрузками решить
            throw new NotImplementedException();
        }

        public override bool DoMagic(Wizard w, Hero h, uint _strength = 0)
        {
            if (w.сurrentMana >= minMana && h.condition == Condition.Dead)
            {
                h.condition = Condition.Normal;
                h.currentHealth = 1;
                w.сurrentMana -= minMana;
                return true;
            }
            return false;
        }

        public override bool DoMagic(Hero h, uint _strength = 0)
        {
            //нужно с этими перегрузками решить
            throw new NotImplementedException();
        }
    }
}
