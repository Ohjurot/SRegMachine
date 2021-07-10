#    **************************************************************** 
#    *                    Simple Register Machine                             *         
#    *               Lötwig Fusel Assembler Tutorial                      *
#    *                           07 Tip Calculator                                     *
#    ****************************************************************
#
#    Setup Registers:
#    - RA: Bill cost in cent (23,50€ --> 2350)
#    - RB: Tip percentage (7% --> 7) optional will default to 7%
#    ---> RC: Tip 
#    ---> RD: Total

# Check if percentage was supplied
MOV RW RB
SUBI RW 1
JMPNN calc # not negative mens percentage valid --> skip default

# Load default tip percentage
LOADI RB 7

:calc
# Compute 1 percente
MOV RX RA
DIVI RX 100
# Compute n percente
MUL RX RB

# Store result
MOV RC RX
MOV RD RX
ADD RD RA

# End of calculations
EOF
