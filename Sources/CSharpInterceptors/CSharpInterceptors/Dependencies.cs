using CSharpInterceptors.Creation;
using CSharpInterceptors.Delegation;
using CSharpInterceptors.Injection;

namespace CSharpInterceptors
{
    public static class Dependencies
    {
        public static PointerInjecter GetPointerInjecter()
        {
            return AnyCPUPointerInjecter.Instance;
        }

        public static MethodCreater GetMethodCreater()
        {
            return CompositeMethodCreater.Instance;
        }

        public static DelegateCreater GetDelegateCreater<TInterceptor, TDelegate>()
        {
            return new ConcreteDelegateCreater<TInterceptor, TDelegate>();
        }
    }
}
