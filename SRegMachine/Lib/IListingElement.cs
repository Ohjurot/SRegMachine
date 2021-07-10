using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRegMachine.Lib {
    // Listing element type
    public enum ListingElementType {
        Instruction,
        Label,
    }
    
    // Listing interface
    public interface IListingElement {
        // Listing type
        ListingElementType getListingType();
    }
}
