using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInterceptors.Reading.Instructions
{
    abstract class AbstractInstruction : Instruction
    {
        private OpCode m_OpCode;

        public abstract void Emit(ILGenerator body);
    }
}
