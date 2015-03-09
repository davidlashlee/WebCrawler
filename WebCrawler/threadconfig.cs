﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace WebCrawler
{
    class Threadconfig
    {
        private static int fileNum = 0;
        public static List<Task> taskList = new List<Task>();
        private static List<Log> _logGroup = new List<Log>();
        public static List<Log> LogGroup { get { return _logGroup; } }
        public async void Initialize(List<Uri> passed_uri_list, int list_index)
        {
            foreach (Uri uriInstance in passed_uri_list)
            {
                int d = 10;
                Log logInstance = new Log();
                try
                {
                    logInstance.TimeStart();
                    logInstance.SaveUri(uriInstance);
                    HttpClient client = new HttpClient();
                    HttpResponseMessage html = await client.GetAsync(uriInstance);
                    HttpContent content = html.Content;
                    string result = await content.ReadAsStringAsync();
                    fileNum++;
                    string filePath = string.Format("Output/outputfile#{0}", fileNum);
                    StreamWriter file = new StreamWriter(filePath);
                    file.Write(result);
                    file.Close();
                }
                catch (HttpRequestException ex)
                {
                    logInstance.SaveError(ex.Message);

                }
                logInstance.TimeStop();
                _logGroup.Add(logInstance);
            }
        }
    }
}