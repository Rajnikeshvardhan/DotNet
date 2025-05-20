namespace Interfaces1
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Class1 obj = new Class1();
            obj.Show();
            //method 1 
            obj.Insert();
            obj.Update();
            obj.Delete();

            //method 2
            IDbFunctions oIDb;
            oIDb = obj;
            oIDb.Insert();
            oIDb.Update();
            oIDb.Delete();

            //method 3
            ((IDbFunctions)obj).Insert();
            ((IDbFunctions)obj).Delete();
            ((IDbFunctions)obj).Update();

            //method 4
            (obj as IDbFunctions).Insert();
            (obj as IDbFunctions).Update();
            (obj as IDbFunctions).Delete();

        }
    }
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }
    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Delete");
        }

        public void Insert()
        {
            Console.WriteLine("Insert");
        }

        public void Update()
        {
            Console.WriteLine("Update");
        }
        public void Show()
        {
            Console.WriteLine("Show");
        }


    }
}


namespace Interfaces2
{
    internal class Program
    {
        static void Main2()
        {
            Class1 obj = new Class1();
            obj.Show();
            //method 1 
            obj.Insert();
            obj.Update();
            obj.Open();
            obj.Close();
            //obj.Delete();


            //method 2
            IFileFunctions oIFile;
            oIFile = obj;
            oIFile.Open();
            oIFile.Close();
            oIFile.Delete();

            (obj as IDbFunctions).Delete();
            (obj as IFileFunctions).Delete();

        }
    }
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }
    public interface IFileFunctions
    {
        void Open();
        void Close();
        void Delete();
    }
    public class Class1 : IDbFunctions , IFileFunctions
    {
        void IDbFunctions.Delete()
        {
            Console.WriteLine("Idb.Delete from class1");
        }
        public void Insert()
        {
            Console.WriteLine("Idb.Insert from class1");
        }

        public void Update()
        {
            Console.WriteLine("Idb.Update from class1");
        }
        public void Show()
        {
            Console.WriteLine("Show");
        }

        //void IFileFunctions.Open()
        //{
        //    Console.WriteLine("IFile.Open from class1");
        //}
        //void IFileFunctions.Close()
        //{
        //    Console.WriteLine("IFile.Close from class1");
        //}
        void IFileFunctions.Delete()
        {
            Console.WriteLine("IFile.Delete from class1");
        }
        public void Open()
        {
            Console.WriteLine("IFile.Open from class1");
        }

        public void Close()
        {
            Console.WriteLine("IFile.Close from class1");
        }
    }
}


namespace Interfaces3
{
    internal class Program
    {
        static void Main1()
        {
            Class1 obj1 = new Class1();
            Class2 obj2 = new Class2();

            IDbFunctions oIDb;
            oIDb = obj1;
            oIDb.Insert();

            oIDb = obj2;
            oIDb.Insert();

        }
        static void Main()
        {
            Class1 obj1 = new Class1();
            Class2 obj2 = new Class2();

            InsertObject(obj1);
            InsertObject(obj2);

       }
        static void InsertObject(IDbFunctions oIDb) //oIDb = obj1
        {
            oIDb.Insert();
        }
    }
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }
  
    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Idb.Delete from class1");
        }
        public void Insert()
        {
            Console.WriteLine("Idb.Insert from class1");
        }

        public void Update()
        {
            Console.WriteLine("Idb.Update from class1");
        }
       
    }

    public class Class2 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Idb.Delete from class2");
        }
        public void Insert()
        {
            Console.WriteLine("Idb.Insert from class2");
        }

        public void Update()
        {
            Console.WriteLine("Idb.Update from class2");
        }

    }
}

namespace n1
{
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }

}

//advantages of interfaces

//contract - class MUST implement all the interface methods
//similar code in entire project for all developers
//polymorphic code
//design patterns 
