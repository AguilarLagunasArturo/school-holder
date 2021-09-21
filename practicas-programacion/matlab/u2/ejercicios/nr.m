clc;
clear all;
disp('Raiz: x^3 + 2x^2 +10x - 20');
tolerancia = input('Tolerancia: ');
err_estimado = tolerancia + 1;

f = @(x) x.^3 + 2.*x.^2 +10.*x - 20;
fp = @(x) 3.*x.^2 + 4.*x + 10;

fprintf('x\t\t\t\ty\n');
for n = -3:3
    fn = f(n);
    fprintf('%e\t%e\n', n, fn);
end
x_estimada = 1;

% ITERACIONES MAXIMAS
max = input('Ireraciones maximas: ');
fprintf('i\tx1\t\t\t\tf(x1)\t\t\tfp(x1)\t\t\tx2\t\t\t\terr\n');
for n = 1:max
    x_1 = x_estimada;
    y = f(x_estimada);
    yp = fp(x_estimada);
    fprintf('%d\t%e\t%e\t%e', n, x_estimada, y, yp);
    % err_estimado = abs( y );
    x_estimada = x_estimada - y/yp;
    err_estimado = abs( x_1 - x_estimada );
    fprintf('\t%e\t%e\n',x_estimada, err_estimado);
    if err_estimado < tolerancia
        break;
    end
end

hold on;
plot(-3:0.01:3, f(-3:0.01:3), '-m');
plot(x_estimada, y, 'bs');
grid on;
xlabel('x');
ylabel('f(x) = x^3 + 2x^2 +10x - 20');
legend('f(x)', 'raiz');

fprintf('Raíz: %f\n', x_1);