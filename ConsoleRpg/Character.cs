using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleRpg
{
    public class Character : Entity
    {
        public override void Hit(List<Entity> enemies)
        {
            if (enemies == null)
            {
                return;
            }

            List<Entity> aliveEnemies = enemies.Where(enemy => enemy.IsAlive).ToList();

            for (int i = 0; i < aliveEnemies.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                aliveEnemies[i].Introduce();
            }

            Console.WriteLine("Who do you want to hit?");
            int enemySelection = SelectEnemy(aliveEnemies.Count);

            
            Console.WriteLine("Do you want to use special ability? Y/N");
            bool isSpecialAbility = IsSpecialAbility();
            
            Hit(aliveEnemies[enemySelection - 1], isSpecialAbility);
        }

        public override void UseSpecialAbility(Entity entity)
        {
            if (Mana >= 5)
            {
                Mana -= 5;
                entity.Hp -= SpecialAbilityDmg;
                Console.WriteLine($"{Name} hit enemy with special ability dealing {SpecialAbilityDmg}");
            }
            else
            {
                Console.WriteLine($"{Name} doesn't have enough mana to use special ability");
            }
        }

        private int SelectEnemy(int selectionLimit)
        {
            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > selectionLimit)
            {
                Console.WriteLine("Select again...");
            }

            return selection;
        }

        private bool IsSpecialAbility()
        {
            char selection;
            while (!char.TryParse(Console.ReadLine(), out selection) || selection != 'Y' && selection != 'N')
            {
                Console.WriteLine("Select again...");
            }

            return selection == 'Y';
        }
    }
}