using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RydiaSoft.Randomizer;
using RydiaSoft.Randomizer.Tests;

namespace RydiaSoft.Randomizer.Tests
{
    public class SFMT607Tests : RandomBaseTests
    {
        protected override RandomBase CreateRandomBase()
        {
            return new SimdOrientedFastMersenneTwister(Seed, MTPeriodType.MT607);
        }

        protected override RandomItem CreateRandomItem()
        {
            return new RandomItem(DotNetRandomAdapter.SimdOrientedFastMersenneTwister607Factory, "SimdOrientedFastMersenneTwister607");
        }
    }
}
