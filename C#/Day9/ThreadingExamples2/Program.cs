namespace ThreadingExamples2
{
    internal class Program
    {
        static void Main()
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Func1));
            //t1.Start("data");
            t1.Start(10);

            Thread t2 = new Thread(Func2);
            int[] arr = new int[2] { 10, 20 };
            arr[0] = 10;
            arr[1] = 20;
            t2.Start(arr);


            Thread t3 = new Thread(delegate(object obj)
            {
                Console.WriteLine(arr[0]);
                Console.WriteLine(arr[1]);
                //for (int i = 0; i < 1000; i++)
                //{
                //    Console.WriteLine("Second : " + i + obj.ToString());
                //}
            });
            t3.Start();
        }

        static void Func1(object obj)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First : " + i + " " + obj.ToString());
            }
        }
        static void Func2(object obj)
        {
            int[] arr = (int[])obj;
            Console.WriteLine(arr[0]);
            Console.WriteLine(arr[1]);
            //for (int i = 0; i < 1000; i++)
            //{
            //    Console.WriteLine("Second : " + i + obj.ToString());
            //}
        }
      
    }
}
/*
 To pass multiple parameters to the functions
1. array
2. collection
3. create a class/struct that has multiple properties.
pass an obj of class/struct
4. create a local func/anon method/lambda
 */