using LifetimesExample.Interfaces;
using System;

namespace LifetimesExample.Models
{
    public class Example : IExampleScoped, IExampleSingleton, IExampleTransient, IExampleSingletonInstance
    {
        public Guid ExampleId { get; set; }

        public Example()
        {
            ExampleId = Guid.NewGuid();
        }

        public Example(Guid exampleId)
        {
            ExampleId = exampleId;
        }
    }

}
