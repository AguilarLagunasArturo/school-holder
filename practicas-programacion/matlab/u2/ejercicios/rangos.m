clc;

n = input('Dame tu califición: ');

if n>=90 && n<=100
    fprintf('%d -> A\n', n);
elseif n>=80 && n<90
    fprintf('%d -> B\n', n);
elseif n>=70 && n<80
    fprintf('%d -> C\n', n);
elseif n>=60 && n<70
    fprintf('%d -> D\n', n);
else
    fprintf('%d -> F\n', n);
end