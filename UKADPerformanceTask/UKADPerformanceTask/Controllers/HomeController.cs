using System.Web.Mvc;
using Services.Analyzer;
using UKADPerformanceTask.Models;

namespace UKADPerformanceTask.Controllers
{
    public class HomeController : Controller
    {
        private IAnalyzer _analyzer;

        public HomeController()
        {
            //todo create IOC 
            _analyzer = new UrlSiteMapParser();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PerformanceModel model)
        {
            ViewBag.SiteMap = _analyzer.ReturnSiteMap(model.Url);
            return View("Index", model);
        }

    }
}