clc;
x = [12, 64, 24];
cond = input('Dame una opcion: ', 's');

% Comparar strings: strcmp('s1', 's2')

switch cond
    case 'bar'
        bar(x);
        title('Barras');
    case {'pie', 'pie3'}
        pie3(x);
        title('Pastel');
    otherwise
        warning('invalido')
end