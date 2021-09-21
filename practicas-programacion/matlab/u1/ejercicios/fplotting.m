fh = @tanh;
subplot(2, 2, 1);
fplot(fh, [-2, 2], 'color', [180,36,240]./255);
title('F plt 0','color', [36, 36, 36]/255, 'fontsize', 14);

subplot(2, 2, 2);
sn = @(x) sin(1 ./ x);
fplot(sn, [0.01, 0.1], '--m');
title('F plt 1','color', [36, 36, 36]/255, 'fontsize', 14);

subplot(2, 2, 3);
cua = @(x) x.^2;
fplot(cua, [-10, 10], '-m');
title('F plt 2','color', [36, 36, 36]/255, 'fontsize', 14);

subplot(2, 2, 4);
fun = @(x, y) x.^2-y.^4;
v = ezplot(fun);
set(v, 'color', 'g', 'linewidth', 1, 'linestyle', '--');
title('plt facil','color', [36, 36, 36]/255, 'fontsize', 14);