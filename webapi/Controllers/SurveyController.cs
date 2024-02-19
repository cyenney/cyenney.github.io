using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    public class SurveyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
