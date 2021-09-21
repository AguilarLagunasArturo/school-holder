% Programa que determina la cantidad de jugadores aceptados, denegados y si
% son suficientes para completar un equipo de basketball, respetando los
% parametros establecidos (estatura mínima, rango de edad).
% Entradas:
%   [+] Vector fila (1, n) para las estaturas
%   [+] Vector fila (1, n) para las edades
% Notas:
%   [+] Los vectores estatura y edad deben tener las mismas dimensiones

clc;

estaturas = input('Estatura de aspirantes: ');
edades = input('Edad de aspirantes: ');

estatura_minima = 1.8;
rango_edad = [18, 24];

isequal(estaturas, edades)

%if length(estaturas) == length(edades)
if isequal(size(estaturas),  size(edades))
    fprintf('\nAspirantes: %d', length(edades))
    
    aceptados = (edades >= rango_edad(1) & edades <= rango_edad(2)) & estaturas >= estatura_minima;
    
    jugadores_aceptados = length(edades( aceptados));
    jugadores_denegados = length(edades(~aceptados));
    
    hold on;
    barh( 1, jugadores_denegados, 'facecolor', 'r' );
    barh( 2, jugadores_aceptados, 'facecolor', 'g' );
    title('Histograma');
    legend('Denegados', 'Aceptados');
    
    fprintf('\nAceptados: %d', jugadores_aceptados);
    fprintf('\nDenegados: %d\n', jugadores_denegados);
    
    if jugadores_aceptados == 0
        fprintf('\nNo se reclutó ningun jugador.\n');
    elseif jugadores_aceptados < 5
        fprintf('\nFaltan %d jugadores para completar un equipo.\n', 5-jugadores_aceptados)
    else
        fprintf('\nSe reclutó al menos %d equipos.\n', round(jugadores_aceptados/5))
    end
else
    warning('El número de estaturas y edades debe ser el mismo.');
end