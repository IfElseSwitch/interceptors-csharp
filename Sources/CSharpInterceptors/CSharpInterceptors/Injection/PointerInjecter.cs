using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CSharpInterceptors.Creation;

namespace CSharpInterceptors.Injection
{
    interface PointerInjecter
    {
        void InjectPointer(MethodInfo inject, MethodInfo into);
    }
}
