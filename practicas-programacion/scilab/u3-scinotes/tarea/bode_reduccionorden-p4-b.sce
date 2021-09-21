//Comparación de modelo de orden reducido
clc;
s=%s;
gh=syslin('c',1/(s^3+24*s^2+165*s+1700)) //función de transferencia de orden superior
gl=syslin('c',((1/1700)*(s+95))/(s^2+4*s+85)) //función de transferencia de orden inferior
bode([gh;gl],['G_H';'G_L'],'rad')
num = poly( [-20*%i], 's', 'r' )
