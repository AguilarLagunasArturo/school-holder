clc;
clear all;

grado = 2;
x = [-1, 0, 2];
y = [0, -1, 3];

p = polyfit(x, y, grado);
hold on;
plot(x, y,'bs');

x_aux = -3:0.01:3;
plot(x_aux, polyval(p, x_aux), '-m');

title('polyfit ejemplificado');