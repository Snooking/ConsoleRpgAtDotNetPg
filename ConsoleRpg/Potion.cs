
namespace ConsoleRpg
{
    class Potion : Item, ICharacterUsable
    {
        public int HpRestored { get; set; }
        public int ManaRestored { get; set; }

        public void Use(Character user)
        {
            user.Hp += HpRestored;
            user.Mana += ManaRestored;
        }

        public override string ToString()
        {
            return $"Potion restoring {HpRestored}hp and {ManaRestored} mana";
        }
    }
}
