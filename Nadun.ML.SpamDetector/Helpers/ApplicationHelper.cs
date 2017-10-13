using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nadun.ML.SpamDetector.Enums;

namespace Nadun.ML.SpamDetector.Helpers
{
    public static class ApplicationHelper
    {
        public static string Identify(DocType docType, string message)
        {
            if (docType == DocType.Ham)
                return message + " is Ham";
            else
                return message + " is Spam";

        }

    }
}
