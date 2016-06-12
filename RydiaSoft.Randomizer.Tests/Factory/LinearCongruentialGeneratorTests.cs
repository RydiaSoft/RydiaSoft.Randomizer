using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RydiaSoft.Randomizer;
using RydiaSoft.Randomizer.Tests;

namespace RydiaSoft.Randomizer.Tests
{
    public class LinearCongruentialGeneratorTests : RandomBaseTests
    {

        /// <summary>
        /// テスト対象のRandomBase派生クラスを作成して返します
        /// </summary>
        /// <returns></returns>
        protected override RandomBase CreateRandomBase()
        {
            return new LinearCongruentialGenerator(Seed);
        }

        protected override RandomItem CreateRandomItem()
        {
            return new RandomItem(DotNetRandomAdapter.LinearCongruentialGeneratorFactory, "LinearCongruentialGenerator");
        }

    }
}
