using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RydiaSoft.Randomizer;
using RydiaSoft.Randomizer.Tests;

namespace RydiaSoft.Randomizer.Tests
{
    public class SFMT1279Tests : RandomBaseTests
    {
        protected override RandomBase CreateRandomBase()
        {
            return new SimdOrientedFastMersenneTwister(Seed, MTPeriodType.MT1279);
        }

        protected override RandomItem CreateRandomItem()
        {
            return new RandomItem(DotNetRandomAdapter.SimdOrientedFastMersenneTwister1279Factory, "SimdOrientedFastMersenneTwister1279");
        }
    }
}
