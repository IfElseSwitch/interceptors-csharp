using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CSharpInterceptors.Delegation;
using System.Reflection.Emit;

namespace CSharpInterceptors.Creation
{
    class BuilderMethodCreater : AbstractMethodCreater
    {
        private static MethodBuilderProvider s_Provider;
        public override MethodInfo CreateMethod(MethodInfo original, string name, Type returnType, Type[] parameterTypes)
        {
            TypeBuilder typeBuilder;
            MethodBuilder methodBuilder = s_Provider.CreateMethodBuilder(original, name, returnType, parameterTypes, out typeBuilder);
            Module module = original.Module;
            MethodBody body = original.GetMethodBody();
            byte[] ilCode = body.GetILAsByteArray();
            //builder.CreateMethodBody(ilCode, ilCode.Length);
            methodBuilder.SetMethodBody(ilCode, body.MaxStackSize, module.ResolveSignature(body.LocalSignatureMetadataToken),
                null, null);

            return s_Provider.Finalize(methodBuilder, typeBuilder);
        }
    }
}
