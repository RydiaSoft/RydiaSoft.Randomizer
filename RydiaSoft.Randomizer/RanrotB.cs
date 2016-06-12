﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RydiaSoft.Randomizer
{

    /// <summary>
    /// Ranrotの擬似乱数ジェネレーターを表すクラスです
    /// </summary>
    /// <seealso cref="RydiaSoft.Randomizer.RandomBase" />
    public class RanrotB : RandomBase
    {

        #region メンバ

        /// <summary>
        /// 内部状態ベクトルの個数を表す定数です
        /// </summary>
        protected const int KK = 17;
        /// <summary>
        /// RanrotBの定数JJ
        /// </summary>
        protected const int JJ = 10;
        /// <summary>
        /// RanrotBの定数R1
        /// </summary>
        protected const int R1 = 13;
        /// <summary>
        /// RanrotBの定数R2
        /// </summary>
        protected const int R2 = 9;

        /// <summary>
        /// 内部状態ベクトルを保持するフィールドです
        /// </summary>
        protected uint[] m_RandBuffer;
        /// <summary>
        /// リングバッファインデックスP1を保持するフィールドです
        /// </summary>
        protected int m_P1;
        /// <summary>
        /// リングバッファインデックスP2を保持するフィールドです
        /// </summary>
        protected int m_P2;

        #endregion

        #region コンストラクタ

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、<see cref="RanrotB"/> classの新しいインスタンスを初期化します
        /// </summary>
        public RanrotB()
            :this(Environment.TickCount)
        {

        }

        /// <summary>
        /// 指定したシード値を使用して<see cref="RanrotB"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public RanrotB(int seed)
        {
            var s = (uint)seed;
            m_RandBuffer = new uint[KK];
            for(int i = 0;i<KK;i++)
            {
                m_RandBuffer[i] = s = s * 2891336453 + 1;
            }
            m_P1 = 0;
            m_P2 = JJ;
            for(int i=0;i<9;i++)
            {
                GenerateInternal();
            }
        }

        #endregion

        #region 実装

        private uint GenerateInternal()
        {
            uint x;
            x = m_RandBuffer[m_P1] = ((m_RandBuffer[m_P2] << R1) | (m_RandBuffer[m_P2] >> (32 - R1))) +
                ((m_RandBuffer[m_P1] << R2) | (m_RandBuffer[m_P1] >> (32 - R2)));

            if (--m_P1 < 0)
                m_P1 = KK - 1;
            if (--m_P2 < 0)
                m_P2 = KK - 1;
            return x;
        }

        /// <summary>
        /// 符号なし32bit整数を生成します。
        /// </summary>
        /// <returns></returns>
        protected internal override uint Generate()
        {
            return GenerateInternal();
        }

        #endregion


    }
}
