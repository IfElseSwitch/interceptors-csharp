using CSharpInterceptors.Binding;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace CSharpInterceptors.Delegation
{
    public abstract class AbstractDelegateCreater : DelegateCreater
    {
        public MethodInfo CreateDelegate(MethodInfo method)
        {
            Delegate d = method.CreateDelegate(GetDelegateType());
            MethodInfo called = GetInterceptorType().GetMethod("Intercept", BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public);
            Bind(d);
            return called;
        }

        public abstract Type GetInterceptorType();

        public abstract Type GetDelegateType();

        private void Bind(Delegate d)
        {
            MethodBinder.Bind(d, this);
        }

        
    }
}
