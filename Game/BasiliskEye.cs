using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class BasiliskEye : Artifact
    {

        public BasiliskEye()
        {
            IsRenewable = false;
        }

        public override bool DoMagic()
        {
            throw new NotImplementedException();
        }

        public override bool DoMagic(Hero h, uint _st)
        {
            if (h.condition != Condition.Dead)
            {
                h.condition = Condition.Paralyzed;
                return IsRenewable;
            }
            return IsRenewable;
        }
    }
}
