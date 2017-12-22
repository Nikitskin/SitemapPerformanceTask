using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IPerformanceDiagostics
    {
        Task<IEnumerable<PerformanceModel>> AsyncGetUrlsToCallBackTime(IEnumerable<string> urls);
        Task<TimeSpan> GetCallBackTime(string url);
    }
}
