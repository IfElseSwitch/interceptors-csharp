using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


namespace CSharpInterceptors.Creation
{
    public class CompositeMethodCreater : AbstractMethodCreater
    {
        private static CompositeMethodCreater s_Instance;

        public static CompositeMethodCreater Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new CompositeMethodCreater();
                return s_Instance;
            }
        }

        private CompositeMethodCreater() { }

        public override MethodInfo CreateMethod(MethodInfo original, string name, Type returnType, Type[] parameterTypes)
        {
            string nameCopy = string.Format("{0}Copy", name);
            MethodInfo copy = BuilderMethodCreater.Instance.CreateMethod(original, nameCopy, returnType, parameterTypes);
            return EmitionMethodCreater.Instance.CreateMethod(copy, name, returnType, parameterTypes);
        }
    }
}
