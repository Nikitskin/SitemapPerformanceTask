using System.ComponentModel.DataAnnotations;

namespace UKADPerformanceTask.Models
{
    public class PerformanceModel
    {
        [Required]
        public string Url { get; set; }
    }
}