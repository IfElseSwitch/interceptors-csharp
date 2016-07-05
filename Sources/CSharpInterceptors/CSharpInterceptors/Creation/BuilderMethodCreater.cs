using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CSharpInterceptors.Delegation;
using System.Reflection.Emit;
using CSharpInterceptors.Creation.Provider;

namespace CSharpInterceptors.Creation
{
    class BuilderMethodCreater : AbstractMethodCreater
    {
        private static BuilderMethodCreater s_Instance;

        public static BuilderMethodCreater Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new BuilderMethodCreater();
                return s_Instance;
            }
        }

        private BuilderMethodCreater()
        {
            m_Provider = SingletonAssemblyMethodBuilderProvider.Instance;
        }

        private MethodBuilderProvider m_Provider;
        public override MethodInfo CreateMethod(MethodInfo original, string name, Type returnType, Type[] parameterTypes)
        {
            TypeBuilder typeBuilder;
            MethodBuilder methodBuilder = m_Provider.CreateMethodBuilder(original, name, returnType, parameterTypes, out typeBuilder);
            Module module = original.Module;
            MethodBody body = original.GetMethodBody();
            byte[] ilCode = body.GetILAsByteArray();
            //builder.CreateMethodBody(ilCode, ilCode.Length);
            methodBuilder.SetMethodBody(ilCode, body.MaxStackSize, module.ResolveSignature(body.LocalSignatureMetadataToken),
                null, null);

            return m_Provider.Finalize(methodBuilder, typeBuilder);
        }
    }
}
