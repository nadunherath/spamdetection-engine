using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace Nadun.ML.SpamDetector.Enums
{
    public enum DocType
    {
       [Description("Ham")]
       Ham,

       [Description("Spam")]
       Spam
    }
}
