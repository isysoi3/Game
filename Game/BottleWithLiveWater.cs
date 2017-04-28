using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class BottleWithLiveWater : Artifact
    {
        public readonly Bottle btBottle;

        public BottleWithLiveWater(Bottle bt)
        {
            btBottle = bt;
            IsRenewable = false;
        }

        public override bool DoMagic()
        {
            //if ((uint)btBottle + this.currentHealth >= this.maxHealth)
            //    this.currentHealth = this.maxHealth;
            //else
            //    this.currentHealth += (uint)btBottle;
            //btBottle = Bottle.Zero;\
            return IsRenewable;
        }

        public override bool DoMagic(Hero h, uint _strength)
        {
            if ((uint)btBottle + h.currentHealth >= h.maxHealth)
                h.currentHealth = h.maxHealth;
            else
                h.currentHealth += (uint)btBottle;
            return IsRenewable;
        }
    }
}
