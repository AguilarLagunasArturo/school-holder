function [aprox] = aprox_con_por(x,n)
aprox = 0;

if abs(x) >= 1
    warning('Serie diverge');
else
    for c = 0:n
        aprox = aprox + x^c;
    end
end
end

