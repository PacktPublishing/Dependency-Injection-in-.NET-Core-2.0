using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;

namespace ConsolePacktApp
{
    public class ExampleRegistration : IRegistration
    {
        public void Register(IKernelInternal kernel)
        {
            // 1. Interceptor Registration
            kernel.Register(
                Component.For<LoggingInterceptor>()
                    .ImplementedBy<LoggingInterceptor>());

            // Another Interceptor registration.
            //kernel.Register(
            //    Component.For<AnotherInterceptor>()
            //        .ImplementedBy<AnotherInterceptor>());

            // 2. Interceptor attached with Example Class.
            kernel.Register(
                Component.For<IExample>()
                         .ImplementedBy<Example>()
                         .Interceptors(InterceptorReference.ForType<LoggingInterceptor>()).Anywhere);

            // Mutiple Interceptors for the same class can be registered with one line as below.
            //kernel.Register(
            //     Component.For<IExample>()
            //                .ImplementedBy<Example>()
            //                .Interceptors(new InterceptorReference[] {
            //                                InterceptorReference.ForType<LoggingInterceptor>(),
            //                                InterceptorReference.ForType<AnotherInterceptor>()
            //     }).Anywhere);

        }
    }
}
