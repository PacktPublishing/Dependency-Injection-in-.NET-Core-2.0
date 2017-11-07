namespace PacktConsoleAppp
{
    class Program
    {
        static void Main(string[] args)
        {
            DeriveClass2 t = new DeriveClass2();

			// Unlike .NET Framework, .NET Core 2.0, as of now, 
			// does not call GC on application termination 
			// to finalise the objects.
			// So, we are trying to manually call GC
			// to see the output.
			System.GC.Collect();
        }
    }

    class BaseClass
    {
        ~BaseClass()
        {
            System.Diagnostics.Trace.WriteLine("BaseClass's destructor is called.");
        }
    }

    class DeriveClass1 : BaseClass
    {
        ~DeriveClass1()
        {
            System.Diagnostics.Trace.WriteLine("DeriveClass1's destructor is called.");
        }
    }

    class DeriveClass2 : DeriveClass1
    {
        public DeriveClass2()
        {
            System.Diagnostics.Trace.WriteLine("DeriveClass2's constructor is called.");
        }

        ~DeriveClass2()
        {
            System.Diagnostics.Trace.WriteLine("DeriveClass2's destructor is called.");
        }
    }
}