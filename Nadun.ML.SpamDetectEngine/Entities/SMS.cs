using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadun.ML.SpamDetectEngine.Entities
{
    public class SMS
    {
        public string ActualType { get; set; }

        public string Message { get; set; }

        public string PredictedType { get; set; }
    }
}
