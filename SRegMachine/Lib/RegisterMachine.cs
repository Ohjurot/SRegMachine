using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRegMachine.Lib {
    public class RegisterMachine {
        // Registers
        public UInt16[] register { get; set; }
        // Zero Flag
        public bool zeroFlag { get; set; }
        // Negative flag
        public bool negFlag { get; set; }
        // Overflow flag
        public bool ovFlag { get; set; }

        // Listings
        private List<IListingElement> m_listings;
        // Instruction pointer
        private int m_instructionPointer = 0;
        // Halt 
        private bool m_halt = false;

        // Constructor
        public RegisterMachine() {
            // Create register array
            register = new UInt16[8];
            m_listings = new List<IListingElement>();
        }

        public void halt() {
            m_halt = true;
        }

        // Step an instruction
        public bool stepInstruction() {
            // Result
            bool hasInstruction = false;

            // Move to nexe instruction
            while (m_instructionPointer < m_listings.Count() && m_listings[m_instructionPointer].getListingType() != ListingElementType.Instruction) {
                m_instructionPointer++;
            }

            // Check bounds
            if (m_instructionPointer < m_listings.Count()) {
                // Get instruction
                Instruction instruction = (Instruction)m_listings[m_instructionPointer++];
                // Run instruction
                instruction.execute(this);

                // Check
                hasInstruction = m_instructionPointer < m_listings.Count();

                // Halt
                if (m_halt) {
                    hasInstruction = false;
                    m_halt = false;
                }
            }

            // Return has instructions
            return hasInstruction;
        }

        // Seek lable
        public void seekLable(string name) {
            // Seek trough list
            for(int i = 0; i < m_listings.Count(); i++) {
                // Check if is lable
                if(m_listings[i].getListingType() == ListingElementType.Label) {
                    // Convert to lable
                    Lable lable = (Lable)m_listings[i];
                    
                    // Check name match
                    if(lable.lableName == name) {
                        m_instructionPointer = i + 1;
                    }
                }
            }
        }

        // Reset PC
        public void reset() {
            // Reset
            m_instructionPointer = 0;
            zeroFlag = false;
            negFlag = false;
            ovFlag = false;
        }

        // Peek
        public string pcPeek() {
            // Peek string
            string peek = "";

            // Find next instrcution
            while (m_instructionPointer < m_listings.Count() && m_listings[m_instructionPointer].getListingType() != ListingElementType.Instruction) {
                m_instructionPointer++;
            }

            // Get text
            if(m_instructionPointer < m_listings.Count()) {
                Instruction instruction = (Instruction)m_listings[m_instructionPointer];
                peek = instruction.instructionText;
            }

            // Return string
            return peek;
        }

        // First step
        public bool isFirstStep() {
            return m_instructionPointer == 0;
        }

        // Parse text
        public bool parse(string text) {
            // Reset
            reset();
            
            // Clear old progamm
            m_listings.Clear();

            // For each line
            foreach(string line in text.Split('\n')) {
                // Parse line
                IListingElement element = Parser.parseLine(line);
                // Null check
                if(element != null) {
                    // Store if not null
                    m_listings.Add(element);
                }
                // Check error
                else {
                    // Error message
                    string errorMessage = Parser.getLastError();
                    if(errorMessage != null) {
                        // Show error
                        MessageBox.Show(null, line + "\n\n" + errorMessage, "Assembler parsing error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        // Issue
                        m_listings.Clear();
                        return false;
                    }
                }
            }

            // OK
            return true;
        }
    }
}
