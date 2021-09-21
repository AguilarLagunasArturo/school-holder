clc;
clear all;

% Datos
rb = [-1.29, 0.7511, 0];   % FIJO
rb_a = [0, 8.99, 0];       % MOVIL (RELATIVO)

% 1: INCOGNITA EN FIJO | 2: INCOGNITA EN MOVIL (RELATIVO)
disp('Lugar de la incognita');
incog = input('(1 - fijo) | (2 - movil/relativo): ');
if incog == 1
    omega1 = sym('omega');
    omega1_p = sym('omega_p');
    omega2 = input('Omega: ');
    omega2_p = input('Omega prima: ');
else
    omega1 = input('Omega: ');
    omega1_p = input('Omega prima: ');
    omega2 = sym('omega');
    omega2_p = sym('omega_p');
end
mag_v_rel = sym('mag_v_rel');
mag_a_rel = sym('mag_a_rel');

disp('Velocidad relativa');
dir = input('(1 - En i) | (2 - En j): ');
if dir == 1
    ii = 1;
    jj = 0;
else
    ii = 0;
    jj = 1;
end

% Calculos de velocidad
vb = cross([0, 0, omega1], rb);
v = cross([0, 0, omega2], rb_a);
v_rel = [ii * mag_v_rel, jj * mag_v_rel, 0];
v_sum = v + v_rel;

disp('Vb = ');
disp(vpa(vb));
disp('Vb_c = ');
disp(vpa(v));
disp('Vrel = ');
disp(vpa(v_rel));

eq_i = vb(1) - v_sum(1);
eq_j = vb(2) - v_sum(2);

S = solve([eq_i == 0, eq_j == 0], [sym('omega'), mag_v_rel]);
if incog == 1
    omega1 = double(S.omega)
else
    omega2 = double(S.omega)
end
mag_v_rel = double(S.mag_v_rel);
v_rel = double(subs(v_rel, mag_v_rel))

% Calculos de asceleracion
ab = cross([0, 0, omega1_p], rb) + cross([0, 0, omega1], cross([0, 0, omega1], rb));
a = cross([0, 0, omega2_p], rb_a) + cross([0, 0, omega2], cross([0, 0, omega2], rb_a));
a_coriolis = cross([0, 0, 2*omega2], v_rel); % DEBUG: omega debe estar siempre en el relativo
a_rel = [ii * mag_a_rel, jj * mag_a_rel, 0];
a_sum = a + a_coriolis + a_rel;

disp('Ab = ');
disp(vpa(ab));
disp('Ab_c = ');
disp(vpa(a));
disp('Acoriolis = ');
disp(vpa(a_coriolis));
disp('Arel = ');
disp(vpa(a_rel));

cond = input('Es curvo? ', 's');
a_rel_n = [0, 0, 0];
if cond == 's'
    % DEBUG: indicaciones para ingresar el vetor poscision
    r = input('Vector poscicion: ');
    a_rel_n = -v_rel(dir)^2/r;
    a_rel_n = [jj * a_rel_n, ii * a_rel_n, 0];
    a_sum = a + a_coriolis + a_rel + a_rel_n;
    
    disp('Arel_n = ');
    disp(vpa(a_rel_n));
end
eq_i = ab(1) - a_sum(1);
eq_j = ab(2) - a_sum(2);

S = solve([eq_i == 0, eq_j == 0], [sym('omega_p'), mag_a_rel]);
if incog == 1
    omega1_p = double(S.omega_p)
else
    omega2_p = double(S.omega_p)
end
mag_a_rel = double(S.mag_a_rel);
a_rel = double(subs(a_rel, mag_a_rel)) + a_rel_n