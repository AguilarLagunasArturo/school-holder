n = input('factorial: ');
fact = 1;

if mod(n, 1) == 0  && n > 0
    for c = n:-1:1
        fact = fact * c;
    end
    fprintf('%d! = %d\n', n, fact);
else
    warning('Solo numeros enteros positivos')
end
