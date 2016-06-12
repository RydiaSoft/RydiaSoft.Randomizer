using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RydiaSoft.Randomizer.Tests
{
    class Program
    {
        static void Main(string[] args)
        {

            //！デバッグ構成だと遅いです！
#if !DEBUG
            var list = new List<RandomItem>();
            list.Add(new RandomItem((seed) => { return new Random(seed); }, "System.Random"));
            list.Add(new RandomItem(DotNetRandomAdapter.LinearCongruentialGeneratorFactory, "LinearCongruentialGenerator"));
            list.Add(new RandomItem(DotNetRandomAdapter.MotherOfAllFactory, "MotherOfAll"));
            list.Add(new RandomItem(DotNetRandomAdapter.MersenneTwisterFactory, "MersenneTwister"));
            list.Add(new RandomItem(DotNetRandomAdapter.XorshiftFactory, "Xorshift"));
            list.Add(new RandomItem(DotNetRandomAdapter.WellFactory, "Well"));
            list.Add(new RandomItem(DotNetRandomAdapter.RanrotBFactory, "RanrotB"));
            list.Add(new RandomItem(DotNetRandomAdapter.SimdOrientedFastMersenneTwister607Factory, "SimdOrientedFastMersenneTwister607"));
            list.Add(new RandomItem(DotNetRandomAdapter.SimdOrientedFastMersenneTwister1279Factory, "SimdOrientedFastMersenneTwister1279"));
            list.Add(new RandomItem(DotNetRandomAdapter.SimdOrientedFastMersenneTwister2281Factory, "SimdOrientedFastMersenneTwister2281"));
            list.Add(new RandomItem(DotNetRandomAdapter.SimdOrientedFastMersenneTwister4253Factory, "SimdOrientedFastMersenneTwister4253"));
            list.Add(new RandomItem(DotNetRandomAdapter.SimdOrientedFastMersenneTwister11213Factory, "SimdOrientedFastMersenneTwister11213"));
            list.Add(new RandomItem(DotNetRandomAdapter.SimdOrientedFastMersenneTwister19937Factory, "SimdOrientedFastMersenneTwister19937"));
            list.Add(new RandomItem(DotNetRandomAdapter.SimdOrientedFastMersenneTwister44497Factory, "SimdOrientedFastMersenneTwister44497"));
            list.Add(new RandomItem(DotNetRandomAdapter.SimdOrientedFastMersenneTwister86243Factory, "SimdOrientedFastMersenneTwister86243"));
            list.Add(new RandomItem(DotNetRandomAdapter.SimdOrientedFastMersenneTwister132049Factory, "SimdOrientedFastMersenneTwister132049"));
            list.Add(new RandomItem(DotNetRandomAdapter.SimdOrientedFastMersenneTwister216091Factory, "SimdOrientedFastMersenneTwister216091"));

            list.ForEach(r => r.Dump());
            list.ForEach(r => r.TimeAttack());

            Console.ReadKey();
#endif

        }
    }
}
