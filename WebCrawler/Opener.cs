using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WebCrawler
{
    class Opener
    {
        public List<string> stringlist = new List<string>(); // gives access to string version of the URL list
        public List<Uri> urilist = new List<Uri>(); // give access to URI version of the URL list

        public Opener()
        {
            string line;
            StreamReader file = new StreamReader("c:\\users\\david lashlee\\documents\\visual studio 2013\\Projects\\WebCrawler\\WebCrawler\\Properties\\testurls.txt");
            while ((line = file.ReadLine()) != null)
            {
                Uri uri = new Uri(line);
                stringlist.Add(line);
                urilist.Add(uri);
            }    
        }
    }
}
