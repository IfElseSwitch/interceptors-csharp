using CSharpInterceptors;
using CSharpInterceptors.Delegation;
using System;

namespace InterceptorsTests
{
    public delegate void Operation(TestClass tc, int i);
    public class AddInterceptor : TestClass, Interceptor
    {
        public void Intercept(int i)
        {
            Operation called = this.GetIntercepted<Operation>();
            called(this, i);
        }
    }

    class MulInterceptor : TestClass, Interceptor
    {
        public void Intercept(int i)
        {
            Operation called = this.GetIntercepted<Operation>();
            called(this, i);
        }
    }

    class LogAddInterceptor : TestClass, Interceptor
    {
        public void Intercept(int i)
        {
            Console.Write(string.Format("{0} + {1}", number, i));
            Operation operation = this.GetIntercepted<Operation>();
            operation(this, i);
            Console.WriteLine(string.Format(" = {0}", number));
        }
    }

    class LogMulInterceptor : TestClass, Interceptor
    {
        public void Intercept(int i)
        {
            Console.Write(string.Format("{0} * {1}", number, i));
            Operation operation = this.GetIntercepted<Operation>();
            operation(this, i);
            Console.WriteLine(string.Format(" = {0}", number));
        }
    }
}
