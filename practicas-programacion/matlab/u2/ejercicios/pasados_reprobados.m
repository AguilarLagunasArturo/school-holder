clc;
valores = [];
c = 1;
while true
    resultado = input(sprintf('%d.- Resultado: ', c));
    if resultado == 1 || resultado == 2
        valores(c) = resultado;
        c = c + 1;
    elseif resultado == 0
        break;
        clc;
    else
        warning('Invalido');
    end
end

total = length( valores );
pasados = length( valores(valores == 1) );
no_pasados = total - pasados;

pie3([pasados, no_pasados]);
legend('Pasaron', 'Reprobaron');

fprintf('Total: %d\n', total);
fprintf('Pasados: %d\n', pasados);
fprintf('Reprobados: %d\n', no_pasados);

if pasados > 8
    disp('Aumentar colegiatura');
end
