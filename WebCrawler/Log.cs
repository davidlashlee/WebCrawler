using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler
{
    class Log
    {
        public DateTime StartTime { get; set;  }
        public String errorMessage;
        public Uri logURI;
        public TimeSpan ElapsedTime { get; set; }
        public string OutputFileName {get; set; }
        public string ResponseCode { get; set; }

        public void TimeStart()
        {
            StartTime = DateTime.Now;
        } 

        public TimeSpan TimeStop()
        {
            DateTime stopTime = DateTime.Now;
            ElapsedTime = stopTime - StartTime;
            return ElapsedTime;
        }

        public void SaveError(string error_text)
        {
            errorMessage = error_text;
        }

        public void SaveUri(Uri uriInstance)
        {
            logURI = uriInstance;
        }

        public void SaveOutputPath(string fileName)
        {
            OutputFileName = fileName;
        }

        public void httpResponseCode(string code)
        {
            ResponseCode = code;
        }
    }
}
