
namespace EmployeeExample3
{
    internal class Program
    {
        static void Main()
        {
            //Manager m = new Manager();
            //m.Insert();

            //Employee employee = new Employee();
            //employee.EmpNo = 10;
            IDbFunctions oIDb;
            oIDb = new Manager();
            oIDb.Insert();
        }
    }
    public abstract class Employee : IDbFunctions
    {

        string name; //-> no blank names should be allowed
        int empNo; //-> must be greater than 0
        protected decimal basic;// -> must be between some range
        short deptNo;// -> must be > 0
        static int lastEmpNo = 0;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != "")
                    name = value;
                else
                    Console.WriteLine("Invalid Name");
            }
        }
        public int EmpNo
        {
            get { return empNo; }

            //property accessor
            //any one of set / get can be given a lesser access
            //you can only reduce access, not increase it
            private set
            {
                if (value > 0)
                    empNo = value;
                else
                    Console.WriteLine("Invalid EmpNo");
            }
        }
        public abstract decimal Basic
        {
            get;
            set;
        }
        public short DeptNo
        {
            get { return deptNo; }
            set
            {
                if (value > 0)
                    deptNo = value;
                else
                    Console.WriteLine("Invalid EmpNo");
            }
        }
        public abstract decimal GetNetSalary();

        public void Insert()
        {
            Console.WriteLine("Employee Insert");
        }

        public Employee( string Name = "default", decimal Basic = 10000, short DeptNo = 1)
        {
            this.EmpNo = ++lastEmpNo;  //property - set
            this.Name = Name;
            this.Basic = Basic;
            this.DeptNo = DeptNo;
        }
    }

    public class Manager : Employee, IDbFunctions
    {
        public Manager(string Name = "default", decimal Basic = 10000, short DeptNo = 1, string Designation = "Desig") : base(Name, Basic, DeptNo)
        {
            this.Designation = Designation;
        }
        public new void Insert()
        {
            Console.WriteLine("Mgr Insert");
        }
        public string Designation { get; set; }
        public override decimal Basic 
        {
            get { return basic; }
            set
            {
                if(value >=10000 && value <=50000)
                    this.basic = value;
                else
                    Console.WriteLine( "invalid");
            }
        }

        public override decimal GetNetSalary()
        {
            return Basic * 2;
        }
    }

    public interface IDbFunctions
    {
        void Insert();
    }
}
