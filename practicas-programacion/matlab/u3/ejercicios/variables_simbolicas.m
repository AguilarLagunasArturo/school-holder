clc;
clear all;

syms a b c x
eqn = a*x^2 + b*x + c == 0
S = solve(eqn, a)
S = solve(eqn)

syms a u v
eq1 = a*u^2+v^2==0
eq2 = u-v == 1
eq3 = a^2+6 == 5*a
[sol_a, sol_u, sol_v] = solve(eq1, eq2, eq3, a, u, v)

syms x
eq = sin(x) == x^2-1
solve(eq, x)