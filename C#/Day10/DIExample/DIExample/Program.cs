using System;

namespace DIExample
{
    class Program //injector class
    {
        static void Main()
        {
            Employee emp = new Employee { EmpNo = 1, Name = "Vikram", Basic = 12345, DeptNo = 10 };
            //constructor injection
            EmployeeClient obj = new EmployeeClient(emp);
            obj.Display();
        }
        static void Main2()
        {

            Employee emp = new Employee { EmpNo = 1, Name = "Vikram", Basic = 12345, DeptNo = 10 };
            EmployeeClient obj = new EmployeeClient();
            //property injection
            obj.Emp = emp;
            obj.Display();
        }
        static void Main3()
        {

            Employee emp = new Employee { EmpNo = 1, Name = "Vikram", Basic = 12345, DeptNo = 10 };
            EmployeeClient obj = new EmployeeClient();
            //method injection
            obj.SetEmp(emp);
            obj.Display();
        }
    }

    public class EmployeeClient
    {
        private Employee emp;
        public EmployeeClient()
        {
        }

        //constructor injection - object passed thru constructor
        public EmployeeClient(Employee emp)
        {
            this.emp = emp;
        }

       //property injection - object passed thru property
        public Employee Emp
        {
            set
            {
                emp = value;
            }
        }




        //method injection - object passed thru method
        public void SetEmp(Employee emp)
        {
            this.emp = emp;
        }



        public void Display()
        {
            Console.WriteLine(emp.EmpNo);
            Console.WriteLine(emp.Name);
        }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
    }
}





//https://en.wikipedia.org/wiki/Dependency_injection

//read more at https://www.tutorialsteacher.com/ioc/introduction
