using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IPerformanceDiagostics
    {
        Task<Dictionary<string, TimeSpan>> AsyncGetUrlsToCallBackTime(List<string> urls);
        Task<TimeSpan> GetCallBackTime(string url);
    }
}
