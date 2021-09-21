% Programa que resuelve sistemas de ecuaciones
% Datos de entrada
clc;
x = input('No. de incognitas: ');
M = zeros(x, x+1);

for n = 1:length( M(:, 1) ) % n para filas
    fprintf('\n== EQ. %d ==\n', n)
    for m = 1:length( M(1, :) ) % m para columnas
        if m == length( M(1, :) )
            M(n, m) = input(sprintf('Equivalencia eq. %d: ', n));
        else
            M(n, m) = input(sprintf('Coeficiente incognita no. %d: ', m));
        end
    end
end

% Se calculan las incognitas
delta = M(:, 1:x);
delta_det = det(delta);

if delta_det == 0
    warning('Determinante igual con 0 eq. tiene varias soluciones.');
else
    for n = 1:x
        delta_aux = delta;
        delta_aux(:, n) = M(:, x+1);
        fprintf('\nIncognita no. %d: %.4f', n, det(delta_aux) / delta_det);
    end
end

% Ejemplo

% x  + 2y + 3z =  2
% x  + 3y - z  = -2
% 3x + 4y + 3z =  0

% x = -1, y = 0, z = 1