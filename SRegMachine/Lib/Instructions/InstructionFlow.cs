using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRegMachine.Lib.Instructions {
    public class InstructionFlow : Instruction {
        private bool halt;
        private bool reset;

        public InstructionFlow(string instructionText, bool halt, bool reset) : base(instructionText) {
            // Set values
            this.halt = halt;
            this.reset = reset;
        }

        public override void execute(RegisterMachine regMachine) {
            // Halt
            if (halt) {
                regMachine.halt();
            }

            // Reset
            if (reset) {
                regMachine.reset();
            }
        }
    }
}
