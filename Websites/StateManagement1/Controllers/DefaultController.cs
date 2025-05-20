using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace StateManagement1.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            //Default/Index2
            ViewData["a"] = 100;
            //ViewBag.a = 100;
            TempData["b"] = 200;
            return View();
            //return RedirectToAction("Index2");  // will not be able to access ViewData from other view
        }
        // /Default/Index2
        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Session1()
        {
            //HttpContext.Session.SetString("key1", "Hello");
            //HttpContext.Session.SetString("key2", "world");
            //HttpContext.Session.SetInt32("key3", 12345);

            //string s = HttpContext.Session.GetString("key1");
            //string s2 = HttpContext.Session.GetString("key2");
            //int i = HttpContext.Session.GetInt32("key3").Value;




            //HttpContext.Session.Set("x", bytearr);
            //byte[] arrbytes = HttpContext.Session.Get("x");
            //HttpContext.Session.SetString("x", "Hello World");
            //string x = HttpContext.Session.GetString("x");

            //HttpContext.Session.SetInt32("y", 123);
            //int y = HttpContext.Session.GetInt32("y").Value;

            //HttpContext.Session.Set()
            //HttpContext.Session.Set("key1", byte_arr);
            //byte_arr = HttpContext.Session.Get("key1");

            //ViewData["key"] = value;


            //HttpContext.Session.Set("key", value);
            //HttpContext.Session.Get()

            HttpContext.Session.SetInt32("a", 10);
            HttpContext.Session.SetString("b", "abcd");

            //decimal d = 1.2M;
            //HttpContext.Session.SetString("d", d.ToString());


            Employee emp = new Employee { EmpNo=1,Name="Vikram"};
            string jsonEmp = JsonSerializer.Serialize<Employee>(emp);
            HttpContext.Session.SetString("emp", jsonEmp);

            //HttpContext.Session.SetString("emp", JsonSerializer.Serialize<Employee>(emp));

            return View();

        }
        public IActionResult Session2()
        {
            int a = HttpContext.Session.GetInt32("a").Value;
            string b = HttpContext.Session.GetString("b");

            //string sd = HttpContext.Session.GetString("d");
            //decimal d = decimal.Parse(sd);


            string e = HttpContext.Session.GetString("emp");
            Employee emp = JsonSerializer.Deserialize<Employee>(e);

            ViewBag.name = emp.Name;
            return View();

        }
        public IActionResult Session3()
        {
            //HttpContext.Session.Remove("key")
            //HttpContext.Session.Clear();
            return View();

        }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
    }

}