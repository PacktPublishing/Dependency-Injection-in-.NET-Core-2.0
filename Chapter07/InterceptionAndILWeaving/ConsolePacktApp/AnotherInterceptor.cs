using Castle.DynamicProxy;
using System;

namespace ConsolePacktApp
{
    public class AnotherInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("AnotherInterceptor started");
            invocation.Proceed();
            Console.WriteLine("AnotherInterceptor exited");
        }
    }
}