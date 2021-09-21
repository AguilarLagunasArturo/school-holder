clc;
clear all;

A = [0, 1, 0, 0; 20.601, 0, 0, 0; 0, 0, 0, 1; -0.4905, 0, 0, 0]
B = [0; -1; 0; 0.5]
Cx1 = [1, 0, 0, 0] % posicion angular
Cx2 = [0, 1, 0, 0] % velocidad angular
Cx3 = [0, 0, 1, 0] % posicion
Cx4 = [0, 0, 0, 1] % velocidad

Ti = [0.1, 0.05, 0.001];       % Resolucion
tsim = 2;       % Tiempo de simulacion

% Condiciones iniciales
X1_aprox(1) = 0;
X2_aprox(1) = 0;
X3_aprox(1) = 0;
X4_aprox(1) = 0;

X_aprox(:, 1) = [X1_aprox; X2_aprox; X3_aprox; X4_aprox]


% Tiempo inicial
t_mejorado(1) = 0;

% Metodo de Euler mejorado
for c = 1:length(Ti)
    a = tsim/Ti(c);    % Iteraciones
    u = ones(1, a+1);
    for k = 1:tsim/Ti(c)
        X_aprox(:, k+1) = X_aprox(:, k) + Ti(c) * (A*X_aprox(:, k) + B*u(k));

        t_mejorado(k+1) = t_mejorado(k) + Ti(c);
        X_aprox(:, k+1) = X_aprox(:, k) + Ti(c) * ( A*X_aprox(:, k) + B*u(k) + A*X_aprox(:, k+1) + B*u(k+1) )/2;

        X1_aprox(k+1) = Cx1 *  X_aprox(:, k+1);
        X2_aprox(k+1) = Cx2 *  X_aprox(:, k+1);
        X3_aprox(k+1) = Cx3 *  X_aprox(:, k+1);
        X4_aprox(k+1) = Cx4 *  X_aprox(:, k+1);
    end
    
    subplot(2, 5, 4);
    hold on;
    plot(t_mejorado, X_aprox(1, :));
    subplot(2, 5, 9);
    hold on;
    plot(t_mejorado, X_aprox(3, :));
end