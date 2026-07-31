using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationFilter.Models;

namespace WebApplicationFilter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exception=HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ErrorViewModel err= new ErrorViewModel 
            { 
                RequestId= Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ControllerName = exception.RouteValues["controller"].ToString(),
                    ActionName = exception.RouteValues["action"].ToString(),
                    Message = exception.Error.Message
           };
             return View(err);

        }
    }
}
