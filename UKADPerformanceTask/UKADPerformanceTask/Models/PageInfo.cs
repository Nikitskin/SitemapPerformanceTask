
using System;
using System.Collections.Generic;
using BusinessLayer.Models;

namespace UKADPerformanceTask.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; } 
        public int TotalItems { get; set; } 
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);
    }

    public class IndexViewModel
    {
        public IEnumerable<PerformanceModel> PerformanceModels { get; set; }
        public PageInfo PageInfo { get; set; }
    }

}