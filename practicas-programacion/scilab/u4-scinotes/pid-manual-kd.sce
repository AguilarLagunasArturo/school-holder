clc;
s = %s;
num = 2*s;
den  = s*(s+1)*(s+2)+2.4;
g = syslin('c', num/den)
evans(g, 4)
sgrid()