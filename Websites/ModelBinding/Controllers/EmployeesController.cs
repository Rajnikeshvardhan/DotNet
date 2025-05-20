using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        //Employees/Index
        public ActionResult Index()
        {
            //List<Employee> objList = new List<Employee>();
            List<Employee> objList = Employee.GetAllEmployees();
            //objList.Add(new Employee {EmpNo = 1, Name = "abc",Basic=55000,DeptNo=10});
            //objList.Add(new Employee { EmpNo = 2, Name = "def", Basic = 75000, DeptNo = 30 });
            //objList.Add(new Employee { EmpNo = 3, Name = "ghi", Basic = 35000, DeptNo = 20 });
            return View(objList);
        }
        // GET: EmployeesController/Details/5
        //Employees/Details/5
        public ActionResult Details(int id)
        {
            Employee obj = Employee.GetSingleEmployee(id);
            //Employee obj = new Employee();
            //obj.EmpNo = 10;
            //obj.Name = "abc";
            //obj.Basic = 36000;
            //obj.DeptNo = 30;
            return View(obj);
        }

        // GET: EmployeesController/Create
        //[HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //model binding - name of the property must be the same as html control
        public ActionResult Create(Employee obj)
        {
            try
            {
                Employee.Insert(obj);
                ViewBag.message = "success";
                return View(obj);
                //return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }


        //binding - variable name must be same as html control name
        //public ActionResult Create(int EmpNo, string Name, decimal Basic, int DeptNo)
        //{
        //    try
        //    {


        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        string name = collection["Name"];
        //        string empno = collection["EmpNo"];
        //        string basic = collection["Basic"];
        //        string deptno = collection["DeptNo"];

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee obj)
        {
            try
            {
                Employee.Update(obj);
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
            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee obj)
        {
            try
            {
                //Employee.Delete(id);
                Employee.Delete2(obj);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
