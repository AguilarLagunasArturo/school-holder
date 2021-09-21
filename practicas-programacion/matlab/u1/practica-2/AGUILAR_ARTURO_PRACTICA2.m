% AGUILAR LAGUNAS ARTURO - PRACTICA NO. 2
clear all;
close all;
clc;

% Condiciones iniciales
tm = input('Temperatura ambiente: ');
cond = input('Condiciones: '); % [t0, t1; T0, T1]
sim_t = input('Tiempo de simulacion: ');
unidades = input('Temperatura [c/f]: ', 's');

% Se calculan incognitas
c = cond(2,1) - tm;
k = log((cond(2,2) - tm) / (cond(2,1) - tm)) / cond(1,2);

% Se convierte de ºC a ºF o viseversa
if unidades == 'c'
    eq_c = @(t) tm + exp(k*t) * c;
    eq_f = @(t) (9/5) * eq_c(t) + 32;
else
    eq_f = @(t) tm + exp(k*t) * c;
    eq_c = @(t) (5/9) * (eq_f(t) - 32);
end

% Se grafica en ºC
subplot(2, 1, 1);
fplot(eq_c, [0, sim_t], '-s', 'color', [120, 180, 200]./255, 'markeredgecolor', 'b', 'linewidth', 2);
xlabel('Tiempo (t)');
ylabel('Temperatura T(t)');
title('Sistema Internacional');
legend('T(t), ºC');
grid on;

% Se grafica en ºF
subplot(2, 1, 2);
fplot(eq_f, [0, sim_t], '-*', 'color', [180, 80, 200]./255, 'markeredgecolor', 'm', 'linewidth', 2);
xlabel('Tiempo (t)');
ylabel('Temperatura T(t)');
title('Sistema Inglés');
legend('T(t), ºF');
grid on;

% Se imprimen temperaturas finales
fprintf('\nT(t_max) = %f ºC', eq_c(sim_t));
fprintf('\nT(t_max) = %f ºF\n', eq_f(sim_t));