namespace Arrays
{
    internal class Program
    {
        static void Main1()
        {
            int[] arr = new int[5];
            //arr[0] = 0;
            //arr[4] = 40;
            for (int i = 0; i < arr.Length; i++)
            {
                // Console.Write("enter value for arr[" + i + "] : ");  //string concatenation
                //Console.Write("enter value for arr[{0}] : ", i);  //placeholders
                Console.Write($"enter value for arr[{i}] : ");  //string interpolation

                //Console.WriteLine("enter value for arr[0]");
                arr[i] = int.Parse(Console.ReadLine());
                //arr[i] = int.Parse(Console.ReadLine()!);
                //arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine($"value for arr[{i}] is {arr[i]} ");
            //}
            foreach (int item in arr)
            {
                //item = 0; // item is readonly
                Console.WriteLine(item);
            }
        }
        static void Main2()
        {
            int[] arr = new int[5] { 10, 20, 30, 40,50 };
            int[] arr2 = { 10, 20, 30, 40};

            int pos = Array.IndexOf(arr, 30);
            pos = Array.LastIndexOf(arr, 30);
            pos = Array.BinarySearch(arr, 30);
            if (pos < 0)
            //if (pos == -1)
                Console.WriteLine("not found");
            else
                Console.WriteLine("found at " + pos);
            //Array.Clear(arr);
            //Array.Copy(arr,arr2, arr.Length);
            ////Array.ConstrainedCopy()
            //Array.Sort(arr);
            //Array.Reverse(arr2);


                foreach (int item in arr)
                {
                    //item = 0; // item is readonly
                    Console.WriteLine(item);
                }
        }

        static void Main3()
        {

            int[,] arr = new int[3,5];
            //arr[0,0] arr[0,1] arr[0,2] arr[0,3] arr[0,4] 
            //arr[1,0] arr[1,1] arr[1,2] arr[1,3] arr[1,4] 
            //arr[2,0] arr[2,1] arr[2,2] arr[2,3] arr[2,4] 

            //Console.WriteLine(arr.Rank);  //2

            //Console.WriteLine(arr.Length);  //15
            //Console.WriteLine(arr.GetLength(0));  //3
            //Console.WriteLine(arr.GetLength(1));  //5

            //Console.WriteLine(arr.GetUpperBound(0));  //2
            //Console.WriteLine(arr.GetUpperBound(1));  //4
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"enter value for arr[{i},{j}] : ");  //string interpolation
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine($"value for arr[{i},{j}] is {arr[i,j]} ");  //string interpolation
                }
                Console.WriteLine();
            }
        }

        static void Main4()
        {
            //jagged
            int[][] arr = new int[4][];

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = new int[x]
            //}

            arr[0] = new int[3]; // arr[0][0] arr[0][1] arr[0][2]
            arr[1] = new int[4]; // arr[1][0] arr[1][1] arr[1][2] arr[1][3]
            arr[2] = new int[2];//  arr[2][0] - arr [2][1]
            arr[3] = new int[3];//  arr[3][0] arr[3][1] arr[3][2]

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write("enter value for subscript [{0}][{1}] : ", i, j);
                    arr[i][j] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine();
                Console.WriteLine();
            }


            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.WriteLine("value for subscript {0},{1} is {2}  ", i, j, arr[i][j]);

                }
            }
            Console.ReadLine();
        }

        static void Main()
        {
            //int[] arr = new int[5];
            Employee[] arr = new Employee[5];
            //arr[0] = new Employee();
            //arr[1] = new Employee();
            //arr[2] = new Employee();
            //arr[3] = new Employee();
            //arr[4] = new Employee();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Employee();
                //arr[i].EmpNo = Console.ReadLine();
                //arr[i].Name = Console.ReadLine();
            }
            //foreach (Employee item in arr)
            //{

            //    item.Name = Console.ReadLine();
            //}
        }

    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }

    }
}


