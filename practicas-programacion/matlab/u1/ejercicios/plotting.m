% plot
x = linspace(0, 2*pi, 20);
grid on;
%plot(x, sin(x), '-go', 'linewidth', 1, 'markersize', 5);
% markeredgecolor, markerfacecolor
%plot(x, sin(x), '-x', 'color', [200, 80, 250]/255, 'linewidth', 2, 'markersize', 6, 'markeredgecolor', 'r');
plot(x, 20*log(cos(x)), '-o', 'color', [20, 80, 100]/255, 'linewidth', 2, 'markersize', 8, 'markeredgecolor', 'k', 'markerfacecolor', 'r');
