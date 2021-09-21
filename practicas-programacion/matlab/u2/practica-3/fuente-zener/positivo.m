% -------------------------------------------------------------------------
%                   AGUILAR LAGUNAS ARTURO - PRACTICA 3
% -------------------------------------------------------------------------
function [out] = positivo(msg)
out = 0;
while true
    out = input(msg);
    if out <= 0
        warning('Solo se aceptan valores positivos.');
    else
        break
    end
end
end

