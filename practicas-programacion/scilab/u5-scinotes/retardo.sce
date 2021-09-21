clc;
s = %s;

num = 10;
den = s*(s+2)*(0.5*s+1);

// Margenes de ganancia y fase
// gh = syslin('c', num, den)
// p_margin(gh)
// bode(gh, 'rad')
// show_margins(gh)

wc = 0.829;
z = wc/10

atenuacion = -14.23;
alpha = 10^(atenuacion/-20);
p = z/alpha

num = (1+s/z) * num;
den = (1+s/p) * den;

// Margenes de ganancia y fase
gh = syslin('c', num, den)
p_margin(gh)
bode(gh, 'rad')
// show_margins(gh, 'r')


