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
        bool DoMagic(Wizard w, Hero h = null, uint _strength = 0);
    }

    enum Bottle { Small = 10, Medium = 25, Large = 50 };

    //class AddHealh : Spell
    //{
    //    public override bool DoMagic()
    //    {

    //    }

    //    public override bool DoMagic(Hero h, uint _strength)
    //    {

    //    }
    //}

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

    /////////////////////////////////////////
}
