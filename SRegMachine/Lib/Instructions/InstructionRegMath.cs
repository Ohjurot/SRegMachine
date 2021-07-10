﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRegMachine.Lib.Instructions {
    // Register math operations
    public enum RegMathOps {
        Add,
        Sub,
        Mul,
        Div,
        Mod,
    }

    public class InstructionRegMath : Instruction {
        // Operations
        private RegMathOps ops;
        // Instruction values
        private UInt16 regA, regB;

        // Constructor
        public InstructionRegMath(string instructionText, RegMathOps operation, UInt16 registerIndexA, UInt16 registerIndexB) : base(instructionText) {
            // Set values
            this.regA = registerIndexA;
            this.regB = registerIndexB;
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
                    regMachine.ovFlag = (regMachine.register[regA] + regMachine.register[regB] > UInt16.MaxValue);
                    regMachine.register[regA] = (UInt16)(regMachine.register[regA] + regMachine.register[regB]);
                    break;
                // Sub
                case RegMathOps.Sub:
                    regMachine.negFlag = (regMachine.register[regA] - regMachine.register[regB] < 0);
                    regMachine.register[regA] = (UInt16)(regMachine.register[regA] - regMachine.register[regB]);
                    break;
                // Mul
                case RegMathOps.Mul:
                    regMachine.ovFlag = (regMachine.register[regA] * regMachine.register[regB] > UInt16.MaxValue);
                    regMachine.register[regA] = (UInt16)(regMachine.register[regA] * regMachine.register[regB]);
                    break;
                // Div
                case RegMathOps.Div:
                    regMachine.register[regA] = (UInt16)(regMachine.register[regA] / regMachine.register[regB]);
                    break;
                // Mod
                case RegMathOps.Mod:
                    regMachine.register[regA] = (UInt16)(regMachine.register[regA] % regMachine.register[regB]);
                    break;
            }

            // Zero flag
            regMachine.zeroFlag = (regMachine.register[regA] == 0);
        }
    }
}
