%                  AGUILAR LAGUNAS ARTURO - PRACTICA 4
% -------------------------------------------------------------------------
%               HERRAMIENTA DE APOYO PARA LA DETECCION DE
%             PIEZAS DEFECTUOSAS EN PROCESOS DE FABRICACION
% -------------------------------------------------------------------------
% MODO MANUAL:
%   [+] SE INGRESAN DATOS MANUALMENTE
%       [*] NOMBRE DE LA PIEZA A ANALIAZAR
%       [*] CANTIDAD DE PARAMETROS A ANALIZAR
%       [*] NOMBRE DE LOS PARAMETROS A ANALIZAR
%       [*] VALOR IDEAL PARA CADA PARAMETRO
%       [*] TOLERANCIAS PARA CADA PARAMETRO
% MODO AUTOMATICO:
%   [+] SE CARGAN DATOS DE UN ARCHIVO .xlsx CON UN FORMATO PREESTABLECIDO
%       [*] NOMBRE DE LA PIEZA A ANALIAZAR
%       [*] CANTIDAD DE PARAMETROS A ANALIZAR
%       [*] NOMBRE DE LOS PARAMETROS A ANALIZAR
%       [*] VALOR IDEAL PARA CADA PARAMETRO
%       [*] TOLERANCIAS PARA CADA PARAMETRO
% -------------------------------------------------------------------------
% RESULTADOS:
%   [-] GRAFICOS PARA CADA PARAMETRO
%       [*] GRAFICO QQ
%       [*] HISTOGRAMA
%       [*] DISTRIBUCION NORMAL
%   [-] CONCLUSIONES PARA CADA PARAMETRO
%       [*] PROBABILIDAD DE PRODUCIR UNA PIEZA FUERA DE LAS TOLERANCIAS
% -------------------------------------------------------------------------

% Se elige el modo de operacion del programa
clc;
clear all;
fprintf('HERRAMIENTA DE APOYO PARA LA DETECCION DE\nPIEZAS DEFECTUOSAS EN PROCESOS DE FABRICACION\n\n');
disp('OPCIONES');
disp('1. CARGAR DATOS .xlsx');
disp('2. INGRESAR DATOS MANUALMENTE');
op = input(sprintf('\nELEGIR MODO: '));

% Variables
mediciones = [];
no_defectos = 0;
nombre_parametros = {};
estandar = [];
tolerancias = [];

% Se ejecuta opcion del usuario
clc;
switch op
    case 1
        % Se cargan los datos de un documento .xlsx con un formato preestablecido
        disp('CARGANDO DATOS .xlsx');
        archivo = input('RUTA DEL ARCHIVO: ', 's');
        [d, s] = xlsread(archivo);
        no_defectos = (length(d(1,:))-1)/2;
        mediciones = d(:, 1:no_defectos);
        nombre_parametros = s(1, 1:no_defectos);
        estandar = d(1, no_defectos+2:no_defectos*2+1);
        tolerancias = d(2, no_defectos+2:no_defectos*2+1);
    case 2
        % Se recupera informacion de la pieza
        nombre_pieza = input(sprintf('NOMBRE DE LA PIEZA A ANALIZAR: '), 's');
        mediciones = [];
        while true
            no_defectos = input('NUMERO DE PARAMETROS A ANALIZAR EN LA PIEZA: ');
            if mod(no_defectos, 1) == 0 && no_defectos > 0
                break;
            else
                warning('El valor debe ser un numero entero positivo.');
            end
        end
        for k = 1:no_defectos
            nombre_parametros(k) = cellstr(input(sprintf('\nNOMBRE DEL PARAMETRO NO. %d: ', k), 's'));
            estandar(k) = input(sprintf('VALOR IDEAL DEL PARAMETRO NO. %d: ', k));
            tolerancias(k) = input(sprintf('TOLERANCIA PARA EL PARAMETRO NO. %d: ', k));
        end
        % Se ingresan datos manualmente
        clc;
        fprintf('COMIENZA INGRESO MANUAL [-1] PARA SALIR\n');
        for k = 1:no_defectos
            fprintf('\nCAPTURANDO PARAMETRO (%s) VALOR ESTANDAR (%.4f) TOLERANCIA (%.4f)\n', string(nombre_parametros(k)), estandar(k), tolerancias(k));
            c = 1;
            while true
                val = input(sprintf('%d.- Valor: ', c));
                if val == -1
                    if c < 10
                        warning('Datos insuficientes para analizar.');
                        return;
                    end
                    break;
                end
                mediciones(c, k) = val;
                c = c + 1;
            end
        end
    otherwise
        % Opcion invalida
        warning('Opcion invalida');
        return;
