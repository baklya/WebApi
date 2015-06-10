using System.Web.Mvc;

namespace PersonsWebApi.Controllers
{
    /// <summary>
    /// Controller for home page
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
