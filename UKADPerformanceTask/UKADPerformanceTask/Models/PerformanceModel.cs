using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UKADPerformanceTask.Analyzer;

namespace UKADPerformanceTask.Models
{
    public class PerformanceModel
    {

        [Required]
        public string Url { get; set; }

        public List<string> ResponseTime
        {
            get
            {
                var analyzer = new UrlSiteMapParser(Url);
                return analyzer.ReturnSiteMap();
            }
            set { }
        }
    }
}