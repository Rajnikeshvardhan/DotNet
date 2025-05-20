using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            //System.Console.WriteLine("Hello, World!");
            //Console.WriteLine("H W");
            Class1 o; //o is a reference of type Class1
            o = new Class1(); //new Class1() is an object
            o.Display();
            o.Display("aaa");

            //positional parameters
            Console.WriteLine(o.Add(10, 20, 30));
            Console.WriteLine(o.Add(10, 20));
            Console.WriteLine(o.Add(10));
            Console.WriteLine(o.Add());

            //named parameters
            Console.WriteLine(o.Add(a: 10, b: 20, c: 30));
            Console.WriteLine(o.Add(c: 30));
            Console.WriteLine(o.Add(b: 20));

        }
    }
    public class Class1 
    { 
        public void Display()
        {
            Console.WriteLine("Display called");
        }
        public void Display(string s)
        {
            Console.WriteLine("Display called" + s);
        }

       //func with default values
        public int Add(int a=0, int b=0,  int c=0)
        {
            return a + b + c;
        }
    }

}
