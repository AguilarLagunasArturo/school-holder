function [aprox] = aprox_con_mientras(x,n)
aprox = 0;

if abs(x) >= 1
    warning('Serie diverge');
else
    c = 0;
    while c <= n
        aprox = aprox + x^c;
        c = c + 1;
    end
end
end