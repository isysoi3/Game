using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testC
{
    interface IMagic
    {
        void DoMagic();
        void DoMagic(Hero h, uint _strength);
    }

    enum Bottle { Zero = 0, Small = 10, Medium = 25, Large = 50 };


    abstract class Spell : IMagic
    {
        private uint minMana;
        private bool needToPronounce;
        private bool needToMotion;

        public bool NeedToMotion
        {
            get
            {
                return needToMotion;
            }

            set
            {
                needToMotion = value;
            }
        }

        public bool NeedToPronounce
        {
            get
            {
                return needToPronounce;
            }

            set
            {
                needToPronounce = value;
            }
        }

        public uint MinMana
        {
            get
            {
                return minMana;
            }

            set
            {
                minMana = value;
            }
        }

        abstract public void DoMagic();
        abstract public void DoMagic(Hero h, uint _strength);
    }

    class AddHealh : Spell
    {
        public override void DoMagic()
        {

        }

        public override void DoMagic(Hero h, uint _strength)
        {

        }
    }

    class Heal : Spell
    {
        Heal()
        {
            MinMana = 20;
        }

        public override void DoMagic()
        {
            if (this.сurrentMana > MinMana)
            {
                this.condition = Condition.Normal;
                this.сurrentMana -= MinMana;
            }
        }

        public override void DoMagic(Hero h, uint _strength = 0)
        {
            if (this.сurrentMana > MinMana)
            {
                h.condition = Condition.Normal;
                this.сurrentMana -= MinMana;
            }
        }
    }

    class Antidote : Spell
    {
        Antidote()
        {
            MinMana = 30;
        }

        public override void DoMagic()
        {
            if (this.сurrentMana > MinMana)
            {
                this.condition = Condition.Normal;
                this.сurrentMana -= MinMana;
            }
        }

        public override void DoMagic(Hero h, uint _strength = 0)
        {
            if (this.сurrentMana > MinMana)
            {
                h.condition = Condition.Normal;
                this.сurrentMana -= MinMana;
            }
        }
    }

    class Animate : Spell
    {
        Animate()
        {
            MinMana = 150;
        }

        public override void DoMagic()
        {
            throw new NotImplementedException();
        }

        public override void DoMagic(Hero h, uint _strength = 0)
        {
            if (this.сurrentMana >= MinMana)
            {
                h.condition = Condition.Normal;
                h.currentHealth = 1;
                this.сurrentMana -= MinMana;
            }
        }
    }

    class Armor : Spell
    {
        Armor()
        {
            MinMana = 50;
        }

        public override void DoMagic()
        {
            throw new NotImplementedException();
        }

        public override void DoMagic(Hero h, uint _strength = 0)
        {
            if (this.сurrentMana >= MinMana)
            {
                //TODO
                this.сurrentMana -= MinMana;
            }
        }
    }

    class TakeOff : Spell
    {
        TakeOff()
        {
            MinMana = 85;
        }

        public override void DoMagic()
        {
            throw new NotImplementedException();
        }

        public override void DoMagic(Hero h, uint _strength = 0)
        {
            if (this.сurrentMana >= MinMana)
            {
                //TODO
                h.condition = Condition.Normal;
                h.currentHealth = 1;
                this.сurrentMana -= MinMana;
            }
        }
    }
    /////////////////////////////////////////

    abstract class Artifact : IMagic
    {
        private uint _strength;
        private bool isRenewable;

        public uint strength
        {
            get
            {
                return strength;
            }

            set
            {
                strength = value;
            }
        }

        abstract public void DoMagic();

        abstract public void DoMagic(Hero h, uint _strength);
    }

    class BottleWithLiveWater : Artifact
    {
        public Bottle btBottle { set; private get; }

        public override void DoMagic()
        {
            if ((uint)btBottle + this.currentHealth >= this.maxHealth)
                this.currentHealth = this.maxHealth;
            else
                this.currentHealth += (uint)btBottle;
            btBottle = Bottle.Zero;
        }

        public override void DoMagic(Hero h, uint _strength)
        {
            if ((uint)btBottle + h.currentHealth >= h.maxHealth)
                h.currentHealth = h.maxHealth;
            else
                h.currentHealth += (uint)btBottle;
            btBottle = Bottle.Zero;
        }
    }

    class BottleWithDeadWater : Artifact
    {
        public Bottle btBottle { set; private get; }

        public override void DoMagic()
        {
            if (this is Wizard)
            {
                da(this as Wizard);
            }
        }

        public override void DoMagic(Hero h, uint _strength)
        {
            if (h is Wizard)
            {
                da(h as Wizard);
            }
        }

        private void da(Wizard w)
        {
            if ((uint)btBottle + w.сurrentMana >= w.maxMana)
                w.сurrentMana = w.maxMana;
            else
                w.сurrentMana += (uint)btBottle;
            btBottle = Bottle.Zero;
        }
    }

    class Staff : Artifact
    {
        Staff(uint s)
        {
            strength = s;
        }

        public override void DoMagic()
        {
            throw new NotImplementedException();
        }

        public override void DoMagic(Hero h, uint _strength)
        {
            //проерка на жизни, мощность и использывани
            if (strength > 0)
            {
                h.currentHealth -= _strength;
                strength -= _strength;
            }
        }
    }

    class Decoction : Artifact
    {
        public override void DoMagic()
        {
            throw new NotImplementedException();
        }

        public override void DoMagic(Hero h, uint _strength)
        {
            h.condition = Condition.Normal;
        }
    }

    class PoisonousSaliva : Artifact
    {
        PoisonousSaliva(uint s)
        {
            strength = s;
        }

        public override void DoMagic()
        {
            throw new NotImplementedException();
        }

        public override void DoMagic(Hero h, uint _strength = 0)
        {
            h.currentHealth -= strength;
            h.condition = Condition.Poisoned;
        }
    }

    class BasiliskEye : Artifact
    {
        public override void DoMagic()
        {
            throw new NotImplementedException();
        }

        public override void DoMagic(Hero h, uint _strength)
        {
            if (h.condition != Condition.Dead)
                h.condition = Condition.Paralyzed;
        }
    }
}
