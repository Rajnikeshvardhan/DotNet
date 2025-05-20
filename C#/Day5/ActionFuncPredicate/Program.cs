namespace ActionFuncPredicate
{
    internal class Program
    {
        static void Main1()
        {
            //Action o1 = new Action(Display);
            Action o1 = Display;
            o1();
            Action<string> o2 = Display;
            o2("aaa");
           Action<string, int> o3 = Display;
            o3("aa", 10);
        }

        static void Main()
        {
            Func<string> o1 = GetTime;
            Console.WriteLine(o1());

            Func<int, int> o2 = MakeDouble;
            Console.WriteLine(o2(10));

            Func<int, int, int> o3 = Add;
            Console.WriteLine(o3(10, 20));
            
            Func<int,bool> o4 = IsEven;
            Console.WriteLine(o4(10));

            Employee obj = new Employee { Basic = 20000 };
            Func<Employee, bool> o5 = IsBasicGreaterThan10000;
            Console.WriteLine(o5(obj));

            Predicate<int> o6 = IsEven;
            Console.WriteLine(o6(10));

            Predicate<Employee> o7 = IsBasicGreaterThan10000;
            Console.WriteLine(o7(obj));

        }
        static void Display()
        {
            Console.WriteLine("display called");
        }
        static void Display(string s)
        {
            Console.WriteLine("display called" + s);
        }
        static void Display(string s, int i)
        {
            Console.WriteLine("display called" + s  + i);
        }

        static string GetTime()
        {
            return DateTime.Now.ToLongTimeString();
        }
        static int MakeDouble(int a)
        {
            return a * 2;
        }
        static bool IsEven(int a)
        {
            if (a % 2 == 0)
                return true;
            else
                return false;
        }
        static int Add(int a, int b)
        {
            return a + b;
        }

        static bool IsBasicGreaterThan10000(Employee emp)
        {
            if(emp.Basic >10000)
                return true;
            else
                return false;
        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public decimal Basic { get; set; }

    }
}
