using System.Collections.Generic;

namespace ConsoleRpg
{
    class DataContext
    {
        public List<Character> Characters { get; set; }
        public List<Character> Enemies { get; set; }

        public DataContext()
        {
            Characters = new List<Character>
            {
                new Character
                {
                    Name = "Snooking",
                    Dmg = 4,
                    Hp = 14
                },
                new Character
                {
                    Name = "Huzdy",
                    Dmg = 5,
                    Hp = 11
                }
            };

            Enemies = new List<Character>
            {
                new Character
                {
                    Name = "zombie",
                    Dmg = 3,
                    Hp = 9
                },
                new Character
                {
                    Name = "skeleton",
                    Dmg = 2,
                    Hp = 11
                }
            };
        }
    }
}
