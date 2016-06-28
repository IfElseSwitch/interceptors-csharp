using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInterceptors.Creation
{
    public interface DelegateCreater
    {
        MethodInfo CreateDelegate(DynamicMethod method);
        Type GetDelegateType();
    }
}
