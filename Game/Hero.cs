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
        // поля
        private static uint nextID = 1;
        private string _name;//не изменяющ
        private uint _ID;//не изменяющ
        private Condition _condition;
        private bool isSpeaking;
        private bool isMoving;
        private Race _race;//не изменяющ
        private Gender _gender;//не изменяющ
        private uint _age;
        private uint _maxHealth;
        private uint _currentHealth;
        private uint _experience;

        //св-ва  
        public string name { get { return _name; } private set { _name = value; } }

        public uint ID { get { return _ID; } private set { _ID = value; } }

        public Condition condition
        {
            get
            {
                return _condition;
            }
            set
            {
                _condition = value;
            }
        }

        public Race race { get { return _race; } set { _race = value; } }

        public Gender gender { get { return _gender; } private set { _gender = value; } }

        public uint age { get { return _age; } set { _age = value; } }

        public uint maxHealth { get { return _maxHealth; } set { _maxHealth = value; } }

        public uint currentHealth
        {
            get
            {
                return _currentHealth;
            }
            set
            {
                _currentHealth = value;
                check();
            }
        }

        public uint experience { get { return _experience; } set { _experience = value; } }

        //Методы
        public Hero(string aname, Race arace, Gender agender)
        {
            ID = nextID++;
            name = aname;
            race = arace;
            gender = agender;
        }

        public override string ToString()
        {
            return "Hero: " + name + " " + age + " " + race + " " + condition + " " + ID;
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

        //состояние
        private void check()
        {
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
    }

    class Wizard : Hero
    {
        // поля
        private uint _maxMana;
        private uint _currentMana;

        //св-ва
        public uint MaxMana { get { return _maxMana; } set { _maxMana = value; } }

        public uint CurrentMana { get { return _currentMana; } set { _currentMana = value; } }

        //методы
        public Wizard(string aname, Race arace, Gender agender) : base(aname, arace, agender)
        {
        }

        public void AddHealth(Hero obj)
        {
            //int addingHealth = CurrentMana / 2;
            if (this.CurrentMana / 2 + obj.currentHealth <= obj.maxHealth)
            {
                obj.currentHealth += this.CurrentMana / 2;
                this.CurrentMana -= this.CurrentMana / 2 * 2;
            }
            else
            {
                uint tmp = (obj.maxHealth - obj.currentHealth) / 2;
                this.CurrentMana -= tmp * 2;
                obj.currentHealth = obj.maxHealth;
            }
        }
    }

}
