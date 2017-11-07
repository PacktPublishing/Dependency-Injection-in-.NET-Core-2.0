using System;
using System.Collections.Generic;

namespace PacktConsoleAppp
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleIDisposable disposable = new ExampleIDisposable(new Dictionary<int, string> {
                { 5, "Object Composition" },
                { 6, "Object Lifetime" }
            });

			// Comment dispose and activate GC to see the difference.
            //disposable.Dispose();
			GC.Collect();
        }
    }

	class ExampleIDisposable : IDisposable
	{
        public Dictionary<int, string> Chapters { get; set; }
		
		public ExampleIDisposable(Dictionary<int, string> chapters)
		{
			// Managed resources
			System.Diagnostics.Trace.WriteLine("Managed Resources acquired");
			Chapters = chapters;

			// Some Unmanaged resources
			System.Diagnostics.Trace.WriteLine("Unmanaged Resources acquired");
		}

		public void Dispose()
		{
			System.Diagnostics.Trace.WriteLine("Someone called Dispose");

			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public void Dispose(bool disposeManagedResources)
		{
			if (disposeManagedResources)
			{
				if (Chapters != null)
				{
					Chapters = null;
				}

				System.Diagnostics.Trace.WriteLine("Managed Resources disposed");
			}

			System.Diagnostics.Trace.WriteLine("Unmanaged Resources disposed");
		}

		~ExampleIDisposable()
		{
			System.Diagnostics.Trace.WriteLine("Finalizer called: Managed resources will be cleaned");
			Dispose(false);
		}
    }
}