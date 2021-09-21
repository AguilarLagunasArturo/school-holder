clc;

iteraciones = input('¿Cuántas calificaciones? ');
sum_cal = 0;
for n = 1:iteraciones
    fprintf('Dame la cal %d: ', n);
    cal = input('');
    sum_cal = sum_cal + cal
end
fprintf('\nPromedio: %.2f\n', sum_cal / iteraciones);