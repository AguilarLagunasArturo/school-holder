x = linspace(-2*pi, 2*pi, 1000);
w = linspace(-2*pi, 2*pi,  900);
z = linspace(-2*pi, 2*pi,  800);

fprintf('long X %d\nlong W %d\nlong Z %d', length(x), length(w), length(z));

y1 = cuadrada(x);
y2 = cubo(w);
y3 = trig(z);

figure;
title('Graficas','color', [36, 36, 36]/255, 'fontsize', 14);
hold on;

plot(x, y1,'--b');
plot(w, y2,'--g');
plot(z, y3,'--r');

grid on;
ylabel('y', 'fontsize', 12, 'fontangle', 'italic');
xlabel('x', 'fontsize', 12, 'fontangle', 'italic');
legend('y1 = cuadrada(x)', 'y2 = cubo(w)', 'y3 = trigonometrica(z)');
