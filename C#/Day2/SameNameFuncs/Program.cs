namespace SameNameFuncs
{
    internal class Program
    {
        static void Main1()
        {
            DerivedClass obj = new DerivedClass();
            obj.Display1(); //base
            obj.Display1(""); //derived

            obj.Display2();
            obj.Display3();
        }
        static void Main(string[] args)
        {
            BaseClass o;
            o = new BaseClass();
            //non virtual method - depends on how the reference has been declared
            //o.Display2();  
            //virtual method - depends on what object it is pointing to
            o.Display3();

            o = new DerivedClass();
            //non virtual method - depends on how the reference has been declared
            //o.Display2();
            //virtual method - depends on what object it is pointing to
            o.Display3();

            o = new SubDerivedClass();
            //non virtual method - depends on how the reference has been declared
            //o.Display2();
            //virtual method - depends on what object it is pointing to
            o.Display3();


            Console.WriteLine();
            o = new SubSubDerivedClass();
            //o.Display2();
            o.Display3();

        }
    }
    public class BaseClass
    {
        public void Display1()
        {
            Console.WriteLine("base Display1");
        }
        public void Display2()
        {
            Console.WriteLine("base Display2");
        }
        public virtual void Display3()
        {
            Console.WriteLine("base Display3");
        }
    }

    public class DerivedClass :BaseClass
    {
        //overloads base class method
        public void Display1(string s)
        {
            Console.WriteLine("Derived Display1");
        }

        //hides the base class method
        public new void Display2()
        {
            Console.WriteLine("derived Display2");
        }

        //overrides the base class method
        public override void Display3()
        {
            Console.WriteLine("derived Display3");
        }
    }

    public class SubDerivedClass : DerivedClass
    {

        //overrides the base class method
        public sealed override void Display3()
        {
            Console.WriteLine("subderived Display3");
        }
    }

    public class SubSubDerivedClass : SubDerivedClass
    {

        //overrides the base class method
        public new void Display3()
        {
            Console.WriteLine("subsubderived Display3");
        }
    }
}
/*
 Employee
   EmpNo,Basic...
   CalcNetSalary()


Manager : Employee

----------------------------------

1. Derived Class (Manager) can overload the base class(Employee) method

Manager : Employee
   CalcNetSalary(......) - same method name, diff parameters

Manager m = new Manager();
m.CalcNetSalary();  -- base class
m.CalcNetSalary(.....); -- derived class

2. Derived Class (Manager) can hide the base class(Employee) method

Manager : Employee
   CalcNetSalary() - same method name, same parameters


Manager m = new Manager();
m.CalcNetSalary(); -- derived class

ANY method can be hidden

3. Derived Class (Manager) can override the base class(Employee) method

Manager : Employee
   CalcNetSalary() - same method name, same parameters


Manager m = new Manager();
m.CalcNetSalary(); -- derived class

only a virtual method can be overridden
--------------------------------------------

virtual method
- late bound
- run time binding
- run time polymorphism
- method to call is decided at run time.

Employee e;
e = new Employee();
e.CalcNetSalary();  -- Employee

e = new Manager();
e.CalcNetSalary();  -- Manager

 */ 