#    **************************************************************** 
#    *                    Simple Register Machine                             *         
#    *               Lötwig Fusel Assembler Tutorial                      *
#    *      05 Mean Value of 4 points sampled voltage           *
#    ****************************************************************
#
#    U0 = 1/T * integral(0 to T, u(t) dt)
#    Numberic for 4 samples
#    U0 = sum(x = 0 to 3, u(x) ) / 4
#
#    Register:
#    - RA = u(0 * T/4)
#    - RB = u(1 * T/4)
#    - RC = u(2 * T/4)
#    - RD = u(3 * T/4)
#    ---> RA = U0

# Sum to RA
ADD RA RB
ADD RA RC
ADD RA RD
DIVI RA 4
EOF