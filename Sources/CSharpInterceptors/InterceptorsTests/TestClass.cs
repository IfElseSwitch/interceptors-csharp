using CSharpInterceptors.Creation;
using CSharpInterceptors.Delegation;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace InterceptorsTests
{
    public delegate void Operation(TestClass tc, int i);
    public class AddDelegated : TestClass
    {
        public AddDelegated():base() { }

        public AddDelegated(TestClass tc)
        {
            number = tc.number;
        }

        static Operation binded = null;

        public static void Bind(Operation to)
        {
            binded = to;
        }

        public void Call(int i)
        {
            binded(this, i);
        }
    }

    class MulDelegated : TestClass
    {
        static Operation binded;

        public static void Bind(Operation to)
        {
            binded = to;
        }

        public void Call(int i)
        {
            MulDelegated.binded(this,i);
        }
    }

    public class TestClass
    {
        public int number;
        public void Add(int i)
        {
            Console.WriteLine("Add");
            number = number + i;
        }

        public void Multiply(int i)
        {
            Console.WriteLine("Multiply");
            number *= i;
        }

        public void NoOperation(int i)
        {
            Console.WriteLine("NoOperation");
        }

        public void NoOperation2(int i)
        {
            Console.WriteLine("NoOperation2");
        }

    }


    public class AddDelegateCreater : DelegateCreater
    {
        public Type GetDelegateType()
        {
            return typeof(Operation);
        }

        public MethodInfo CreateDelegate(DynamicMethod method)
        {
            Operation op = (Operation)method.CreateDelegate(typeof(Operation));
            MethodInfo callInfo = typeof(AddDelegated).GetMethod("Call");
            AddDelegated.Bind(op);
            return callInfo;
        }
    }

    public class MulDelegateCreater : DelegateCreater
    {
        public Type GetDelegateType()
        {
            return typeof(Operation);
        }

        public MethodInfo CreateDelegate(DynamicMethod method)
        {
            Operation op = (Operation)method.CreateDelegate(typeof(Operation));
            MethodInfo callInfo = typeof(MulDelegated).GetMethod("Call");
            MulDelegated.Bind(op);
            return callInfo;
        }
    }
}
