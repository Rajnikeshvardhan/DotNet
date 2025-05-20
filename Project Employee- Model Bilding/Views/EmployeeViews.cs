using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Modelbild.Models;
using System.Data;

namespace Modelbild.Views
{
    public class EmployeeViews
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
   
    
    }
}
