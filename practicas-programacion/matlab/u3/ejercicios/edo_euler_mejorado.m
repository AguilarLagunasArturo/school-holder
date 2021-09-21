clc;
clear all;

% Condiciones iniciales
to = 1;
tf = 1.5;
xo = 1;
yo = 1;

%X = @(t) tm + exp(-k*t) * (ti - tm)    % sol. analitica
X_prima = @(x, y) 2.*x.*y          % despeje T prima

Ti = 0.05;   % Resolucion
tsim = tf;  % Tiempo de simulacion

t_aprox(1) = to; % Inicializando tiempo
X_aprox(1) = yo; % Inicializando temperatura

% Metodo de Euler
% for k = 1:tsim/Ti
%     X_aprox(k+1) = T_aprox(k) + Ti * T_prima(T_aprox(k));
%     t_aprox(k+1) = t_aprox(k) + Ti;
% end

% Metodo de Euler mejorado
for k = 1:(length(to:Ti:tf) - 1)
    X_aux = X_aprox(k) + Ti * X_prima(t_aprox(k), X_aprox(k));
    t_aprox(k+1) = t_aprox(k) + Ti;
    X_aprox(k+1) = X_aprox(k) + Ti * ( X_prima(t_aprox(k), X_aprox(k)) + X_prima(t_aprox(k+1), X_aux ))/2;
end