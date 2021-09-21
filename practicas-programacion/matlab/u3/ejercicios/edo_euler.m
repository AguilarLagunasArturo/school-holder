clc;
clear all;

% Parametros
R = 100;
C = 0.01;
V = 10;

% Condiciones iniciales
qo = 0;
to = 0;

% Ecuaciones
Q = @(t) V.*C.*(1-exp(-t/(R.*C))) % Sol. Analitica
Q_prima = @(q) V/R - q/(R*C)      % Despeje. Q prima

Ti = 0.1; % Resolucion
tsim = 5; % Tiempo de simulacion

Q_aprox(1) = qo; % Inicializando carga inicial
t_aprox(1) = to; % Inicializando tiempo inicial

% Metodo de Euler
for k = 1:tsim/Ti
    Q_aprox(k+1) = Q_aprox(k) + Ti * Q_prima(Q_aprox(k));
    t_aprox(k+1) = t_aprox(k) + Ti;
end

t_r = linspace(0, tsim, 1000);
hold on;
plot(t_r, Q(t_r));
plot(t_aprox, Q_aprox);
legend('Analitico', 'Euler');
title('Q(t)');
xlabel('tiempo (s)');
ylabel('carga (coulomb)');
grid on;