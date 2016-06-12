using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RydiaSoft.Randomizer
{

    /// <summary>
    /// すべての疑似乱数クラスの基底クラスです。
    /// </summary>
    public abstract class RandomBase
    {

        #region ファクトリメソッド

        #region LinearCongruentialGenerator

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、<see cref="LinearCongruentialGenerator"/> classの新しいインスタンスを作成して返します
        /// </summary>
        /// <returns></returns>
        public static RandomBase LinearCongruentialGeneratorFactory()
        {
            return LinearCongruentialGeneratorFactory(Environment.TickCount);
        }

        /// <summary>
        /// 指定したシード値を使用して<see cref="LinearCongruentialGenerator"/> classの新しいインスタンスを作成して返します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static RandomBase LinearCongruentialGeneratorFactory(int seed)
        {
            return LinearCongruentialGeneratorFactory(seed, LinearCongruentialGenerator.DefaultParamA, LinearCongruentialGenerator.DefaultParamC);
        }

        /// <summary>
        /// 指定したパラメータを使用して<see cref="LinearCongruentialGenerator"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        /// <param name="paramA">LCGパラメータAを表す数値</param>
        /// <param name="paramC">LCGパラメータCを表す数値</param>
        public static RandomBase LinearCongruentialGeneratorFactory(int seed, uint paramA, uint paramC)
        {
            return new LinearCongruentialGenerator(seed, paramA, paramC);
        }

        #endregion

        #region MersenneTwister

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、<see cref="MersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        public static RandomBase MersenneTwisterFactory()
        {
            return MersenneTwisterFactory(Environment.TickCount);
        }

        /// <summary>
        /// 指定したシード値を使用して<see cref="MersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static RandomBase MersenneTwisterFactory(int seed)
        {
            return new MersenneTwister(seed);
        }


        #endregion

        #region MotherOfAll()

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、<see cref="MotherOfAll"/> classの新しいインスタンスを初期化します
        /// </summary>
        public static RandomBase MotherOfAllFactory()
        {
            return MotherOfAllFactory(Environment.TickCount);
        }

        /// <summary>
        /// 指定したシード値を使用して<see cref="MotherOfAll"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static RandomBase MotherOfAllFactory(int seed)
        {
            return new MotherOfAll(seed);
        }

        #endregion

        #region RanrotB

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、<see cref="RanrotB"/> classの新しいインスタンスを初期化します
        /// </summary>
        public static RandomBase RanrotBFactory()
        {
            return RanrotBFactory(Environment.TickCount);
        }

        /// <summary>
        /// 指定したシード値を使用して<see cref="RanrotB"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static RandomBase RanrotBFactory(int seed)
        {
            return new RanrotB(seed);
        }

        #endregion

        #region SimdOrientedFastMersenneTwister

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、(2^19937-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        public static RandomBase SimdOrientedFastMersenneTwisterFactory()
        {
            return SimdOrientedFastMersenneTwister19937Factory(Environment.TickCount);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^19937-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static RandomBase SimdOrientedFastMersenneTwister19937Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT19937);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^19937-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static RandomBase SimdOrientedFastMersenneTwister607Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT607);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^19937-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static RandomBase SimdOrientedFastMersenneTwister1279Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT1279);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^19937-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static RandomBase SimdOrientedFastMersenneTwister2281Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT2281);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^19937-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static RandomBase SimdOrientedFastMersenneTwister4253Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT4253);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^19937-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static RandomBase SimdOrientedFastMersenneTwister11213Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT11213);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^19937-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static RandomBase SimdOrientedFastMersenneTwister44497Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT44497);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^19937-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static RandomBase SimdOrientedFastMersenneTwister86243Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT86243);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^19937-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static RandomBase SimdOrientedFastMersenneTwister132049Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT132049);
        }

        /// <summary>
        /// 指定したシード値を使用し、(2^19937-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static RandomBase SimdOrientedFastMersenneTwister216091Factory(int seed)
        {
            return SimdOrientedFastMersenneTwisterFactory(seed, MTPeriodType.MT216091);
        }

        /// <summary>
        /// 指定したシード値を使用し、指定されたフラグに基づく周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        /// <param name="period">周期を表すフラグ</param>
        public static RandomBase SimdOrientedFastMersenneTwisterFactory(int seed, MTPeriodType period)
        {
            return new SimdOrientedFastMersenneTwister(seed, period);
        }

        #endregion

        #region Well

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、<see cref="Well"/> classの新しいインスタンスを初期化します
        /// </summary>
        public static RandomBase WellFactory()
        {
            return WellFactory(Environment.TickCount);
        }

        /// <summary>
        /// 指定したシード値を使用し、<see cref="Well"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static RandomBase WellFactory(int seed)
        {
            return new Well(seed);
        }

        #endregion

        #region Xorshift

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、<see cref="XorShift"/> classの新しいインスタンスを初期化します
        /// </summary>
        public static RandomBase XorshiftFactory()
        {
            return XorshiftFactory(Environment.TickCount);
        }

        /// <summary>
        /// 指定したシード値を使用し、<see cref="XorShift"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public static RandomBase XorshiftFactory(int seed)
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
        public static RandomBase XorshiftFactory(uint seed1, uint seed2, uint seed3, uint seed4)
        {
            return new XorShift(seed1, seed2, seed3, seed4);
        }


        #endregion

        #endregion

        #region 実装

        /// <summary>
        /// <see cref="System.Random"/>互換の<see cref="DotNetRandomAdapter"/>を通して<see cref="System.Random"/>へ変換して返します
        /// </summary>
        /// <returns></returns>
        public System.Random ToDotNetRandomAdapter()
        {
            return new DotNetRandomAdapter(this);
        }

        /// <summary>
        /// 符号なし32bit整数を生成します。
        /// 派生クラスでオーバーライドする必要があります。
        /// </summary>
        /// <returns></returns>
        protected internal abstract uint Generate();

        /// <summary>
        /// 符号なし32bitの擬似乱数を生成して返します
        /// </summary>
        /// <returns>
        /// 0 以上で<see cref="uint.MaxValue"/>より小さい 32 ビット符号なし整数。
        /// </returns>
        public uint NextUInt32()
        {
            return Generate();
        }

        /// <summary>
        /// 符号あり32bitの擬似乱数を生成して返します
        /// </summary>
        /// <returns>
        /// 0 以上で<see cref="int.MaxValue"/>より小さい 32 ビット符号付き整数。
        /// </returns>
        public int NextInt32()
        {
            int result = (int)Generate();
            return Math.Abs(result);
        }

        /// <summary>
        /// 符号なし64bitの擬似乱数を取得します。
        /// </summary>
        public virtual ulong NextUInt64()
        {
            ulong result = ((ulong)NextUInt32() << 32) | NextUInt32();
            return result;
        }

        /// <summary>
        /// 符号あり64bitの擬似乱数を取得します。
        /// </summary>
        public virtual long NextInt64()
        {
            long result = (long)NextUInt64();
            return Math.Abs(result);
        }

        /// <summary>
        /// 指定したバイト配列の要素に乱数を格納します。
        /// </summary>
        /// <param name="buffer">乱数を格納するバイト配列。</param>
        public virtual void NextBytes(byte[] buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException("buffer は null です。");
            int i = 0;
            int ii = 0;
            uint r;
            while (i + 4 <= buffer.Length)
            {
                r = NextUInt32();
                for (ii = 0; ii < 4; ii++) 
                {
                    buffer[i++] = NextBytes(ii, r);
                }
            }
            if (i >= buffer.Length)
                return;
            r = NextUInt32();
            for (ii = 0; ii < 3; ii++)
            {
                if (i + ii >= buffer.Length)
                    return;
                buffer[i + ii] = NextBytes(ii, r);
            }
        }

        private byte NextBytes(int index, uint r)
        {
            if (index < 0 || index > 3)
                throw new ArgumentOutOfRangeException();
            switch (index)
            {
                case 1:
                    return (byte)(r >> 8);
                case 2:
                    return (byte)(r >> 16);
                case 3:
                    return (byte)(r >> 24);
            }
            return (byte)r;
        }

        /// <summary>
        /// 0.0 以上 1.0 未満のランダムな浮動小数点数を返します。
        /// [0,1]を<see cref="UInt32.MaxValue"/>個に均等にわけ、そのうち一つを返します。
        /// <see cref="Generate"/>を1回呼び出します。
        /// </summary>
        public virtual double NextDouble()
        {
            var r1 = Generate();
            double result = r1 * (1.0 / UInt32.MaxValue);
            if (result >= 0.0 && result <= 1.0)
                return result;
            if (result > 1.0)
                return 1.0;
            return 0.0;
        }

        #endregion


    }
}
