clc;
clear all;

% Parametros
M = 2.0;
m = 0.1;
l = 0.5;
g = 9.81;

% Ecuaciones de estado
A = [0, 1, 0, 0; (M+m)*g, 0, 0, 0; 0, 0, 0, 1; -m*g, 0, 0, 0];
B = [0; -1; 0; 1];

Cx1 = [1, 0, 0, 0]; % posicion angular
Cx2 = [0, 1, 0, 0]; % velocidad angular
Cx3 = [0, 0, 1, 0]; % posicion
Cx4 = [0, 0, 0, 1]; % velocidad

% Condiciones iniciales
X1_aprox(1) = 0;
X2_aprox(1) = 0;
X3_aprox(1) = 0;
X4_aprox(1) = 0;
X_aprox(:, 1) = [X1_aprox; X2_aprox; X3_aprox; X4_aprox];

Ti = [0.1, 0.05, 0.001];     % Resolucion
tsim = 2;       % Tiempo de simulacion

% Entrada del sistema
f = 1;

% Tiempo inicial
t_aprox(1) = 0;


% Metodo de Euler
for c = 1:length(Ti)
    % Iteraciones
    a = tsim/Ti(c);
    u = f * ones(1, a);
    for k = 1:tsim/Ti(c)
        X_aprox(:, k+1) = X_aprox(:, k) + Ti(c) * (A*X_aprox(:, k) + B*u(k));

        X1_aprox(k+1) = Cx1 *  X_aprox(:, k+1);
        X2_aprox(k+1) = Cx2 *  X_aprox(:, k+1);
        X3_aprox(k+1) = Cx3 *  X_aprox(:, k+1);
        X4_aprox(k+1) = Cx4 *  X_aprox(:, k+1);

        t_aprox(k+1) = t_aprox(k) + Ti(c);
    end
    
    subplot(2, 5, 2);
    hold on;
    plot(t_aprox, X_aprox(1, :));
    grid on;
    
    subplot(2, 5, 7);
    hold on;
    plot(t_aprox, X_aprox(3, :));
    grid on;
end

subplot(2, 5, 2);
legend('1', '2', '3');

subplot(2, 5, 7);
legend('1', '2', '3');