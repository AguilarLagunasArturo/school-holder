clc;
clear all;

% Parametros

% Ecuaciones
%Q = @(t) V.*C.*(1-exp(-t/(R.*C))) % Sol. Analitica

A = [0, 1, 0, 0; -9, 0, 5, 0; 0, 0, 0, 1; 2.5, 0, -2.5, 0]
B = [0; 0; 0; 0.5]
Cx1 = [1, 0, 0, 0] % posicion angular
Cx2 = [0, 1, 0, 0] % velocidad angular
Cx3 = [0, 0, 1, 0] % posicion
Cx4 = [0, 0, 0, 1] % velocidad

Ti = 0.001;       % Resolucion
tsim = 6;       % Tiempo de simulacion
a = tsim/Ti;    % Iteraciones

% Condiciones iniciales
X1_aprox(1) = 0;
X2_aprox(1) = 0;
X3_aprox(1) = 0;
X4_aprox(1) = 0;

X_aprox(:, 1) = [X1_aprox; X2_aprox; X3_aprox; X4_aprox]

u = ones(1, a);
% Tiempo inicial
t_aprox(1) = 0;

% Metodo de Euler
for k = 1:tsim/Ti
    X_aprox(:, k+1) = X_aprox(:, k) + Ti * (A*X_aprox(:, k) + B*u(k));
    
    X1_aprox(k+1) = Cx1 *  X_aprox(:, k+1);
    X2_aprox(k+1) = Cx2 *  X_aprox(:, k+1);
    X3_aprox(k+1) = Cx3 *  X_aprox(:, k+1);
    X4_aprox(k+1) = Cx4 *  X_aprox(:, k+1);
    
    t_aprox(k+1) = t_aprox(k) + Ti;
end

t_r = linspace(0, tsim, 1000);
figure(2)
hold on;
%plot(t_r, Q(t_r));
subplot(1, 2, 1);
plot(t_aprox, X_aprox(1, :));
subplot(1, 2, 2);
plot(t_aprox, X_aprox(2, :));
%legend('Analitico', 'Euler');
%title('Q(t)');
%xlabel('tiempo (s)');
%ylabel('carga (coulomb)');
grid on;