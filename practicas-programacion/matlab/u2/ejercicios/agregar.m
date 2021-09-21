function r = agregar(a,b)

switch nargin
    case 1
        r = a + a;
    case 2
        r = a + b;
    otherwise
        r = 0;
end

end

