using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeLibrary;
using Azure;

namespace MyMVC_Client.Controllers
{
    public class EmployeesController : Controller
    {
        static string url = "https://localhost:44306/Api/";
        // GET: EmployeesController
        public ActionResult Index()
        {
            List<Employee> emp = new List<Employee>();
            using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responeTask = client.GetAsync("EmployeesAPI");
                responeTask.Wait();
                var result=responeTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data=result.Content.ReadAsAsync<List<Employee>>();
                    data.Wait();
                    if (data != null)
                        emp = data.Result;
                }
            }
            return View(emp);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
