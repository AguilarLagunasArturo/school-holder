clc;
clear all;

acum = 0;

while true
    valor = input('Precio del platillo: ');
    acum = acum + valor;
    
    salir = input('-1 para salir del programa: ');
    if salir == -1
        break;
    end
end

neto = acum;
neto_iva = acum * (1 + 0.16);
neto_propina = acum * (1 + 0.26);

fprintf('\nNeto: %.2f\n', neto);
fprintf('Mas IVA: %.2f\n', neto_iva);
fprintf('Mas IVA + propina: %.2f\n', neto_propina);