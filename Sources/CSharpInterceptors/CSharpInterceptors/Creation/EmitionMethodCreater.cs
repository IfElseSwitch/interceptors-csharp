using CSharpInterceptors.Delegation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace CSharpInterceptors.Creation
{
    public class IncompatibleMethodsException : Exception
    {

    }

    public class EmitionMethodCreater : MethodCreater
    {
        private static bool ArraysEquals<T>(T[] A, T[] B)
        {
            if (A.Length != B.Length)
                return false;
            for (int i = 0; i < A.Length; ++i)
            {
                if (A[i].Equals(B[i]) == false)
                    return false;
            }
            return true;
        }

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
        
        private bool CompareReturnTypes(MethodInfo first, MethodInfo second)
        {
            if (first.ReturnType == null || second.ReturnType == null)
                return true;

            if (first.ReturnType == typeof(void) || second.ReturnType == typeof(void))
                return true;

            return false;
        }

        public MethodInfo CallBoth(MethodInfo first, MethodInfo second, DelegateCreater delegateCreater, Type owner)
        {
            if (CompareReturnTypes(first, second) == false)
                throw new IncompatibleMethodsException();
            if (ArraysEquals(first.GetParameters(), second.GetParameters()))
                throw new IncompatibleMethodsException();
            

            RuntimeHelpers.PrepareMethod(first.MethodHandle);
            RuntimeHelpers.PrepareMethod(second.MethodHandle);

            string name = string.Format("CallBoth_{0}_{1}", first.Name, second.Name);
            Type returnType = first.ReturnType;
            Type[] parameterTypes = ExtractParameterTypes(first);
            List<Type> paramList = new List<Type>(parameterTypes);
            paramList.Insert(0, owner);
            parameterTypes = paramList.ToArray();
 
            DynamicMethod newMethod = new DynamicMethod(name, returnType, parameterTypes, owner, true);
            ILGenerator body = newMethod.GetILGenerator();
            //body.EmitWriteLine("First Call - Load parameters");
            
            //for (int i = 0; i < parameterTypes.Length; ++i)
            //{
            //    Label label = body.DefineLabel();
            //    body.Emit(OpCodes.Ldarg, i);
            //    body.Emit(OpCodes.Brtrue, label);
            //    body.EmitWriteLine(string.Format("arg {0}/{1} null ({2})", i + 1, parameterTypes.Length, parameterTypes[i].ToString()));
            //    body.MarkLabel(label);
            //}
            for (int i = 0; i < parameterTypes.Length; ++i)
            {
                body.Emit(OpCodes.Ldarg, i);
            }
            //body.EmitWriteLine("First Call - Call function");
            //Console.WriteLine(string.Format("--{0}", first.Name)); 
            body.Emit(OpCodes.Callvirt, first);
            //body.EmitWriteLine("Second Call - Load parameters");
            for (int i = 0; i < parameterTypes.Length; ++i)
            {
                body.Emit(OpCodes.Ldarg, i);
            }
            //body.EmitWriteLine("Second Call - Call function");
            //Console.WriteLine(string.Format("--{0}", second.Name));
            body.Emit(OpCodes.Callvirt, second);
            body.Emit(OpCodes.Ret);

            return delegateCreater.CreateDelegate(newMethod);
        }
    }
}
