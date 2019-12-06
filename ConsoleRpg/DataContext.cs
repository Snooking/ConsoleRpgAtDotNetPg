using System.Collections.Generic;

namespace ConsoleRpg
{
    class DataContext
    {
        public List<Entity> Characters { get; set; }
        public List<Entity> Enemies { get; set; }

        public DataContext()
        {
            Characters = new List<Entity>
            {
                new Character
                {
                    Name = "Snooking",
                    Dmg = 4,
                    Hp = 14,
                    Mana = 10,
                    EquippedWeapon = new Weapon{ DmgBonus = 3},
                    DataContext = this,
                    ItemBag = new []
                    {
                        new Potion{HpRestored = 3, ManaRestored = 0},
                        new Potion{HpRestored = 3, ManaRestored = 2},
                        new Potion{HpRestored = 3, ManaRestored = 1}
                    }
                },
                new Character
                {
                    Name = "Huzdy",
                    Dmg = 5,
                    Hp = 11,
                    Mana = 8,
                    DataContext = this
                }
            };

            Enemies = new List<Entity>
            {
                new Enemy
                {
                    Name = "zombie",
                    Dmg = 3,
                    Hp = 9
                },
                new Enemy
                {
                    Name = "skeleton",
                    Dmg = 2,
                    Hp = 11,
                    EquippedWeapon = new Weapon{ DmgBonus = 3 }
                }
            };
        }
    }
}
