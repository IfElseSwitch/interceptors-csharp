using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using CSharpInterceptors;

namespace InterceptorsTests
{
    [TestClass]
    public class InterceptorTest
    {
        public static void LogAdd(TestClass tc, int i)
        {
            Console.WriteLine(string.Format("{0} + {1}", tc.number, i));
        }

        public static void LogMultiply(TestClass tc, int i)
        {
            Console.WriteLine(string.Format("{0} + {1}", tc.number, i));
        }

        public static void Log(TestClass tc, int i)
        {
            Console.WriteLine(string.Format(" = {0}", tc.number));
        }

        [TestMethod]
        public void InterceptorTestMethod()
        {
            Interceptor interceptor = new Interceptor();

            MethodInfo logadd = typeof(InterceptorTest).GetMethod("LogAdd", BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly);
            MethodInfo logmultiply = typeof(InterceptorTest).GetMethod("LogMultiply", BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly);
            MethodInfo log = typeof(InterceptorTest).GetMethod("Log", BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly);

            Assert.IsNotNull(logadd);
            Assert.IsNotNull(logmultiply);
            Assert.IsNotNull(log);

            MethodInfo add = typeof(TestClass).GetMethod("Add", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            MethodInfo multiply = typeof(TestClass).GetMethod("Multiply", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            Assert.IsNotNull(add);
            Assert.IsNotNull(multiply);

            interceptor.PreCall(add, logadd, new AddDelegateCreater());
            interceptor.PreCall(multiply, logmultiply, new MulDelegateCreater());

            //interceptor.PostCall(add, log, new AddDelegateCreater());
            //interceptor.PostCall(multiply, log, new MulDelegateCreater());

            TestClass test = new TestClass();
            test.number = 1; // 1
            test.Add(1); // 1 + 1
            Assert.AreEqual(2, test.number);
            test.Multiply(2); // 2 * 2
            Assert.AreEqual(4, test.number);
        }
    }
}
