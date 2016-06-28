using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInterceptors.Creation
{
    public interface MethodCreater
    {
        MethodInfo CallBoth(MethodInfo first, MethodInfo second, DelegateCreater delegateCreater, Type owner);
    }
}
