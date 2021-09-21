clc;
clear all;

A = [0, 1, 0, 0; 20.601, 0, 0, 0; 0, 0, 0, 1; -0.4905, 0, 0, 0]
B = [0; -1; 0; 0.5]

Cx1 = [1, 0, 0, 0] % posicion angular
Cx2 = [0, 1, 0, 0] % velocidad angular
Cx3 = [0, 0, 1, 0] % posicion
Cx4 = [0, 0, 0, 1] % velocidad

Ti = 0.001;       % Resolucion
tsim = 2;         % Tiempo de simulacion
a = tsim/Ti;      % Iteraciones

% Condiciones iniciales
X1_rk4(1) = 0;
X2_rk4(1) = 0;
X3_rk4(1) = 0;
X4_rk4(1) = 0;
X_ek4(:, 1) = [X1_rk4; X2_rk4; X3_rk4; X4_rk4]

u = ones(1, a+1);
% Tiempo inicial
t_rk4(1) = 0;

% Metodo RK4
for k = 1:tsim/Ti
    %k1, k2, k3, k4
    Xn = X_ek4(:, k);
    
    k1 = A*Xn + B*u(k);
    k2 = A*(Xn + (Ti/2) * k1) + B*u(k);
    k3 = A*(Xn + (Ti/2) * k2) + B*u(k);
    k4 = A*(Xn + Ti * k3) + B*u(k);
    
    X_ek4(:, k+1) = X_ek4(:, k) + (Ti/6) * (k1 + 2.*k2 + 2.*k3 + k4);
    
    X1_rk4(k+1) = Cx1 *  X_ek4(:, k+1);
    X2_rk4(k+1) = Cx2 *  X_ek4(:, k+1);
    X3_rk4(k+1) = Cx3 *  X_ek4(:, k+1);
    X4_rk4(k+1) = Cx4 *  X_ek4(:, k+1);
    
    t_rk4(k+1) = t_rk4(k) + Ti;
end

figure(2);
hold on;
plot(t_rk4, X_ek4(1, :));
plot(t_rk4, X_ek4(4, :));

