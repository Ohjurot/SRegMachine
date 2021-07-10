using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRegMachine.Lib.Instructions {
    public class InstructionMOV : Instruction {
        // Instruction values
        private UInt16 regA, regB;

        // Constructor
        public InstructionMOV(string instructionText, UInt16 regIndexA, UInt16 regIndexB) : base(instructionText) {
            // Set values
            this.regA = regIndexA;
            this.regB = regIndexB;
        }

        // Exectue function
        public override void execute(RegisterMachine regMachine) {
            // Set value
            regMachine.register[regA] = regMachine.register[regB];
        }
    }
}
