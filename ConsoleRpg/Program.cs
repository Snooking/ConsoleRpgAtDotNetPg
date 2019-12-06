using System;
using System.Collections;
using System.Linq;

namespace ConsoleRpg
{
    class Program
    {
        public static DataContext DataContext { get; set; } = new DataContext();

        static void Main(string[] args)
        {
            foreach (var entity in DataContext.Characters.Concat(DataContext.Enemies))
            {
                entity.Introduce();
            }

            bool IsAnyCharacterAndEnemyAlive() => DataContext.Characters.Any(character => character.IsAlive)
                                                  && DataContext.Enemies.Any(enemy => enemy.IsAlive);


            while (IsAnyCharacterAndEnemyAlive())
            {
                foreach (Character character in DataContext.Characters)
                {
                    character.ChooseAction();
                }
                Console.WriteLine();

                foreach (Entity enemy in DataContext.Enemies)
                {
                    enemy.Hit(DataContext.Characters);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
