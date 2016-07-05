using System;
using System.Reflection;
using System.Reflection.Emit;

namespace CSharpInterceptors.Creation.Provider
{
    interface MethodBuilderProvider
    {
        MethodBuilder CreateMethodBuilder(MethodInfo original, string name, Type returnType, Type[] parameterTypes, out TypeBuilder typeBuilder);
        MethodInfo Finalize(MethodBuilder methodBuilder, TypeBuilder typeBuilder);
    }
}
