using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInterceptors.Injection
{
    public class Int64PointerInjecter : AbstractPointerInjecter
    {
        public override void Inject(RuntimeMethodHandle injectHandle, RuntimeMethodHandle intoHandle)
        {
            unsafe
            {
                long* injected = (long*)injectHandle.Value.ToPointer() + 1;
                long* target = (long*)intoHandle.Value.ToPointer() + 1;

                *target = *injected;
            }
        }
    }
}
