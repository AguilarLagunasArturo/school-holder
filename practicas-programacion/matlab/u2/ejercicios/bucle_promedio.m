clear all;
clc;

cal = 0;
contador = 1;
disp('-1 para salir.');

while true
    val = input(sprintf('%d. - Calificacion entre 0-100: ', contador));
    if val >= 0 && val <= 100
        cal(contador) = val;
    else
        if val == -1
            break
        end
        warning('No cumple con las condiciones');
        continue;
    end
    contador = contador + 1;
end
fprintf('Promedio: %.2f\n', mean(cal));
