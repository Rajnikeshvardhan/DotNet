namespace ExplicitImplementationOfInterfaces1
{
    internal class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();
            o.Insert();

            //o.Select();//error - n. a.
            //if class1 has not wrritten code for Select, def imp code will be called
            (o as IDbFunctions).Select();
        }
    }

    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
        void Select()
        {
            Console.WriteLine("def implementation for select");
        }
    }

    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Delete");
        }

        public void Insert()
        {
            Console.WriteLine("Insert from class1");
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


namespace ExplicitImplementationOfInterfaces2
{
    internal class Program
    {
        static void Main2()
        {
            Class1 o = new Class1();
            o.Insert();

            o.Select();//available, code from Class1

            //if class1 HAS written code for Select, Class1 code will be called
            (o as IDbFunctions).Select();
        }
    }

    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
        void Select()
        {
            Console.WriteLine("def implementation for select");
        }
    }

    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Delete");
        }

        public void Insert()
        {
            Console.WriteLine("Insert from class1");
        }
        public void Select()
        {
            Console.WriteLine("Select from class1");
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


namespace ExplicitImplementationOfInterfaces3
{
    internal class Program
    {
        static void Main()
        {
            Class1 o = new Class1();
            o.Insert();

            //o.Select();//not available

            //if class1 HAS written code for Select, Class1 code will be called
            (o as IDbFunctions).Select();
            (o as IFileFunctions).Select();
        }
    }

    public interface IDbFunctions
    {
        static int a;

        void Insert();
        void Update();
        void Delete();
        void Select()
        {
            Console.WriteLine("def implementation for IDb.select");
        }
    }
    public interface IFileFunctions
    {
        void Open();
        void Close();
        void Select()
        {
            Console.WriteLine("def implementation for IFile.select");
        }
    }
    public class Class1 : IDbFunctions, IFileFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Delete");
        }

        public void Insert()
        {
            Console.WriteLine("Insert from class1");
        }
        void IDbFunctions.Select()
        {
            Console.WriteLine("IDb.Select from class1");
        }
        void IFileFunctions.Select()
        {
            Console.WriteLine("IFile.Select from class1");
        }
        public void Update()
        {
            Console.WriteLine("Update");
        }
        public void Show()
        {
            Console.WriteLine("Show");
        }

        public void Open()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}