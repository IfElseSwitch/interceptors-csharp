using CSharpInterceptors.Creation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            if (this == null)
                Console.WriteLine("the reference to this is null...");
            number = number + i;
        }

        public void Multiply(int i)
        {
            number *= i;
        }

        public void NoOperation(int i) { }

        
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
            MethodInfo callInfo = typeof(AddDelegated).GetMethod("Call");
            MulDelegated.Bind(op);
            return callInfo;
        }
    }
}
