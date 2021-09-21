for n = 1:3
    no_cuenta = input('no. cuenta ', 's');
    limite = input('limite credito ');
    saldo_actual = input('saldo actual ');
    
    n_limite = limite/2;
    
    fprintf('\nNuevo limite: %f\n', n_limite);
    if saldo_actual > n_limite
        warning('saldo actual excede nuevo limite.');
    end
end

