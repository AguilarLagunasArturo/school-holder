clc;
x = 0:0.01:0.5;                     % vector con valores de x
n = [1, 2, 3, 4, 5];             % n para las aproximaciones
r1 = zeros(length(n), length(x));   % resultados aproximados
r2 = zeros(length(n), length(x));   % resultados verdaderos

for k = 1:length(n)      % ciclo para las disdintos valores de n (filas)
    for c = 1:length(x)  % ciclo para los valores de x (columnas)
        r1(k, c) = aprox_con_por(x(c), n(k));
        r2(k, c) = 1/(1-x(c));
    end
    
    % Se calcula error promedio para n(k)
    err = abs(r1(k, :) - r2(k, :));
    fprintf('n=%d \tError promedio: %e\n', n(k), mean(err));
    
    % Se grafica
    subplot(2, length(n), k);
    hold on;
    plot(x, r1(k, :));
    plot(x, r2(k, :));
    title( sprintf('aprox(x) n=%d vs f(x)', n(k)) );
    legend('aprox(x)', 'f(x)', 'location', 'SouthEast');
    grid on;
    
    subplot(2, length(n), k+length(n));
    plot(x, err);
    title( sprintf('abs(err) n=%d', n(k)) );
    grid on;
    xlim([0 0.5])
end