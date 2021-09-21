fprintf('x=1, n=4\n');
aprox = programa2(1, 4);
fprintf('log(1+%d) = %f\n', 1, aprox);

iteraciones = [1, 2, 3, 5, 10, 20, 50];

fprintf('\n== x=-0.5 ==\n');
for c = 1:length(iteraciones)
    n = iteraciones(c);
    fprintf('x=-0.5, n=%d\n', n);
    aprox = programa2(-0.5, n);
    fprintf('log(1-0.5) = %f\n', aprox);
end
fprintf('valor real de log(0.5) = %f\n', log(0.5));

fprintf('\n== x=0.5 ==\n');
for c = 1:length(iteraciones)
    n = iteraciones(c);
    fprintf('x=0.5, n=%d\n', n);
    aprox = programa2(0.5, n);
    fprintf('log(1+0.5) = %f\n', aprox);
end
fprintf('valor real de log(1.5) = %f\n', log(1.5));