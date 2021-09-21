clc;
clear all;

eqs = @(t, y) [y(2).*y(3); -y(1).*y(3); -0.5.*y(1).*y(2)]
y0 = [0, 1, 1];

tsim = [0, 10];

[t, y] = ode45(eqs, tsim, y0);

subplot(3, 1, 1);
plot(t, y(:, 1), '-b');
title('y');

subplot(3, 1, 2);
plot(t, y(:, 2), '-m');
title('dy');

subplot(3, 1, 3);
plot(t, y(:, 3), '-g');
title('dy^2');
