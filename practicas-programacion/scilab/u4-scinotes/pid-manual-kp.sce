clc;
s = %s;
num = 2;
den  = s*(s+1)*(s+2);
g = syslin('c', num/den);
evans(g, 10)
sgrid()

// kp < 3 | tanteando kp = 1.2

ku = 2.998;
wu = 1.414;
tu = (2*%pi)/wu;

kp = 0.6*ku
ki = 1.2*(ku/tu)
kd = (0.6/8)*(ku*tu)

// Manual
// kp = 1.7988
// ki = 0.045
// kd = 1.2
