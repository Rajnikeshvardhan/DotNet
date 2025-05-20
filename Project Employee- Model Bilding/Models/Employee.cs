using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection.Metadata;

namespace Modelbild.Models
{
    public class Employee
    {
        public int e ; 
        [Key]
        [Required(ErrorMessage =" invalid ")]
        [Display(Name = "Employee Number")]
        [Range(1, 100000, ErrorMessage = "Enter a valid Employee Number")]
        public int EmpNo { get; set; }   
        [Display(Name = "Employee Name")]
        public string Name { get; set; }
        [Display(Name = "Basic Salary")]
        public decimal Basic { get; set; }
        [Display(Name = "Department Number")]
        public int DeptNo { get; set; }
        //public IEnumerable<SelectListItem> Departments { get; set; }
       


        public static Employee GetSingleEmployee(int EmpNo)
        {
            Employee emp = null;
            SqlConnection cn = new("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HydMay25;Integrated Security=True");
           

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from Employees where EmpNo="+ EmpNo, cn);
                cmd.CommandType = CommandType.Text;
                
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    emp = new Employee();
                    emp.EmpNo = dr.GetInt32("EmpNo");
                    emp.Name = dr.GetString("Name");
                    emp.Basic = dr.GetDecimal("Basic");
                    emp.DeptNo = dr.GetInt32("DeptNo");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return emp;
        }
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> lstEmps = new List<Employee>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HydMay25;Integrated Security=True;";

            try
            {
                cn.Open();
             
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";

                SqlDataReader dr = cmd.ExecuteReader();
                //dr.HasRows --->t/f

                while (dr.Read())
                {
                    
                    Employee emp = new Employee();

                    
                    emp.EmpNo = dr.GetInt32("EmpNo");
                  

                    emp.Name = dr.GetString("Name");
                    emp.Basic = dr.GetDecimal("Basic");
                    emp.DeptNo = dr.GetInt32("DeptNo");

                    lstEmps.Add(emp);

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

            return lstEmps;
        }
        public static List<Department> GetAllDepartments()
        {
            List<Department> lstEmps = new List<Department>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HydMay25;Integrated Security=True;";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from departments";

                SqlDataReader dr = cmd.ExecuteReader();
                //dr.HasRows --->t/f

                while (dr.Read())
                {
                    
                    Department emp = new Department();

                    
                    emp.DeptName = dr.GetString("DeptName");
                   
                    emp.DeptNo = dr.GetInt32("DeptNo");

                    lstEmps.Add(emp);

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

            return lstEmps;
        }
        public static void Insert(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HydMay25;Integrated Security=True;";
            try
            {
                cn.Open();
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
$"insert into Employees values({obj.EmpNo},'{obj.Name}',{obj.Basic}, {obj.DeptNo})";

                
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

        }
        public static void UpdateWithStoredProcedure(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HydMay25;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("update Employees set name=@Name,Basic=@Basic, DeptNo=@DeptNo  where EmpNo=@EmpNo", cn);
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmd.Parameters.AddWithValue("@Basic", obj.Basic);


                cmd.ExecuteNonQuery();
                Console.WriteLine("Inserted2");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
            finally
            {
                cn.Close();
            }
        }
        public static void Delete(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HydMay25;Integrated Security=True;";
            try
            {
                cn.Open();
                //command
                SqlCommand cmd = new("delete from employees where EmpNo=" + id, cn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw;//Console.WriteLine(ex.Message); ;
            }
            finally
            {
                cn.Close();
            }
        }
        public static Employee SingleEmp(int EmpNo) {
            Employee emp=null;

            SqlConnection cn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HydMay25;Integrated Security=True;");
            try
            {
                cn.Open();
                SqlCommand cmd = new("Select * from employees where EmpNo=@Empno ", cn);
            
                cmd.Parameters.AddWithValue("@Empno",EmpNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emp = new Employee();
                    emp.EmpNo = dr.GetInt32("EmpNo");
                    emp.Name = dr.GetString("Name");
                    emp.Basic = dr.GetDecimal("Basic");
                    emp.DeptNo = dr.GetInt32("DeptNo");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally { cn.Close(); }
            return emp;

        }

    }
}
