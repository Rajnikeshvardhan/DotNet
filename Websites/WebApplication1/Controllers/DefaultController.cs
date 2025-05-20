using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        //Default/Index/123?a=111&b=222&c=333
        //Default/Index/123?b=222
        //Default/Index/123?a=111&c=333

        public IActionResult Index(int? id, int c=30, int b=20, int a=10)
        {
            //if(id==null)
            //    return NotFound();
            //else
            ViewBag.id = id;  //dynamic coding - ExpandoObject
            ViewBag.a = a;  //dynamic coding
            ViewBag.b = b;  //dynamic coding
            ViewBag.c = c;  //dynamic coding

            return View();
        }
    }
}
