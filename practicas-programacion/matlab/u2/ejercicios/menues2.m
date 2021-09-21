clc;

disp('== MENU ==');
disp('A) Suma de dos numeros enteros');
disp('B) Resta de dos numeros enteros');
disp('C) Multiplicacion de dos numeros enteros');

op = input('Dame una opcion: ', 's');
a = input('Dame el numero entero a: ');
b = input('Dame el numero entero b: ');

switch op
    case {'a', 'A'}
        fprintf('a + b = %d\n', a + b)
    case {'b', 'B'}
        if a > b
            fprintf('a - b = %d\n', a - b)
        else
            warning('Tu numero es negativo')
        end
    case {'c', 'C'}
        fprintf('a * b = %d\n', a * b)
    otherwise
        warning('No hay opcion %s', op)
end