using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Decoction : Artifact
    {
        public Decoction()
        {
            IsRenewable = false;
        }

        public override bool DoMagic()
        {
            throw new NotImplementedException();
        }

        public override bool DoMagic(Hero h, uint _strength)
        {
            // испарвить состояния
            //h.condition = Condition.Normal;
            if (h.condition == Condition.Poisoned)
                h.currentHealth = h.currentHealth;
            return IsRenewable;
        }
    }
}
