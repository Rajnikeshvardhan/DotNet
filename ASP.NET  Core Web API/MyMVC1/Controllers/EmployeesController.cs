using EmployeeLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MyMVC1.Controllers
{
    public class EmployeesController : Controller
    {
        string url = "https://localhost:44306/api/";

        // GET: EmployeesController
        public async Task<ActionResult> Index()
        {
            List<Employee> emp = new List<Employee>();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var result= await client.GetAsync("EmployeesAPI");
    
                if (result.IsSuccessStatusCode)
                {
                    emp = await result.Content.ReadAsAsync<List<Employee>>();


                }
            }
            return View(emp);
        }

        // GET: EmployeesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Employee obj=new Employee();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(url);
                var result = await client.GetAsync("EmployeesAPI/" + id);
                
               

                if (result.IsSuccessStatusCode)
                {
                    obj = await result.Content.ReadAsAsync<Employee>();
                    
                }
            }
            return View(obj);

           
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee obj)
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
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                Employee obj = new Employee();
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(url);
                    var result = await client.DeleteAsync("EmployeesAPI/" + id);



                    if (result.IsSuccessStatusCode)
                    {
                        obj = await result.Content.ReadAsAsync<Employee>();

                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
