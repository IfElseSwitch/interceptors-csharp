using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInterceptors.Injection
{
    public class AnyCPUPointerInjecter : PointerInjecter
    {
        private static AnyCPUPointerInjecter s_Instance;
        public static AnyCPUPointerInjecter Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new AnyCPUPointerInjecter();
                return s_Instance;
            }
        }

        Int32PointerInjecter int32Injecter;
        Int64PointerInjecter int64Injecter;

        private AnyCPUPointerInjecter()
        {
            int32Injecter = new Int32PointerInjecter();
            int64Injecter = new Int64PointerInjecter();
        }

        public void InjectPointer(MethodInfo inject, MethodInfo into)
        {
            if (IntPtr.Size == 4)
            {
                int32Injecter.InjectPointer(inject, into);
                return;
            }
            if (IntPtr.Size == 8)
            {
                int64Injecter.InjectPointer(inject, into);
                return;
            }
            throw new PlatformNotSupportedException();
        }
    }
}
