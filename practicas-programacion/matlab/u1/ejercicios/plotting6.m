x = linspace(-2*pi, 2*pi, 1000);
w = linspace(-2*pi, 2*pi,  900);
z = linspace(-2*pi, 2*pi,  800);

fprintf('long X %d\nlong W %d\nlong Z %d\n', length(x), length(w), length(z));

y1 = cuadrada(x);
y2 = cubo(w);
y3 = trig(z);

subplot(2, 2, 1);
plot(x, y1,'-m', 'linewidth', 1.4);
title('Cuadrada','color', [36, 36, 36]./255, 'fontsize', 14);
ylabel('y1', 'fontsize', 12, 'fontangle', 'italic');
xlabel('x', 'fontsize', 12, 'fontangle', 'italic');
grid on;

subplot(2, 2, 3);
plot(w, y2,'-b', 'linewidth', 1.4);
title('Cubica','color', [36, 36, 36]./255, 'fontsize', 14);
ylabel('y2', 'fontsize', 12, 'fontangle', 'italic');
xlabel('w', 'fontsize', 12, 'fontangle', 'italic');
grid on;

subplot(2, 2, [2,4]);
plot(z, y3,'-g', 'linewidth', 1.4);
title('Trigonometrica','color', [36, 36, 36]./255, 'fontsize', 14);
ylabel('y3', 'fontsize', 12, 'fontangle', 'italic');
xlabel('z', 'fontsize', 12, 'fontangle', 'italic');
grid on;