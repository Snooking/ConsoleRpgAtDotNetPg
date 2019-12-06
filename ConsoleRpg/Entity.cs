using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleRpg
{
    class Entity
    {
        public IEnumerable<Item> ItemBag { get; set; } = new List<Item>();
        public IWeapon EquippedWeapon { get; set; }

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

        

        public virtual void Hit(List<Entity> enemies)
        {
            Entity enemy = enemies.FirstOrDefault(character => character.IsAlive);

            if (enemy == null)
            {
                Console.WriteLine($"All enemies of {Name} are dead.");
                return;
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
                    int damageDealt;
                    if (EquippedWeapon != null)
                    {
                        damageDealt = Dmg + EquippedWeapon.DmgBonus;
                    }
                    else
                    {
                        damageDealt = Dmg;
                    }

                    entity.Hp -= damageDealt;
                    Console.WriteLine($"{Name} attacked {entity.Name} dealing {damageDealt}. " +
                                      $"{entity.Name} hp is now at {entity.Hp}");

                }
            }
            else
            {
                Console.WriteLine($"{Name} tried to attack {entity.Name}, but {Name} is already dead.");
            }
        }

        public virtual void UseSpecialAbility(Entity entity)
        {
            Console.WriteLine($"{Name} doesn't have any special ability...");
        }
    }
}
