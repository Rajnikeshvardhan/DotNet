namespace StaticMembers
{
    internal class Program
    {
        static void Main()
        {
            //Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(Class1.si);
            Class1.si = 12345;
            Class1.sProp1 = 123;
            Class1.sDisplay();
            Class1 o1;
            o1 = new Class1();
            Class1 o2 = new Class1();

            o1.i = 100;
            o2.i = 200;
            o1.Prop1 = 100;
            Console.WriteLine(o1.i);
            Console.WriteLine(o2.i);
            o1.Display();
            o2.Display();

            
        }
    }
    public class Class1
    {
        public int i;
        //static variable - single copy 
        public static int si;
        public void Display()
        {
            Console.WriteLine("display");
            Console.WriteLine(i);
            Console.WriteLine(si);
        }
        //static method - can be called directly classname.methodname
        //without creating an object

        public static void sDisplay()
        {
            Console.WriteLine("static display");
            //from a static member you can only access static members directly.
            //to access a non static member you need to have an object reference
            //Console.WriteLine(i);  //error
            Console.WriteLine(si);

        }

        private int prop1;
        public int Prop1
        {
            set
            {
                if (value > 100)
                    Console.WriteLine("invalid value");
                else
                    prop1 = value;
            }
            get
            {
                return prop1;
            }
        }
        private static int sprop1;
        public static  int sProp1
        {
            set
            {
                if (value > 100)
                    Console.WriteLine("invalid value");
                else
                    sprop1 = value;
            }
            get
            {
                return sprop1;
            }
        }
        //static constructor is implicitly private - cannot have an access specifier
        //static cons is implicitly called
        //static cons is parameterless - and therefore cannot be overloaded
        static Class1()
        {
            Console.WriteLine("static cons called");
            si = 99999;
            sProp1 = 99;
        }
    }
}
//why property - validations
//why static variable - single copy
//why static property - single copy with validations
//why static constructor? - to initialise the static data members
//when does the static constructor get called? - when the class is initialised
// when is the class initialised? - when the first object is created
//                                  OR when the first static member is accessed.

//to do 
//create a static class
//can only have static members
//cannot be instantiated
//cannot be a base class

