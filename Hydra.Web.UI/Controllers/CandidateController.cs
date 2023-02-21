using Microsoft.AspNetCore.Mvc;

namespace Hydra.Web.UI.Controllers {
    public class CandidateController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
