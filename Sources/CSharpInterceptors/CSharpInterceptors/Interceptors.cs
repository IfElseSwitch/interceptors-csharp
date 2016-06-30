﻿using CSharpInterceptors.Creation;
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
    public class Interceptors
    {
        #region Members

        PointerInjecter m_Injecter;
        MethodCreater m_Creater;

        #endregion


        #region Constructor

        public Interceptors()
        {
            m_Injecter = Dependencies.GetPointerInjecter();
            m_Creater = Dependencies.GetMethodCreater();
        }

        #endregion


        #region Protected Methods

        public void PostCall(MethodInfo call, MethodInfo post, DelegateCreater delegateCreater)
        {
            MethodInfo replacement = m_Creater.CallBoth(call, post, delegateCreater, call.DeclaringType);
            m_Injecter.InjectPointer(replacement, call);
        }

        public void PreCall(MethodInfo call, MethodInfo pre, DelegateCreater delegateCreater)
        {
            MethodInfo replacement = m_Creater.CallBoth(pre, call, delegateCreater, call.DeclaringType);
            m_Injecter.InjectPointer(replacement, call);
        }

        #endregion
    }
}
