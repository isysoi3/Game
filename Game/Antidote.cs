using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Antidote : Spell
    {
        public Antidote()
        {
            minMana = 30;
        }

        public override bool DoMagic()
        {
            //if (this.сurrentMana > minMana)
            //{
            //    this.condition = Condition.Normal;
            //    this.сurrentMana -= minMana;
            //}
            return true;
        }

        public override bool DoMagic(Hero h, uint _strength = 0)
        {
            if ((h as Wizard).сurrentMana >= minMana /* && h.condition == Condition.Poisoned */)
            {
                h.condition = Condition.Normal;
                h.currentHealth = h.currentHealth;
                (h as Wizard).сurrentMana -= minMana;
            }
            return true;
        }
    }
}
