clc;
clear all;

% Condiciones iniciales
to = 0;
tf = 10;
ti = 68;
tm = 21;
k = 0.1;

T = @(t) tm + exp(-k*t) * (ti - tm)              % sol. analitica
T_prima = @(temperatura) -k*(temperatura - tm)   % despeje T prima

Ti = 0.5;   % Resolucion
tsim = tf;  % Tiempo de simulacion

T_aprox(1) = ti; % Inicializando temperatura
t_aprox(1) = to; % Inicializando tiempo

% Metodo de Euler
for k = 1:tsim/Ti
    T_aprox(k+1) = T_aprox(k) + Ti * T_prima(T_aprox(k));
    t_aprox(k+1) = t_aprox(k) + Ti;
end

% Metodo de Euler mejorado
for k = 1:tsim/Ti
    T_aprox(k+1) = T_aprox(k) + Ti * T_prima(T_aprox(k));
    
    
    t_aprox(k+1) = t_aprox(k) + Ti;
end

t_r = linspace(0, tsim, 1000);
hold on;
plot(t_r, T(t_r));
plot(t_aprox, T_aprox);
legend('Analitico', 'Euler');
title('T(t) Cambio de temperatura a travez tiempo');
xlabel('tiempo (min)');
ylabel('temperatura (ºC)');
grid on;