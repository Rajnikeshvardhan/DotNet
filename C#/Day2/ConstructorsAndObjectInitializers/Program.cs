namespace ConstructorsAndObjectInitializers
{
    internal class Program
    {
        static void Main1()
        {
            Employee obj = new Employee();
            Console.WriteLine(obj.EmpNo);
            Console.WriteLine(obj.Name);
            Console.WriteLine(obj.Basic);

            Employee obj2 = new Employee(10,20,30);
            Console.WriteLine(obj2.EmpNo);
            Console.WriteLine(obj2.Name);
            Console.WriteLine(obj2.Basic);

           // Employee obj3 = new Employee()
          // obj = null;

        }
        static void Main()
        {
            Employee2 obj = new Employee2();
            obj.EmpNo = 10;
            obj.Name = 20;
            obj.Basic = 30;

            //object initializer
            Employee2 obj2 = new Employee2() { EmpNo = 10, Name = 20, Basic = 30 };
            Employee2 obj3 = new Employee2{ EmpNo = 10, Name = 20, Basic = 30 };
            Console.WriteLine(obj2.EmpNo);
        }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public int Name { get; set; }
        public int Basic { get; set; }
        //public Employee()
        //{
        //    Console.WriteLine("no parameter cons called");
        //    EmpNo = 1;
        //    Name = 2;
        //    Basic = 3;
        //}
        //public Employee(int EmpNo, int Name, int Basic)
        //{
        //    Console.WriteLine("parameterised cons called");
        //    this.EmpNo = EmpNo;
        //    this.Name = Name;
        //    this.Basic = Basic;
        //}

        //default values
        public Employee(int EmpNo = 1, int Name = 2, int Basic = 3)
        {
            Console.WriteLine("parameterised cons called");
            this.EmpNo = EmpNo;
            this.Name = Name;
            this.Basic = Basic;

        }

        //DO NOT DO THIS
        //~Employee()
        //{
        //    Console.WriteLine("destructor called");

        //}
    }

    public class Employee2
    {
        public int EmpNo { get; set; }
        public int Name { get; set; }
        public int Basic { get; set; }
 
    }
}
