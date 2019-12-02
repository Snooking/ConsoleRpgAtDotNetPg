using System;
using System.Linq;

namespace ConsoleRpg
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext();

            foreach (Entity character in dataContext.Characters)
            {
                character.Introduce();
            }

            foreach (Entity enemy in dataContext.Enemies)
            {
                enemy.Introduce();
            }

            while (dataContext.Characters.Any(character => character.IsAlive)
                && dataContext.Enemies.Any(enemy => enemy.IsAlive))
            {
                foreach (Entity character in dataContext.Characters)
                {
                    character.Hit(dataContext.Enemies);
                }
                Console.WriteLine();

                foreach (Entity enemy in dataContext.Enemies)
                {
                    enemy.Hit(dataContext.Characters);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
