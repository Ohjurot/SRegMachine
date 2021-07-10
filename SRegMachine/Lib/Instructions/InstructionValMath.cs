using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRegMachine.Lib.Instructions {
    public class InstructionValMath : Instruction {
        // Operations
        private RegMathOps ops;
        // Instruction values
        private UInt16 regA, value;

        // Constructor
        public InstructionValMath(string instructionText, RegMathOps operation, UInt16 registerIndexA, UInt16 value) : base(instructionText) {
            // Set values
            this.regA = registerIndexA;
            this.value = value;
            this.ops = operation;
        }

        // Exectue function
        public override void execute(RegisterMachine regMachine) {
            // Clear flags
            regMachine.ovFlag = false;
            regMachine.negFlag = false;
            regMachine.zeroFlag = false;
            
            // Set value
            switch (ops) {
                // Add
                case RegMathOps.Add:
                    regMachine.ovFlag = (regMachine.register[regA] + value > UInt16.MaxValue);
                    regMachine.register[regA] = (UInt16)(regMachine.register[regA] + value);
                    break;
                // Sub
                case RegMathOps.Sub:
                    regMachine.negFlag = (regMachine.register[regA] - value < 0);
                    regMachine.register[regA] = (UInt16)(regMachine.register[regA] - value);
                    break;
                // Mul
                case RegMathOps.Mul:
                    regMachine.ovFlag = (regMachine.register[regA] * value > UInt16.MaxValue);
                    regMachine.register[regA] = (UInt16)(regMachine.register[regA] * value);
                    break;
                // Div
                case RegMathOps.Div:
                    regMachine.register[regA] = (UInt16)(regMachine.register[regA] / value);
                    break;
                // Mod
                case RegMathOps.Mod:
                    regMachine.register[regA] = (UInt16)(regMachine.register[regA] % value);
                    break;
            }

            // Zero flag
            regMachine.zeroFlag = (regMachine.register[regA] == 0);
        }
    }
}
