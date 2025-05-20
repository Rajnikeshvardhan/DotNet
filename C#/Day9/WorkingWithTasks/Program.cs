//calling a method with void return type using taskobj.Start
namespace WorkingWithTasks
{
    internal class Program
    {
        static void Main1()
        {
            //Task t0 = new Task(new Action(Func1));

            Task t1 = new Task(Func1);
            Task t2 = new Task(Func2);
            t1.Start();
            t2.Start();

            //t1.Wait(); //waiting call
            //t2.Wait();

            Console.ReadLine();
        }
        static void Func1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First : " + i);
            }
        }
        static void Func2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("second Func called from {0},{1}",
                    Thread.CurrentThread.ManagedThreadId, i);
            }
        }
    }
}

//calling a method with void return type using Task.Run and Task.Factory.StartNew
namespace Example2
{
    class Program
    {
        static void Main2()
        {
            Task t1 = Task.Run(Func1);
            Task t2 = Task.Factory.StartNew(Func2);
            Console.ReadLine();
        }
        static void Func1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("first Func called from {0},{1}", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
        static void Func2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("second Func called from {0},{1}", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
    }
}

//calling a method with void return type and parameters 
namespace Example3
{
    class Program
    {
        static void Main3()
        {
            //Task t1 = new Task(new Action<object>(Func1), "passed data");
            Task t1 = new Task(Func1, "passed data");
            t1.Start();

            Task t2 = Task.Factory.StartNew(Func2, "passed data");

            //Task t3 = Task.Run()
            //Task.Run - cannot be used with parameters. 
            //use anonymous methods instead to access variables declared in calling code
            string s = "ccc";
            Task.Run(delegate () { Console.WriteLine(s); });
            Task.Run(() => { Console.WriteLine(s); });
            Console.ReadLine();
        }
        static void Func1(object obj)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("first Func called {0}{1}", i, obj.ToString());
            }
        }
        static void Func2(object obj)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("second Func called {0},{1}", i, obj.ToString());
            }
        }
    }
}

//calling methods with return value 
namespace Example4
{
    class Program
    {
        static void Main1()
        {
            //Task<int> t1 = new Task<int>(new Func<int>(Func1));
            Task<int> t1 = new Task<int>(Func1);
            t1.Start();

            Task<int> t2 = new Task<int>(Func2, "passed value");
            t2.Start();

            Console.WriteLine("finish other code");

            //get the return value
            //if(!t1.IsCompleted)
            //{
            //    t1.Wait();
            //}
            Console.WriteLine(t1.Result); //waiting call
            Console.WriteLine(t2.Result); //waiting call

            Console.ReadLine();
        }
        static void Main()
        {
            Task<int> t1 = Task.Factory.StartNew<int>(Func1);
            Task<int> t2 = Task.Run<int>(Func1);

            Console.WriteLine(t1.Result);
            Console.WriteLine(t2.Result);

            Task<int> t3 = Task.Factory.StartNew<int>(Func2, "passed value"); ;
            Console.WriteLine(t3.Result);

           

        }

        static int Func1()
        {
            int i;
            for (i = 0; i < 10; i++)
            {
                Console.WriteLine("first Func called {0}", i);
            }
            return i;
        }
        static int Func2(object obj)
        {
            int i;
            for (i = 0; i < 20; i++)
            {
                Console.WriteLine("second Func called {0},{1}", i, obj.ToString());
            }
            return i;
        }
    }
}
