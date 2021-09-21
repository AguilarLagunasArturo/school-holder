clc;
// EJERCICIO

// GRAFICAR POLOS Y CEROS
// REGLA 1 | LUGARES DE RAIZ
// REGLA 2 | CENTROIDE ASINTOTAS PARA LOS EXCEDENTES
// REGLA 3 | ANGULOS DE PARTIDA (POLOS) ARRIBO (CEROS)

num = poly( [], 's', 'r' )
den = poly( [0; -1], 's', 'r' )

g = syslin('c', num/den)
evans(g, 0.7880)
sgrid()

// REGLA 4: ITERSECCIONES
c = den/num
c_d = derivat(c)
r = roots(c_d.num);
for i = 1:length(r)
    if imag(r(i)) == 0 then
        intersection = real(r(i));
        disp('interseccion: ' + string(intersection))
    end
end

/* REGLA 5: CRUCE EN EJE IMAGINARIO - METODO ALGEBRAICO (A MANO)
m = poly([0, 1], 'w', 'c');
k = (m^6-76*m^4+459*m^2)/(m^4-38*m^2+289)
eq = 13*m^5-m^3*(4*k+252)+m*(68*k+351)
r = roots(eq.num);
for i = 1:length(r)
    if imag(r(i)) == 0 then
        y = real(r(i));
        kk = horner( k, y );
        disp('i: ' + string(y) + '  k: ' + string(kk));
    end
end
*/
// TABLA DE ROUTH
routh_t(num/den, poly(0, 'k'))
