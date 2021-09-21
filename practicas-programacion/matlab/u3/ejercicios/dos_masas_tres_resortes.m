clc; clear all;
disp('Sistema masa-resorte con dos masas y tres resortes.');
disp('h1=0.20');
disp('h2=0.10');
disp('h3=0.02');

% Datos de la simulacion
tsim = 12;
ti = [0.2, 0.1, 0.02];

% Parametros del sistema
m1 = 10;
m2 = 13;
k1 = 12;
k2 = 10;
k3 = 15;
% Entrada del sistema
f = 1;

% Ecuaciones de estado
A = [0, 1, 0, 0; (-(k1+k2)/(m1)), 0, (k2/m1), 0; 0, 0, 0, 1; (k2/m2), 0, (-(k2+k3)/(m2)), 0];
B = [0; 1/m1; 0; 0];
C = [1, 0, 0, 0; 0, 1, 0, 0];


% Metodo de Euler
for m = 1:length(ti)
    % condiciones iniciales
    clear x_euler t_euler;
    x_euler(:, 1) = [0, 0, 0, 0];
    t_euler(1) = 0;
    
    for n = 1:tsim/ti(m)
        x_euler(:, n+1) = x_euler(:, n) + ti(m) * (A*x_euler(:, n) + B*f);
        t_euler(n+1) = t_euler(n) + ti(m);
    end
    x_euler = C *  x_euler;
    
    subplot(2, 5, 1); 
    hold on;
    plot(t_euler, x_euler(1, :));
    
    subplot(2, 5, 6); 
    hold on;
    plot(t_euler, x_euler(2, :));
end

subplot(2, 5, 1);
legend('h1', 'h2', 'h3');
title('Desplazamiento M1 (Euler)');
xlabel('segundos');
ylabel('m');

subplot(2, 5, 6);
legend('h1', 'h2', 'h3');
title('Velocidad M1 (Euler)');
xlabel('segundos');
ylabel('m/s');

% Metodo de Euler mejorado
for m = 1:length(ti)
    % condiciones iniciales
    clear t_mejorado x_mejorado;
    t_mejorado(1) = 0;
    x_mejorado(:, 1) = [0, 0, 0, 0];
    
    for n = 1:tsim/ti(m)
        x_mejorado(:, n+1) = x_mejorado(:, n) + ti(m) * (A*x_mejorado(:, n) + B*f);
        t_mejorado(n+1) = t_mejorado(n) + ti(m);
        x_mejorado(:, n+1) = x_mejorado(:, n) + ti(m) * ( A*x_mejorado(:, n) + B*f + A*x_mejorado(:, n+1) + B*f )/2;
    end
    x_mejorado = C *  x_mejorado;
    
    subplot(2, 5, 2);
    hold on;
    plot(t_mejorado, x_mejorado(1, :));
    
    subplot(2, 5, 7);
    hold on;
    plot(t_mejorado, x_mejorado(2, :));
end

subplot(2, 5, 2);
legend('h1', 'h2', 'h3');
title('Desplazamiento M1 (E. Mejorado)');
xlabel('segundos');
ylabel('m');

subplot(2, 5, 7);
legend('h1', 'h2', 'h3');
title('Velocidad M1 (E. Mejorado)');
xlabel('segundos');
ylabel('m/s');

% Metodo Runge-Kutta orden 4
for m = 1:length(ti)
    % condiciones iniciales
    clear x_kr4 t_kr4;
    x_kr4(:, 1) = [0, 0, 0, 0];
    t_kr4(1) = 0;
    
    for n = 1:tsim/ti(m)
        xn = x_kr4(:, n);
        k_1 = A*xn + B*f;
        k_2 = A*(xn + (ti(m)/2) * k_1) + B*f;
        k_3 = A*(xn + (ti(m)/2) * k_2) + B*f;
        k_4 = A*(xn + ti(m) * k_3) + B*f;

        x_kr4(:, n+1) = x_kr4(:, n) + (ti(m)/6) * (k_1 + 2.*k_2 + 2.*k_3 + k_4);
        t_kr4(n+1) = t_kr4(n) + ti(m);
    end
    X1_rk4 = C *  x_kr4;
    
    subplot(2, 5, 3);
    hold on;
    plot(t_kr4, x_kr4(1, :));
    
    subplot(2, 5, 8);
    hold on;
    plot(t_kr4, x_kr4(2, :));
end

subplot(2, 5, 3);
legend('h1', 'h2', 'h3');
title('Desplazamiento M1 (RK-4)');
xlabel('segundos');
ylabel('m');

subplot(2, 5, 8);
legend('h1', 'h2', 'h3');
title('Velocidad M1 (RK-4)');
xlabel('segundos');
ylabel('m/s');

% Metodo ODE45
ecuaciones_estado = @(t, x) [x(2); x(1) * (-(k1+k2)/(m1)) + x(3) * (k2/m1) + f/m1; x(4); x(1) * (k2/m2) + x(3) * (-(k2+k3)/(m2))];

% condiciones iniciales
xo = [0, 0, 0, 0];

tspan = [0, tsim];
[t, x] = ode45(ecuaciones_estado, tspan, xo);

subplot(2, 5, 4);
plot(t, x(:, 1));
title('Desplazamiento de M1 (ODE45)');
xlabel('segundos');
ylabel('m');

subplot(2, 5, 9);
plot(t, x(:, 2));
title('Velocidad de M1 (ODE45)');
xlabel('segundos');
ylabel('m/s');


% Metodo analitico
x_anal = @(t) 0.0555- 0.0195.*cos(1.7173.*t) - 0.0359.*cos(1.0833.*t);
x_anal_prima = @(t) 0.0389.*sin(1.0833.*t) + 0.0336.*sin(1.7173.*t);
t = 0:0.01:tsim;

subplot(2, 5, 5);
plot(t, x_anal(t));
title('Desplazamiento de M1');
xlabel('segundos');
ylabel('m');

subplot(2, 5, 10);
plot(t, x_anal_prima(t));
title('Velocidad de M1');
xlabel('segundos');
ylabel('m/s');

figure(2);
F = f * ones(1, length(t));
F(1) = 0;
subplot(3, 1, 1);
plot(t, F, '-r');
title('Fuerza (Escalon unitario)');
xlabel('segundos');
ylabel('N');
subplot(3, 1, 2);
plot(t, x_anal(t), '-y');
title('Posicion (Analitica)');
xlabel('segundos');
ylabel('m');
subplot(3, 1, 3);
plot(t, x_anal_prima(t), '-g');
title('Velocidad (Analitica)');
xlabel('segundos');
ylabel('m/s');


