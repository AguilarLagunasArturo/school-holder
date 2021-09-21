clc;
clear all;

disp('Introducir 0 para salir.');

while true
    val = input('Valor de x: ');
    if val ~= 0
        solucion = fprintf('Solucion: %.2f\n', funcion_problema_2(val));
    else
        break;
    end
end