clc;
clear all;

elemento = 0.0005;
elemento_actual = 1;

x = input('Angulo cos(x) en rad: ');

aprox = 1;
c = 1;
while elemento_actual >= elemento
    elemento_actual = x^(c*2)/factorial(c*2);
    if mod(c, 2) == 0
        aprox = aprox + elemento_actual;
    else
        aprox = aprox - elemento_actual;
    end
    c = c+1;
end

fprintf('cos(%f) = %f\n', x, aprox);