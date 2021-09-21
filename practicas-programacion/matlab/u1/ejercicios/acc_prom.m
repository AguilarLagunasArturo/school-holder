function [acc] = acc_prom(v1, v2, sec)
acc = (v2 - v1) / sec;
fprintf('a = %f m/s^2\n', acc);
end