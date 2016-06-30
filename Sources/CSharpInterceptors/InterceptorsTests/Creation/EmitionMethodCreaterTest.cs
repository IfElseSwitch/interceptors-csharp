using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpInterceptors.Creation;
using System.Reflection;
using CSharpInterceptors.Injection;

namespace InterceptorsTests.Creation
{
    [TestClass]
    public class EmitionMethodCreaterTest
    {
        
        [TestMethod]
        public void EmitionMethodCreaterTestMethod()
        {
            MethodCreater creater = new EmitionMethodCreater();
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
            MethodInfo noOp2 = typeof(TestClass).GetMethod("NoOperation2", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            Assert.IsNotNull(add);
            Assert.IsNotNull(multiply);
            Assert.IsNotNull(noOp);
            Assert.IsNotNull(noOp2);

            MethodInfo addmul = creater.CallBoth(add, multiply, new AddDelegateCreater(), typeof(TestClass));
            injecter.InjectPointer(addmul, noOp);
            test.NoOperation(2);
            Assert.AreEqual(12, test.number);


            test.number = 4; // 4
            Assert.AreEqual(4, test.number);

            MethodInfo muladd = creater.CallBoth(multiply, add, new MulDelegateCreater(), typeof(TestClass));
            injecter.InjectPointer(muladd, noOp2);
            test.NoOperation2(2);
            Assert.AreEqual(10, test.number);
        }
    }
}
