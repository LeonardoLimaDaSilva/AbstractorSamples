using System.Web.Mvc;

namespace AbstractorSamples.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}