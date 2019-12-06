using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRpg
{
    abstract class Item
    {
        public int Value { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"Item weighting {Weight} and valued {Value}";
        }
    }
}
