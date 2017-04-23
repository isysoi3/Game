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
        public string name { get; private set; }//не изменяющ
        public uint ID { get; private set; }
        public Condition condition;
        public bool isSpeaking;
        public bool isMoving;
        public Race race { get; private set; }//не изменяющ
        public Gender gender { get; private set; }//не изменяющ
        public int age;
        public int maxHealth;
        public int currentHealth;
        public int experience { get; private set; }

        public Hero(string aname, Race arace, Gender agender)
        {
            ID = nextID++;
            name = aname;
            race = arace;
            gender = agender;
        }

        public Hero Compare(Hero a, Hero b)
        {
            return a.experience.CompareTo(b.experience);
        }

        public override string ToString()
        {
            return "Hero: " + name + " " + age + " " + race + " " + condition + " ";
        }

    }
}
