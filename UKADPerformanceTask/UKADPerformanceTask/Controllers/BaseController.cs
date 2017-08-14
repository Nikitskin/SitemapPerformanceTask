using Ninject;
using System.Web.Mvc;
using UKADPerformanceTask.Models;

namespace UKADPerformanceTask.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }
    }
}