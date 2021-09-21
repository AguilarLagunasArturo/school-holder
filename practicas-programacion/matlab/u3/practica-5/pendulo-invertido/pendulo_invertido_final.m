% PROGRAMA QUE MUESTRA EL COMPORTAMIENTO DE LA POSICION DE LAS MASAS EN UN
% SISTEMA DE ECUACIONES DIFERENCIALES, ESPECIFICAMENTE UN PENDULO INVERTIDO
% -------------------------------------------------------------------------
clc;
clear all;

% Datos para metodos numericos
tsim = 2;
Ti = [0.2, 0.1, 0.05];
% Parametros del sistema
M = 2.0;
m = 0.1;
l = 0.5;
g = 9.81;
% Entrada del sistema
f = 1;
% Condiciones iniciales del sistema
condiciones = [0, 0, 0, 0];
% Titulos
titulo_x = 'tiempo (t)';
titulo_y_1 = 'posicion angular (theta) [DEG]';
titulo_y_2 = 'posicion (x) [m]';
grid_y = 2;
grid_x = 6;

% ECUACIONES DE ESTADO
A = [0, 1, 0, 0; ((M+m)*g)/(M*l), 0, 0, 0; 0, 0, 0, 1; -(m*g)/M, 0, 0, 0];
B = [0; -1/(M*l); 0; 1/M];
C = eye(4);
% C(1,:), posicion angular
% C(2,:), velocidad angular
% C(3,:), posicion
% C(4,:), velocidad

% EULER
% Condiciones iniciales
X_aprox(:, 1) = [condiciones(1); condiciones(2); condiciones(3); condiciones(4)];
% Tiempo inicial
t_euler(1) = 0;
for c = 1:length(Ti)
    % Iteraciones
    a = tsim/Ti(c);
    u = f * ones(1, a);
    
    for k = 1:tsim/Ti(c)
        X_aprox(:, k+1) = X_aprox(:, k) + Ti(c) * (A*X_aprox(:, k) + B*u(k));
        t_euler(k+1) = t_euler(k) + Ti(c);
    end
    
    X_aprox = C *  X_aprox;
    
    subplot(grid_y, grid_x, 1);
    hold on;
    plot(t_euler, X_aprox(1, :));
    
    subplot(grid_y, grid_x, 7);
    hold on;
    plot(t_euler, X_aprox(3, :));
end

subplot(grid_y, grid_x, 1);
legend(sprintf('h = %.4f', Ti(1)), sprintf('h = %.4f', Ti(2)), sprintf('h = %.4f', Ti(3)), 'Location', 'SouthWest');
title('Euler');
xlabel(titulo_x);
ylabel(titulo_y_1);
grid on;
    
subplot(grid_y, grid_x, 7);
legend(sprintf('h = %.4f', Ti(1)), sprintf('h = %.4f', Ti(2)), sprintf('h = %.4f', Ti(3)), 'Location', 'NorthWest');
title('Euler');
xlabel(titulo_x);
ylabel(titulo_y_2);
grid on;

% MEJORADO
t_mejorado(1) = 0;
X_mejorado(:, 1) = [condiciones(1); condiciones(2); condiciones(3); condiciones(4)];

for c = 1:length(Ti)
    a = tsim/Ti(c);    % Iteraciones
    u = ones(1, a+1);
    for k = 1:tsim/Ti(c)
        X_mejorado(:, k+1) = X_mejorado(:, k) + Ti(c) * (A*X_mejorado(:, k) + B*u(k));
        t_mejorado(k+1) = t_mejorado(k) + Ti(c);
        X_mejorado(:, k+1) = X_mejorado(:, k) + Ti(c) * ( A*X_mejorado(:, k) + B*u(k) + A*X_mejorado(:, k+1) + B*u(k+1) )/2;

    end
    X1_mejorado = C *  X_mejorado;
    subplot(grid_y, grid_x, 2);
    hold on;
    plot(t_mejorado, X_mejorado(1, :));
    subplot(grid_y, grid_x, 8);
    hold on;
    plot(t_mejorado, X_mejorado(3, :));
end
subplot(grid_y, grid_x, 2);
legend(sprintf('h = %.4f', Ti(1)), sprintf('h = %.4f', Ti(2)), sprintf('h = %.4f', Ti(3)), 'Location', 'SouthWest');
title('Euler mejorado');
xlabel(titulo_x);
ylabel(titulo_y_1);
grid on;
subplot(grid_y, grid_x, 8);
legend(sprintf('h = %.4f', Ti(1)), sprintf('h = %.4f', Ti(2)), sprintf('h = %.4f', Ti(3)), 'Location', 'NorthWest');
title('Euler mejorado');
xlabel(titulo_x);
ylabel(titulo_y_2);
grid on;

