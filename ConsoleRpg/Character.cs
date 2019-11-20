using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleRpg
{
    class Character
    {
        public string Name { get; set; }
        public int Dmg { get; set; }
        public int Hp { get; set; }
        public bool IsAlive
        {
            get
            {
                return Hp > 0;
            }
        }

        public void Introduce()
        {
            Console.WriteLine($"Hi, my name is {Name}. My dmg is {Dmg} and my hp is {Hp}.");
        }

        public void GetHit(int dmg, bool isEnemyAlive, string enemyName)
        {
            if (isEnemyAlive)
            {
                Hp -= dmg;
                Console.WriteLine($"{Name} got hit for {dmg} dmg. My hp is at {Hp} and am I alive? {IsAlive}.");
            }
            else
            {
                Console.WriteLine($"Enemy named {enemyName} tried to attack me, but he's dead already. My hp is still at {Hp}.");
            }
        }

        public void GetHit(Character enemy)
        {
            if (enemy.IsAlive)
            {
                Hp -= enemy.Dmg;
                Console.WriteLine($"{Name} got hit for {enemy.Dmg} dmg. My hp is at {Hp} and am I alive? {IsAlive}.");
            }
            else
            {
                Console.WriteLine($"Enemy named {enemy.Name} tried to attack me, but he's dead already. My hp is still at {Hp}.");
            }
        }

        public void Hit(List<Character> enemies)
        {
            Character enemy = enemies.FirstOrDefault(character => character.IsAlive);

            if (enemy == null)
            {
                Console.WriteLine($"All enemies of {Name} are dead.");
                return;
            }

            if (IsAlive)
            {
                enemy.Hp -= Dmg;
                Console.WriteLine($"{Name} attacked {enemy.Name} dealing {Dmg}. {enemy.Name} hp is now at {enemy.Hp}");
            }
            else
            {
                Console.WriteLine($"{Name} tried to attack {enemy.Name}, but {Name} is already dead.");
            }
        }
    }
}
