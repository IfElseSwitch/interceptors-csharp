using CSharpInterceptors.Delegation;
using System.Reflection;

namespace CSharpInterceptors.Creation
{
    public interface MethodCreater
    {
        MethodInfo CallOne(MethodInfo method, DelegateCreater delegateCreater);
    }
}
