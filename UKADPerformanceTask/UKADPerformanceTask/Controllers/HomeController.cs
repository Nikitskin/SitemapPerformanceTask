using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult> Index(RequestModel model, int page = 1)
        {
            var _listOfUrls = _analyzer.ReturnSiteMap(model.UrlToGetSitemap);
            ViewBag.ListOfUrls = _listOfUrls;
            var pageInfo = new PageInfo { PageSize = int.Parse(model.PageSize), TotalItems = _listOfUrls.Count, PageNumber = page };
            var recordsPerPage = _listOfUrls.Skip((page - 1) * pageInfo.PageSize).Take(pageInfo.PageSize); 
            var result = await _performanceDiagostics.AsyncGetUrlsToCallBackTime(recordsPerPage);
            ViewBag.PageIndex = new IndexViewModel { PageInfo = pageInfo, PerformanceModels = result };
            return View(model);
        }
    }
}