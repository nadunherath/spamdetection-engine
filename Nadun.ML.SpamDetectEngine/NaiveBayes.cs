using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nadun.ML.SpamDetectEngine.Entities;

namespace Nadun.ML.SpamDetectEngine
{
    public class NaiveBayes
    {
        private List<SMS> smsList;
        private int countSpamSMS = 153;
        private int countHamSMS = 847;

        public NaiveBayes()
        {
            SMSReader smsReader = new SMSReader();
            smsList = smsReader.Read(@"D:\Nadun.ML.SpamDetector\Nadun.ML.SpamDetector\Data\evaluating.csv");
            countSpamSMS = smsList.Count( x => x.ActualType == "spam");
            countHamSMS = smsList.Count(x => x.ActualType == "ham");
        }

        public bool CheckSMS(string text, int evaluatingCriteria)
        {
            Parser parser = new Parser();
            foreach (var spamMail in smsList.Where( x => x.ActualType == "spam").ToList())
            {
                parser.Parse(spamMail.Message,evaluatingCriteria);
            }
            var spamWords = parser.WordCounter;
            parser = new Parser();
            foreach (var notSpamMail in smsList.Where(x => x.ActualType == "ham").ToList())
            {
                parser.Parse(notSpamMail.Message,evaluatingCriteria);
            }
            var notSpamWords = parser.WordCounter;
            var result = true;
            if (evaluatingCriteria == 0)
            {
                result = CheckIfSpam(text, countSpamSMS,
                spamWords, countHamSMS, notSpamWords);
            }
            else if (evaluatingCriteria == 1)
            {
                result = CheckIfSpam2(text, countSpamSMS,
               spamWords, countHamSMS, notSpamWords);
            }
            else if (evaluatingCriteria == 2)
            {
                var spamWordsTop20 = spamWords.OrderByDescending(x => x.Value).Take(20).ToDictionary(t => t.Key, t => t.Value);
                var notSpamWordsTop20 = notSpamWords.OrderByDescending(x => x.Value).Take(20).ToDictionary(t => t.Key, t => t.Value);

                var intersection = spamWordsTop20.Keys.Intersect(notSpamWordsTop20.Keys).ToList();

                result = CheckIfSpam2(text, countSpamSMS,
                    spamWordsTop20, countHamSMS, notSpamWordsTop20);
            }
            return result;

        }

        private bool CheckIfSpam(string text,int countSpamMails, Dictionary<string, int> spamWordList,
            int countNotSpamMails, Dictionary<string, int> notSpamWordList)
        {
            var stringArray = text.Split(' ');
            var sumQ = 0.0;
            var spamScore = 1.0;
            var hamScore = 1.0;
            
            var wordCounter = 0;
            foreach (var item in stringArray)
            {
                spamScore *= CalculateSpamScore(item.ToLower(),  spamWordList,  notSpamWordList);
                hamScore *= CalculateHamScore(item.ToLower(), spamWordList, notSpamWordList);
                wordCounter++;
            }
            if (spamScore > hamScore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckIfSpam2(string text, int countSpamMails, Dictionary<string, int> spamWordList,
            int countNotSpamMails, Dictionary<string, int> notSpamWordList)
        {
            var stringArray = text.Split(' ');
            var sumQ = 0.0;
            var spamScore = 1.0;
            var hamScore = 1.0;

            var wordCounter = 0;
            foreach (var item in stringArray)
            {
                spamScore *= CalculateSpamScore(item, spamWordList, notSpamWordList);
                hamScore *= CalculateHamScore(item, spamWordList, notSpamWordList);
                wordCounter++;
            }
            if (spamScore > hamScore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //private double CalculateQ(string word, int countSpamSMS, Dictionary<string, int> spamWordList,
        //    int countNotSpamSMS, Dictionary<string, int> notSpamWordList)
        //{
        //    double wordCountSpam = 1;
        //    if (spamWordList.ContainsKey(word))
        //    {
        //        wordCountSpam = spamWordList[word];
        //    }
        //    double Ph1e = (0.5)*(wordCountSpam/countSpamSMS);
           
        //    double wordCountNotSpam = 1;
        //    if (notSpamWordList.ContainsKey(word))
        //    {
        //        wordCountNotSpam = notSpamWordList[word];
        //    }
        //    double Ph2e = 0.5*(wordCountNotSpam/countNotSpamSMS);
            
        //    double q = Ph1e/Ph2e;
        //    return q;
        //}


        private double CalculateSpamScore(string word,  Dictionary<string, int> spamWordList,
            Dictionary<string, int> notSpamWordList)
        {
            double wordCountSpam = 1;
            if (spamWordList.ContainsKey(word))
            {
                wordCountSpam = spamWordList[word];
            }
            
            double wordCountNotSpam = 1;
            if (notSpamWordList.ContainsKey(word))
            {
                wordCountNotSpam = notSpamWordList[word];
            }
            double x = wordCountSpam/ (wordCountSpam + wordCountNotSpam);
            return x;
        }

        private double CalculateHamScore(string word,  Dictionary<string, int> spamWordList,
             Dictionary<string, int> notSpamWordList)
        {
            double wordCountSpam = 1;
            if (spamWordList.ContainsKey(word))
            {
                wordCountSpam = spamWordList[word];
            }
            
            double wordCountNotSpam = 1;
            if (notSpamWordList.ContainsKey(word))
            {
                wordCountNotSpam = notSpamWordList[word];
            }
            double Ph2e =  wordCountNotSpam / (wordCountSpam + wordCountNotSpam);
            return Ph2e;
        }



    }
}
