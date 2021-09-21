clc;
clear all;

ts = 0:0.1:2*pi;
F = ones(1, round(length(ts)/2));
F = [F, 0 * ones(1, round(length(ts)/2))];

disp('Resolviendo eq. diff');

syms X1(t) X2(t) X3(t) X4(t);
syms f

f = 1;
ode1 = diff(X1) == X2;
ode2 = diff(X2) == -9*X1+5*X3;
ode3 = diff(X3) == X4;
ode4 = diff(X4) == (f-5*X3+5*X1)/2;
odes = [ode1; ode2; ode3; ode4];

cond1 = X1(0) == 0;
cond2 = X2(0) == 0;
cond3 = X3(0) == 0;
cond4 = X4(0) == 0;

conds = [cond1; cond2; cond3; cond4];

% S = dsolve(odes, conds);
[X1Sol(t), X2Sol(t), X3Sol(t), X4Sol(t)] = dsolve(odes,conds);
disp( vpa(X1Sol(t)) );
disp( vpa(X2Sol(t)) );

hold on;
subplot(1, 4, 1)
plot( ts, subs(X1Sol(t), ts) )
subplot(1, 4, 2)
plot( ts, subs(X2Sol(t), ts) )
