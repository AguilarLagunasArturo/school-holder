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
rank(M(:, 1:x));
r = M(:, 1:x) \ M(:, x+1)
% delta = M(:, 1:x);
% delta_det = det(delta);
% 
% if delta_det == 0
%     warning('Determinante igual con 0 eq. invalida.');
% else
%     for n = 1:x
%         delta_aux = delta;
%         delta_aux(:, n) = M(:, x+1);
%         fprintf('\nIncognita no. %d: %.4f', n, det(delta_aux) / delta_det);
%     end
% end