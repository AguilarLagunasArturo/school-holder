clc;

a = (1750:25:2000)';
po = 1e6*[791 856 978 1050 1262 1544 1650 2532 6122 8170 11560]';

T = table(a, po)

hold on;
plot(a, po, 'o');

p = polyfit(a', po', 2);

nr = 1750:5:2000;
plot(nr, polyval(p, nr));

grid on;

p3 = polyfit(a', po', 6);
hold on;
plot(nr, polyval(p3, nr));

legend('Muesta de datos', 'Ajuste g2', 'Ajuste g3');
xlabel = 'Anios';
ylabel = 'Poblacion';
title = 'Crecimiento poblacional';

err_g2 = mean( abs( po - polyval(p, a)) )
err_g3 = mean( abs( po - polyval(p3, a)) )

figure(2)
hold on;
plot(abs( po - polyval(p, a)))
hold on;
plot(abs( po - polyval(p3, a)))

po_2025 = polyval(p3, 2025)