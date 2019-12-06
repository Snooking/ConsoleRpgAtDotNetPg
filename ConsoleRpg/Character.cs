using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleRpg
{
    class Character : Entity
    {
        public DataContext DataContext { get; set; }
        public int Mana { get; set; }
        public int SpecialAbilityDmg
        {
            get => Dmg + 3;
        }

        public void ChooseAction()
        {
            Console.WriteLine($"{Name}: What should I do?");

            Console.WriteLine("1. Use an item");
            Console.WriteLine("2. Attack someone");

            char choice;
            bool TryGetChoice() => char.TryParse(Console.ReadLine(), out choice)
                                   && (choice == '1' || choice == '2');

            while (!TryGetChoice())
            {
                Console.WriteLine("You had one job...");
            }

            switch (choice)
            {
                case '1':
                    var item = SelectItem();
                    if (item is ICharacterUsable usable)
                    {
                        usable.Use(this);
                        Console.WriteLine($"You've just used {usable.ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("The item you've selected cannot be used");
                    }
                    break;
                case '2':
                    Hit(DataContext.Enemies);
                    break;
            }
        }

        private Item SelectItem()
        {
            int i = 0;
            foreach (var item in ItemBag)
            {
                Console.WriteLine($"{i++}.{item.ToString()}");
            }

            Console.WriteLine("Please choose an item");
            int choice;
            bool TryGetChoice() => int.TryParse(Console.ReadLine(), out choice) && choice < i && choice >= 0;

            while (!TryGetChoice())
            {
                Console.WriteLine("Please select one of your items");
            }

            return ItemBag.ElementAt(choice);
        }

        public override void Hit(List<Entity> enemies)
        {
            if (enemies == null)
            {
                Console.WriteLine($"All enemies of {Name} are dead.");
                return;
            }
            List<Entity> aliveEnemies = enemies.Where(enemy => enemy.IsAlive).ToList();

            if (aliveEnemies.Any())
            {
                for (int i = 0; i < aliveEnemies.Count; i++)
                {
                    Console.Write($"{i + 1}. ");
                    aliveEnemies[i].Introduce();
                }

                int enemySelection = SelectEnemy(aliveEnemies.Count);

                bool isSpecialAbility = IsSpecialAbility();

                Hit(aliveEnemies[enemySelection - 1], isSpecialAbility);
            }
        }

        private int SelectEnemy(int enemiesCount)
        {
            Console.WriteLine("Who do you want to hit?");

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > enemiesCount)
            {
                Console.WriteLine("Select again...");
            }

            return selection;
        }


        public override void UseSpecialAbility(Entity enemy)
        {
            if (Mana >= 5)
            {
                Mana -= 5;
                enemy.Hp -= SpecialAbilityDmg;
                Console.WriteLine($"{Name} hit enemy  with special ability " +
                                  $"dealing {SpecialAbilityDmg}");
            }
            else
            {
                Console.WriteLine($"{Name} doesn't have enough mana to use special ability");
            }
        }

        private bool IsSpecialAbility()
        {
            Console.WriteLine("Do you want to use special ability? Y/N");
            char selection;

            while (!char.TryParse(Console.ReadLine(), out selection)
                   || selection != 'Y'
                   && selection != 'N')
            {
                Console.WriteLine("Select again...");
            }

            return selection == 'Y';
        }
    }
}
