﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    abstract class Artifact : IMagic
    {
        private uint _strength;
        private bool _isRenewable;

        public uint strength
        {
            get
            {
                return _strength;
            }

            set
            {
                _strength = value;
            }
        }

        public bool IsRenewable
        {
            get { return _isRenewable; }
            set { _isRenewable = value; }
        }

        public bool DoMagic(Wizard w, Hero h = null, uint _strength = 0)
        {
            return false;
        }

        abstract public bool DoMagic();

        abstract public bool DoMagic(Hero h, uint _strength = 0);
    }
}
