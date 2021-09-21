clc;
clear all;

ts = 0:0.1:2;
F = ones(1, round(length(ts)/2));
F = [F, 0 * ones(1, round(length(ts)/2))];

M = 2.0;
m = 0.1;
l = 0.5;
f = 1;
g = 9.81;

disp('Resolviendo eq. diff');

syms X1(t) X2(t) X3(t) X4(t);
syms f

ode1 = diff(X1) == X2;
ode2 = diff(X2) == ((M+m)*g)/(M*l)*X1-f;
ode3 = diff(X3) == X4;
ode4 = diff(X4) == -((m*g)/M)*X1 + f/M;
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
for n = 1:length(ts)
    fprintf('%.2f%%\n', (n/length(ts)) * 100);
    val3(n) = double(subs(X3Sol(t), [t, f], [ts(n), F(n)]));
    val4(n) = double(subs(X4Sol(t), [t, f], [ts(n), F(n)]));
end
clc;

disp('graficando?');
figure(1)
hold on;
subplot(2, 1, 1);
plot( ts, val3 )
subplot(2, 1, 2);
plot( ts, val4 )

%plot( ts, val3 )
%plot( ts, subs(X3Sol(t), ts) )

% disp(O1Sol(t));
% disp(O3Sol(t));
% ode1 = diff(u) == 3*u + 4*diff(v);
% ode2 = diff(v) == -4*u + 3*v;
% odes = [ode1; ode2];
% S = dsolve(odes);