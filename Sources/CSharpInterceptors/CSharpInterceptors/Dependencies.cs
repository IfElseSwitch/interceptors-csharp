using CSharpInterceptors.Creation;
using CSharpInterceptors.Delegation;
using CSharpInterceptors.Injection;

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

        public static DelegateCreater GetDelegateCreater<TInterceptor, TDelegate>()
        {
            return new ConcreteDelegateCreater<TInterceptor, TDelegate>();
        }
    }
}
