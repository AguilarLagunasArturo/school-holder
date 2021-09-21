clear all;
clc;

% SE ASUME ANGULOS PARA ESLABON SENTIDO ANTI-HORARIO CON RESPECTO AL EJE REAL
to_rad = pi/180;
% [longitudes;angulos]
eslab = [30, 60 ,0 ,0 ; 150*to_rad, pi - asin(15/60), 180, 0];
long_x = cos(eslab(2,1)) * eslab(1,1) + cos(eslab(2,2)) * eslab(1,2) + cos(eslab(2,3)) * eslab(1,3);
long_y = sin(eslab(2,1)) * eslab(1,1) + sin(eslab(2,2)) * eslab(1,2) + sin(eslab(2,3)) * eslab(1,3);
eslab(1,4) = sqrt(long_x^2 + long_y^2);
eslab(2,4) = 180*to_rad - atan(abs(long_y/long_x));
eslab_xyz = descomponer(eslab(1,:)', eslab(2,:)');

x_count = 0;
y_count = 0;
x_prev = 0;
y_prev = 0;
c_x = [0, 0];
c_y = [0, 0];
hold on;
for k = 1:length(eslab_xyz(:,1))
    if eslab_xyz(k, 1) == 0 && eslab_xyz(k, 2) == 0
        continue
    end
    x_prev = x_prev + x_count;
    y_prev = y_prev + y_count;
    x_count = x_count + eslab_xyz(k, 1);
    y_count = y_count + eslab_xyz(k, 2);
    if k == 4
        plot([0, eslab_xyz(k, 1)], [0, eslab_xyz(k, 2)]);
        break;
    end
    plot([x_prev, x_count], [y_prev, y_count]);
end

% OMEGAS SE ASUMEN COMO RAD/S
omega2 = 10.47;
omega3 = sym('w3');

% CALCULOS PARA VELOCIDAD
rb = eslab_xyz(1,:);
rcb = eslab_xyz(2,:);

% VB = omega2 x rb
VB = cross([0, 0, omega2], rb);

% VC = VB + V_C/B
VC = VB + cross([0, 0, omega3], rcb);
% DEBUG: DESCOMPONER VC_X, VC_Y | SEPARAR EQ. EN I, J | EC. SIMULTANEAS
w3 = double( solve( VC(2) ) );
VC = double( subs( VC, w3 ) );

% RESULTADOS VELOCIDAD
fprintf('VB = %.2fi + %.2fj\n', VB(1), VB(2));
fprintf('|VB| = %.2f \tangulo(VB) = %.2f\n', norm(VB), atan(VB(2)/VB(1))/to_rad);
fprintf('VC = %.2fi + %.2fj\n', VC(1), VC(2));
fprintf('|VC| = %.2f \tangulo(VC) = %.2f\n', norm(VC), atan(VC(2)/VC(1))/to_rad);

% CALCULOS PARA ASCELERACION