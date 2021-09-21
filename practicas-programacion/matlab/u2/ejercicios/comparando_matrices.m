clc;

a = round (rand( input('A size: ') ) * 10)
b = round (rand( input('B size: ') ) * 10)

if isequal(size(a), size(b))
    c = [a ; b];
    disp(c);
else
    warning('A y B no comparten el mismo tamaño');
    disp([]);
end