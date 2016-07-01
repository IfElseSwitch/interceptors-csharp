using CSharpInterceptors.Delegation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace CSharpInterceptors.Creation
{
    public class EmitionMethodCreater : MethodCreater
    {
        private static EmitionMethodCreater s_Instance;

        public static EmitionMethodCreater Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new EmitionMethodCreater();
                return s_Instance;
            }
        }

        private EmitionMethodCreater() { }


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
            List<Type> paramList = new List<Type>(parameterTypes);
            paramList.Insert(0, method.DeclaringType);
            parameterTypes = paramList.ToArray();

            DynamicMethod newMethod = new DynamicMethod(name, returnType, parameterTypes, method.DeclaringType, true);
            ILGenerator body = newMethod.GetILGenerator();
            //Load arguments
            for (int i = 0; i < parameterTypes.Length; ++i)
            {
                body.Emit(OpCodes.Ldarg, i);
            }
            //Call method
            body.Emit(OpCodes.Callvirt, method);
            //Return
            body.Emit(OpCodes.Ret);

            return delegateCreater.CreateDelegate(newMethod);
        }
    }
}
