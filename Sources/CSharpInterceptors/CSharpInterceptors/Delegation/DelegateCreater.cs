using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInterceptors.Delegation
{
    public interface DelegateCreater
    {
        MethodInfo CreateDelegate(DynamicMethod method);

        /// <summary>
        /// Returns the type of the binded class
        /// </summary>
        /// <returns></returns>
        Type GetInterceptorType();

        /// <summary>
        /// Returns the type of the delegate
        /// </summary>
        /// <returns></returns>
        Type GetDelegateType();

        void Bind(Delegate d);
    }
}
