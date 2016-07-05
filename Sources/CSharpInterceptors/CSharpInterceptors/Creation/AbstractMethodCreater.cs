using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CSharpInterceptors.Delegation;
using System.Runtime.CompilerServices;

namespace CSharpInterceptors.Creation
{
    public abstract class AbstractMethodCreater : MethodCreater
    {
        private Type[] ExtractParameterTypes(MethodInfo method)
        {
            ParameterInfo[] parameterInfos = method.GetParameters();
            int length = parameterInfos.Length;
            int start = 0;
            if (method.IsStatic)
            {
                length -= 1;
                start = 1;
            }
            Type[] parameterTypes = new Type[length];

            for (int i = start; i < parameterInfos.Length; ++i)
            {
                parameterTypes[i - start] = parameterInfos[i].ParameterType;
            }
            return parameterTypes;
        }

        public MethodInfo CallOne(MethodInfo method, DelegateCreater delegateCreater)
        {
            RuntimeHelpers.PrepareMethod(method.MethodHandle);

            string name = string.Format("Call_{0}", method.Name);
            Type returnType = method.ReturnType;
            Type[] parameterTypes = ExtractParameterTypes(method);

            MethodInfo created = CreateMethod(method, name, returnType, parameterTypes);

            return delegateCreater.CreateDelegate(created);

        }

        public abstract MethodInfo CreateMethod(MethodInfo original, string name, Type returnType, Type[] parameterTypes);
    }
}
