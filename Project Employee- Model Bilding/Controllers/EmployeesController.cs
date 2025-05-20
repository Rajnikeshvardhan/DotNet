using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Modelbild.Models;
using System.Data;

namespace Modelbild.Controllers
{
    public class EmployeesController : Controller
    {
        private bool selected;

        // GET: EmployeesController
        public ActionResult Index()
        {
            //List<Employee> objlist = new List<Employee>();
            //objlist.Add(new Employee { EmpNo=1,Name="abc",Basic=10000,DeptNo=10});
            //objlist.Add(new Employee { EmpNo = 2, Name = "bcd", Basic = 20000, DeptNo = 20 });
            //objlist.Add(new Employee { EmpNo = 3, Name = "cde", Basic = 30000, DeptNo = 30 });
            List<Employee> objlist = Employee.GetAllEmployees();

            return View(objlist);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            Employee obj1 = Employee.GetSingleEmployee(id);

            //Employee obj = new Employee();
            //obj.EmpNo = 10;
            //obj.Name= "Nikesh";
            //obj.Basic =20000;
            //obj.DeptNo = 30;


            return View(obj1);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
             
               List<SelectListItem> l = new List<SelectListItem>();
             foreach(var i in Employee.GetAllDepartments()) {
                l.Add(new SelectListItem(i.DeptNo.ToString(), i.DeptNo.ToString()));
            }
                
            ViewData["D"]= l;
            
            return View();

            
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        //string name=collection["name"];
        //        //string empno = collection["EmpNo"];
        //        //string deptno = collection["DeptNo"];
        //        //string basic = collection["Basic"];

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        //vairale name must be same as html control name
        //public ActionResult Create(int EmpNo, string Name, decimal Basic, int DeptNo)//better for less number of items
        //{
        //    try
        //    {
        //        Employee emp = new Employee();

        //        emp.EmpNo = EmpNo;
        //        emp.Name = Name;
        //        emp.Basic = Basic;
        //        emp.DeptNo = DeptNo;
        //        //EmpNo=emp.EmpNo;
        //        //Name=emp.Name;
        //        //Basic=emp.Basic;
        //        //DeptNo=emp.DeptNo;
        //        Employee.Insert(emp);

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Create(Employee obj)
        {
          
            try
            {
                Employee.Insert(obj);
              

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();

            }
            
            
        }
       // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee obj = Employee.GetSingleEmployee(id);
            List<SelectListItem> l = new List<SelectListItem>();
            foreach (var i in Employee.GetAllDepartments())
            {
                l.Add(new SelectListItem(i.DeptName,i.DeptNo.ToString()));
            }

            ViewData["DeptNo"] = l;


            return View(obj);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee obj)
        {
            try
            {
                Employee.UpdateWithStoredProcedure(obj);
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
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Employee.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        


    }
}
