function [componentes] = descomponer(longitud,angulo)
componentes = [longitud .* cos(angulo), longitud .* sin(angulo), zeros(length(longitud),1)];
end

