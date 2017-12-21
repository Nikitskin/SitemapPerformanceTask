using System.Threading.Tasks;
using System.Web.Mvc;
using BusinessLayer.Analyzer;
using BusinessLayer.Interfaces;
using UKADPerformanceTask.Models;

namespace UKADPerformanceTask.Controllers
{
    public class HomeController : Controller
    {
        private IAnalyzer _analyzer;
        private IPerformanceDiagostics _performanceDiagostics;

        public HomeController()
        {
            //todo create IOC 
            _analyzer = new UrlSiteMapParser();
            _performanceDiagostics= new PerformanceDiagnostics();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(PerformanceModel model)
        {
            ViewBag.SiteMap = await _performanceDiagostics.GetUrlsToCallBackTime(_analyzer.ReturnSiteMap(model.Url));
            return View("Index", model);
        }

    }
}