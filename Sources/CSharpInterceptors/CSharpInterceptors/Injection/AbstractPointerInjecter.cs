using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInterceptors.Injection
{
    public abstract class AbstractPointerInjecter : PointerInjecter
    {
        public void InjectPointer(MethodInfo inject, MethodInfo into)
        {
            RuntimeMethodHandle injectHandle, intoHandle;

            injectHandle = inject.MethodHandle;

            intoHandle = into.MethodHandle;

            Inject(injectHandle, intoHandle);
        }

        public abstract void Inject(RuntimeMethodHandle injectHandle, RuntimeMethodHandle intoHandle);

        protected unsafe void DebugInjection(byte* injected, byte* target)
        {

            int* injSrc = (int*)(injected + 1);
            int* tarSrc = (int*)(target + 1);

            *tarSrc = (((int)injected + 5) + *injSrc) - ((int)target + 5);
        }
    }
}
