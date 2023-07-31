using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MVCTaskManager.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {       
        public IActionResult Index()
        {
            return View();
        }
    }
}
