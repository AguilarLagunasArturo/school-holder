val = input('Dame un numero entero positivo: ');

if mod(val, 1) == 0 && val > 0
    while true
        disp(val);
        if val == 0
            break
        end
        val = val -1;
    end
else
    warning('No cumple');
end