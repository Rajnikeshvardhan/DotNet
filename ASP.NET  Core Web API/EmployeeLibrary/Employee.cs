using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace EmployeeLibrary
{
    public class Employee
    {
        public int e;
        [Key]
        [Required]
        [Display(Name = "Employee Number")]
        [Range(1, 100000, ErrorMessage = "Enter a valid Employee Number")]
        public int EmpNo
        {
            get { return e; }
            set
            {
                if (value > 0)
                    e = value;
            }
        }




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
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HydMay25;Integrated Security=True;";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees where EmpNo=@EmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);
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
                //command
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";

                SqlDataReader dr = cmd.ExecuteReader();
                //dr.HasRows --->t/f

                while (dr.Read())
                {
                    //Console.WriteLine(dr[1]);
                    //Console.WriteLine(dr["Name"]);
                    Employee emp = new Employee();

                    //emp.EmpNo = (int)dr["EmpNo"];
                    //emp.EmpNo = (int)dr[0];
                    emp.EmpNo = dr.GetInt32("EmpNo");
                    //emp.EmpNo = dr.GetInt32(0);

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
        public static void Insert(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HydMay25;Integrated Security=True;";
            try
            {
                cn.Open();
                //command
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
$"insert into Employees values({obj.EmpNo},'{obj.Name}',{obj.Basic}, {obj.DeptNo})";

                Console.WriteLine(cmd.CommandText);

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
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HydMay25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            try
            {
                cn.Open();
                //command
                SqlCommand cmd = new SqlCommand("UpdateEmployee", cn);
                //SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //cmd.CommandText = "UpdateEmployee";
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
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HydMay25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            try
            {
                cn.Open();
                //command
                SqlCommand cmd = new("delete from employees where EmpNo=" + id, cn);
                //SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                //cmd.CommandText = $"insert into Employees values({obj.EmpNo},'{obj.Name}',{obj.Basic},{obj.DeptNo})";
                cmd.ExecuteNonQuery();
                //Console.WriteLine("Inserted2");

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

        public static implicit operator List<object>(Employee v)
        {
            throw new NotImplementedException();
        }
    }
}
