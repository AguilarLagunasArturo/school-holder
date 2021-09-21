clc;
n = input('Dame un número entero positivo: ');
if n > 0
    if n>=0 && n<=4
        i = input('Dame el intervalo para el seno ');
        grid on;
        plot(i, sin(i))
    else
        i = input('Dame el intervalo para el coseno ');
        grid on;
        plot(i, cos(i))
    end
else
    disp('El numero no es positivo');
end
