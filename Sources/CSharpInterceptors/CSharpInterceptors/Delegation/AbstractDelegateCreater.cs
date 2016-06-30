using CSharpInterceptor.Binding;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace CSharpInterceptors.Delegation
{
    public abstract class AbstractDelegateCreater : DelegateCreater
    {
        public MethodInfo CreateDelegate(DynamicMethod method)
        {
            Delegate d = method.CreateDelegate(GetDelegateType());
            MethodInfo called = GetBindedType().GetMethod("Call", BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public);
            Bind(d);
            return called;
        }

        public abstract Type GetBindedType();

        public abstract Type GetDelegateType();

        public void Bind(Delegate d)
        {
            MethodBinder.Bind(d, this);
        }

        
    }
}
