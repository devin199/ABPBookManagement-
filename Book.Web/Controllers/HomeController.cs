using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Book.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : BookControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}