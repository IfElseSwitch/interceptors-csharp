using CSharpInterceptors.Delegation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace CSharpInterceptors.Creation
{
    class EmitionMethodCreater : AbstractMethodCreater
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



        public override MethodInfo CreateMethod(MethodInfo original, string name, Type returnType, Type[] parameterTypes)
        {
            List<Type> paramList = new List<Type>(parameterTypes);
            paramList.Insert(0, original.DeclaringType);
            parameterTypes = paramList.ToArray();
            DynamicMethod newMethod = new DynamicMethod(name, returnType, parameterTypes, original.DeclaringType, true);
            ILGenerator body = newMethod.GetILGenerator();
            //Load arguments
            for (int i = 0; i < parameterTypes.Length; ++i)
            {
                body.Emit(OpCodes.Ldarg, i);
            }
            //Call method
            body.Emit(OpCodes.Callvirt, original);
            //Return
            body.Emit(OpCodes.Ret);

            return newMethod;
        }
    }
}
