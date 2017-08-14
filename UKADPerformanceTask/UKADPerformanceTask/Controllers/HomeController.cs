using System.Web.Mvc;
using UKADPerformanceTask.Models;

namespace UKADPerformanceTask.Controllers
{
    public class HomeController : BaseController
    {
        [HttpPost]
        public ActionResult Performance(PerformanceModel model)
        {
            return View("Index", model);
        }

    }
}