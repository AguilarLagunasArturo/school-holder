clc;
T = [23, 24, 22.5, 21, 23, 24, 25, 23.5, 26, 25.4, 24, 22];
D = 1:length(T);

a = T(T>=24);
disp('Cantidad de días cuya temperatura fue mayor o igual a 24ºC');
disp(length(a));

b = T(T>=24 & T<=26);
disp('Cantidad de días cuya temperatura estuvo entre 24ºC y 26ºC');
disp(length(b));

c = D(T>=24);
disp('Días cuya temperatura fue mayor o igual a 24ºC');
disp(c);