using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInterceptors.Delegation
{
    public class ConcreteDelegateCreater<TInterceptor, TDelegate> : AbstractDelegateCreater
    {
        public override Type GetInterceptorType()
        {
            return typeof(TInterceptor);
        }

        public override Type GetDelegateType()
        {
            return typeof(TDelegate);
        }
    }
}
