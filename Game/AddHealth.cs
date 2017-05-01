using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class AddHealth : Spell
    {
        public override bool DoMagic()
        {
            throw new NotImplementedException();
        }

        public override bool DoMagic(Hero h, uint _strength = 0)
        {
            throw new NotImplementedException();
        }

        public override bool DoMagic(Wizard w, Hero h = null, uint _strength = 0)
        {
            if (h == null)
                h = w as Hero;
            w.AddHealth(h);
            return true;
        }
    }
}