% rk4
X_rk4(:, 1) = [condiciones(1); condiciones(2); condiciones(3); condiciones(4)];
t_rk4(1) = 0;

for c = 1:length(Ti)
    a = tsim/Ti(c);    % Iteraciones
    u = ones(1, a+1);
    for k = 1:tsim/Ti(c)
        %k1, k2, k3, k4
        Xn = X_rk4(:, k);

        k1 = A*Xn + B*u(k);
        k2 = A*(Xn + (Ti(c)/2) * k1) + B*u(k);
        k3 = A*(Xn + (Ti(c)/2) * k2) + B*u(k);
        k4 = A*(Xn + Ti(c) * k3) + B*u(k);

        X_rk4(:, k+1) = X_rk4(:, k) + (Ti(c)/6) * (k1 + 2.*k2 + 2.*k3 + k4);
        t_rk4(k+1) = t_rk4(k) + Ti(c);
    end
    
    X1_rk4 = C *  X_rk4;
    
    subplot(grid_y, grid_x, 3);
    hold on;
    plot(t_rk4, X_rk4(1, :));
    subplot(grid_y, grid_x, 9);
    hold on;
    plot(t_rk4, X_rk4(3, :));
end
subplot(grid_y, grid_x, 3);
legend(sprintf('h = %.4f', Ti(1)), sprintf('h = %.4f', Ti(2)), sprintf('h = %.4f', Ti(3)), 'Location', 'SouthWest');
title('rk4');
xlabel(titulo_x);
ylabel(titulo_y_1);
grid on;
subplot(grid_y, grid_x, 9);
legend(sprintf('h = %.4f', Ti(1)), sprintf('h = %.4f', Ti(2)), sprintf('h = %.4f', Ti(3)), 'Location', 'NorthWest');
title('rk4');
xlabel(titulo_x);
ylabel(titulo_y_2);
grid on;

% ode45
eqs = @(t, x) [x(2); ((M+m)*g)/(M*l)*x(1)-f; x(4); -((m*g)/M)*x(1) + f/M];
Xo = [condiciones(1), condiciones(2), condiciones(3), condiciones(4)];

tspan = [0, tsim];

[t, x] = ode45(eqs, tspan, Xo);

subplot(grid_y, grid_x, 4);
plot(t, x(:, 1));
title('ode45');
xlabel(titulo_x);
ylabel(titulo_y_1);
grid on;

subplot(grid_y, grid_x, 10);
plot(t, x(:, 3));
title('ode45');
xlabel(titulo_x);
ylabel(titulo_y_2);
grid on;


% ANALITICA
disp('Resolviendo ecuacion diferencial');
% Variables simbolicas
syms X1(t) X2(t) X3(t) X4(t);   % Variables de estado
syms f;                         % Entrada del sistema
% Sistema de ecuaciones
ode1 = diff(X1) == X2;
ode2 = diff(X2) == ((M+m)*g)/(M*l)*X1-f/(M*l);
ode3 = diff(X3) == X4;
ode4 = diff(X4) == -((m*g)/M)*X1 + f/M;
odes = [ode1; ode2; ode3; ode4];
% Condiciones iniciales
cond1 = X1(0) == condiciones(1);
cond2 = X2(0) == condiciones(2);
cond3 = X3(0) == condiciones(3);
cond4 = X4(0) == condiciones(4);
conds = [cond1; cond2; cond3; cond4];
% Reolucion
[X1Sol(t), X2Sol(t), X3Sol(t), X4Sol(t)] = dsolve(odes,conds);
% Datos simulacion
t_anal = 0:0.1:tsim;                     % Tiempo de simulacion
F = ones(1, round(length(t_anal)/2));
F = [F, 0 *F];
F = ones(1, length(t_anal));             % Entrada escalon unitario

% Generando grafica
disp('Generandoo grafica');
for n = 1:length(t_anal)
    fprintf('%.2f%%\n', (n/length(t_anal)) * 100);
    val1(n) = double(subs(X1Sol(t), [t, f], [t_anal(n), F(n)]));
    val3(n) = double(subs(X3Sol(t), [t, f], [t_anal(n), F(n)]));
end

clc;

subplot(grid_y, grid_x, 5);
plot( t_anal, val1 );
title('Solucion analitica');
xlabel(titulo_x);
ylabel(titulo_y_1);
grid on;

subplot(grid_y, grid_x, 11);
plot( t_anal, val3 );
title('Solucion analitica');
xlabel(titulo_x);
ylabel(titulo_y_2);
grid on;
