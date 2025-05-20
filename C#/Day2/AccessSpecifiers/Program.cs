namespace AccessSpecifiers
{
    //default access specifier is 'internal' in a namespace
    class Class1
    {

    }
    internal class Program
    {
        static void Main()
        {
            //BaseClass o = new BaseClass();
            //o.

            TestAccessSpecifiers.BaseClass o2 = new TestAccessSpecifiers.BaseClass();
            //o2.PUBLIC
        }
    }
//public - everywhere
//private - same class
//protected - same class, derived class
//internal - same class, same assembly(same project)
//protected internal - same class, derived class, same assembly(same project)
//private protected - same class, derived class that is in the same assembly
    public class BaseClass
    {
        //default access specifier is 'private' for class members

        int x;
        public int PUBLIC;
        private int PRIVATE;
        protected int PROTECTED;
        internal int INTERNAL;
        protected internal int PROTECTED_INTERNAL;
        private protected int PRIVATE_PROTECTED;
    }

    //  public class DerivedClass : BaseClass
    public class DerivedClass : TestAccessSpecifiers.BaseClass
    {
        void DoSomething()
        {
            //this.
        }
    }
}
