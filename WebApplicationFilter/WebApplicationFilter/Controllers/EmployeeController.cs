using Microsoft.AspNetCore.Mvc;

namespace WebApplicationFilter.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Displaymsg()

        {
            int a = 10, b = 0, c;
          
                c = a / b;
                ViewBag.msg = "Div=" + c;
            
            
           
            return View();
        }
        public IActionResult ArrayDisplay()
        {
            int[] arr = new int[5] { 10, 20, 30, 40, 50 };
            int b = arr[5];
            ViewBag.arr = arr;
            return View(arr);
        }

    }
}
