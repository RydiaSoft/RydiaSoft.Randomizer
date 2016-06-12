using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RydiaSoft.Randomizer.Tests
{
    public class RandomItem
    {
        private const int Seed = 1234;
        private Random m_Randmizer;
        private Func<int, Random> m_Factory;
        private string m_Name;

        public RandomItem(Func<int,Random> dele,string name)
        {
            m_Factory = dele;
            m_Name = name;
            Reset();
        }

        public void Reset()
        {
            m_Randmizer = m_Factory.Invoke(Seed);
        }

        public Random Randmizer
        {
            get
            {
                return m_Randmizer;
            }
        }

        public string Text
        {
            get;
            set;
        }

        public int Time
        {
            get;
            set;
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
