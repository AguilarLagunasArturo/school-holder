clc;
clear all;

p = [1, -6, -72, -27];
r = roots(p)
v = polyval(p, [3, -4, 0, 1, 2, 12])
