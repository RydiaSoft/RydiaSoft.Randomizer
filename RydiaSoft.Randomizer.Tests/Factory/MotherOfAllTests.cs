﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RydiaSoft.Randomizer;
using RydiaSoft.Randomizer.Tests;

namespace RydiaSoft.Randomizer.Tests
{
    public class MotherOfAllTests : RandomBaseTests
    {
        protected override RandomBase CreateRandomBase()
        {
            return new MotherOfAll(Seed);
        }

        protected override RandomItem CreateRandomItem()
        {
            return new RandomItem(DotNetRandomAdapter.MotherOfAllFactory, "MotherOfAll");
        }
    }
}
