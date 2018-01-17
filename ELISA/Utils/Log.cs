using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELISA.Utils
{
    class Log
    {

        public static void logInfo(string text)
        {
            Trace.TraceInformation(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") +"\t"+ text);
        }

        public static void logError(string text)
        {
            Trace.TraceError(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + "\t" + text);
        }
        
        
    }
}
