using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Staff : Artifact
    {
        public Staff(uint s)
        {
            strength = s;
            IsRenewable = true;
        }

        public override bool DoMagic()
        {
            throw new NotImplementedException();
        }

        public override bool DoMagic(Hero h, uint st)
        {
            //проерка на жизни, мощность и использывани
            if (strength > 0)
            {
                if (h.currentHealth > st)
                {
                    h.currentHealth -= st;
                }
                else
                {
                    h.currentHealth = 0;
                }
                if (st < strength)
                    strength -= st;
                else
                    strength = 0;
            }
            return IsRenewable;
        }
    }
}
