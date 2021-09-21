clc;
clear all;

// Ecuaciones de estado
A = [0, 1, 0, 0; -100, -10, 100, 10; 0, 0, 0, 1; 100, 10, -200, -20]
B = [0; 0; 0; 1/100]
C = [1, 0, 0, 0]
D = [0]

// Crontrolabilidad
Cc = [B, A * B, A^2 * B, A^3 * B]
det(Cc)

// Funcion de transferencia (integrador / no integrador | ess = 0)
s = %s;
As = size(A);
H = C * inv(s.*eye(As(1), As(2)) - A) * B + D

// Polos para condiciones del problema (interpolando)
interpol_values = [
    0.2, 1.5, 4.6, 9.5, 16.3, 25.4, 37.2;
    0.9, 0.8, 0.7, 0.6, 0.5, 0.4, 0.3  
];
po = 15;
ts = 2;
zeta = interpln(interpol_values, po);
theta = acos(zeta) .* (180/%pi);
zeta_omega = 4 ./ ts;
y = zeta_omega * tan(theta .* (%pi/180));
d = 10 * zeta_omega;

// Agregar integrador
P = [-zeta_omega+y*%i;-zeta_omega-y*%i;-d;-d;-d]
AA = [A, [zeros(As(1), 1)]; -C, 0]
BB = [B; 0]
K = ppol(AA, BB, P)
Ks = size(K)
Ki = -K(Ks(2))
K = K(1:Ks(2)-1)

// Matrices modificadas 
Amod = [A-B*K, B*Ki;-C, 0]
Bmod = [zeros(As(1),1);1]
Cmod = [C, 0]
Dmod = D
Xo = [zeros(As(1), 1); 0]

//Xp = Amod * Xo + Bmod
//Y = Cmod * Xo + D
// 16515.677   3400.   11421.615   5496.8646  -118745.84
