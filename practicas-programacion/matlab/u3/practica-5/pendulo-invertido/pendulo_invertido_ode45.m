clc;
clear all;

M = 2.0;
m = 0.1;
l = 0.5;
f = 1;
g = 9.81;

eqs = @(t, x) [x(2); ((M+m)*g)/(M*l)*x(1)-f; x(4); -((m*g)/M)*x(1) + f/M]
y0 = [0, 0, 0, 0];

tsim = [0, 2];

[t, x] = ode45(eqs, tsim, y0);

hold on;
plot(t, x(:, 1));
plot(t, x(:, 3));

% subplot(3, 1, 1);
% plot(t, y(:, 1), '-b');
% title('y');
% 
% subplot(3, 1, 2);
% plot(t, y(:, 2), '-m');
% title('dy');
% 
% subplot(3, 1, 3);
% plot(t, y(:, 3), '-g');
% title('dy^2');
