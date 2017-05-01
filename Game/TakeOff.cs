using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class TakeOff : Spell
    {
        public TakeOff()
        {
            minMana = 85;
        }

        public override bool DoMagic()
        {
            throw new NotImplementedException();
        }

        public override bool DoMagic(Wizard w, Hero h, uint _strength = 0)
        {
            if (w.сurrentMana >= minMana && h.condition == Condition.Paralyzed)
            {
                //TODO
                h.condition = Condition.Normal;
                h.currentHealth = 1;
                w.сurrentMana -= minMana;
                return true;
            }
            return false;
        }


        public override bool DoMagic(Hero h, uint _strength = 0)
        {
            throw new NotImplementedException();
        }
    }
}
