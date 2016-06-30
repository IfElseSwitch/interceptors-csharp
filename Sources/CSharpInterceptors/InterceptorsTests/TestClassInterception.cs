using CSharpInterceptors;
using CSharpInterceptors.Delegation;
using System;

namespace InterceptorsTests
{
    public delegate void Operation(TestClass tc, int i);
    public class AddDelegated : TestClass, Interceptor
    {
        public void Call(int i)
        {
            Operation called = this.GetIntercepted<Operation>();
            called(this, i);
        }
    }

    class MulDelegated : TestClass, Interceptor
    {
        public void Call(int i)
        {
            Operation called = this.GetIntercepted<Operation>();
            called(this, i);
        }
    }


    public class AddDelegateCreater : AbstractDelegateCreater
    {
        public override Type GetBindedType()
        {
            return typeof(AddDelegated);
        }

        public override Type GetDelegateType()
        {
            return typeof(Operation);
        }
    }

    public class MulDelegateCreater : AbstractDelegateCreater
    {
        public override Type GetDelegateType()
        {
            return typeof(Operation);
        }
        public override Type GetBindedType()
        {
            return typeof(MulDelegated);
        }
    }
}
