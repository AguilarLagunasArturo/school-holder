clc;
clear all;

% Condiciones iniciales
to = 0;
tf = 10;
yi = 0;
Q = 1500;
A = 1200;

% T = @(t) tm + exp(-k*t) * (ti - tm)              % sol. analitica
Y_prima = @(t) (3*Q*sin(t)*sin(t))/A - Q/A   % despeje Y prima

Ti = 0.1;   % Resolucion
tsim = tf;  % Tiempo de simulacion

Y_aprox(1) = yi; % Inicializando temperatura
t_aprox(1) = to; % Inicializando tiempo

% Metodo de Euler
for k = 1:tsim/Ti
    Y_aprox(k+1) = Y_aprox(k) + Ti * Y_prima(t_aprox(k));
    t_aprox(k+1) = t_aprox(k) + Ti;
end

%t_r = linspace(0, tsim, 1000);
hold on;
%plot(t_r, T(t_r));
plot(t_aprox, Y_aprox);
%legend('Analitico', 'Euler');
title('Y(t) Cambio volumen con respecto al tiempo');
xlabel('tiempo (d)');
ylabel('volumen (m^3)');
grid on;