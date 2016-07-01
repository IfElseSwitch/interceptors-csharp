using CSharpInterceptors.Creation;
using CSharpInterceptors.Delegation;
using CSharpInterceptors.Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInterceptors
{
    public class InterceptorManager
    {
        #region Members

        PointerInjecter m_Injecter;
        MethodCreater m_MethodCreater;

        #endregion


        #region Constructor

        public InterceptorManager()
        {
            m_Injecter = Dependencies.GetPointerInjecter();
            m_MethodCreater = Dependencies.GetMethodCreater();
        }

        #endregion


        #region Public Methods

        public void DefineInterceptor<TInterceptor, TDelegate>(MethodInfo call)
        {
            MethodInfo replacement = m_MethodCreater.CallOne(call, Dependencies.GetDelegateCreater<TInterceptor, TDelegate>());
            m_Injecter.InjectPointer(replacement, call);
        }

        #endregion
        
    }
}
