clc;
clear all;

h = 5700;
m = 300;
t = 500:500:10000;

Mt = m .* funcion_problema_4(t, h);

tiempo = t';
masa = Mt';
T = table(tiempo, masa);
disp(T);