using CSharpInterceptors.Binding;
using System;
using System.Diagnostics;

namespace CSharpInterceptors
{
    public static class BinderWrapper
    {
        public static T GetIntercepted<T>(this Interceptor bindable)
        {
            StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(1);
            Type calling = frame.GetMethod().DeclaringType;
            return MethodBinder.GetBoundFromType<T>(calling);
        }
    }
}
