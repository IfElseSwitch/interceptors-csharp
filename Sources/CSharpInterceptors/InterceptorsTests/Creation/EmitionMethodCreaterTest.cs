using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpInterceptors.Creation;
using System.Reflection;

namespace InterceptorsTests.Creation
{
    [TestClass]
    public class EmitionMethodCreaterTest
    {
        
        [TestMethod]
        public void EmitionMethodCreaterTestMethod()
        {
            MethodCreater creater = new EmitionMethodCreater();
            TestClass test = new TestClass();
            test.number = 1; // 1
            test.Add(1); // 1 + 1
            Assert.AreEqual(2, test.number);
            test.Multiply(2); // 2 * 2
            Assert.AreEqual(4, test.number);

            MethodInfo add = typeof(TestClass).GetMethod("Add", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            MethodInfo multiply = typeof(TestClass).GetMethod("Multiply", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            Assert.IsNotNull(add);
            Assert.IsNotNull(multiply);
            
            MethodInfo addmul = creater.CallBoth(add, multiply, new AddDelegateCreater(), typeof(TestClass));
            addmul.Invoke((AddDelegated)test, new object[] { 2 }); // (4 + 2) * 2
            Assert.AreEqual(12, test.number);
            
            test.number = 4; // 4
            Assert.AreEqual(4, test.number);

            MethodInfo muladd = creater.CallBoth(multiply, add, new MulDelegateCreater(), typeof(TestClass));
            muladd.Invoke((MulDelegated)test, new object[] { 2 }); // (4 * 2) + 2
            Assert.AreEqual(10, test.number);
        }
    }
}
