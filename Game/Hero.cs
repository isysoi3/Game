using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Game
{
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
        private int _currentHealth;
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
        public int currentHealth { get { return _currentHealth; } set { _currentHealth = value; } }
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
    }


    class Wizard : Hero
    {
        // поля
        private uint _maxMana;
        private int _currentMana;


        public uint maxMana { get { return _maxMana; } set { _maxMana = value; } }
        public int CurrentMana { get { return _currentMana; } set { _currentMana = value; } }

        public Wizard(string aname, Race arace, Gender agender) : base(aname, arace, agender)
        {
        }

        public void AddHealth()
        {
            int addingHealth = CurrentMana / 2;
            if (addingHealth + currentHealth <= maxHealth)
            {
                currentHealth += addingHealth;
                CurrentMana -= addingHealth * 2;
            }
            else
            {

            }

        }

    }
}
