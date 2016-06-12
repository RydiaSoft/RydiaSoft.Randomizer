using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RydiaSoft.Randomizer
{
    /// <summary>
    /// SFMT乱数ジェネレータを表すクラスです
    /// </summary>
    /// <seealso cref="RydiaSoft.Randomizer.RandomBase" />
    public class SimdOrientedFastMersenneTwister : RandomBase
    {

        #region メンバ

        
        /// <summary>
        /// 周期を表す指数を保持するフィールドです。
        /// </summary>
        protected int m_MEXP;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        protected int m_POS1;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        protected int m_SL1;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        protected int m_SL2;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        protected int m_SR1;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        protected int m_SR2;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        protected uint m_MSK1;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        protected uint m_MSK2;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        protected uint m_MSK3;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        protected uint m_MSK4;
        /// <summary>
        /// MTの周期を保証するための確認に用いるパラメーターの一つ。
        /// </summary>
        protected uint m_PARITY1;
        /// <summary>
        /// MTの周期を保証するための確認に用いるパラメーターの一つ。
        /// </summary>
        protected uint m_PARITY2;
        /// <summary>
        /// MTの周期を保証するための確認に用いるパラメーターの一つ。
        /// </summary>
        protected uint m_PARITY3;
        /// <summary>
        /// MTの周期を保証するための確認に用いるパラメーターの一つ。
        /// </summary>
        protected uint m_PARITY4;

        /// <summary>
        /// 各要素を128bitとしたときの内部状態ベクトルの個数。
        /// </summary>
        protected int N;
        /// <summary>
        /// 各要素を32bitとしたときの内部状態ベクトルの個数。
        /// </summary>
        protected int N32;
        /// <summary>
        /// 計算の高速化用。
        /// </summary>
        protected int SL2_x8;
        /// <summary>
        /// 計算の高速化用。
        /// </summary>
        protected int SR2_x8;
        /// <summary>
        /// 計算の高速化用。
        /// </summary>
        protected int SL2_ix8;
        /// <summary>
        /// 計算の高速化用。
        /// </summary>
        protected int SR2_ix8;

        /// <summary>
        /// 内部状態ベクトル。
        /// </summary>
        protected uint[] sfmt;
        /// <summary>
        /// 内部状態ベクトルのうち、次に乱数として使用するインデックス。
        /// </summary>
        protected int idx;

        private static Dictionary<MTPeriodType, Func<MersenneTwisterDetail>> s_Details = new Dictionary<MTPeriodType, Func<MersenneTwisterDetail>>();
        #endregion

        #region コンストラクタ

        static SimdOrientedFastMersenneTwister()
        {
            s_Details[MTPeriodType.MT607] = MersenneTwisterDetail.MT607;
            s_Details[MTPeriodType.MT1279] = MersenneTwisterDetail.MT1279;
            s_Details[MTPeriodType.MT2281] = MersenneTwisterDetail.MT2281;
            s_Details[MTPeriodType.MT4253] = MersenneTwisterDetail.MT4253;
            s_Details[MTPeriodType.MT11213] = MersenneTwisterDetail.MT11213;
            s_Details[MTPeriodType.MT19937] = MersenneTwisterDetail.MT19937;
            s_Details[MTPeriodType.MT44497] = MersenneTwisterDetail.MT44497;
            s_Details[MTPeriodType.MT86243] = MersenneTwisterDetail.MT86243;
            s_Details[MTPeriodType.MT132049] = MersenneTwisterDetail.MT132049;
            s_Details[MTPeriodType.MT216091] = MersenneTwisterDetail.MT216091;
        }

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、(2^19937-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        public SimdOrientedFastMersenneTwister()
            :this(Environment.TickCount,MTPeriodType.MT19937)
        {

        }

        /// <summary>
        /// 指定したシード値を使用し、(2^19937-1)周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public SimdOrientedFastMersenneTwister(int seed)
            :this(seed,MTPeriodType.MT19937)
        {

        }

        /// <summary>
        /// 指定したシード値を使用し、指定されたフラグに基づく周期の<see cref="SimdOrientedFastMersenneTwister"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        /// <param name="period">周期を表すフラグ</param>
        public SimdOrientedFastMersenneTwister(int seed, MTPeriodType period)
        {
            if (!Enum.IsDefined(typeof(MTPeriodType), period))
                throw new ArgumentOutOfRangeException();
            
            MersenneTwisterDetail data = s_Details[period].Invoke();
            m_MEXP = data.m_mexp;
            m_POS1 = data.m_POS1;
            m_SL1 = data.m_SL1;
            m_SL2 = data.m_SL2;
            m_SR1 = data.m_SR1;
            m_SR2 = data.m_SR2;
            m_MSK1 = data.m_MSK1;
            m_MSK2 = data.m_MSK2;
            m_MSK3 = data.m_MSK3;
            m_MSK4 = data.m_MSK4;
            m_PARITY1 = data.m_PARITY1;
            m_PARITY2 = data.m_PARITY2;
            m_PARITY3 = data.m_PARITY3;
            m_PARITY4 = data.m_PARITY4;
            InitializeGenerateRand(seed);
        }

        #endregion

        #region 実装

        /// <summary>
        /// 符号なし32bit整数を生成します。
        /// </summary>
        /// <returns></returns>
        protected internal override uint Generate()
        {
            if (idx >= N32)
            {
                GenerateRandAll();
                idx = 0;
            }
            return sfmt[idx++];
        }

        /// <summary>
        /// ジェネレータを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        protected void InitializeGenerateRand(int seed)
        {
            N = m_MEXP / 128 + 1;
            N32 = N * 4;
            SL2_x8 = m_SL2 * 8;
            SR2_x8 = m_SR2 * 8;
            SL2_ix8 = 64 - SL2_x8;
            SR2_ix8 = 64 - SR2_x8;
            sfmt = new uint[N32];
            sfmt[0] = (uint)seed;
            int i;
            for (i = 1; i < N32; i++)
                sfmt[i] = (uint)(1812433253 * (sfmt[i - 1] ^ (sfmt[i - 1] >> 30)) + i);
            PeriodCertification();
            idx = N32;
        }

        /// <summary>
        /// 内部状態ベクトルが適切かどうかを判断し、調節します。
        /// </summary>
        protected void PeriodCertification()
        {
            uint[] parity = new uint[] { m_PARITY1, m_PARITY2, m_PARITY3, m_PARITY4 };
            uint inner = 0;
            uint work;
            int i; 
            int j;
            for (i=0;i<4;i++)
                inner ^= sfmt[i] & parity[i];
            for (i = 16; i > 0; i >>= 1)
                inner ^= inner >> i;
            inner &= 1;
            if (inner == 1)
                return;
            for (i = 0; i < 4; i++)
            {
                work = 1;
                for (j = 0; j < 32; j++)
                {
                    if ((work & parity[i]) != 0)
                    {
                        sfmt[i] ^= work;
                        return;
                    }
                    work = work << 1;
                }
            }
        }

        /// <summary>
        /// 内部状態ベクトルを更新します。
        /// </summary>
        protected virtual void GenerateRandAll()
        {
            if(m_MEXP == 19937)
            {
                GenerateRandAll19937();
                return;
            }
            var a = 0;
            var b = m_POS1 * 4;
            var c = (N - 2) * 4;
            var d = (N - 1) * 4;
            ulong xh;
            ulong xl;
            ulong yh;
            ulong yl;
            do
            {
                xh = ((ulong)sfmt[a+3] << 32) | sfmt[a + 2];
                xl = ((ulong)sfmt[a + 1] << 32) | sfmt[a + 0];
                yh = xh << (SL2_x8) | xl >> (SL2_ix8);
                yl = xl << (SL2_x8);
                xh = ((ulong)sfmt[c + 3] << 32) | sfmt[c + 2];
                xl = ((ulong)sfmt[c + 1] << 32) | sfmt[c + 0];
                yh ^= xh >> (SR2_x8);
                yl ^= xl >> (SR2_x8) | xh << (SR2_ix8);

                sfmt[a + 3] = sfmt[a + 3] ^ ((sfmt[b + 3] >> m_SR1) & m_MSK4) ^ (sfmt[d + 3] << m_SL1) ^ ((uint)(yh >> 32));
                sfmt[a + 2] = sfmt[a + 2] ^ ((sfmt[b + 2] >> m_SR1) & m_MSK3) ^ (sfmt[d + 2] << m_SL1) ^ ((uint)yh);
                sfmt[a + 1] = sfmt[a + 1] ^ ((sfmt[b + 1] >> m_SR1) & m_MSK2) ^ (sfmt[d + 1] << m_SL1) ^ ((uint)(yl >> 32));
                sfmt[a + 0] = sfmt[a + 0] ^ ((sfmt[b + 0] >> m_SR1) & m_MSK1) ^ (sfmt[d + 0] << m_SL1) ^ ((uint)yl);

                c = d;
                d = a;
                a += 4;
                b += 4;
                if (b >= N32)
                    b = 0;
            } while (a < N32);
        }

        /// <summary>
        /// 内部状態ベクトルを更新します。
        /// [(2^19937-1)周期用]
        /// </summary>
        private void GenerateRandAll19937()
        {
            const int cMEXP = 19937;
            const int cPOS1 = 122;
            const uint cMSK1 = 0xdfffffefU;
            const uint cMSK2 = 0xddfecb7fU;
            const uint cMSK3 = 0xbffaffffU;
            const uint cMSK4 = 0xbffffff6U;
            const int cSL1 = 18;
            const int cSR1 = 11;
            const int cN = cMEXP / 128 + 1;
            const int cN32 = cN * 4;
            var a = 0;
            var b = cPOS1 * 4;
            var c = (cN - 2) * 4;
            var d = (cN - 1) * 4;
            uint[] p = sfmt;
            do
            {
                p[a + 3] = p[a + 3] ^ (p[a + 3] << 8) ^ (p[a + 2] >> 24) ^ (p[c + 3] >> 8) ^ ((p[b + 3] >> cSR1) & cMSK4) ^ (p[d + 3] << cSL1);
                p[a + 2] = p[a + 2] ^ (p[a + 2] << 8) ^ (p[a + 1] >> 24) ^ (p[c + 3] << 24) ^ (p[c + 2] >> 8) ^ ((p[b + 2] >> cSR1) & cMSK3) ^ (p[d + 2] << cSL1);
                p[a + 1] = p[a + 1] ^ (p[a + 1] << 8) ^ (p[a + 0] >> 24) ^ (p[c + 2] << 24) ^ (p[c + 1] >> 8) ^ ((p[b + 1] >> cSR1) & cMSK2) ^ (p[d + 1] << cSL1);
                p[a + 0] = p[a + 0] ^ (p[a + 0] << 8) ^ (p[c + 1] << 24) ^ (p[c + 0] >> 8) ^ ((p[b + 0] >> cSR1) & cMSK1) ^ (p[d + 0] << cSL1);
                c = d; d = a; a += 4; b += 4;
                if (b >= cN32) b = 0;
            } while (a < cN32);
        }

        #endregion

        #region プロパティ

        #endregion

    }
}
