m1 = 3.0;
m2 = 1.0;
l1 = 16.0;
l2 = 16.0;
g = 32;

syms O1(t) O2(t) O3(t) O4(t);
ode1 = diff(O1) == O2;
ode2 = diff(O2) == -(m2*l1*l2*diff(O4)+(m1+m2)*l1*g*O1)/((m1+m2)*power(l1, 2));
ode3 = diff(O3) == O4;
ode4 = diff(O4) == -(m2*l1*l2*diff(O2)+m2*l2*g*O3)/(m2*power(l2, 2));
odes = [ode1; ode2; ode3; ode4];

cond1 = O1(0) == 1;
cond2 = O2(0) == 0;
cond3 = O3(0) == -1;
cond4 = O4(0) == 0;

conds = [cond1; cond2; cond3; cond4];

% S = dsolve(odes, conds);
[O1Sol(t), O2Sol(t), O3Sol(t), O4Sol(t)] = dsolve(odes,conds);
disp(O1Sol(t));
disp(O3Sol(t));

ts = 1:0.01:10;
plot( ts, subs(O1Sol(t), ts) )

% disp(O1Sol(t));
% disp(O3Sol(t));
% ode1 = diff(u) == 3*u + 4*diff(v);
% ode2 = diff(v) == -4*u + 3*v;
% odes = [ode1; ode2];
% S = dsolve(odes);