using System.Web.Mvc;
using Services.Analyzer;
using UKADPerformanceTask.Models;

namespace UKADPerformanceTask.Controllers
{
    public class HomeController : Controller
    {
        private IAnalyzer _analyzer;

        public HomeController(IAnalyzer analyzer)
        {
            _analyzer = analyzer;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PerformanceModel model)
        {
            _analyzer.ReturnSiteMap();
            return View("Index", model);
        }

    }
}