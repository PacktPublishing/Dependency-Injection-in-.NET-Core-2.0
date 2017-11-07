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

            disposable.Dispose();
            disposable.Dispose();
            disposable.Dispose();
        }
    }

    class ExampleIDisposable : IDisposable
    {
        public Dictionary<int, string> Chapters { get; set; }
        bool disposed = false;

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

        protected virtual void Dispose(bool disposeManagedResources)
        {
            if (disposed)
            {
                System.Diagnostics.Trace.WriteLine("Dispose(bool) already called");
                return;
            }

            if (disposeManagedResources)
            {
                if (Chapters != null)
                {
                    Chapters = null;
                }

                System.Diagnostics.Trace.WriteLine("Managed Resources disposed");
            }

            System.Diagnostics.Trace.WriteLine("Unmanaged Resources disposed");

            disposed = true;
        }

        ~ExampleIDisposable()
        {
            System.Diagnostics.Trace.WriteLine("Finalizer called: Managed resources will be cleaned");
            Dispose(false);
        }
    }
}