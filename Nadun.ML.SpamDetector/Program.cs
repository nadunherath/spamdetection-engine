using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadun.ML.SpamDetector
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var reader = new StreamReader(@"D:\Nadun.ML.SpamDetector\Nadun.ML.SpamDetector\Data\training.csv"))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Replace("\"","");
                    var values = line.Split(',');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                }
            }

        }
    }
}
