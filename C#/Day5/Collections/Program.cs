using System;
using System.Collections;

namespace Collections
{
    internal class Program
    {
        static void Main1()
        {
            ArrayList obj = new ArrayList();
            obj.Add(10);
            obj.Add("Vikram");
            obj.Add(true);
            obj.Add(1.2345);

            obj.Insert(0, "inserted");

            ArrayList obj2 = new ArrayList();
            obj2.Add(20);
            obj2.Add(30);

            obj.AddRange(obj2);
            obj.InsertRange(0, obj2);

            obj.Remove("Vikram");
            obj.RemoveAt(0);
            //obj.RemoveRange(index, count)
            obj.RemoveRange(0, 3);

            //obj.Clear(); //like Remove ALl

            //obj.BinarySearch
            //obj.IndexOf
            //obj.LastIndexOf

            ArrayList o3 = (ArrayList)obj.Clone();

            bool isFound = obj.Contains("Vikram");

            object[] arr = new object[obj.Count];
            obj.CopyTo(arr);

            object[] arr2 = obj.ToArray();

            ArrayList obj4 = obj.GetRange(0, 3);

            //obj.Reverse();
            //obj.Sort();

            ArrayList obj5 = new ArrayList();
            obj5.Add(100);
            obj5.Add(200);
            obj5.Add(300);

            obj.SetRange(0, obj5);
            //initial obj 10,20,30,40.....
            //after setrange - 100,200,300,40....

            //obj[0] = "new";  //obj.this[0] = "new" - indexer

            Console.WriteLine(obj.Count);
            foreach (object item in obj)
            {
                Console.WriteLine(item);
            }
        }

        static void Main2()
        {
            ArrayList objArrayList = new ArrayList();
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add("a");
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add("a");
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add("a");
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add("a");
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add("a");
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add("a");
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add("a");
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add("a");
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add("a");
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.TrimToSize();
            Console.WriteLine($"after trim Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

        }

        static void Main3()
        {
            //Hashtable objDictionary = new Hashtable();
            SortedList objDictionary = new SortedList();
            objDictionary.Add(10, "Vikram");
            objDictionary.Add(20, "Shweta");
            objDictionary.Add(30, "Harsh");
            objDictionary.Add(40, "Ananya");

            objDictionary[10] = "changed value";
            objDictionary[50] = "new value";

            objDictionary.Remove(10); //key
            objDictionary.RemoveAt(10); //index

            //objDictionary.Contains
            //objDictionary.ContainsKey
            //objDictionary.ContainsValue

            //objDictionary.GetByIndex(index) //returns value
            // objDictionary.GetKey(index)
            IList keys = objDictionary.GetKeyList();
            IList values = objDictionary.GetValueList();

            //objDictionary.IndexOfKey
            //objDictionary.IndexOfValue

            ICollection keys2 = objDictionary.Keys;
            ICollection values2 = objDictionary.Values;

            //objDictionary.SetByIndex(0, "changed value");

            foreach (DictionaryEntry item in objDictionary)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }
        }
        static void Main4()
        {
            Stack s = new Stack();
            s.Push("pa");
            Console.WriteLine(s.Peek());
            Console.WriteLine(s.Pop());

            Queue q = new Queue();
            q.Enqueue(10);
            Console.WriteLine(q.Peek());
            Console.WriteLine(q.Dequeue());

        }
        static void Main5()
        {
            List<int> lst1 = new List<int>();
            lst1.Add(10);
            foreach (int item in lst1)
            {
                
            }
            List<Employee> lst2 = new List<Employee>();
            lst2.Add(new Employee { EmpNo = 1, Name = "a" });
            lst2.Add(new Employee { EmpNo = 2, Name = "b" });
            lst2.Add(new Employee { EmpNo = 3, Name = "c" });

            foreach (Employee item in lst2)
            {
                Console.WriteLine(item.EmpNo);
                Console.WriteLine(item.Name);
            }

        }
        static void Main()
        {
            SortedList<int,string> s1 = new SortedList<int,string>();
            s1.Add(10, "Vikram");
            s1.Add(20, "Shweta");
            s1.Add(30, "Harsh");

            foreach (KeyValuePair<int, string> item in s1)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }

            SortedList<int,Employee> s2 = new SortedList<int,Employee>();
            s2.Add(1, new Employee { EmpNo = 1, Name = "a" });
            s2.Add(2, new Employee { EmpNo = 2, Name = "b" });
            s2.Add(3, new Employee { EmpNo = 3, Name = "c" });

            foreach (KeyValuePair<int, Employee> item in s2)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value.Name);
            }
        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }

    }
}
