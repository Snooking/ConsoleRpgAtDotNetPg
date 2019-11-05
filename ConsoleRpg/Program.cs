using System;

namespace ConsoleRpg
{
    class Program
    {
        static void Main(string[] args)
        {
            Character me = new Character
            {
                Name = "Snooking",
                Dmg = 4,
                Hp = 14
            };

            Character enemy = new Character
            {
                Name = "zombie",
                Dmg = 3,
                Hp = 9
            };

            me.Introduce();
            enemy.Introduce();

            while (me.IsAlive && enemy.IsAlive)
            {
                enemy.GetHit(me);
                me.GetHit(enemy);
            }

            Console.ReadLine();
        }
    }
}
