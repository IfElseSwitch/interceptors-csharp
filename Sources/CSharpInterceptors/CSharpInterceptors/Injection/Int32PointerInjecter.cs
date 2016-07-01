using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CSharpInterceptors.Creation;

namespace CSharpInterceptors.Injection
{
    public class Int32PointerInjecter : AbstractPointerInjecter
    {
        public override void Inject(RuntimeMethodHandle injectHandle, RuntimeMethodHandle intoHandle)
        {
            unsafe
            {
                //*((IntPtr*)new IntPtr(((IntPtr*)intoHandle.Value.ToPointer() + 2)).ToPointer()) = injectHandle.GetFunctionPointer();

                int* injected = (int*)injectHandle.Value.ToPointer() + 2;
                int* target = (int*)intoHandle.Value.ToPointer() + 2;

                *target = *injected;
            }
        }
    }
}
