function [aprox] = programa2(x,n)
aprox = 0;
for c = 1:n
    if mod(c, 2) == 0
        aprox = aprox - (x^c)/c;
    else
        aprox = aprox + (x^c)/c;
    end
end
end

