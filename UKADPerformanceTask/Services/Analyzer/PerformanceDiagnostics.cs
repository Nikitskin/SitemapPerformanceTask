﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Analyzer
{
    public class PerformanceDiagnostics : IPerformanceDiagostics
    {
        private readonly double _timeoutValue;

        public PerformanceDiagnostics(double timeoutValue = 20.0d)
        {
            _timeoutValue = timeoutValue;
        }

        public async Task<Dictionary<string, TimeSpan>> AsyncGetUrlsToCallBackTime(List<string> urls)
        {
            var resultingDictionary = new Dictionary<string, TimeSpan>();
            var taskList = urls.Select(url =>
                Task.Factory.StartNew(async () =>
                {
                    resultingDictionary.Add(url, await GetCallBackTime(url));
                }));
            await Task.WhenAll(taskList);
            return resultingDictionary;
        }

        //todo can be refactored with the model using
        /// <summary>
        /// Returns time needed to get response from url
        /// if timeout reached, then TimeSpan.MaxValue returned
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<TimeSpan> GetCallBackTime(string url)
        {
            var httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(_timeoutValue)
            };
            var timer = Stopwatch.StartNew();
            var result = await httpClient.GetAsync(url);
            timer.Stop();
            return result.IsSuccessStatusCode ? timer.Elapsed : TimeSpan.MaxValue;
        }
    }
}