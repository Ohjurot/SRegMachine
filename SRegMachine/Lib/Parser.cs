using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRegMachine.Lib {
    public class Parser {
        private static string m_lastErrMessage = null;

        // Get last error
        public static string getLastError() {
            // Temp store
            string temp = m_lastErrMessage;
            // Unset
            m_lastErrMessage = null;
            // Return
            return temp;
        }

        // Parse line
        public static IListingElement parseLine(string line) {
            // Output element
            IListingElement element = null;

            // Builder list
            List<string> builderList = new List<string>();

            // State 
            int state = 0;

            // Char state machine
            foreach(char c in line) {
                // Swtich on state
                switch (state) {
                    // Case 0 - Nothing detected
                    case 0:
                        // Swtich character
                        switch (c) {
                            // Comment
                            case '#':
                                state = 99;
                                break;

                            // Lable
                            case ':':
                                builderList.Add("");
                                state = 1;
                                break;

                            // Space / Tab (ignore)
                            case ' ':
                            case '\t':
                                break;

                            // Default (Net state instruction) 
                            default:
                                // New string
                                builderList.Add("");
                                builderList[0] += Char.ToUpper(c);
                                // State
                                state = 4;
                                break;
                        }
                        break;

                    // Case 1 - Lable
                    case 1:
                        // Switch character
                        switch (c) {
                            // Label end text
                            case ' ':
                            case '\t':
                                state = 2;
                                break;

                            // Comment begin
                            case '#':
                                state = 3;
                                break;

                            // Default append lable name
                            default:
                                // Append lable name
                                builderList[0] += Char.ToUpper(c);
                                break;

                        }
                        break;

                    // Case 2 - label text end
                    case 2:
                        switch (c) {
                            // Allow spaces
                            case ' ':
                            case '\t':
                                break;

                            // Allow comment
                            case '#':
                                state = 3;
                                break;

                            // Any other char will fail
                            default:
                                m_lastErrMessage = "No spaces allowed in lable names!";
                                state = 99;
                                break;
                        }
                        break;

                    // Case 3 - comment
                    case 3:
                        // Nothing on comment
                        break;

                    // Case 4 - instruction arguments
                    case 4:
                        // Switch character
                        switch (c) {
                            // First break
                            case ' ':
                            case '\t':
                                // State is spacing
                                state = 5;
                                break;

                            // Start comment
                            case '#':
                                // State is comments
                                state = 6;
                                break;

                            // Any other char
                            default:
                                // Append char
                                builderList[builderList.Count() - 1] += Char.ToUpper(c);
                                break;

                        }
                        break;

                    // Case 5 - spacings
                    case 5:
                        // Switch character
                        switch (c) {
                            // Spaced continue execution
                            case ' ':
                            case '\t':
                                break;

                            // Start comment
                            case '#':
                                // State is comments
                                state = 6;
                                break;

                            // Next argument
                            default:
                                builderList.Add("");
                                builderList[builderList.Count() - 1] += Char.ToUpper(c);
                                state = 4;
                                break;
                        }
                        break;

                    // Case 6 - comment instruction
                    case 6:
                        break;

                    // NULL State
                    case 99:
                        break;
                }
            }

            // Check final state
            switch (state) {
                // Label 
                // Valid while name and comment
                case 1:
                case 2:
                case 3:
                    // Create lable
                    element = new Lable(builderList[0]);
                    break;

                // Instruction
                case 4:
                case 5:
                case 6:
                    element = parseInstruction(ref builderList);
                    break;
            }

            // Return element
            return element;
        }

        // Register index
        public static UInt16 registerIndex(string str) {
            // String
            switch (str) {
                case "RA":
                    return 0;
                case "RB":
                    return 1;
                case "RC":
                    return 2;
                case "RD":
                    return 3;

                case "RW":
                    return 4;
                case "RX":
                    return 5;
                case "RY":
                    return 6;
                case "RZ":
                    return 7;

                default:
                    return 100;
            }
        }

        public static IListingElement parseInstruction(ref List<string> textArgs) {
            // Element
            IListingElement element = null;

            // Build text
            string instructionText = "";
            foreach(string arg in textArgs) {
                instructionText += arg + " ";
            }

            // Parse error message
            switch (textArgs[0]) {
                // LOADI
                case "LOADI":
                    // Set error message (optinal)
                    m_lastErrMessage = "Invalid usage of instruction LOADI.\nLOADI <REG> <VALUE>";

                    // Valid arg count
                    if (textArgs.Count == 3) {
                        // Index and value 
                        UInt16 index = registerIndex(textArgs[1]);
                        UInt16 value = 0;
                        if(index <= 7 && UInt16.TryParse(textArgs[2], out value)) {
                            element = new Instructions.InstructionLOADI(instructionText, index, value);
                            m_lastErrMessage = null;
                        }
                    }
                    break;

                // MOV
                case "MOV":
                    // Set error message (optinal)
                    m_lastErrMessage = "Invalid usage of instruction MOV.\nMOV <REG> <REG>";

                    // Valid arg count
                    if (textArgs.Count == 3) {
                        // Registers
                        UInt16 regA = registerIndex(textArgs[1]);
                        UInt16 regB = registerIndex(textArgs[2]);
                        if (regA <= 7 && regB <= 7) {
                            element = new Instructions.InstructionMOV(instructionText, regA, regB);
                            m_lastErrMessage = null;
                        }
                    }
                    break;

                // ADD
                case "ADD":
                    // Set error message (optinal)
                    m_lastErrMessage = "Invalid usage of instruction ADD.\nADD <REG> <REG>";

                    // Valid arg count
                    if (textArgs.Count == 3) {
                        // Registers
                        UInt16 regA = registerIndex(textArgs[1]);
                        UInt16 regB = registerIndex(textArgs[2]);
                        if (regA <= 7 && regB <= 7) {
                            element = new Instructions.InstructionRegMath(instructionText, Instructions.RegMathOps.Add, regA, regB);
                            m_lastErrMessage = null;
                        }
                    }
                    break;

                // ADDI
                case "ADDI":
                    // Set error message (optinal)
                    m_lastErrMessage = "Invalid usage of instruction ADDI.\nADDI <REG> <VALUE>";

                    // Valid arg count
                    if (textArgs.Count == 3) {
                        // Registers
                        UInt16 regA = registerIndex(textArgs[1]);
                        UInt16 value = 0;
                        if (regA <= 7 && UInt16.TryParse(textArgs[2], out value)) {
                            element = new Instructions.InstructionValMath(instructionText, Instructions.RegMathOps.Add, regA, value);
                            m_lastErrMessage = null;
                        }
                    }
                    break;

                // SUB
                case "SUB":
                    // Set error message (optinal)
                    m_lastErrMessage = "Invalid usage of instruction SUB.\nSUB <REG> <REG>";

                    // Valid arg count
                    if (textArgs.Count == 3) {
                        // Registers
                        UInt16 regA = registerIndex(textArgs[1]);
                        UInt16 regB = registerIndex(textArgs[2]);
                        if (regA <= 7 && regB <= 7) {
                            element = new Instructions.InstructionRegMath(instructionText, Instructions.RegMathOps.Sub, regA, regB);
                            m_lastErrMessage = null;
                        }
                    }
                    break;

                // SUBI
                case "SUBI":
                    // Set error message (optinal)
                    m_lastErrMessage = "Invalid usage of instruction SUBI.\nSUBI <REG> <VALUE>";

                    // Valid arg count
                    if (textArgs.Count == 3) {
                        // Registers
                        UInt16 regA = registerIndex(textArgs[1]);
                        UInt16 value = 0;
                        if (regA <= 7 && UInt16.TryParse(textArgs[2], out value)) {
                            element = new Instructions.InstructionValMath(instructionText, Instructions.RegMathOps.Sub, regA, value);
                            m_lastErrMessage = null;
                        }
                    }
                    break;

                // MUL
                case "MUL":
                    // Set error message (optinal)
                    m_lastErrMessage = "Invalid usage of instruction MUL.\nMUL <REG> <REG>";

                    // Valid arg count
                    if (textArgs.Count == 3) {
                        // Registers
                        UInt16 regA = registerIndex(textArgs[1]);
                        UInt16 regB = registerIndex(textArgs[2]);
                        if (regA <= 7 && regB <= 7) {
                            element = new Instructions.InstructionRegMath(instructionText, Instructions.RegMathOps.Mul, regA, regB);
                            m_lastErrMessage = null;
                        }
                    }
                    break;

                // MULI
                case "MULI":
                    // Set error message (optinal)
                    m_lastErrMessage = "Invalid usage of instruction MULI.\nMULI <REG> <VALUE>";

                    // Valid arg count
                    if (textArgs.Count == 3) {
                        // Registers
                        UInt16 regA = registerIndex(textArgs[1]);
                        UInt16 value = 0;
                        if (regA <= 7 && UInt16.TryParse(textArgs[2], out value)) {
                            element = new Instructions.InstructionValMath(instructionText, Instructions.RegMathOps.Mul, regA, value);
                            m_lastErrMessage = null;
                        }
                    }
                    break;

                // ADD
                case "DIV":
                    // Set error message (optinal)
                    m_lastErrMessage = "Invalid usage of instruction DIV.\nDIV <REG> <REG>";

                    // Valid arg count
                    if (textArgs.Count == 3) {
                        // Registers
                        UInt16 regA = registerIndex(textArgs[1]);
                        UInt16 regB = registerIndex(textArgs[2]);
                        if (regA <= 7 && regB <= 7) {
                            element = new Instructions.InstructionRegMath(instructionText, Instructions.RegMathOps.Div, regA, regB);
                            m_lastErrMessage = null;
                        }
                    }
                    break;

                // DIVI
                case "DIVI":
                    // Set error message (optinal)
                    m_lastErrMessage = "Invalid usage of instruction DIVI.\nDIVI <REG> <VALUE>";

                    // Valid arg count
                    if (textArgs.Count == 3) {
                        // Registers
                        UInt16 regA = registerIndex(textArgs[1]);
                        UInt16 value = 0;
                        if (regA <= 7 && UInt16.TryParse(textArgs[2], out value)) {
                            element = new Instructions.InstructionValMath(instructionText, Instructions.RegMathOps.Div, regA, value);
                            m_lastErrMessage = null;
                        }
                    }
                    break;

                // MOD
                case "MOD":
                    // Set error message (optinal)
                    m_lastErrMessage = "Invalid usage of instruction MOD.\nMOD <REG> <REG>";

                    // Valid arg count
                    if (textArgs.Count == 3) {
                        // Registers
                        UInt16 regA = registerIndex(textArgs[1]);
                        UInt16 regB = registerIndex(textArgs[2]);
                        if (regA <= 7 && regB <= 7) {
                            element = new Instructions.InstructionRegMath(instructionText, Instructions.RegMathOps.Mod, regA, regB);
                            m_lastErrMessage = null;
                        }
                    }
                    break;

                // MODI
                case "MODI":
                    // Set error message (optinal)
                    m_lastErrMessage = "Invalid usage of instruction MODI.\nMODI <REG> <VALUE>";

                    // Valid arg count
                    if (textArgs.Count == 3) {
                        // Registers
                        UInt16 regA = registerIndex(textArgs[1]);
                        UInt16 value = 0;
                        if (regA <= 7 && UInt16.TryParse(textArgs[2], out value)) {
                            element = new Instructions.InstructionValMath(instructionText, Instructions.RegMathOps.Mod, regA, value);
                            m_lastErrMessage = null;
                        }
                    }
                    break;

                // JMP
                case "JMP":
                    // Valid arg count
                    if(textArgs.Count == 2) {
                        element = new Instructions.InstructionJump(instructionText, Instructions.JumpOperation.Always, false, textArgs[1]);
                    }
                    // Invalid args
                    else {
                        m_lastErrMessage = "Invalid usage of instruction JMP.\nJMP <LABLE>";
                    }
                    break;

                // JMPZ
                case "JMPZ":
                    // Valid arg count
                    if(textArgs.Count == 2) {
                        element = new Instructions.InstructionJump(instructionText, Instructions.JumpOperation.ZeroFlag, true, textArgs[1]);
                    }
                    // Invalid args
                    else {
                        m_lastErrMessage = "Invalid usage of instruction JMPZ.\nJMPZ <LABLE>";
                    }
                    break;

                // JMPNZ
                case "JMPNZ":
                    // Valid arg count
                    if(textArgs.Count == 2) {
                        element = new Instructions.InstructionJump(instructionText, Instructions.JumpOperation.ZeroFlag, false, textArgs[1]);
                    }
                    // Invalid args
                    else {
                        m_lastErrMessage = "Invalid usage of instruction JMPNZ.\nJMPNZ <LABLE>";
                    }
                    break;

                // JMPN
                case "JMPN":
                    // Valid arg count
                    if(textArgs.Count == 2) {
                        element = new Instructions.InstructionJump(instructionText, Instructions.JumpOperation.NegFlag, true, textArgs[1]);
                    }
                    // Invalid args
                    else {
                        m_lastErrMessage = "Invalid usage of instruction JMPN.\nJMPN <LABLE>";
                    }
                    break;

                // JMPNN
                case "JMPNN":
                    // Valid arg count
                    if(textArgs.Count == 2) {
                        element = new Instructions.InstructionJump(instructionText, Instructions.JumpOperation.NegFlag, false, textArgs[1]);
                    }
                    // Invalid args
                    else {
                        m_lastErrMessage = "Invalid usage of instruction JMPNN.\nJMPNN <LABLE>";
                    }
                    break;

                // JMPO
                case "JMPO":
                    // Valid arg count
                    if(textArgs.Count == 2) {
                        element = new Instructions.InstructionJump(instructionText, Instructions.JumpOperation.OvFlag, true, textArgs[1]);
                    }
                    // Invalid args
                    else {
                        m_lastErrMessage = "Invalid usage of instruction JMPO.\nJMPO <LABLE>";
                    }
                    break;

                // JMPON
                case "JMPON":
                    // Valid arg count
                    if(textArgs.Count == 2) {
                        element = new Instructions.InstructionJump(instructionText, Instructions.JumpOperation.OvFlag, false, textArgs[1]);
                    }
                    // Invalid args
                    else {
                        m_lastErrMessage = "Invalid usage of instruction JMPON.\nJMPON <LABLE>";
                    }
                    break;

                // HOLD
                case "HOLD":
                    if(textArgs.Count == 1) {
                        element = new Instructions.InstructionFlow(instructionText, true, false);
                    }
                    // Invalid args
                    else {
                        m_lastErrMessage = "HALT takes no arguments!";
                    }
                    break;

                // RST
                case "RST":
                    if(textArgs.Count == 1) {
                        element = new Instructions.InstructionFlow(instructionText, false, true);
                    }
                    // Invalid args
                    else {
                        m_lastErrMessage = "RST takes no arguments!";
                    }
                    break;

                // EOF
                case "EOF":
                    if(textArgs.Count == 1) {
                        element = new Instructions.InstructionFlow(instructionText, true, true);
                    }
                    // Invalid args
                    else {
                        m_lastErrMessage = "EOF takes no arguments!";
                    }
                    break;

                // Invalid instruction
                default:
                    m_lastErrMessage = "Instruction \"" + textArgs[0] + "\" is not a valid instruction!";
                    break;
            }

            // Return element
            return element;
        }
    }
}
