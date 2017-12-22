using System.ComponentModel.DataAnnotations;

namespace UKADPerformanceTask.Models
{
    public class RequestModel
    {
        [Required]
        public string UrlToGetSitemap { get; set; }

        public string PageSize { get; set; }
    }
}