using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler
{
    class Log
    {
        public DateTime startTime;
        public String errorMessage;
        public Uri logURI;
        public TimeSpan elapsedTime;

        public void TimeStart()
        {
            DateTime startTime = DateTime.Now;
        } 

        public TimeSpan TimeStop()
        {
            DateTime stopTime = DateTime.Now;
            TimeSpan elapsedTime = stopTime - startTime;
            return elapsedTime;
        }

        public void SaveError(string error_text)
        {
            errorMessage = error_text;
        }

        public void SaveUri(Uri uriInstance)
        {
            logURI = uriInstance;
        }


    }
}
