using System;
using System.Linq;

namespace ConsoleRpg
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext();

            foreach (Character character in dataContext.Characters)
            {
                character.Introduce();
            }

            foreach (Character enemy in dataContext.Enemies)
            {
                enemy.Introduce();
            }


            while (dataContext.Characters.Any(character => character.IsAlive)
                && dataContext.Enemies.Any(enemy => enemy.IsAlive))
            {
                foreach (Character character in dataContext.Characters)
                {
                    character.Hit(dataContext.Enemies);
                }
                Console.WriteLine();

                foreach (Character enemy in dataContext.Enemies)
                {
                    enemy.Hit(dataContext.Characters);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
