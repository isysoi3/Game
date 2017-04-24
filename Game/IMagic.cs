using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IMagic
    {
        // a нужен ли этот метод?
        bool DoMagic();
        bool DoMagic(Hero h = null, uint _strength = 0);
    }

    enum Bottle { Small = 10, Medium = 25, Large = 50 };

    abstract class Spell : IMagic
    {
        private uint _minMana;
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

        public uint minMana
        {
            get
            {
                return _minMana;
            }
            set { _minMana = value; }
        }

        abstract public bool DoMagic();
        abstract public bool DoMagic(Hero h, uint _strength = 0);
    }

    //class AddHealh : Spell
    //{
    //    public override bool DoMagic()
    //    {

    //    }

    //    public override bool DoMagic(Hero h, uint _strength)
    //    {

    //    }
    //}

    class Heal : Spell
    {
        public Heal()
        {
            minMana = 20;
        }

        public override bool DoMagic()
        {
            //if (сurrentMana > minMana)
            //{
            //    tcondition = Condition.Normal;
            //    this.сurrentMana -= minMana;
            //}
            return false;
        }

        public override bool DoMagic(Hero h, uint _strength)
        {
            //исправить
            if ((h as Wizard).сurrentMana >= minMana)
            {
                //h.condition = Condition.Normal;
                h.currentHealth = h.currentHealth;
                (h as Wizard).сurrentMana -= minMana;
            }
            return true;
        }
    }

    class Antidote : Spell
    {
        public Antidote()
        {
            minMana = 30;
        }

        public override bool DoMagic()
        {
            //if (this.сurrentMana > minMana)
            //{
            //    this.condition = Condition.Normal;
            //    this.сurrentMana -= minMana;
            //}
            return true;
        }

        public override bool DoMagic(Hero h, uint _strength = 0)
        {
            if ((h as Wizard).сurrentMana >= minMana)
            {
                h.condition = Condition.Normal;
                h.currentHealth = h.currentHealth;
                (h as Wizard).сurrentMana -= minMana;
            }
            return true;
        }
    }

    class Animate : Spell
    {
        Animate()
        {
            minMana = 150;
        }

        public override bool DoMagic()
        {
            throw new NotImplementedException();
        }

        public override bool DoMagic(Hero h, uint _strength = 0)
        {
            if ((h as Wizard).сurrentMana >= minMana && h.condition == Condition.Dead)
            {
                h.condition = Condition.Normal;
                h.currentHealth = 1;
                (h as Wizard).сurrentMana -= minMana;
            }
            return true;
        }
    }

    //class Armor : Spell
    //{
    //    Armor()
    //    {
    //        minMana = 50;
    //    }

    //    public override bool DoMagic()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool DoMagic(Hero h, uint _strength = 0)
    //    {
    //        if (this.сurrentMana >= minMana)
    //        {
    //            //TODO
    //            this.сurrentMana -= minMana;
    //        }
    //    }
    //}

    class TakeOff : Spell
    {
        TakeOff()
        {
            minMana = 85;
        }

        public override bool DoMagic()
        {
            throw new NotImplementedException();
        }

        public override bool DoMagic(Hero h, uint _strength = 0)
        {
            if ((h as Wizard).сurrentMana >= minMana)
            {
                //TODO
                h.condition = Condition.Normal;
                h.currentHealth = 1;
                (h as Wizard).сurrentMana -= minMana;
            }
            return true;
        }
    }


    /////////////////////////////////////////

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

        abstract public bool DoMagic();

        abstract public bool DoMagic(Hero h, uint _strength = 0);
    }

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
