#    **************************************************************** 
#    *                    Simple Register Machine                             *         
#    *               Lötwig Fusel Assembler Tutorial                      *
#    *                   06 Jump (Multiply by add)                              *
#    ****************************************************************
#
#    Setup Registers:
#    - RA: Number 01
#    - RB: Number 02
#    ---> RD = RA * RB

# Start
:start
LOADI RD 0
MOV RC RB

# Loop
:loop
ADD RD RA
SUBI RC 1
JMPNZ loop

# End
:end
EOF
