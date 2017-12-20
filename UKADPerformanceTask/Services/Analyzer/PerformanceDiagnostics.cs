using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Web;

namespace Services.Analyzer
{
    public static class PerformanceDiagnostics
    {
        public static Dictionary<string,TimeSpan> GetUrlsResponseTime(List<string> urls)
        {
            var resultMap = new Dictionary<string, TimeSpan>();
            foreach (var url in urls)
            {
                var timer = new Stopwatch();
                var request = (HttpWebRequest)WebRequest.Create(url);
                timer.Start();
                var response = (HttpWebResponse) request.GetResponse();
                timer.Stop();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    
                }
                resultMap.Add(url, timer.Elapsed);
            }
            return resultMap;
        }
    }
}