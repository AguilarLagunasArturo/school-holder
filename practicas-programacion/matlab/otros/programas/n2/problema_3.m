clear all;
clc;

n = 1;
m = 2;
p = 3;

A = zeros(n, m);
B = zeros(m, p);

disp('Captura matriz A:')
for fila = 1:n
    for columna = 1:m
        A(fila, columna) = input('Elemento: ');
    end
end
disp(A);

disp('Captura matriz B:')
for fila = 1:m
    for columna = 1:p
        B(fila, columna) = input('Elemento:');
    end
end
disp(B);

B_prima = B';

disp('A*B=');
disp(A * B);
disp('A+B=');
disp(A + B_prima);