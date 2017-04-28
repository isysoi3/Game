using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class BottleWithDeadWater : Artifact
    {
        public readonly Bottle btBottle;

        public BottleWithDeadWater(Bottle bt)
        {
            btBottle = bt;
            IsRenewable = false;
        }

        public override bool DoMagic()
        {
            //if (this is Wizard)
            //{
            //    da(this as Wizard);
            //}
            return IsRenewable;
        }

        public override bool DoMagic(Hero h, uint _strength)
        {
            if (h is Wizard)
            {
                da(h as Wizard);
                return IsRenewable;
            }

            return true;
        }

        private void da(Wizard w)
        {
            if ((uint)btBottle + w.сurrentMana >= w.maxMana)
                w.сurrentMana = w.maxMana;
            else
                w.сurrentMana += (uint)btBottle;
        }
    }
}
