using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RydiaSoft.Randomizer;
using RydiaSoft.Randomizer.Tests;

namespace RydiaSoft.Randomizer.Tests
{
    public class SFMT86243Tests : RandomBaseTests
    {
        protected override RandomBase CreateRandomBase()
        {
            return new SimdOrientedFastMersenneTwister(Seed, MTPeriodType.MT86243);
        }

        protected override RandomItem CreateRandomItem()
        {
            return new RandomItem(DotNetRandomAdapter.SimdOrientedFastMersenneTwister86243Factory, "SimdOrientedFastMersenneTwister86243");
        }
    }
}
