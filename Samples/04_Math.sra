#    **************************************************************** 
#    *                    Simple Register Machine                             *         
#    *               Lötwig Fusel Assembler Tutorial                      *
#    *                        04 Math (line function)                              *
#    ****************************************************************
#       
#    Samples a value from a line of form
#    f(x) = m * x + b
#
#    Setup Registers:
#    - RA: Parameter "m"
#    - RB: Parameter "b"
#    - RC: Parameter "x"
#    ---> RD = f(x)

MOV RD RA
MUL RD RC
ADD RD RB
EOF


