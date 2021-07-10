using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRegMachine.Lib.Instructions {
    // Jump operations
    public enum JumpOperation {
        Always,
        ZeroFlag,
        NegFlag,
        OvFlag,
    }

    public class InstructionJump : Instruction {
        // Instruction values
        private JumpOperation op;
        private string lable;
        bool checkCondition;

        // Constructor
        public InstructionJump(string instructionText, JumpOperation operation, bool condition, string lable) : base(instructionText) {
            // Set values
            this.op = operation;
            this.lable = lable;
            this.checkCondition = condition;
        }

        // Exectue function
        public override void execute(RegisterMachine regMachine) {
            // Switch on operation mode
            switch (op) {
                // Always
                case JumpOperation.Always:
                    regMachine.seekLable(lable);
                    break;

                // Zero flag
                case JumpOperation.ZeroFlag:
                    if(regMachine.zeroFlag == checkCondition){
                        regMachine.seekLable(lable);
                    }
                    break;

                // Negative flag
                case JumpOperation.NegFlag:
                    if(regMachine.negFlag == checkCondition){
                        regMachine.seekLable(lable);
                    }
                    break;

                // Overflow flag
                case JumpOperation.OvFlag:
                    if(regMachine.ovFlag == checkCondition){
                        regMachine.seekLable(lable);
                    }
                    break;
            }
        }
    }
}
