clc; clear all; close all;

%% DATOS SISTEMA
J1 = 5;
J2 = 4;

K1= 10;
K2= 8;

T1 = 1;

%% EC. ESTADO
A = [0, 1, 0, 0; -(K1+K2)/J1, 0, K2/J1, 0; 0, 0, 0, 1; K2/J2, 0, -K2/J2, 0];
B = [0; T1/J1; 0; 0];
C = eye(4);

%% DATOS. SIM
tiempo_sim = 12;
h = [0.08, 0.05, 0.01]

%% M. ANALITICO
p_angular = @(t) 0.1 - 0.0704*cos(0.9167*t) - 0.0295*cos(2.1816*t);
v_angular = @(t) 0.0645*sin(2.1816*t) + 0.0645*sin(0.9167*t);

t = 0:0.1:tiempo_sim;
T = T1 * ones(1, length(t));
figure(1);
plot(t, T);
title('Entrada del sistema (Escalon unitario) [Torque]');
xlabel('segundos');
ylabel('N-m');

figure(2);
subplot(2, 5, 1);
plot(t, p_angular(t));
title('[Analitico] Posicion angular');
xlabel('segundos');
ylabel('radianes');

subplot(2, 5, 6);
plot(t, v_angular(t));
title('[Analitico] Velocidad angular');
xlabel('segundos');
ylabel('radianes/s');

%% M. EULER
x_e(:, 1) = [0, 0, 0, 0];
t_e(1) = 0;
for n = 1:length(h)
    for m = 1:tiempo_sim/h(n)
        x_e(:, m+1) = x_e(:, m) + h(n) * (A*x_e(:, m) + B*T1);
        t_e(m+1) = t_e(m) + h(n);
    end
    
    x_e = C *  x_e;
    subplot(2, 5, 2); hold on;
    plot(t_e, x_e(1, :));
    
    subplot(2, 5, 7); hold on;
    plot(t_e, x_e(2, :));
end
subplot(2, 5, 2);
legend('h1', 'h2', 'h3');
title('[Euler] Posicion angular');
xlabel('segundos');
ylabel('radianes');
subplot(2, 5, 7);
legend('h1', 'h2', 'h3');
title('[Euler] Velocidad angular');
xlabel('segundos');
ylabel('radianes/s');

%% M. EULER MEJORADO
x_m(:, 1) = [0, 0, 0, 0];
t_m(1) = 0;
for n = 1:length(h)
    for m = 1:tiempo_sim/h(n)
        x_m(:, m+1) = x_m(:, m) + h(n) * (A*x_m(:, m) + B*T1);
        t_m(m+1) = t_m(m) + h(n);
        x_m(:, m+1) = x_m(:, m) + h(n) * ( A*x_m(:, m) + B*T1 + A*x_m(:, m+1) + B*T1 )/2;
    end
    
    X1_mejorado = C *  x_m;
    subplot(2, 5, 3); hold on;
    plot(t_m, x_m(1, :));
    
    subplot(2, 5, 8); hold on;
    plot(t_m, x_m(2, :));
end
subplot(2, 5, 3);
legend('h1', 'h2', 'h3');
title('[Euler m.] Posicion angular');
xlabel('segundos');
ylabel('radianes');
subplot(2, 5, 8);
legend('h1', 'h2', 'h3');
title('[Euler m.] Velocidad angular');
xlabel('segundos');
ylabel('radianes/s');

%% M. RK4
x_kutta(:, 1) = [0, 0, 0, 0];
t_kutta(1) = 0;
for n = 1:length(h)
    for m = 1:tiempo_sim/h(n)
        Xn = x_kutta(:, m);
        
        k1 = A*Xn + B*T1;
        k2 = A*(Xn + (h(n)/2) * k1) + B*T1;
        k3 = A*(Xn + (h(n)/2) * k2) + B*T1;
        k4 = A*(Xn + h(n) * k3) + B*T1;

        x_kutta(:, m+1) = x_kutta(:, m) + (h(n)/6) * (k1 + 2.*k2 + 2.*k3 + k4);
        t_kutta(m+1) = t_kutta(m) + h(n);
    end
    
    X1_rk4 = C *  x_kutta;
    subplot(2, 5, 4); hold on;
    plot(t_kutta, x_kutta(1, :));
    
    subplot(2, 5, 9); hold on;
    plot(t_kutta, x_kutta(2, :));
end
subplot(2, 5, 4);
legend('h1', 'h2', 'h3');
title('[RK4] Posicion angular');
xlabel('segundos');
ylabel('radianes');
subplot(2, 5, 9);
legend('h1', 'h2', 'h3');
title('[RK4] Velocidad angular');
xlabel('segundos');
ylabel('radianes/s');

%% M. ODE45
ecuaciones_estado = @(t, x) [x(2); -((K1+K2)*x(1))/J1+(K2*x(3))/J1+T1/J1; x(4); (K2*x(1))/J2-(K2*x(3))/J2];
xo = [0, 0, 0, 0];
tspan = [0, tiempo_sim];
[t, x] = ode45(ecuaciones_estado, tspan, xo);
subplot(2, 5, 5);
plot(t, x(:, 1));

title('[ode45] Posicion angular');
xlabel('segundos');
ylabel('radianes');
subplot(2, 5, 10);
plot(t, x(:, 2));
title('[ode45] Velocidad angular');
xlabel('segundos');
ylabel('radianes/s');