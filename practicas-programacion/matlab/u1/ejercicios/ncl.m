function [temp_c, temp_f] = ncl(tm, cond, sim_t, unidades)
c = cond(2,1) - tm;
k = log((cond(2,2) - tm) / (cond(2,1) - tm)) / cond(1,2);

if unidades == 'c'
    eq_c = @(t) tm + exp(k*t) * c;
    eq_f = @(t) (9/5) * (tm + exp(k*t) * c) + 32;
else
    eq_f = @(t) tm + exp(k*t) * c;
    eq_c = @(t) (5/9) * (tm + exp(k*t) * c - 32);
end

subplot(2, 1, 1);
fplot(eq_c, [0, sim_t], '-s', 'color', [120, 180, 200]./255, 'markeredgecolor', 'b', 'linewidth', 2);
xlabel('Tiempo (t)');
ylabel('Temperatura T(t)');
title('Sistema Internacional');
legend('T(t), ºC');
grid on;

subplot(2, 1, 2);
fplot(eq_f, [0, sim_t], '-*', 'color', [180, 80, 200]./255, 'markeredgecolor', 'm', 'linewidth', 2);
xlabel('Tiempo (t)');
ylabel('Temperatura T(t)');
title('Sistema Inglés');
legend('T(t), ºF');
grid on;

temp_c = eq_c(sim_t);
temp_f = eq_f(sim_t);
end

