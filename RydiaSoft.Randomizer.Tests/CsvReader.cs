using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RydiaSoft.Randomizer.Tests
{
    public static class CsvReader
    {
        const string TestDir = @"TestData\";
        static Encoding enc = Encoding.UTF8;


        public static List<double> ReadNextDouble(Tests.RandomItem item)
        {
            var result = new List<double>();
            ReadFor(item, "NextDouble", (value) => {
                result.Add(Convert.ToDouble(value));
            });
            return result;
        }

        public static List<long> ReadNextInt64(Tests.RandomItem item)
        {
            var result = new List<long>();
            ReadFor(item, "NextInt64", (value) => {
                result.Add(Convert.ToInt64(value));
            });
            return result;
        }

        public static List<int> ReadNextInt32(Tests.RandomItem item)
        {
            var result = new List<int>();
            ReadFor(item, "NextInt32", (value) => {
                result.Add(Convert.ToInt32(value));
            });
            return result;
        }

        public static List<uint> ReadNextUInt32(Tests.RandomItem item)
        {
            var result = new List<uint>();
            ReadFor(item, "NextUInt32", (value) => {
                result.Add(Convert.ToUInt32(value));
            });
            return result;
        }

        public static List<ulong> ReadNextUInt64(Tests.RandomItem item)
        {
            var result = new List<ulong>();
            ReadFor(item, "NextUInt64", (value) => {
                result.Add(Convert.ToUInt64(value));
            });
            return result;
        }

        public static byte[] ReadNextBytes(Tests.RandomItem item)
        {
            var result = new List<byte>();
            ReadFor(item, "NextBytes", (value) => {
                result.Add(Convert.ToByte(value));
            });
            return result.ToArray();
        }

        private static void ReadFor(Tests.RandomItem item, string fileName,Action<string> dele)
        {
            var values = ReadCsv(item, fileName);
            foreach (var value in values)
            {
                if (value == "")
                    continue;
                dele.Invoke(value);
            }
        }

        private static string[] ReadCsv(Tests.RandomItem item,string fileName)
        {
            var enc = Encoding.UTF8;
            var result = new List<string>();
            var filePath = TestDir + item.Name + @"\" + fileName + ".csv";
            Console.WriteLine(filePath);
            using (var sr = new StreamReader(filePath, enc)) 
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split(',');
                    result.AddRange(values);
                }
            }
            return result.ToArray();
        }
          
    }
}
