% -------------------------------------------------------------------------
%                   AGUILAR LAGUNAS ARTURO - PRACTICA 3
% -------------------------------------------------------------------------
% HERRAMIENTA DE APOYO PARA EL DISEÑO DE FUENTES REGULADAS UTILIZANDO
% TRANSFORMADOR CON TAP CENTRAL, RECTIFICADOR Y DIODO ZENER.
% EN FUNCION DE LOS PARAMETROS INICIALES INDICADOS POR EL USUARIO
% SE ESTIMAN LOS VALORES DE LOS COMPONENTES Y LAS SEÑALES RESULTANTES.
% -------------------------------------------------------------------------
% SE ASUME
%   [-] TRANSFORMADOR CON TAP CENTRAL COMPLATIBLE CON 120VAC/60HZ
%   [-] FACTOR DE SEGURIDAD DE 10%
% -------------------------------------------------------------------------
% PARAMETROS PARA EL TRANSFORMADOR (TAP CENTRAL, 60HZ)
%   [+] VT
%   [+] IT
% PARAMETROS PARA EL RECTIFICADOR
%   [+] 1 FASE 1/2 ONDA         F.U = 0.2865
%   [+] 2 FASES 1/2 ONDA        F.U = 0.5731
%   [+] 1 FASE ONDA COMPLETA    F.U = 0.8105
% PARAMETROS PARA LA CARGA
%   [+] VRL
%   [+] IRL
% -------------------------------------------------------------------------
% RESULTADOS
%   [-] DIODO	1N40017 [] UNIDADES
%   [-] C =		[] F    [] V
%   [-] RC =	[] Ohms [] W
%   [-] ZENER =	[] V    [] W
% -------------------------------------------------------------------------

clear all;
clc;
% CONSTANTES
FS = 0.1;
frecuencia = 60;

% SE RECIBEN PARAMETROS DEL TRANSFORMADOR
disp('PARAMETROS DEL TRANSFORMADOR');
VT = positivo('Voltaje de tu transformador: ');
IT = positivo('Amperaje de tu transformador: ');
fprintf('\n');

% SE ELIGE EL TIPO DE RECTIFICADOR
disp('OPCIONES DE RECTIFICADOR');
fprintf('\t1) 1 FASE 1/2 ONDA\n');
fprintf('\t2) 2 FASES 1/2 ONDA\n');
fprintf('\t3) 1 FASE ONDA COMPLETA\n');
op = input('Selecciona el rectificador: ');
fprintf('\n');

% SE CALCULA EL TIEMPO DE DESCARGA EN FUNCION DEL RECTIFICADOR
switch op
    case 1
        % SE CALCULAN DATOS PARA 1 FASE 1/2 ONDA
        FU = 0.2865;
        diodos = 1;
        tension_diodos = 0.7;
        VTmax = VT - tension_diodos;
        Tdescarga = 1/frecuencia;
        % SE DECLARA EL ESQUEMA DEL CIRCUITO
        m(1)={'                                            --          '};
        m(2)={'             +-------------|D1|----------+-|RC|-+------+'};
        m(3)={'             |                           |  --  |      |'};
        m(4)={'        TR   |                           |      |      |'};
        m(5)={' +----)    (-+                           -      -     --'};
        m(6)={'(AC)  ) || (--                           C    |Dz|   |RL|'};
        m(7)={' +----)    (-+                           -      -     --'};
        m(8)={'             |                           |      |      |'};
        m(9)={'             |                           |      |      |'};
        m(10)={'             +---------------------------+------+------+'};
    case 2
        % SE CALCULAN DATOS PARA 2 FASES 1/2 ONDA
        FU = 0.5731;
        diodos = 2;
        tension_diodos = 0.7;
        VTmax = (VT/2) - tension_diodos;
        Tdescarga = 1/(frecuencia*2);
        m(1)={'                                            --          '};
        m(2)={'             +-----|D1|-----+------------+-|RC|-+------+'};
        m(3)={'             |              |            |  --  |      |'};
        m(4)={'        TR   |              |            |      |      |'};
        m(5)={' +----)    (-+              |            -      -     --'};
        m(6)={'(AC)  ) || (----------------)------+     C    |Dz|   |RL|'};
        m(7)={' +----)    (-+              |      |     -      -     --'};
        m(8)={'             |              |      |     |      |      |'};
        m(9)={'             |              |      |     |      |      |'};
        m(10)={'             +----|D2|------+      +-----+------+------+'};
    case 3
        % SE CALCULAN DATOS PARA 1 FASE ONDA COMPLETA
        FU = 0.8105;
        diodos = 4;
        tension_diodos = 0.7 * 2;
        VTmax = VT - tension_diodos;
        Tdescarga = 1/(frecuencia*2);
        m(1)={'                                            --          '};
        m(2)={'             +-------------+         +---+-|RC|-+------+'};
        m(3)={'             |             |         |   |  --  |      |'};
        m(4)={'        TR   |       +-|D1|-|D2|-+   |   |      |      |'};
        m(5)={' +----)    (-+       |           |   |   -      -     --'};
        m(6)={'(AC)  ) || (--   +---|           +---+   C    |Dz|   |RL|'};
        m(7)={' +----)    (-+   |   |           |       -      -     --'};
        m(8)={'             |   |   +-|D3|-|D4|-+       |      |      |'};
        m(9)={'             |   |         |             |      |      |'};
        m(10)={'             |   +---------)-------------+------+------+'};
        m(11)={'             |             |'};
        m(12)={'             +-------------+'};
    otherwise
        warning('Opcion invalida.');
        return;
