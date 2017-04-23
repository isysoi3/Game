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
        private static uint nextID = 1;//не изменяющ
        public string name { get; }//не изменяющ
        public uint ID { get; }
        public Condition condition;
        public bool isSpeaking;
        public bool isMoving;
        public Race race { get; }//не изменяющ
        public Gender gender { get; }//не изменяющ
        public int age;
        public int maxHealth;
        public int currentHealth;
        public int experience { get; set; }

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
    }
}
