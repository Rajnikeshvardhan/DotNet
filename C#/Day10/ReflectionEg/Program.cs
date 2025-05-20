using System.Reflection;
namespace ReflectionEg
{
    internal class Program
    {
        static void Main()
        {
            //Assembly asm = Assembly.GetExecutingAssembly();
            //Assembly asm = Assembly.GetCallingAssembly();
            //Assembly asm = Assembly.GetEntryAssembly();
            //Assembly asm = Assembly.GetAssembly(typeof(int));

            Assembly assembly = Assembly.LoadFrom(@"D:\Trainings\ActsJan25\Day1\ClassBasics\bin\Debug\net8.0\ClassBasics.dll");

            //Console.WriteLine(assembly.FullName);
            Console.WriteLine(assembly.GetName().Name);
            Type[] arrTypes = assembly.GetTypes();
            foreach (Type t in arrTypes)
            {
                Console.WriteLine("    "+ t.Name);
                MethodInfo[] arrMethods = t.GetMethods();
                foreach (MethodInfo m in arrMethods)
                {
                    Console.WriteLine("        " + m.Name);
                }
            }
        }
    }
}

//asm1 -> asm2 -> asm3 ->asm4