function [sumas] = programa3(n, x)

sumas = zeros(1, length(x));
suma = 0;

for m = 1:length(x)
    for c = 1:n
        suma = suma + factorial(c)/(x(m)^c*sqrt(2^c));
    end
    sumas(1,m) = suma;
    suma = 0;
end
end

