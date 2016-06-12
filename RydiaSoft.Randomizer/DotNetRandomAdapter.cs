using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RydiaSoft.Randomizer
{
    /// <summary>
    /// <see cref="RandomBase"/>を継承する乱数ジェネレータークラスを<see cref="System.Random"/>クラス互換にするための
    /// アダプター機能を提供するクラスです
    /// </summary>
    /// <seealso cref="System.Random" />
    public class DotNetRandomAdapter : System.Random
    {
        /// <summary>
        /// 乱数ジェネレータを保持するフィールドです
        /// </summary>
        private RandomBase m_Orign;

        /// <summary>
        /// サンプル算出係数を表す定数
        /// </summary>
        private const double SampleValue = 4.6566128752457969E-10;


        #region コンストラクタ

        /// <summary>
        ///   <see cref="DotNetRandomAdapter"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="random">乱数ジェネレータのポインタ</param>
        public DotNetRandomAdapter(RandomBase random)
        {
            m_Orign = random;
        }

        #endregion
        
        #region ファクトリメソッド

        #region LinearCongruentialGenerator

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、<see cref="LinearCongruentialGenerator"/> classの新しいインスタンスを作成して返します
        /// </summary>
        /// <returns></returns>
        public static DotNetRandomAdapter LinearCongruentialGeneratorFactory()
        {
            return LinearCongruentialGeneratorFactory(Environment.TickCount);
        }

        /// <summary>
        /// 指定したシード値を使用して<see cref="LinearCongruentialGenerator"/> classの新しいインスタンスを作成して返します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static DotNetRandomAdapter LinearCongruentialGeneratorFactory(int seed)
        {
            return LinearCongruentialGeneratorFactory(seed, LinearCongruentialGenerator.DefaultParamA, LinearCongruentialGenerator.DefaultParamC);
        }

        /// <summary>
        /// 指定したパラメータを使用して<see cref="LinearCongruentialGenerator"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        /// <param name="paramA">LCGパラメータAを表す数値</param>
        /// <param name="paramC">LCGパラメータCを表す数値</param>
        public static DotNetRandomAdapter LinearCongruentialGeneratorFactory(int seed, uint paramA, uint paramC)
        {
            var orign = new LinearCongruentialGenerator(seed, paramA, paramC);
            return new DotNetRandomAdapter(orign);
        }

        #endregion

        #region MersenneTwister

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、<see cref="MersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        public static DotNetRandomAdapter MersenneTwisterFactory()
        {
            return MersenneTwisterFactory(Environment.TickCount);
        }

        /// <summary>
        /// 指定したシード値を使用して<see cref="MersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static DotNetRandomAdapter MersenneTwisterFactory(int seed)
        {
            return new DotNetRandomAdapter(new MersenneTwister(seed));
        }


        #endregion

        #region MotherOfAll()

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、<see cref="MotherOfAll"/> classの新しいインスタンスを初期化します
        /// </summary>
        public static DotNetRandomAdapter MotherOfAllFactory()
        {
            return MotherOfAllFactory(Environment.TickCount);
        }

        /// <summary>
        /// 指定したシード値を使用して<see cref="MotherOfAll"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static DotNetRandomAdapter MotherOfAllFactory(int seed)
        {
            return new DotNetRandomAdapter(new MotherOfAll(seed));
        }

        #endregion

        #region RanrotB

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、<see cref="RanrotB"/> classの新しいインスタンスを初期化します
        /// </summary>
        public static DotNetRandomAdapter RanrotBFactory()
        {
            return RanrotBFactory(Environment.TickCount);
        }

        /// <summary>
        /// 指定したシード値を使用して<see cref="RanrotB"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static DotNetRandomAdapter RanrotBFactory(int seed)
        {
            return new DotNetRandomAdapter(new RanrotB(seed));
        }

        #endregion

        #region SimdOrientedFastMersenneTwister

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、(2^19937-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        public static DotNetRandomAdapter SimdOrientedFastMersenneTwisterFactory()
        {
            return SimdOrientedFastMersenneTwister19937Factory(Environment.TickCount);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^607-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static DotNetRandomAdapter SimdOrientedFastMersenneTwister607Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT607);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^1279-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static DotNetRandomAdapter SimdOrientedFastMersenneTwister1279Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT1279);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^2281-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static DotNetRandomAdapter SimdOrientedFastMersenneTwister2281Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT2281);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^4253-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static DotNetRandomAdapter SimdOrientedFastMersenneTwister4253Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT4253);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^11213-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static DotNetRandomAdapter SimdOrientedFastMersenneTwister11213Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT11213);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^19937-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static DotNetRandomAdapter SimdOrientedFastMersenneTwister19937Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT19937);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^44497-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static DotNetRandomAdapter SimdOrientedFastMersenneTwister44497Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT44497);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^86243-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static DotNetRandomAdapter SimdOrientedFastMersenneTwister86243Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT86243);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^132049-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static DotNetRandomAdapter SimdOrientedFastMersenneTwister132049Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT132049);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^216091-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static DotNetRandomAdapter SimdOrientedFastMersenneTwister216091Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT216091);
        }

        /// <summary>
        /// 指定したシード値を使用し、指定されたフラグに基づく周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        /// <param name="period">周期を表すフラグ</param>
        public static DotNetRandomAdapter SimdOrientedFastMersenneTwisterFactory(int seed, MTPeriodType period)
        {
            return new DotNetRandomAdapter(new SimdOrientedFastMersenneTwister(seed, period));
        }

        #endregion

        #region Well

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、<see cref="Well"/> classの新しいインスタンスを初期化します
        /// </summary>
        public static DotNetRandomAdapter WellFactory()
        {
            return WellFactory(Environment.TickCount);
        }

        /// <summary>
        /// 指定したシード値を使用し、<see cref="Well"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static DotNetRandomAdapter WellFactory(int seed)
        {
            return new DotNetRandomAdapter(new Well(seed));
        }

        #endregion

        #region Xorshift

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、<see cref="XorShift"/> classの新しいインスタンスを初期化します
        /// </summary>
        public static DotNetRandomAdapter XorshiftFactory()
        {
            return XorshiftFactory(Environment.TickCount);
        }

        /// <summary>
        /// 指定したシード値を使用し、<see cref="XorShift"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static DotNetRandomAdapter XorshiftFactory(int seed)
        {
            return XorshiftFactory((uint)seed, XorShift.DefaultSeed2, XorShift.DefaultSeed3, XorShift.DefaultSeed4);
        }

        /// <summary>
        /// すべてのシードを指定して、<see cref="XorShift"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed1">擬似乱数系列の開始値を計算するために使用する数値。</param>
        /// <param name="seed2">擬似乱数系列の開始値を計算するために使用する数値。</param>
        /// <param name="seed3">擬似乱数系列の開始値を計算するために使用する数値。</param>
        /// <param name="seed4">擬似乱数系列の開始値を計算するために使用する数値。</param>
        public static DotNetRandomAdapter XorshiftFactory(uint seed1, uint seed2, uint seed3, uint seed4)
        {
            return new DotNetRandomAdapter(new XorShift(seed1, seed2, seed3, seed4));
        }


        #endregion

        #endregion

        #region 実装

        /// <summary>
        /// 0 以上のランダムな整数を返します。
        /// </summary>
        /// <returns>
        /// 0 以上で MaxValue より小さい 32 ビット符号付き整数。
        /// </returns>
        public override int Next()
        {
            uint rnd;
            do
                rnd = m_Orign.Generate() & 0x7FFFFFFF;
            while (rnd == int.MaxValue);
            return (int)rnd;
        }

        /// <summary>
        /// 指定した最大値より小さい 0 以上のランダムな整数を返します。
        /// </summary>
        /// <param name="maxValue">生成される乱数の排他的上限値。 maxValue は、0 以上である必要があります。</param>
        /// <returns>
        /// 0 以上で maxValue 未満の 32 ビット符号付き整数。
        /// つまり、戻り値の範囲に 0 は含まれますが、maxValue は含まれません。
        /// ただし、maxValue が 0 の場合は、maxValue が返されます。
        /// </returns>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">maxValueが0未満です。</exception>
        public override int Next(int maxValue)
        {
            return base.Next(maxValue);
        }

        /// <summary>
        /// 指定した範囲内のランダムな整数を返します。
        /// </summary>
        /// <param name="minValue">返される乱数の包括的下限値。</param>
        /// <param name="maxValue">返される乱数の排他的上限値。 maxValue は、minValue 以上である必要があります。</param>
        /// <returns>
        /// minValue 以上で maxValue 未満の 32 ビット符号付き整数。
        /// つまり、戻り値の範囲に maxValue は含まれますが minValue は含まれません。
        /// minValue が maxValue に等しい場合は、minValue が返されます。
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// maxValueが0未満です。
        /// or
        /// minValueがMaxValueより大きい値です。
        /// </exception>
        public override int Next(int minValue, int maxValue)
        {
            if (maxValue < 0)
                throw new ArgumentOutOfRangeException("maxValueが0未満です。");
            if (minValue > maxValue)
                throw new ArgumentOutOfRangeException("minValueがMaxValueより大きい値です。");
            if (minValue == maxValue)
                return minValue;
            uint range = (uint)((long)maxValue - minValue);
            uint residue = (uint.MaxValue - range + 1) % range;
            uint r;
            do
                r = m_Orign.Generate();
            while (r < residue);
            return (int)((long)((r - residue) % range) + minValue);
        }

        /// <summary>
        /// 指定したバイト配列の要素に乱数を格納します。
        /// </summary>
        /// <param name="buffer">乱数を格納するバイト配列。</param>
        public override void NextBytes(byte[] buffer)
        {
            m_Orign.NextBytes(buffer);
        }

        /// <summary>
        /// 0.0 以上 1.0 未満のランダムな浮動小数点数を返します。
        /// </summary>
        /// <returns>0.0 以上 1.0 未満の倍精度浮動小数点数。</returns>
        public override double NextDouble()
        {
            return m_Orign.NextDouble();
        }

        /// <summary>
        /// 0.0 と 1.0 の間のランダムな浮動小数点数を返します。
        /// </summary>
        /// <returns>0.0 以上 1.0 未満の倍精度浮動小数点数。</returns>
        protected override double Sample()
        {
            return Next() * SampleValue;
        }


        public override string ToString()
        {
            return m_Orign.GetType().FullName;
        }

        #endregion

    }
}
