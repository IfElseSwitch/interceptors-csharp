using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using CSharpInterceptors;
using System.Collections.Generic;

namespace InterceptorsTests
{
    [TestClass]
    public class InterceptorTest
    {
        static List<string> s_Logs;

        [TestMethod]
        public void InterceptorTestMethod()
        {
            InterceptorManager manager = new InterceptorManager();
            TestClass test = new TestClass();
            test.number = 1; // 1

            MethodInfo add = typeof(TestClass).GetMethod("Add", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            MethodInfo multiply = typeof(TestClass).GetMethod("Multiply", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            Assert.IsNotNull(add);
            Assert.IsNotNull(multiply);
            manager.DefineInterceptor<LogAddInterceptor, Operation>(add);
            manager.DefineInterceptor<LogMulInterceptor, Operation>(multiply);


            test.Add(1); // 1 + 1
            Assert.AreEqual(2, test.number);
            test.Multiply(2); // 2 * 2
            Assert.AreEqual(4, test.number);
            Assert.IsNotNull(s_Logs);
            Assert.AreEqual(2, s_Logs.Count);
        }

        public static void Log(string text)
        {
            if (s_Logs == null)
                s_Logs = new List<string>();
            s_Logs.Add(text);
        }
    }

}
