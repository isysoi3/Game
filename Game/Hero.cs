using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    enum Gender{ male, female };

    enum Race{ human, gnome };


    class Hero
    {
        public static uint ID = 0;
        private string name;
        //состояние, возможность разговаривать, двигаться, раса,пол
        private int age;
        private int maxHealth;
        private int currentHealth;
        private int experience;
    }
}
