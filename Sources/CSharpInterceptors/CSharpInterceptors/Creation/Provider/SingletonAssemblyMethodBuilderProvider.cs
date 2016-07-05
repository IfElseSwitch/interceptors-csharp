using System;
using System.Reflection;
using System.Reflection.Emit;

namespace CSharpInterceptors.Creation.Provider
{
    // Try saying that one three times fast
    class SingletonAssemblyMethodBuilderProvider : MethodBuilderProvider
    {
        private static SingletonAssemblyMethodBuilderProvider s_Instance;

        public static SingletonAssemblyMethodBuilderProvider Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new SingletonAssemblyMethodBuilderProvider();
                return s_Instance;
            }
        }

        private AssemblyBuilder m_AssemblyBuilder;
        private ModuleBuilder m_ModuleBuilder;

        private SingletonAssemblyMethodBuilderProvider()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            string curName = Assembly.GetCallingAssembly().FullName;
            string name = string.Format("{0}Dynamic", curName);
            string dllName = string.Format("{0}.dll", name);
            AssemblyName asmName = new AssemblyName();
            asmName.Name = name;
            m_AssemblyBuilder = domain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave);

            m_ModuleBuilder = m_AssemblyBuilder.DefineDynamicModule(name, dllName);
        }

        public MethodBuilder CreateMethodBuilder(MethodInfo original, string name, Type returnType, Type[] parameterTypes, out TypeBuilder typeBuilder)
        {
            string typeName = string.Format("{0}{1}Caller", original.DeclaringType.Name, name);

            typeBuilder = m_ModuleBuilder.DefineType(typeName, TypeAttributes.Public, original.DeclaringType);

            MethodBuilder methodBuilder = typeBuilder.DefineMethod(name, MethodAttributes.Public, returnType, parameterTypes);

            return methodBuilder;
        }

        public MethodInfo Finalize(MethodBuilder methodBuilder, TypeBuilder typeBuilder)
        {
            string name = methodBuilder.Name;
            Type type = typeBuilder.CreateType();
            return type.GetMethod(name);
        }
    }
}
