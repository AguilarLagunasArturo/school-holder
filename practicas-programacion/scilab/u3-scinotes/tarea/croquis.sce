s = %s;
k = 0.6343;
p = 2/3;
num = k;
den = s^2+p*s;
sgrid();
evans(num/den, k);
