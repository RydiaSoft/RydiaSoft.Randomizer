using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RydiaSoft.Randomizer;
using RydiaSoft.Randomizer.Tests;

namespace RydiaSoft.Randomizer.Tests
{
    public class XorshiftTests : RandomBaseTests
    {
        protected override RandomBase CreateRandomBase()
        {
            return new XorShift(Seed);
        }

        protected override RandomItem CreateRandomItem()
        {
            return new RandomItem(DotNetRandomAdapter.XorshiftFactory, "Xorshift");
        }
    }
}
