clc;
clear all;

pares = [];
impares = [];

while true
    val = input('Dame un numero entero: ');
    if mod(val, 1) == 0
        if mod(val, 2) == 0
            pares = [pares; val];
        else
            impares = [impares; val];
        end
    else
        warning('El numero debe ser entero.');
        continue;
    end
    salir = input('-1 para salir del programa: ');
    if salir == -1
        break;
    end
end

fprintf('\nResultados\n\n');
pares
impares