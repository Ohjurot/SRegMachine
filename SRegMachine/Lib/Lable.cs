using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRegMachine.Lib {
    public class Lable : IListingElement {
        // Lable name
        public string lableName { get; }

        // Constructor
        public Lable(string name) {
            lableName = name;
        }

        // Interface
        public ListingElementType getListingType() {
            return ListingElementType.Label;
        }
    }
}
