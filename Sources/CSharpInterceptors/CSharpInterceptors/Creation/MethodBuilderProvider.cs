using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInterceptors.Creation
{
    interface MethodBuilderProvider
    {
        MethodBuilder CreateMethodBuilder(MethodInfo original, string name, Type returnType, Type[] parameterTypes, out TypeBuilder typeBuilder);
        MethodInfo Finalize(MethodBuilder methodBuilder, TypeBuilder typeBuilder);
    }
}
