using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadun.ML.SpamDetector
{
    public class NaiveBayes
    {
        public string Token { get; set; }

        public List<string> TokenizedDoc { get; set; }

        public List<string> Tokenizer(string token)
        {
            return new List<string>();
        }
    }
}
