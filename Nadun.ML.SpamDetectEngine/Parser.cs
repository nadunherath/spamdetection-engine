using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadun.ML.SpamDetectEngine
{
    public class Parser
    {
        private Dictionary<string, int> wordCounter = new Dictionary<string, int>();

        public Dictionary<string, int> WordCounter
        {
            get { return wordCounter; }
            set { wordCounter = value; }
        }

        public void Parse(string textToParse,int evaluatingCriteria)
        {
            var stringArray = textToParse.Split(' ');

            foreach (var str in stringArray)
            {
                if (evaluatingCriteria == 0)
                {
                    if (wordCounter.ContainsKey(str.ToLower()))
                    {
                        wordCounter[str.ToLower()] += 1;
                      
                    }
                    else
                    {
                        wordCounter.Add(str.ToLower(), 1);
                        
                    }
                }
                else if (evaluatingCriteria == 1 || evaluatingCriteria == 2)
                {
                    if (wordCounter.ContainsKey(str))
                    {
                        wordCounter[str] += 1;
                    }
                    else
                    {
                        wordCounter.Add(str, 1);
                    }
                }
                
            }
        }
    }
}
