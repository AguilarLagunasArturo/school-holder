clc;
clear all;

% Ec
U = @(x, y) x.^2 + x.*y - 10;
V = @(x, y) y + 3.*x.*y.^2 - 57;
% Du x, y
dUx = @(x, y) 2.*x + y;
dUy = @(x, y) x;
% Dv x, y
dVx = @(x, y) 3.*y.^2;
dVy = @(x, y) 1 + 6.*x.*y;

% Condicones iniciales
xo = 1.5;
yo = 3.5;
err = 0.002;
err_n = err+1;

hold on;
xx = linspace(-5, 5, 1000);
yy = linspace(-5, 5, 1000);
plot( xx, U(xx, yy) );
plot( xx, V(xx, yy) );

while err_n > err
    dj = dUx(xo, yo)*dVy(xo, yo) - dUy(xo, yo)*dVx(xo, yo);
    xo_aux = xo;
    yo_aux = yo;
    xo = xo - ( U(xo_aux, yo_aux)*dVy(xo_aux, yo_aux) - V(xo_aux, yo_aux)*dUy(xo_aux, yo_aux) )/dj;
    yo = yo - ( V(xo_aux, yo_aux)*dUx(xo_aux, yo_aux) - U(xo_aux, yo_aux)*dVx(xo_aux, yo_aux) )/dj;
    
    err_u = abs( U(xo, yo) );
    err_v = abs( V(xo, yo) );
    
    err_n = abs(err_u + err_v);
end
plot(xo, yo, 'ms');

legend('U(x, y)', 'V(x, y)', 'xo, yo');
xlabel('x');
ylabel('y');
title('Sistemas no lineales (N-R)');
grid on;

xo
yo