end

while true
    % Se elige el tipo de grafico
    fprintf('\nVISUALIZACION DE DATOS\n');
    disp('1. QQ PLOT');
    disp('2. HISTOGRAMA');
    disp('3. DISTRIBUCION NORMAL');
    disp('4. TODAS');
    op = input(sprintf('\nELEGIR MODO: '));

    % Se muestran los datos capturados
    clc;
    disp('TABLA DE DATOS ');
    indices = (1:length(mediciones))';
    datos = mediciones(:, 1:no_defectos);
    T = table(indices, datos)

    % Color primario y secundario de los graficos
    p_color = [140, 69, 132]./255;
    s_color = [223, 84, 32]./255;

    % Se grafican los datos correspondientes e imprimen los resultados
    disp('CONCLUSIONES');
    switch op
        case 1
            for k = 1:no_defectos
                % Se calcula la desviacion normal
                medicion_aux =  mediciones(:, k);
                medicion_aux = medicion_aux(medicion_aux ~= 0);
                m = mean(medicion_aux);
                z = std(medicion_aux);
                nd = @(x) exp( (-1/2)*((x-m)./z).^2 )/(sqrt(2*pi)*z);
                m_min = min(medicion_aux);
                m_max = max(medicion_aux);

                % QQ-plot
                subplot(1, no_defectos, k);
                q = qqplot(medicion_aux);
                q(1).Marker = 'o';
                q(1).MarkerEdgeColor = p_color;
                q(3).Color = s_color;
                title(sprintf('Grafico-QQ (%s)', string(nombre_parametros(k))));
                xlabel('Cantidades teoricas');
                ylabel('Cantidades reales');

                % Resultados
                fprintf(sprintf( '\nSegun la muestra de datos del parametro (%s):\n', string(nombre_parametros(k)) ));
                area = integral(nd, estandar(k)-tolerancias(k), estandar(k)+tolerancias(k));
                fprintf('Probabilidad de producir pieza fuera de las tolerancias: %.2f %%\n', (1-area)*100);
            end
        case 2
            for k = 1:no_defectos
                % Se calcula la desviacion normal
                medicion_aux =  mediciones(:, k);
                medicion_aux = medicion_aux(medicion_aux ~= 0);
                m = mean(medicion_aux);
                z = std(medicion_aux);
                nd = @(x) exp( (-1/2)*((x-m)./z).^2 )/(sqrt(2*pi)*z);
                m_min = min(medicion_aux);
                m_max = max(medicion_aux);

                % Histograma
                subplot(1, no_defectos, k);
                h = histfit(medicion_aux);
                h(1).FaceColor = p_color;
                h(2).Color = s_color;
                title('Histograma');
                xlabel(nombre_parametros(k));
                ylabel('Frecuencia');

                % Resultados
                fprintf(sprintf( '\nSegun la muestra de datos del parametro (%s):\n', string(nombre_parametros(k)) ));
                area = integral(nd, estandar(k)-tolerancias(k), estandar(k)+tolerancias(k));
                fprintf('Probabilidad de producir pieza fuera de las tolerancias: %.2f %%\n', (1-area)*100);
            end
        case 3
            for k = 1:no_defectos
                % Se calcula la desviacion normal
                medicion_aux =  mediciones(:, k);
                medicion_aux = medicion_aux(medicion_aux ~= 0);
                m = mean(medicion_aux);
                z = std(medicion_aux);
                nd = @(x) exp( (-1/2)*((x-m)./z).^2 )/(sqrt(2*pi)*z);
                m_min = min(medicion_aux);
                m_max = max(medicion_aux);

                % Desviacion normal
                subplot(1, no_defectos, k);
                th = 0.01 * estandar(k);
                limites = [estandar(k)-tolerancias(k), estandar(k)+tolerancias(k)];
                x = linspace(limites(1)-th, limites(2)+th, 1000);
                hold on;
                plot( x, nd(x), '-', 'color', p_color, 'linewidth', 1.8);
                plot(limites, nd(limites),'s', 'color', s_color, 'markersize', 8);
                legend('Distribucion', 'Tolerancias');
                xlabel(nombre_parametros(k));
                ylabel('Valores normalizados');
                title('Distribucion');

                % Resultados
                fprintf(sprintf( '\nSegun la muestra de datos del parametro (%s):\n', string(nombre_parametros(k)) ));
                area = integral(nd, estandar(k)-tolerancias(k), estandar(k)+tolerancias(k));
                fprintf('Probabilidad de producir pieza fuera de las tolerancias: %.2f %%\n', (1-area)*100);
            end
        case 4
            for k = 1:no_defectos
                % Se calcula la desviacion normal
                medicion_aux =  mediciones(:, k);
                medicion_aux = medicion_aux(medicion_aux ~= 0);
                m = mean(medicion_aux);
                z = std(medicion_aux);
                nd = @(x) exp( (-1/2)*((x-m)./z).^2 )/(sqrt(2*pi)*z);
                m_min = min(medicion_aux);
                m_max = max(medicion_aux);

                % QQ-plot
                subplot(no_defectos, 3, 1+3*(k-1));
                q = qqplot(medicion_aux);
                q(1).Marker = 'o';
                q(1).MarkerEdgeColor = p_color;
                q(3).Color = s_color;
                title(sprintf('Grafico-QQ (%s)', string(nombre_parametros(k))));
                xlabel('Cantidades teoricas');
                ylabel('Cantidades reales');

                % Histograma
                subplot(no_defectos, 3, 2+3*(k-1));
                h = histfit(medicion_aux);
                h(1).FaceColor = p_color;
                h(2).Color = s_color;
                title('Histograma');
                xlabel(nombre_parametros(k));
                ylabel('Frecuencia');

                % Desviacion normal
                subplot(no_defectos, 3, 3+3*(k-1));
                th = 0.01 * estandar(k);
                limites = [estandar(k)-tolerancias(k), estandar(k)+tolerancias(k)];
                x = linspace(limites(1)-th, limites(2)+th, 1000);
                hold on;
                plot( x, nd(x), '-', 'color', p_color, 'linewidth', 1.8);
                plot(limites, nd(limites),'s', 'color', s_color, 'markersize', 8);
                legend('Distribucion', 'Tolerancias');
                xlabel(nombre_parametros(k));
                ylabel('Valores normalizados');
                title('Distribucion Normal');

                % Resultados
                fprintf(sprintf( '\nSegun la muestra de datos del parametro (%s):\n', string(nombre_parametros(k)) ));
                area = integral(nd, estandar(k)-tolerancias(k), estandar(k)+tolerancias(k));
                fprintf('Probabilidad de producir pieza fuera de las tolerancias: %.2f %%\n', (1-area)*100);
            end
        otherwise
            warning('Opcion invalida');
            return;
    end
    fprintf('\n[0] PARA GRAFICAR DE NUEVO CUALQUIER OTRO PARA FINALIZAR PROGRAMA\n');
    cond = input('ELECCION: ');
    if cond ~= 0
        break;
    end
    close all;
    clc;
end