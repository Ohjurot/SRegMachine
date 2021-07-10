using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRegMachine.Lib.Instructions {
    public class InstructionLOADI : Instruction {
        // Instruction values
        private UInt16 registerIndex, registerValue;
        
        // Constructor
        public InstructionLOADI(string instructionText, UInt16 registerIndex, UInt16 registerValue) : base(instructionText) {
            // Set values
            this.registerIndex = registerIndex;
            this.registerValue = registerValue;
        }

        // Exectue function
        public override void execute(RegisterMachine regMachine) {
            // Set value
            regMachine.register[registerIndex] = registerValue;
        }
    }
}
