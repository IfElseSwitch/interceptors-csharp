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
            number += i;
            called(this, i);
        }
    }

    class MulInterceptor : TestClass, Interceptor
    {
        public void Intercept(int i)
        {
            Operation called = this.GetIntercepted<Operation>();
            number *= i;
            called(this, i);
        }
    }

    class LogAddInterceptor : TestClass, Interceptor
    {
        public void Intercept(int i)
        {
            string txt1, txt2;
            txt1 = string.Format("{0} + {1}", number, i);
            Console.Write(txt1);
            Operation operation = this.GetIntercepted<Operation>();
            operation(this, i);
            txt2 = string.Format(" = {0}", number);
            Console.WriteLine(txt2);
            InterceptorTest.Log(string.Format("{0}{1}", txt1, txt2));
        }
    }

    class LogMulInterceptor : TestClass, Interceptor
    {
        public void Intercept(int i)
        {
            string txt1, txt2;
            txt1 = string.Format("{0} * {1}", number, i);
            Console.Write(txt1);
            Operation operation = this.GetIntercepted<Operation>();
            operation(this, i);
            txt2 = string.Format(" = {0}", number);
            Console.WriteLine(txt2);
            InterceptorTest.Log(string.Format("{0}{1}", txt1, txt2));
        }
    }
}
