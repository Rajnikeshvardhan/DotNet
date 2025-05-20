using System.Collections;

namespace OperatorOverloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList o = new ArrayList();
            o[0] = 10;
            //o.this[0] = 10;
            Console.WriteLine(o[0]);
            //Console.WriteLine(o.this[0]);


            Employee e1 = new Employee { EmpNo = 1, Name = "Vik", Basic = 12345, DeptNo = 10 };
            Employee e2 = new Employee { EmpNo = 2, Name = "Ram", Basic = 22345, DeptNo = 20 };
            e1 = e1 + 5;
            //e1 = Employee.operator+(e1,5)
            e1 = e1 * e2;
            //e1 = Employee.operator*(e1,e2)


            Console.WriteLine(e1.EmpNo);
        }
    }

    public class Employee
    {
        public static Employee operator*(Employee e1, Employee e2)
        {
            Employee retval = new Employee();
            retval.Name = e1.Name;
            retval.DeptNo = e2.DeptNo;
            retval.EmpNo = e1.EmpNo;
            retval.Basic = e2.Basic;
            return retval;
        }
        public static Employee operator+(Employee e1, int i)
        { 
            Employee retval = new Employee();
            retval.Name = e1.Name;
            retval.DeptNo = e1.DeptNo;
            retval.EmpNo = e1.EmpNo + i;
            retval.Basic = e1.Basic;
            return retval;
        }
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
    }
}
