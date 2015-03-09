using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net.Http;

namespace WebCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime programStartTime = DateTime.Now;
            Opener urls = new Opener(); // Opens the supplied text file and parses each string and converts into URIs
            Config configed = new Config(urls.urilist, 10); // Second Argument is where you config core count
            int i = -1;
            var threads = new List<Thread>();
           foreach (List<Uri> splitUriListInstance in configed.parsedData) // Splits up the work load and spins up the threads
           {

               i++;
               Thread th = new Thread(() => ThreadPass(splitUriListInstance, i)); // sackoverflow code, using a lamda to call a method with arguments, http://stackoverflow.com/questions/3360555/how-to-pass-parameters-to-threadstart-method-in-thread
               threads.Add(th);
               th.Start();
           }
           foreach (Thread threadInstance in threads)
           {
               threadInstance.Join();
           }
           List<Log> temp = Threadconfig.LogGroup;
           Console.WriteLine(temp.Count);
           StreamWriter logFile = new StreamWriter("logfile.txt");
            foreach (Log logInstance in temp)
            {
                logFile.Write("URL: ");
                logFile.WriteLine(logInstance.logURI);
                logFile.Write("Time: ");
                logFile.WriteLine(logInstance.elapsedTime);
                if (logInstance.errorMessage != null)
                {
                    logFile.Write("Error Message: ");
                    logFile.WriteLine(logInstance.errorMessage);
                }
            }

            DateTime programStopTime = DateTime.Now;
            TimeSpan programEllapsedTime = programStopTime - programStartTime;
            logFile.Write("Total Time: ");
            logFile.Write(programEllapsedTime);
            logFile.Close();
            Console.WriteLine(programEllapsedTime);
            Console.ReadKey();
            
            
        }

        public static async Task ThreadPass(List<Uri> testing, int listIndex) // struggled with passing a class with params into a new thread, this part of my solution
        {
            Threadconfig threadInstance = new Threadconfig();
            await threadInstance.Initialize(testing, listIndex);
        }
    }
}
