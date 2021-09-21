clc;
clear all;

ts = 0:0.1:12;

m1 = 10;
m2 = 13;

k1 = 12;
k2 = 10;
k3 = 15;

f = 1;

disp('Resolviendo eq. diff');

syms X1(t) X2(t) X3(t) X4(t);
%syms f

ode1 = diff(X1) == X2;
ode2 = diff(X2) == X1 * (-(k1+k2)/(m1)) + X3 * (k2/m1) + f/m1;
ode3 = diff(X3) == X4;
ode4 = diff(X4) == X1 * (k2/m2) + X3 * (-(k2+k3)/(m2));
odes = [ode1; ode2; ode3; ode4];

cond1 = X1(0) == 0;
cond2 = X2(0) == 0;
cond3 = X3(0) == 0;
cond4 = X4(0) == 0;

conds = [cond1; cond2; cond3; cond4];

% S = dsolve(odes, conds);
[X1Sol(t), X2Sol(t), X3Sol(t), X4Sol(t)] = dsolve(odes,conds);
%disp( X1Sol(t) );
%disp( double(subs(X1Sol(t), [t, f], [ts(1), F(1)])) );
%disp( vpa(X3Sol(t)) );


disp('Generandoo grafica');
disp('graficando?');
disp( vpa(X1Sol(t)) );
disp( vpa(X2Sol(t)) );

figure(2)
hold on;

subplot(2, 1, 1);
plot( ts, double(subs(X1Sol(t), ts)) )
subplot(2, 1, 2);
plot( ts, double(subs(X2Sol(t), ts)) )

%plot( ts, val3 )
%plot( ts, subs(X3Sol(t), ts) )

% disp(O1Sol(t));
% disp(O3Sol(t));
% ode1 = diff(u) == 3*u + 4*diff(v);
% ode2 = diff(v) == -4*u + 3*v;
% odes = [ode1; ode2];
% S = dsolve(odes);