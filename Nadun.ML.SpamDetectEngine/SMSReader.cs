using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nadun.ML.SpamDetectEngine.Entities;

namespace Nadun.ML.SpamDetectEngine
{
    public class SMSReader
    {
        public List<SMS> Read(string pathToFiles)
        {
            List<SMS> smsList = new List<SMS>();

            using (var reader = new StreamReader(pathToFiles))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Replace("\"", "");
                    var values = line.Split(',');
                    var sms = new SMS();
                    sms.ActualType = values[0];
                    sms.Message = values[1];
                    smsList.Add(sms);
                }
            }
            return smsList;

        }

    }
}
