using System;
using System.Collections.Generic;
using System.Text;
using ILReaderLibrary.ILReader;
using System.Reflection;
using System.Collections;
using CSharpInterceptors.Reading.Visitor;

namespace CSharpInterceptors.Reading
{
    public class ILMethodReader : MethodReader
    {
        ILReader m_Reader;

        private ILMethodReader() { }

        public Instruction[] ReadMethod(MethodInfo method)
        {
            m_Reader = new ILReader(method);
            IEnumerator<ILInstruction> enumerator = m_Reader.GetEnumerator();
            InstructionVisitor visitor = new InstructionVisitor();
            for(; enumerator.MoveNext();)
            {
                ILInstruction instruction = enumerator.Current;
                instruction.Accept(visitor);
            }

            return visitor.Instructions.ToArray();
        }
    }
}
