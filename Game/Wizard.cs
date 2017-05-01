using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Wizard : Hero
    {
        // поля
        private uint _maxMana;
        private uint _сurrentMana;
        private HashSet<Spell> spells = new HashSet<Spell>();

        public uint maxMana { get { return _maxMana; } set { _maxMana = value; } }

        public uint сurrentMana { get { return _сurrentMana; } set { _сurrentMana = value; } }

        public Wizard(string aname, Race arace, Gender agender) : base(aname, arace, agender)
        {
        }

        public void AddHealth()
        {
            AddHealth(this);
        }

        public void AddHealth(Hero obj)
        {
            //int addingHealth = сurrentMana / 2;
            if (this.сurrentMana / 2 + obj.currentHealth <= obj.maxHealth)
            {
                obj.currentHealth += this.сurrentMana / 2;
                this.сurrentMana -= this.сurrentMana / 2 * 2;
            }
            else
            {
                uint tmp = (obj.maxHealth - obj.currentHealth);  // тут вроде как делить на два не надо.
                this.сurrentMana -= tmp * 2;
                obj.currentHealth = obj.maxHealth;
            }
        }

        public void LearnSpel(Spell s)
        {
            if (!spells.Add(s))
            {
                Console.WriteLine("Уже есть");
            }
        }

        public void ForgetSpel(Spell s)
        {
            if (!spells.Remove(s))
            {
                Console.WriteLine("Заклинания нет");
            }

        }

        public void CastSpell(Spell s)
        {
            CastSpell(s, this);
        }

        public void CastSpell(Spell s, Hero h)
        {
            // исправить магию
            s.DoMagic(this, h);
        }
    }

}
