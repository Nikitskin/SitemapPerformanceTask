using System;

namespace BusinessLayer.Models
{
    public class PerformanceModel
    {
        public string Url { get; set; }

        public TimeSpan ResponseTime { get; set; }
    }
}