using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace Services.Analyzer
{
    public static class PerformanceDiagnostics
    {
        public static Dictionary<string,TimeSpan> GetUrlsResponseTime(List<string> urls)
        {
            var resultMap = new Dictionary<string, TimeSpan>();
            foreach (var url in urls)
            {
                Stopwatch timer = new Stopwatch();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                timer.Start();
                var response = (HttpWebResponse)request.GetResponse();
                timer.Stop();
                resultMap.Add(url, timer.Elapsed);
            }
            return resultMap;
        }
    }
}