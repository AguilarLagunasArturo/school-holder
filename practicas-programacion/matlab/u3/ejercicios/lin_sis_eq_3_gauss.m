clear all;
clc;

% Datos
A = [1, 1, -1; 2, 1, -1; 0, -1, 1];
b = [0; 1; 1];

% Se calculan las incognitas
x = A\b
x = rref([A b])

clear all;

% Datos
A = [1, 2, 2; 3, 1, 2; 4, 3, 3];
b = [1; 5; 8];

% Se calculan las incognitas
x = A\b
x = rref([A b])

