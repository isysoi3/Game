using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Heal : Spell
    {
        public Heal()
        {
            minMana = 20;
        }

        public override bool DoMagic()
        {
            //if (сurrentMana > minMana)
            //{
            //    tcondition = Condition.Normal;
            //    this.сurrentMana -= minMana;
            //}
            return false;
        }

        public override bool DoMagic(Hero h, uint _strength)
        {
            //исправить
            if ((h as Wizard).сurrentMana >= minMana /* && h.condition ==  Condition.Sick */)
            {
                //h.condition = Condition.Normal;
                h.currentHealth = h.currentHealth;
                (h as Wizard).сurrentMana -= minMana;
            }
            return true;
        }
    }
}
