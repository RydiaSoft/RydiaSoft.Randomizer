using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RydiaSoft.Randomizer.Tests
{
    public class RandomItem
    {
        const int maxCount = 100000000;
        internal const int Seed = 1234;
        private string m_Name;
        private Random m_Randmizer;
        private Func<int, Random> m_Factory;

        public RandomItem(Func<int, Random> dele, string name)
        {
            m_Factory = dele;
            m_Name = name;
            Reset();
        }

        public void Reset()
        {
            m_Randmizer = m_Factory.Invoke(Seed);
        }

        public void Dump()
        {
            var builder = new StringBuilder();
            builder.AppendLine(m_Name);
            for (int i = 0; i < 10; i++)
            {
                builder.AppendLine(string.Format("{0,10} {1,10} {2,10} {3,10} {4,10} ", m_Randmizer.Next(), m_Randmizer.Next(), m_Randmizer.Next(), m_Randmizer.Next(), m_Randmizer.Next()));
            }
            Console.WriteLine(builder.ToString());
            Console.WriteLine();
        }

        public void TimeAttack()
        {
            Reset();
            
            int start = Environment.TickCount;
            int end;
            for (int i = 0; i < maxCount; i++)
            {
                m_Randmizer.Next();
            }
            end = Environment.TickCount;
            var time = (end - start);

            Console.WriteLine("{0}:{1}msec ({2}回乱数生成)", m_Name, time.ToString(), maxCount.ToString());
        }
    }
}
