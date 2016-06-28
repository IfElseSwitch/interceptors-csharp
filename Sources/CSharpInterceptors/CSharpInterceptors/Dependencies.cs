using CSharpInterceptors.Creation;
using CSharpInterceptors.Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInterceptors
{
    static class Dependencies
    {
        public static PointerInjecter GetPointerInjecter()
        {
            return new BaseInjecter();
        }

        public static MethodCreater GetMethodCreater()
        {
            return new EmitionMethodCreater();
        }
    }
}
