using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RydiaSoft.Randomizer;
using RydiaSoft.Randomizer.Tests;

namespace RydiaSoft.Randomizer.Tests
{
    public class SFMT19937Tests : RandomBaseTests
    {
        protected override RandomBase CreateRandomBase()
        {
            return new SimdOrientedFastMersenneTwister(Seed, MTPeriodType.MT19937);
        }

        protected override RandomItem CreateRandomItem()
        {
            return new RandomItem(DotNetRandomAdapter.SimdOrientedFastMersenneTwister19937Factory, "SimdOrientedFastMersenneTwister19937");
        }
    }
}
