clc;
x = 0:0.01:0.5;
n = 5;
r1 = zeros(1, length(x));
r2 = zeros(1, length(x));

for c = 1:length(x)
    r1(c) = aprox_con_por(x(c), n);
    r2(c) = 1/(1-x(c));
end

err = abs(r1 - r2);
fprintf('Error promedio: %e\n', mean(err));

subplot(2, 1, 1);
hold on;
plot(x, r1);
plot(x, r2);
title('aprox(x) vs f(x)');
legend('aprox(x)', 'f(x)', 'location', 'SouthEast');
grid on;

subplot(2, 1, 2);
plot(x, err);
title('Error absoluto');
grid on;