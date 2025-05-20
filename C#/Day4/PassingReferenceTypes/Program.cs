namespace PassingReferenceTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 obj = new Class1();
            obj.i = 100;
            //DoSomething1(obj);
            //DoSomething2(obj);
            //DoSomething3(ref obj);
            //DoSomething4(out obj);
            DoSomething5(in obj);
            Console.WriteLine(obj.i);
        }
        static void DoSomething1(Class1 o2) //o2 = obj
        {
            //pass a reference type
            //changes made in func reflect back in calling code
            o2.i = 200;
        }
        static void DoSomething2(Class1 o2) //o2 = obj
        {
            //making o2 point to something else DOES NOT reflect back in calling code
            o2 = new Class1();
            o2.i = 200;
        }
        static void DoSomething3(ref Class1 o2) //o2 = obj
        {
            //making o2 point to something else reflects back in calling code
            //IF passed as a ref
            o2 = new Class1();
            o2.i = 200;
        }
        static void DoSomething4(out Class1 o2) //o2 = obj
        {
            //making o2 point to something else reflects back in calling code
            //IF passed as a out
            //o2 loses its initial value
            //o2 MUST be initialised

            o2 = new Class1();
            o2.i = 200;
        }
        static void DoSomething5(in Class1 o2) //o2 = obj
        {
            //o2 = new Class1(); //error - o2 is readonly
            //for a reference type readonly means it cant point to something else
            //BUT data can be changed
            o2.i = 200;
        }
    }
    public class Class1
    {
        public int i;
    }
}
