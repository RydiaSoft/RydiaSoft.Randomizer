using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace RydiaSoft.Randomizer.Tests
{
    [TestFixture]
    public abstract class RandomBaseTests
    {

        #region メンバ・定数

        /// <summary>
        /// テスト対象乱数ジェネレータを保持するフィールドです
        /// </summary>
        protected RandomBase m_Random;
        
        /// <summary>
        /// 乱数シードを表す定数です
        /// </summary>
        protected const int Seed = 1234;

        protected const uint TestDoubleRange = 5000;

        protected const double Epsilon = 0.00000000000001;

        #endregion

        #region テストコード

        #region 初期化メソッド

        /// <summary>
        /// テスト処理前の初期化を実行します
        /// </summary>
        private void Initialize()
        {

            m_Random = CreateRandomBase();

            Console.WriteLine("Randmizerクラス　:　{0}　のテストを開始します", m_Random.GetType().FullName);
        }

        #endregion

        #region ファクトリメソッド

        /// <summary>
        /// テスト対象のRandomBase派生クラスを作成して返します
        /// </summary>
        /// <returns></returns>
        protected abstract RandomBase CreateRandomBase();

        protected abstract Tests.RandomItem CreateRandomItem();
        #endregion


        /// <summary>
        /// <see cref="RandomBase.NextBytes(byte[])"/>のアルゴリズムが正しいかどうかを検証します
        /// </summary>
        [Test]
        public virtual void NextBytesTest()
        {
            Initialize();
            byte[] bufferExpected = CsvReader.ReadNextBytes(CreateRandomItem());
            byte[] bufferActual = new byte[bufferExpected.Length];
            m_Random.NextBytes(bufferActual);
            Console.WriteLine("サンプル数:{0}回", bufferExpected.Length);
            Console.WriteLine("実装元ライブラリから同じシードで生成された乱数アルゴリズムのNextBytes()関数との一致を確認します");
            for (int i = 0; i < bufferExpected.Length; i++)
            {
                Console.Write("{0} : ", i);
                Console.Write("Expected = {0}", bufferExpected[i]);
                Console.WriteLine(" , Actual = {0}", bufferActual[i]);
                Assert.AreEqual(bufferExpected[i], bufferActual[i], "{0}", i, bufferExpected[i], bufferActual[i]);
            }
        }

        /// <summary>
        /// <see cref="RandomBase.NextDouble"/>の戻り値が0.0以上1.0以下であることを検証します
        /// </summary>
        [Test]
        public virtual void NextDoubleRange()
        {
            Initialize();
            double Ry = 0;
            double min = 0.5;
            double max = 0.5;
            Console.WriteLine("サンプル数:{0}回", TestDoubleRange);
            Console.WriteLine("0 < X > 1.0 かどうかを検証します");
            for (uint i = 0; i < TestDoubleRange; i++)
            {
                Ry = m_Random.NextDouble();
                if (Ry < min)
                    min = Ry;
                if (Ry > max)
                    max = Ry;
                Console.Write("{0} : ", i);
                Console.WriteLine("{0}", Ry);
                Assert.IsTrue(Ry >= 0.0 && Ry <= 1.0);
            }
            Console.Write("max = {0}, min = {1}", max, min);
        }

        /// <summary>
        /// <see cref="RandomBase.NextDouble"/>のアルゴリズムが正しいかどうかを検証します
        /// </summary>
        [Test]
        public virtual void NextDoubleTest()
        {
            Initialize();
            var list = CsvReader.ReadNextDouble(CreateRandomItem());
            double Re = 0;
            double Ry = 0;
            Console.WriteLine("サンプル数:{0}回", list.Count);
            Console.WriteLine("実装元ライブラリから同じシードで生成された乱数アルゴリズムのNextDouble()関数との一致を確認します");
            for (int i = 0; i < list.Count; i++)
            {
                Re = list[i];
                Ry = m_Random.NextDouble();
                Console.WriteLine("{0} : Expected = {1} , Actual = {2}", i, Re, Ry);
                Assert.AreEqual(Re, Ry, Epsilon, "{0}: expected = {1}, actual = {2}", i, Re, Ry);
            }
        }

        /// <summary>
        /// <see cref="RandomBase.NextInt32"/>の戻り値が0以上<see cref="int.MaxValue"/>未満であることを検証します
        /// </summary>
        [Test]
        public virtual void NextInt32Negate()
        {
            Initialize();
            var list = CsvReader.ReadNextInt32(CreateRandomItem());
            int Re = 0;
            int Ry = 0;
            Console.WriteLine("サンプル数:{0}回", list.Count);
            Console.WriteLine("0 < X > int.MaxValue かどうかを検証します");
            for (int i = 0; i < list.Count; i++)
            {
                Re = list[i];
                Ry = m_Random.NextInt32();
                Console.Write("{0} : ", i);
                Console.WriteLine("{0}", Ry);
                Assert.IsTrue(Re == Ry);
                Assert.IsTrue(Ry >= 0 && Ry <= int.MaxValue);
                Assert.IsTrue(Re >= 0 && Re <= int.MaxValue);
            }
        }

        /// <summary>
        /// <see cref="RandomBase.NextInt32"/>のアルゴリズムが正しいかどうかを検証します
        /// </summary>
        [Test]
        public virtual void NextInt32Test()
        {
            Initialize();
            var list = CsvReader.ReadNextInt32(CreateRandomItem());
            int Re = 0;
            int Ry = 0;
            Console.WriteLine("サンプル数:{0}回", list.Count);
            Console.WriteLine("実装元ライブラリから同じシードで生成された乱数アルゴリズムのNextInt32()関数との一致を確認します");
            for (int i = 0; i < list.Count; i++)
            {
                Re = list[i];
                Ry = m_Random.NextInt32();
                Console.WriteLine("{0} : Expected = {1} , Actual = {2}", i, Re, Ry);
                Assert.IsTrue(Re == Ry);
            }
        }

        /// <summary>
        /// <see cref="RandomBase.NextInt64"/>の戻り値が0以上<see cref="long.MaxValue"/>未満であることを検証します
        /// </summary>
        [Test]
        public virtual void NextInt64Negate()
        {
            Initialize();
            var list = CsvReader.ReadNextInt64(CreateRandomItem());
            long Re = 0;
            long Ry = 0;
            Console.WriteLine("サンプル数:{0}回", list.Count);
            Console.WriteLine("0 < X > long.MaxValue かどうかを検証します");
            for (int i = 0; i < list.Count; i++)
            {
                Re = list[i];
                Ry = m_Random.NextInt64();
                Console.Write("{0} : ", i);
                Console.WriteLine("{0}", Ry);
                Assert.IsTrue(Re == Ry);
                Assert.IsTrue(Re >= 0 || Re < long.MaxValue);
                Assert.IsTrue(Ry >= 0 || Ry < long.MaxValue);
            }
        }

        /// <summary>
        /// <see cref="RandomBase.NextInt64"/>のアルゴリズムが正しいかどうかを検証します
        /// </summary>
        [Test]
        public virtual void NextInt64Test()
        {
            Initialize();
            var list = CsvReader.ReadNextInt64(CreateRandomItem());

            long Re = 0;
            long Ry = 0;
            Console.WriteLine("サンプル数:{0}回", list.Count);
            Console.WriteLine("実装元ライブラリから同じシードで生成された乱数アルゴリズムのNextInt64()関数との一致を確認します");
            for (int i = 0; i < list.Count; i++)
            {
                Re = list[i];
                Ry = m_Random.NextInt64();
                Console.WriteLine("{0} : Expected = {1} , Actual = {2}", i, Re, Ry);
                Assert.IsTrue(Re == Ry);
            }
        }


        /// <summary>
        /// <see cref="RandomBase.NextUInt32"/>のアルゴリズムが正しいかどうかを検証します
        /// </summary>
        [Test]
        public virtual void NextUInt32Test()
        {
            Initialize();
            var list = CsvReader.ReadNextUInt32(CreateRandomItem());
            uint Re = 0;
            uint Ry = 0;
            Console.WriteLine("サンプル数:{0}回", list.Count);
            Console.WriteLine("実装元ライブラリから同じシードで生成された乱数アルゴリズムのNextUInt32()関数との一致を確認します");
            for (int i = 0; i < list.Count; i++)
            {
                Re = list[i];
                Ry = m_Random.NextUInt32();
                Console.WriteLine("{0} : Expected = {1} , Actual = {2}", i, Re, Ry);
                Assert.IsTrue(Re == Ry);
            }
        }


        /// <summary>
        /// <see cref="RandomBase.NextUInt64"/>のアルゴリズムが正しいかどうかを検証します
        /// </summary>
        [Test]
        public virtual void NextUInt64Test()
        {
            Initialize();
            var list = CsvReader.ReadNextUInt64(CreateRandomItem());
            ulong Re = 0;
            ulong Ry = 0;
            Console.WriteLine("サンプル数:{0}回", list.Count);
            Console.WriteLine("実装元ライブラリから同じシードで生成された乱数アルゴリズムのNextUInt64()関数との一致を確認します");
            for (int i = 0; i < list.Count; i++)
            {
                Re = list[i];
                Ry = m_Random.NextUInt64();
                Console.WriteLine("{0} : Expected = {1} , Actual = {2}", i, Re, Ry);
                Assert.IsTrue(Re == Ry);
            }
        }

        


        /// <summary>
        /// <see cref="RandomBase.ToDotNetRandomAdapter"/>の戻り値の型が正しいかどうかを検証します
        /// </summary>
        [Test]
        public virtual void ToRandomTest()
        {
            Initialize();
            var rand = m_Random.ToDotNetRandomAdapter();
            Console.WriteLine("RandomBase.ToRandomの戻り値の型が　System.Random　および　DotNetRandomAdapter クラスであるかどうかを検証します");
            Assert.IsInstanceOf<Random>(rand);
            Assert.IsInstanceOf<DotNetRandomAdapter>(rand);
        }

        


        #endregion

    }
}
