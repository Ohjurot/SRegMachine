using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRegMachine.Lib {
    // Instruction
    public abstract class Instruction : IListingElement {
        public string instructionText { get; }
        
        // Constructor
        public Instruction(string plainString) {
            instructionText = plainString;
        }

        // Interface
        public ListingElementType getListingType() {
            return ListingElementType.Instruction;
        }

        // Execute instruction
        public abstract void execute(RegisterMachine regMachine);
    }
}
