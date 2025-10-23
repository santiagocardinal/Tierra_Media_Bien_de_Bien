using System;
using System.Collections.Generic;
using System.IO.Pipes;

namespace Library
{
    public class Elf : GoodGuy
    {
        public Elf(string name, int amountLife, int initialLife) : base(name, amountLife, initialLife)
        {
        }
    }
}
