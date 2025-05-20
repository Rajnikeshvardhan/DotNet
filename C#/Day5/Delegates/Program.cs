namespace Delegates
{
    //step1 : create a delegate class having the same signature as the func to call
    public delegate void Del1();
    public delegate int DelAdd(int a, int b);
    //Object
    //Delegate
    //MulticastDelegate
    //Del1
    internal class Program
    {
        static void Main1()
        {
            //step 2 :
            //declare a delegate reference.
            // create a delegate object, passing func name as a parameter
            // make delegate referece point to delegate object
            Del1 objDel = new Del1(Display);

            //step 3 : call the func via the delegate reference
            objDel();
        }
        static void Main2()
        {
            Del1 objDel = Display;
            objDel();

            objDel = Show;
            objDel();
            objDel();
        }
        static void Main3()
        {
            Del1 objDel = Display;
            objDel();

            Console.WriteLine();
            objDel += Show;
            objDel();

            Console.WriteLine();
            objDel += Display;
            objDel();

            Console.WriteLine();
            objDel -= Display;
            objDel();

            Console.WriteLine();
            objDel -= Show;
            objDel();

            Console.WriteLine();
            objDel -= Display;
            objDel();

        }
        static void Main4()
        {
            DelAdd objDelAdd = Add;
            //int ans = objDelAdd(10, 5);
            //Console.WriteLine(ans);
            Console.WriteLine(objDelAdd(10,5));


        }
        static void Main5()
        {
            DelAdd objDelAdd = Add;
            objDelAdd += Subtract;
            Console.WriteLine(objDelAdd(10, 5));

            //int ans;
            //ans = Add(10, 5);
            //ans = Subtract(10, 5);

        }
        static void Main6()
        {
            //Class1.Display();
            Del1 objDel = Class1.Display;
            objDel();

            Class1 objClass1 = new Class1();
            objDel = objClass1.Show;

        }

        static void Main7()
        {
            Del1 objDel = (Del1) Delegate.Combine(new Del1(Display), new Del1(Show), new Del1(Display));
            objDel();

            Console.WriteLine();
            //objDel = (Del1)Delegate.Remove(objDel, new Del1(Display));
            objDel = (Del1)Delegate.RemoveAll(objDel, new Del1(Display));
            objDel();
        }
        static void Display()
        {
            Console.WriteLine("display called");
        }
        static void Show()
        {
            Console.WriteLine("Show called");
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Subtract(int a, int b)
        {
            return a - b;
        }

        static void Main()
        {
            Console.WriteLine(CallMathOperation(Add,20,10));
            Console.WriteLine(CallMathOperation(Subtract,10,5));
        }
        //passing func as a parameter using delegates
        static int CallMathOperation(DelAdd objMath, int a, int b)  //objMath = Subtract
        {
            return objMath(a, b);
        }
    }

    public class Class1
    {
        public static void Display()
        {
            Console.WriteLine("display called");
        }
        public void Show()
        {
            Console.WriteLine("Show called");
        }
    }
}
