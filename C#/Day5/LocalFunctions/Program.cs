namespace LocalFunctions
{
    internal class Program
    {
        static void Main()
        {
            Class1 o = new Class1();
            o.Display();
        }
    }

    public class Class1
    {
        public void Display()
        {
            int i = 100; //local variable
            Console.WriteLine("Display called");
             DoSomething1();
            DoSomething2();
            //func defined inside another function is a local func
            //implicitly private
            //cannot be accessed from any other code
            //cannot be overloaded
            void DoSomething1() //local function
            {
                //local function can access local variables defined in the outer function
                Console.WriteLine(++i);
                Console.WriteLine("Do Something 1");
            }
            static void DoSomething2() //local function
            {
                //static local function CANNOT access local variables defined in the outer function
                //Console.WriteLine(i); //error
                Console.WriteLine("Do Something 2");
            }
        }
      
    }
}
