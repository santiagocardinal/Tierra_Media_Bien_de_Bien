using System;
using System.Collections.Generic;
using System.IO.Pipes;

namespace Program
{
    public class Elf : GoodGuy
    {
        public Elf(string name, int amountLife, int initialLife) : base(name, amountLife, initialLife)
        {
        }
    }
}
