namespace AbstractClasses
{
    internal class Program
    {
        static void Main()
        {
            //AbsClass1 o = new AbsClass1();
            Derived1 o1 = new Derived1();
            o1.M1();
            Derived2 o2 = new Derived2();
            o2.Display();
        }
    }

    public abstract class AbsClass1
    {
        public void M1()
        {
            Console.WriteLine("M1");
        }
    }
    public class Derived1 : AbsClass1 
    {

    }

    public abstract  class AbsClass2
    {
        public void M1()
        {
            Console.WriteLine("M1");
        }
        public abstract void Display();
        public abstract void Show();
    }
    public class Derived2 : AbsClass2
    {
        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override void Show()
        {
            throw new NotImplementedException();
        }
    }
    public abstract class Derived3 : AbsClass2
    {
        public override void Display()
        {
            throw new NotImplementedException();
        }
    }
}
 