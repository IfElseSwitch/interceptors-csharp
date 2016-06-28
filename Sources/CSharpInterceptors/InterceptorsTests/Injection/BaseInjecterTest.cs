using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using CSharpInterceptors.Injection;

namespace InterceptorsTests.Injection
{
    [TestClass]
    public class BaseInjecterTest
    {
        [TestMethod]
        public void BaseInjecterTestMethod()
        {
            BaseInjecter injecter = new BaseInjecter();
            TestClass test = new TestClass();
            test.number = 1; // 1
            test.Add(1); // 1 + 1
            Assert.AreEqual(2, test.number);
            test.Multiply(2); // 2 * 2
            Assert.AreEqual(4, test.number);

            MethodInfo add = typeof(TestClass).GetMethod("Add", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            MethodInfo multiply = typeof(TestClass).GetMethod("Multiply", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            MethodInfo noOp = typeof(TestClass).GetMethod("NoOperation", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            Assert.IsNotNull(add);
            Assert.IsNotNull(multiply);
            Assert.IsNotNull(noOp);
            injecter.InjectPointer(add, noOp);
            injecter.InjectPointer(multiply, add);

            test.Add(2); // 4 * 2

            Assert.AreEqual(8, test.number);

            injecter.InjectPointer(noOp, add);

            test.Add(2); // 8 + 2
            Assert.AreEqual(10, test.number);
        }
    }
}
