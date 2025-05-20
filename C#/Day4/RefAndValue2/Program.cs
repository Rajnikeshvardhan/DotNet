namespace RefAndValue2
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            int x, y; //local variables - unassigned
            Init(out x, out y);
            Swap(ref x, ref y);
            Print(in x);
            Print(y);
            //Console.WriteLine(x);
            //Console.WriteLine(y);
        }
        //ref - changes made in func reflect back in calling code
         static void Swap(ref int a,ref int b)//a = x, b = y
        {
            int temp = a;
            a = b;
            b = temp;
        }
        //out - changes made in func reflect back in calling code
        //the initial value is discarded
        //out variables MUST be initialized in the function
        static void Init(out int a, out int b)
        {
            // Console.WriteLine(a); //error
            a = 100;
            b = 200;
        }
        static void Print(in int x)
        {
            //x is a readonly value
            //x = 100; //error
            Console.WriteLine(x);

        }
    }
}
