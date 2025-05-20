namespace ExtensionMethods
{
    internal class Program
    {
        static void Main1()
        {
            
            int a = 100;
            a = a.Add(10);
            a.Display();
            a.ExtMethodForBaseClass();  
            string s = "aaa";
            s.Show();
            s.ExtMethodForBaseClass();
        }
        static void Main2()
        {
            int a = 100;
            //a = a.Add(10);
            //a.Display();
            a = MyExtClass.Add(a, 10);
            MyExtClass.Display(a);
            string s = "aaa";
            //s.Show();
            MyExtClass.Show(s);
        }
        static void Main()
        {
            ClsMaths objClsMaths = new ClsMaths();
            Console.WriteLine(objClsMaths.Multiply(10, 20));
            Console.WriteLine(objClsMaths.Add(10, 20));
            Console.WriteLine(objClsMaths.Subtract(40, 20));

        }
        //static void Main4()
        //{
        //    class1 o = new class1 { a = 10, b = 20 };
        //    int x = o.a + o.b;
        //    int y = o.AddAllProperties();

        //}
    }

    class class1
    {
        public int a;
        public int b;
    }
    //step 1  : create a static method in a static class
    public static class MyExtClass
    {
        //step 2 :
         //the first parameter must be the type you
         //are writing an extension method, preceded by the 'this' keyword
        public static void Display(this int i)
        {
            Console.WriteLine(i);
        }
        public static void Show(this string s)
        {
            Console.WriteLine(s);
        }
        public static int Add(this int i, int j)
        {
            return i + j;
        }
        //if you add an ext method for the base class,
        //it is also available for the derived class
        public static void ExtMethodForBaseClass(this object o)
        {
            Console.WriteLine(o);
        }
        //if you add an ext method for an interface,
        //it is also available for all classes that implement that interface
        public static int Subtract(this IMathOperations objIMath, int a, int b)
        {
            return a - b;
        }
    }
    public interface IMathOperations
    {
        int Add(int a, int b);
        int Multiply(int a, int b);
    }
    public class ClsMaths : IMathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }

}
