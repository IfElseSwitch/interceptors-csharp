using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using CSharpInterceptors.Injection;

namespace InterceptorsTests.Injection
{
    [TestClass]
    public class PointerInjecterTest
    {
        [TestMethod]
        public void PointerInjecterTestMethod()
        {
            PointerInjecter injecter = new Int32PointerInjecter();
            TestClass test = new TestClass();
            test.number = 1; // 1
            test.Add(1); // 1 + 1
            Assert.AreEqual(2, test.number);
            test.Multiply(2); // 2 * 2
            Assert.AreEqual(4, test.number);

            MethodInfo add = typeof(TestClass).GetMethod("Add", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            MethodInfo multiply = typeof(TestClass).GetMethod("Multiply", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            MethodInfo noOp = typeof(TestClass).GetMethod("NoOperation", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            MethodInfo noOp2 = typeof(TestClass).GetMethod("NoOperation2", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            Assert.IsNotNull(add);
            Assert.IsNotNull(multiply);
            Assert.IsNotNull(noOp);

            injecter.InjectPointer(add, noOp);

            test.NoOperation(2); // 4 + 2

            Assert.AreEqual(6, test.number);

            injecter.InjectPointer(multiply, noOp2);
            test.NoOperation2(2); // 6 * 2
            Assert.AreEqual(12, test.number);
        }
    }
}
