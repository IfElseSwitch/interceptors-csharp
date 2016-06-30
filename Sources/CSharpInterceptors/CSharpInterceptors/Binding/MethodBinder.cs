using CSharpInterceptors.Delegation;
using System;
using System.Collections.Generic;

namespace CSharpInterceptor.Binding
{
    static class MethodBinder
    {
        private static Dictionary<Type, Delegate> s_Bindings;

        private static Dictionary<Type, Delegate> Bindings
        {
            get
            {
                if (s_Bindings == null)
                    s_Bindings = new Dictionary<Type, Delegate>();
                return s_Bindings;
            }
        }

        public static void Bind(Delegate d, DelegateCreater creater)
        {
            Type key = creater.GetInterceptorType();
            if (Bindings.ContainsKey(key))
                Bindings.Remove(key);
            Bindings.Add(key, d);
        }

        public static T GetBoundFromType<T>(Type type)
        {
            return CastTo<T>(Bindings[type]);
        }
        
        private static TCast CastTo<TCast>(object obj)
        {
            try
            {
                return (TCast)obj;
            }
            catch
            {
                return default(TCast);
            }
        }
    }
}
