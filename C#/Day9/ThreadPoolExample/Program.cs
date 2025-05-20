namespace ThreadPoolExample
{
    internal class Program
    {
        static void Main()
        {
            //ThreadPool.QueueUserWorkItem(new WaitCallback(Func1));
            ThreadPool.QueueUserWorkItem(Func1);
            ThreadPool.QueueUserWorkItem(Func2, "data");
            Console.ReadLine();
        }
        static void Main2()
        {
            int workerthreads, iothreads;
            ThreadPool.GetAvailableThreads(out workerthreads, out iothreads);
            ////ThreadPool.SetMinThreads()
            ////ThreadPool.SetMaxThreads
            //ThreadPool.GetMinThreads(out workerthreads, out iothreads);
            //ThreadPool.GetMaxThreads(out workerthreads, out iothreads);
            Console.WriteLine(workerthreads);
            Console.WriteLine(iothreads);

            Console.ReadLine();
        }
        static void Func1(object obj)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First : " + i + " " );
            }
        }
        static void Func2(object obj)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Second : " + i + " " + obj.ToString());
            }
        }
    }
}
