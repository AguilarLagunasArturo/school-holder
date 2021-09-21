x = 0:pi/20:2*pi;
y1 = sin(x);
y2 = sin(x-0.25);
y3 = sin(x-0.5);

figure;
title('Graficas de seno','color', [36, 36, 36]/255, 'fontsize', 14);
hold on;

plot(x, y1,'-bo', 'markerfacecolor', 'c');
plot(x, y2, '--gs', 'markeredgecolor', 'r');
plot(x, y3, 'rx', 'markeredgecolor', 'k');

grid on;
ylabel('y', 'fontsize', 12, 'fontangle', 'italic');
xlabel('x', 'fontsize', 12, 'fontangle', 'italic');
legend('y1 = sen(x)', 'y2 = sen(x-0.25)', 'y3 = sen(x-0.5)');
