using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class TakeOff : Spell
    {
        TakeOff()
        {
            minMana = 85;
        }

        public override bool DoMagic()
        {
            throw new NotImplementedException();
        }

        public override bool DoMagic(Hero h, uint _strength = 0)
        {
            if ((h as Wizard).сurrentMana >= minMana /* h.condition == Condition.Paralyzed */)
            {
                //TODO
                h.condition = Condition.Normal;
                h.currentHealth = 1;
                (h as Wizard).сurrentMana -= minMana;
            }
            return true;
        }
    }
}
