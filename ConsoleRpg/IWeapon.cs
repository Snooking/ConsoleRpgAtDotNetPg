using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRpg
{
    interface IWeapon
    {
        int DmgBonus { get; set; }
    }

    class Weapon : IWeapon
    {
        public int DmgBonus { get; set; }
    }
}
