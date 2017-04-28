using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Game
{
     enum Gender { Male, Female };
    enum Condition { Normal, Weakened, Sick, Poisoned, Paralyzed, Dead };
    enum Race { Human, Gnome, Elf, Orc, Goblin };

    class Hero : IComparable
    {
        private static uint nextID = 1;

        // поля
        private readonly uint _ID;//не изменяющ
        private readonly string _name;//не изменяющ
        private Condition _condition;
        private bool isSpeaking;
        private bool isMoving;
        private readonly Race _race;//не изменяющ
        private readonly Gender _gender;//не изменяющ
        private uint _age;
        private uint _maxHealth;
        private uint _currentHealth;
        private uint _experience;
        public List<Artifact> inventory = new List<Artifact>();


        //св-ва  
        public string name { get { return _name; } }

        public uint ID { get { return _ID; } }

        public Race race { get { return _race; } }

        public Gender gender { get { return _gender; } }

        public uint age { get { return _age; } set { _age = value; } }

        public uint maxHealth { get { return _maxHealth; } set { _maxHealth = value; } }

        public uint experience { get { return _experience; } set { _experience = value; } }

        public Condition condition
        {
            get
            {
                return _condition;
            }
            set
            {
                if (condition != Condition.Dead)
                    _condition = value;
            }
        }

        public uint currentHealth
        {
            get
            {
                return _currentHealth;
            }
            set
            {
                _currentHealth = value;
                CheckHealth();
            }
        }

        //конструктор
        public Hero(string aname, Race arace, Gender agender)
        {
            _ID = nextID++;
            _name = aname;
            _race = arace;
            _gender = agender;
        }

        //Методы
        public override string ToString()
        {
            return "Hero: " + name + " " + age + " " + race + " " + condition + " " + ID; // я бы выводила айди вначале 
        }

        public int CompareTo(object obj)
        {
            if (obj is Hero)
            {
                Hero h = (Hero)obj;
                return experience.CompareTo(h.experience);
            }
            throw new ArgumentException("Object is not a Hero");
        }

        private void CheckHealth()
        {
            if (condition != Condition.Poisoned || condition != Condition.Paralyzed || condition != Condition.Sick)
                if (currentHealth == 0)
                {
                    condition = Condition.Dead;
                }
                else if (1.0 * currentHealth / maxHealth < 0.1)
                {
                    condition = Condition.Weakened;
                }
                else
                {
                    condition = Condition.Normal;
                }
        }
        //состояние

        public void AddToInventory(Artifact a)
        {
            inventory.Add(a);
        }

        public void ThrowArtifact(Artifact a)
        {
            inventory.Remove(a);
        }

        public void TransferArtifact(Artifact a, Hero h)
        {
            inventory.Remove(a);
            h.inventory.Add(a);
        }

        public void UseArtifact(Artifact a)
        {
            UseArtifact(a, this);
            //if (inventory.Contains(a))
            //{
            //    if (a.DoMagic())
            //        inventory.Remove(a);
            //}
            //else
            //    Console.WriteLine("Не использован");
        }

        public void UseArtifact(Artifact a, Hero h, uint st = 0)
        {
            if (inventory.Contains(a))
            {
                if (!a.DoMagic(h, st))
                    inventory.Remove(a);
            }
            else
                Console.WriteLine("Не использован");
        }

    }

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
                uint tmp = (obj.maxHealth - obj.currentHealth) / 2;  // тут вроде как делить на два не надо.
                this.сurrentMana -= tmp * 2;
                obj.currentHealth = obj.maxHealth;
            }
        }
        
        //public void AddHealth()
        //{
        //    AddHealth(this);
        //}

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
            s.DoMagic(h);
        }
    }
}
