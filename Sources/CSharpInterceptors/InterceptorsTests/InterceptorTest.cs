using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using CSharpInterceptors;

namespace InterceptorsTests
{
    [TestClass]
    public class InterceptorTest
    {
        [TestMethod]
        public void InterceptorTestMethod()
        {
            Interceptors interceptor = new Interceptors();
            TestClass test = new TestClass();
            test.number = 1; // 1

            MethodInfo add = typeof(TestClass).GetMethod("Add", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            MethodInfo multiply = typeof(TestClass).GetMethod("Multiply", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            Assert.IsNotNull(add);
            Assert.IsNotNull(multiply);

            interceptor.DefineInterceptor<LogAddInterceptor, Operation>(add);
            interceptor.DefineInterceptor<LogMulInterceptor, Operation>(multiply);


            test.Add(1); // 1 + 1
            Assert.AreEqual(2, test.number);
            test.Multiply(2); // 2 * 2
            Assert.AreEqual(4, test.number);
        }
    }
}
