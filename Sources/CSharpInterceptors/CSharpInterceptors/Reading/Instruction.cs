using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInterceptors.Reading
{
    public interface Instruction
    {
        void Emit(ILGenerator body);
    }
}
