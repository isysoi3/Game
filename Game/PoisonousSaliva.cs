using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class PoisonousSaliva : Artifact
    {
        public PoisonousSaliva(uint s)
        {
            strength = s;
            IsRenewable = true;
        }

        public override bool DoMagic()
        {
            throw new NotImplementedException();
        }

        public override bool DoMagic(Hero h, uint _st = 0)
        {
            if (h.condition == Condition.Normal || h.condition == Condition.Weakened)
            {
                if (h.currentHealth > strength)
                {
                    h.currentHealth -= strength;
                    h.condition = Condition.Poisoned;
                }
                else
                {
                    h.currentHealth = 0;
                    h.condition = Condition.Dead;
                }
            }
            return IsRenewable;
        }
    }
}
