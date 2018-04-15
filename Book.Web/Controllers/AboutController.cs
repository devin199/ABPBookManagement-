using System.Web.Mvc;

namespace Book.Web.Controllers
{
    public class AboutController : BookControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}