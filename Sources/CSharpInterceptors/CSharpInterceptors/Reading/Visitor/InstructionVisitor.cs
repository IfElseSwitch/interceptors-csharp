using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILReaderLibrary.ILReader;
namespace CSharpInterceptors.Reading.Visitor
{
    class InstructionVisitor : ILInstructionVisitor
    {

        private List<Instruction> m_Instructions;

        public InstructionVisitor()
        {
            m_Instructions = new List<Instruction>();
        }

        public List<Instruction> Instructions
        {
            get
            {
                return m_Instructions;
            }
        }

        public override void VisitInlineBrTargetInstruction(InlineBrTargetInstruction inlineBrTargetInstruction)
        {
            base.VisitInlineBrTargetInstruction(inlineBrTargetInstruction);
        }

        public override void VisitInlineFieldInstruction(InlineFieldInstruction inlineFieldInstruction)
        {
            base.VisitInlineFieldInstruction(inlineFieldInstruction);
        }

        public override void VisitInlineI8Instruction(InlineI8Instruction inlineI8Instruction)
        {
            base.VisitInlineI8Instruction(inlineI8Instruction);
        }

        public override void VisitInlineIInstruction(InlineIInstruction inlineIInstruction)
        {
            base.VisitInlineIInstruction(inlineIInstruction);
        }

        public override void VisitInlineMethodInstruction(InlineMethodInstruction inlineMethodInstruction)
        {
            base.VisitInlineMethodInstruction(inlineMethodInstruction);
        }

        public override void VisitInlineNoneInstruction(InlineNoneInstruction inlineNoneInstruction)
        {
            base.VisitInlineNoneInstruction(inlineNoneInstruction);
        }

        public override void VisitInlineRInstruction(InlineRInstruction inlineRInstruction)
        {
            base.VisitInlineRInstruction(inlineRInstruction);
        }

        public override void VisitInlineSigInstruction(InlineSigInstruction inlineSigInstruction)
        {
            base.VisitInlineSigInstruction(inlineSigInstruction);
        }

        public override void VisitInlineStringInstruction(InlineStringInstruction inlineStringInstruction)
        {
            base.VisitInlineStringInstruction(inlineStringInstruction);
        }

        public override void VisitInlineSwitchInstruction(InlineSwitchInstruction inlineSwitchInstruction)
        {
            base.VisitInlineSwitchInstruction(inlineSwitchInstruction);
        }

        public override void VisitInlineTokInstruction(InlineTokInstruction inlineTokInstruction)
        {
            base.VisitInlineTokInstruction(inlineTokInstruction);
        }

        public override void VisitInlineTypeInstruction(InlineTypeInstruction inlineTypeInstruction)
        {
            base.VisitInlineTypeInstruction(inlineTypeInstruction);
        }

        public override void VisitInlineVarInstruction(InlineVarInstruction inlineVarInstruction)
        {
            base.VisitInlineVarInstruction(inlineVarInstruction);
        }

        public override void VisitShortInlineBrTargetInstruction(ShortInlineBrTargetInstruction shortInlineBrTargetInstruction)
        {
            base.VisitShortInlineBrTargetInstruction(shortInlineBrTargetInstruction);
        }

        public override void VisitShortInlineIInstruction(ShortInlineIInstruction shortInlineIInstruction)
        {
            base.VisitShortInlineIInstruction(shortInlineIInstruction);
        }

        public override void VisitShortInlineRInstruction(ShortInlineRInstruction shortInlineRInstruction)
        {
            base.VisitShortInlineRInstruction(shortInlineRInstruction);
        }

        public override void VisitShortInlineVarInstruction(ShortInlineVarInstruction shortInlineVarInstruction)
        {
            base.VisitShortInlineVarInstruction(shortInlineVarInstruction);
        }
    }
}
