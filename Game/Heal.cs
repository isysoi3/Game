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


        public override bool DoMagic(Wizard w, Hero h, uint _strength)
        {
            if (h == null)
                h = w as Hero;
            if (w.сurrentMana >= minMana && h.condition == Condition.Sick)
            {
                h.condition = Condition.Normal;
                //h.currentHealth = h.currentHealth;
                w.сurrentMana -= minMana;
                return true;
            }
            return false;
        }

        public override bool DoMagic()
        {
            //нужно с этими перегрузками решить
            throw new NotImplementedException();
        }

        public override bool DoMagic(Hero h, uint _strength)
        {
            //нужно с этими перегрузками решить
            throw new NotImplementedException();
        }
    }
}
