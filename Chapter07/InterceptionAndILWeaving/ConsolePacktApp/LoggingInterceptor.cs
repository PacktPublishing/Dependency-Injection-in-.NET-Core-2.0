using Castle.DynamicProxy;
using System;

namespace ConsolePacktApp
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                Console.WriteLine("Log Interceptor Starts");
                invocation.Proceed();
                Console.WriteLine("Log Interceptor Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Log Interceptor Exception");
                throw;
            }
            finally
            {
                Console.WriteLine("Log Interceptor Exit");
            }
        }
    }
}