end

% SE COMPRUEBA QUE EL VOLTAJE TRANSFORMADOR NO SEA MUY BAJO
if VTmax <= 0
    warning('El voltaje del transformador es muy bajo.');
    return;
end
disp('PARAMETROS PARA LA FUENTE REGULADA');
fprintf('Voltaje máximo de diseño: %fV\n', VTmax * (1-FS));

% SE CALCULA LA CORRIENTE MAXIMA ENTREGADA POR EL TRANSFORMADOR
Ientregada = IT * FU;
fprintf('Corriente máxima de diseño: %fA\n', Ientregada * (1-FS));

% SE RECIBEN PARAMETROS DE LA CARGA
VRL = positivo('Ingresa voltaje de la fuente: ');
IRL = positivo('Ingresa amperaje de la fuente: ');
fprintf('\n');

% SE CALCULAN PARAMETROS DEL DIODO ZENER Y CAPACITOR
VZ = VRL;
IZ = IRL * FS;
PZ = VZ * (IRL + IZ);
IC = IZ + IRL;

% SE VERIFICA QUE EL TRANSDORMADOR PUEDA SUMINISTRAR LA POTENCIA NECESARIA
if Ientregada <= IC || VRL >= VTmax
    warning('La fuente requiere de %fV y %fA, favor de elegir los parametros adecuados para la fuente o utilizar otro transformador.', VRL, IC);
    return;
end

% SE CALCULAN LOS VALORES DE LOS COMPONENTES
VZmin = VTmax * (1-FS);
c = (IC*Tdescarga)/(VTmax-VZmin);
RC = (VZmin-VZ)/(IC);
PRC = (VTmax-VZ)^2/RC;
if (c < 0) || (RC < 0) || (PRC < 0)
    warning('Valores negativos, parametros del tranformador o de la fuente son invalidos.');
    return;
end

% SE IMPRIMEN LOS RESULTADOS
disp('VALORES DE LOS COMPONENTES');
fprintf('Diodos\t1N40017 (x%d)\n', diodos);
fprintf('AC =\t120 VAC\t\t\t%f HZ\n', frecuencia);
fprintf('TR =\t%f V\t\t%f A\n', VT, IT);
fprintf('C =\t\t%f F\t\t%f V\n', c, VTmax);
fprintf('RC =\t%f Ohm\t%f W\n', RC, PRC);
fprintf('Dz =\t%f V\t\t%f W\n', VZ, PZ);
fprintf('RL =\tCarga resistiva');
fprintf('\n');

% SE GRAFICAN LAS CURVAS DE LOS COMPONENTES
t_simulacion = 0:0.0001:(2/frecuencia);         % Tiempo de simulacion
t_descarga = 0:0.0001:Tdescarga;                % Tiempo de descarga
y = VTmax * sin(2*pi*frecuencia*t_simulacion);  % Onda senoidal
y_rectificada = abs(y);                         % Onda rectificada
medio_semicilo = (1/frecuencia)/4;              % Tiempo de medio semiciclo

if op == 2 || op == 3
    % Se crea la señal de descarga dentro del tiempo de simulacion
    t_aux = [t_descarga+medio_semicilo, t_descarga+3*medio_semicilo, t_descarga+5*medio_semicilo];
    descarga = VTmax * exp(-t_descarga/(RC*c));
    descarga = [descarga, descarga, descarga];
else
    % Se igualan con cero los semiciclos negativos
    z = 1:length(y);
    r = (z >= length(y)/4 & z <= length(y)/2) | (z >= 3*length(y)/4 & z <= length(y));
    y_rectificada(~r) = 0;
    % Se crea la señal de descarga dentro del tiempo de simulacion
    descarga = VTmax * exp(-t_descarga/(RC*c));
    t_aux = t_descarga+3*medio_semicilo;
end

hold on;
title(sprintf('Señales de la fuente regulada %.2fV %.3fA', VRL, IRL));
xlabel('Tiempo (s)');
ylabel('Voltaje (V)');

% Se grafica onda senoidal
plot(t_simulacion, y, '--');
% Se grafica onda rectificada
plot(t_simulacion, y_rectificada);
% Se grafica descarga del capacitor
plot(t_aux, descarga);
% Se grafica voltaje zener
plot(t_simulacion, zeros(1, length(t_simulacion)) + VRL);
% Se grafica GND
plot(t_simulacion, zeros(1, length(t_simulacion)));

legend('Señal de transformador', 'Señal de rectificador', 'Descarga del capacitor estimada', 'Voltaje Zener', 'GND', 'location', 'southwest');
grid on;

% SE HACEN OBSERVACIONES SOBRE LA DESCARGA DEL CAPACITOR
if descarga(length(descarga)) <= VZ
    warning('El capacitor se descarga muy rapido, se recomienda elegir un voltaje para la fuente mas pequeño o utilizar un transformador con mas voltaje.');
    return;
end

fprintf('\nDIAGRAMA DE FUENTE REGULADA %.2fV %.3fA', VRL, IRL);
fprintf('%s\n', m{:});