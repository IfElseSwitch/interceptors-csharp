using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CSharpInterceptors.Creation;

namespace CSharpInterceptors.Injection
{
    public class BaseInjecter : PointerInjecter
    {
        public void InjectPointer(MethodInfo inject, MethodInfo into)
        {
            RuntimeMethodHandle injectHandle, intoHandle;

            injectHandle = inject.MethodHandle;

            intoHandle = into.MethodHandle;
            
            unsafe
            {
                *((IntPtr*)new IntPtr(((IntPtr*)intoHandle.Value.ToPointer() + 2)).ToPointer()) = injectHandle.GetFunctionPointer();
            }
        }
    }
}
