using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleRpg
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public int Dmg { get; set; }
        public int Hp { get; set; }
        public int Mana { get; set; }

        public int SpecialAbilityDmg
        {
            get { return Dmg + 3; }
        }

        public bool IsAlive
        {
            get { return Hp > 0; }
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
                Console.WriteLine(
                    $"Enemy named {enemyName} tried to attack me, but he's dead already. My hp is still at {Hp}.");
            }
        }

        public void GetHit(Entity enemy)
        {
            if (enemy.IsAlive)
            {
                Hp -= enemy.Dmg;
                Console.WriteLine($"{Name} got hit for {enemy.Dmg} dmg. My hp is at {Hp} and am I alive? {IsAlive}.");
            }
            else
            {
                Console.WriteLine(
                    $"Enemy named {enemy.Name} tried to attack me, but he's dead already. My hp is still at {Hp}.");
            }
        }

        public virtual void Hit(List<Entity> enemies)
        {
            Entity enemy = enemies.FirstOrDefault(character => character.IsAlive);

            if (enemy == null)
            {
                Console.WriteLine($"All enemies of {Name} are dead.");
            }
            else
            {
                Hit(enemy);
            }
        }

        protected void Hit(Entity entity, bool isSpecialAbility = false)
        {
            if (IsAlive)
            {
                if (isSpecialAbility)
                {
                    UseSpecialAbility(entity);
                }
                else
                {
                    entity.Hp -= Dmg;
                    Console.WriteLine(
                        $"{Name} attacked {entity.Name} dealing {Dmg}. {entity.Name} hp is now at {entity.Hp}");
                }
            }
            else
            {
                Console.WriteLine($"{Name} tried to attack {entity.Name}, but {Name} is already dead.");
            }
        }

        public virtual void UseSpecialAbility(Entity entity)
        {
            Console.WriteLine($"{Name} doesn't have any special ability.");
        }
    }
}