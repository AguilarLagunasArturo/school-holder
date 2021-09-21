function [suma, producto] = programa1(v1, v2)
if length(v1) == length(v2)
    suma = v1 + v2;
    producto = dot(v1, v2);
else
    warning('Los vectores deben compartir el mismo tamaño');
    suma = 0;
    producto = 0;
end
end

