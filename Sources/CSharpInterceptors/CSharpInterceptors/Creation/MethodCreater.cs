using CSharpInterceptors.Delegation;
using System;
using System.Reflection;

namespace CSharpInterceptors.Creation
{
    public interface MethodCreater
    {
        MethodInfo CallBoth(MethodInfo first, MethodInfo second, DelegateCreater delegateCreater, Type owner);

        MethodInfo CallOne(MethodInfo method, DelegateCreater delegateCreater);
    }
}
