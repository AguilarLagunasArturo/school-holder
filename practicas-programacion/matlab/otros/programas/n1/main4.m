clear all;

fprintf('x\tsin(x)\tcos(x)\ttan(x)\tcot(x)\tsec(x)\tcsc(x)\n');

x = 0;
n = 1;
cond = true;
while cond
    funciones = programa4(x);
    eje_x(n) = x; 
    f1(n) = funciones(1);
    f2(n) = funciones(2);
    f3(n) = funciones(3);
    f4(n) = funciones(4);
    f5(n) = funciones(5);
    f6(n) = funciones(6);
    
    fprintf('%.2f\t%.2f\t%.2f\t%.2f\t%.2f\t%.2f\t%.2f\n', x, funciones(1), funciones(2), funciones(3), funciones(4), funciones(5), funciones(6));
    
    val = input('Para terminar presiona 0: ');
    if val == 0
        cond = false;
    end
    
    x = x + pi/10;
    n = n+1;
end

subplot(2, 3, 1)
plot(eje_x, f1);
title('sen(x)');

subplot(2, 3, 2)
plot(eje_x, f2);
title('cos(x)');

subplot(2, 3, 3)
plot(eje_x, f3);
title('tan(x)');

subplot(2, 3, 4)
plot(eje_x, f4);
title('cot(x)');

subplot(2, 3, 5)
plot(eje_x, f5);
title('sec(x)');

subplot(2, 3, 6)
plot(eje_x, f6);
title('csc(x)');
