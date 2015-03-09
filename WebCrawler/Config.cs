using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WebCrawler
{
    class Config
    {
        public int ratio;
        public List<List<Uri>> parsedData;
        

        public Config(List<Uri> passedData, int threadCount)
        {
            ratio = (passedData.Count + 1) / threadCount;
            parsedData = Splitdata(passedData, ratio);
        }

        public List<List<Uri>> Splitdata(List<Uri> passedData, int chunkSize)
        {
            if (!passedData.Any())
            {
                return new List<List<Uri>>();
            }

            List<List<Uri>> result = new List<List<Uri>>();
            List<Uri> currentData = new List<Uri>();
            result.Add(currentData);
            int i = 0;
            foreach(Uri uriInstance in passedData)
            {
                if (i >= chunkSize)
                {
                    i = 0;
                    currentData = new List<Uri>();
                    result.Add(currentData);
                }
                i += 1;
                currentData.Add(uriInstance);
            }
            return result;
        }
    }
}
