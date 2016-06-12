using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RydiaSoft.Randomizer
{

    /// <summary>
    /// Mother-of-Allの擬似乱数ジェネレーターを表すクラスです
    /// </summary>
    /// <seealso cref="RydiaSoft.Randomizer.RandomBase" />
    public class MotherOfAll : RandomBase
    {

        #region メンバ

        private uint[] m_Vector;

        private const uint MOAValue = 29943829;

        #endregion

        #region コンストラクタ/初期化

        /// <summary>
        /// 時間に依存する既定のシード値を使用し、<see cref="MotherOfAll"/> classの新しいインスタンスを初期化します
        /// </summary>
        public MotherOfAll()
            :this(Environment.TickCount)
        {

        }

        /// <summary>
        /// 指定したシード値を使用して<see cref="MotherOfAll"/> classの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="seed">擬似乱数系列の開始値を計算するために使用する数値。負数を指定した場合、その数値の絶対値が使用されます。</param>
        public MotherOfAll(int seed)
        {
            Initialize(seed);
        }

        private void Initialize(int seed)
        {
            m_Vector = new uint[5];
            var s = (uint)seed;
            X = s = InitGenerateMotherVector(s);
            Y = s = InitGenerateMotherVector(s);
            Z = s = InitGenerateMotherVector(s);
            W = s = InitGenerateMotherVector(s);
            V = s = InitGenerateMotherVector(s);
            for (int i = 0; i < 19; i++)
            {
                GenerateInternal();
            }
        }

        private uint GenerateInternal()
        {
            var s = 2111111111UL * W + 1492UL * Z + 1776UL * Y + 5115UL * X + V;
            W = Z;
            Z = Y;
            Y = X;
            X = (uint)s;
            V = (uint)(s >> 32);
            return m_Vector[0];
        }

        private uint InitGenerateMotherVector(uint s)
        {
            return MOAValue * s - 1;
        }

        #endregion

        #region 実装

        /// <summary>
        /// 符号なし32bit整数を生成します。
        /// </summary>
        protected internal override uint Generate()
        {
            return GenerateInternal();
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 内部状態ベクトルXを取得または設定します
        /// </summary>
        protected uint X
        {
            get
            {
                return m_Vector[0];
            }
            set
            {
                m_Vector[0] = value;
            }
        }

        /// <summary>
        /// 内部状態ベクトルYを取得または設定します
        /// </summary>
        protected uint Y
        {
            get
            {
                return m_Vector[1];
            }
            set
            {
                m_Vector[1] = value;
            }
        }

        /// <summary>
        /// 内部状態ベクトルZを取得または設定します
        /// </summary>
        protected uint Z
        {
            get
            {
                return m_Vector[2];
            }
            set
            {
                m_Vector[2] = value;
            }
        }

        /// <summary>
        /// 内部状態ベクトルWを取得または設定します
        /// </summary>
        protected uint W
        {
            get
            {
                return m_Vector[3];
            }
            set
            {
                m_Vector[3] = value;
            }
        }

        /// <summary>
        /// 内部状態ベクトルVを取得または設定します
        /// </summary>
        protected uint V
        {
            get
            {
                return m_Vector[4];
            }
            set
            {
                m_Vector[4] = value;
            }
        }
        

        #endregion


    }
}
