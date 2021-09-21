x1 = -4:0.25:4;
x2 = -10:0.1:10;

y1 = 0.6 .* power(x1, 5) - 5 .* power(x1, 3) + 9 .* x1 + 2;
y2 = (power(x2, 2) - x2 + 1) ./ (power(x2, 2) + x2 + 1);

subplot(2, 1, 1);
plot(x1, y1,'r*', 'linewidth', 0.2);
title('Grafica 1','color', [36, 36, 36]./255, 'fontsize', 14);
ylabel('y', 'fontsize', 12, 'fontangle', 'italic');
xlabel('f(x)', 'fontsize', 12, 'fontangle', 'italic');
grid on;

subplot(2, 1, 2);
plot(x2, y2,'--g', 'linewidth', 2);
title('Grafica 2','color', [36, 36, 36]./255, 'fontsize', 14);
ylabel('y', 'fontsize', 12, 'fontangle', 'italic');
xlabel('f(x)', 'fontsize', 12, 'fontangle', 'italic');
grid on;