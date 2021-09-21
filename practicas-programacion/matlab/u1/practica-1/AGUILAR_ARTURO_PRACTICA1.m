% AGUILAR LAGUNAS ARTURO (P. 01)
%% I VECTORES.
%% I, 1.
disp('i) ********')
x = [ 3, -4];
y = [-2,  8];
disp('a) X + Y =');
disp(x + y);
disp('b) X - Y =');
disp(x - y);
disp('c) 3X =');
disp(3*x);
disp('d) ||X|| =');
disp(norm(x));
disp('e) 7Y - 4X =');
disp(7*y - 4*x);
disp('f) X·Y =');
disp(dot(x, y));
disp('g) ||7Y - 4X|| =');
disp(norm(7*y-4*x));

disp('ii) ********')
x = [-6,  3,  2];
y = [-8,  5,  1];
disp('a) X + Y =');
disp(x + y);
disp('b) X - Y =');
disp(x - y);
disp('c) 3X =');
disp(3*x);
disp('d) ||X|| =');
disp(norm(x));
disp('e) 7Y - 4X =');
disp(7*y - 4*x);
disp('f) X·Y =');
disp(dot(x, y));
disp('g) ||7Y - 4X|| =');
disp(norm(7*y-4*x));

disp('iii) ********')
x = [ 4,  -8,   1 ];
y = [ 1,  -12, -11];
disp('a) X + Y =');
disp(x + y);
disp('b) X - Y =');
disp(x - y);
disp('c) 3X =');
disp(3*x);
disp('d) ||X|| =');
disp(norm(x));
disp('e) 7Y - 4X =');
disp(7*y - 4*x);
disp('f) X·Y =');
disp(dot(x, y));
disp('g) ||7Y - 4X|| =');
disp(norm(7*y-4*x));

disp('iv) ********')
x = [ 1, -2,  4,  2];
y = [ 3, -5, -4,  0];
disp('a) X + Y =');
disp(x + y);
disp('b) X - Y =');
disp(x - y);
disp('c) 3X =');
disp(3*x);
disp('d) ||X|| =');
disp(norm(x));
disp('e) 7Y - 4X =');
disp(7*y - 4*x);
disp('f) X·Y =');
disp(dot(x, y));
disp('g) ||7Y - 4X|| =');
disp(norm(7*y - 4*x));
%% I, 2.
disp('a) angulo en rad.');
x = [-6, 3, 2];
y = [2, -2, 1];
disp(acos(( dot(x, y))/(norm(x)*norm(y)) ));
disp('b) angulo en rad.');
x = [4, -8, 1];
y = [3, 4, 12];
disp(acos((dot(x, y))/(norm(x)*norm(y))));

%% I, 3.
x = [-6, 4, 2];
y = [6, 5, 8];
fprintf('b) X·Y = %f\n', dot(x, y));
x = [-4, 8, 3];
y = [2, 5, 16];
fprintf('c) X·Y = %f\n', dot(x, y));
x = [-5, 7, 2];
y = [4, 1, 6];
fprintf('d) X·Y = %f\n', dot(x, y));

x = [1, 2, -5];
v = [2, 1, 0.8];
fprintf('e)\tX·V1 = %f\n', dot(x, v));
v = [10, 5, 4];
fprintf('\tX·V2 = %f\n', dot(x, v));

%% I, 4
a = [-1 9 4; 2 -3 -6; 0 5 7];
b = [-4 9 2; 3 -5 7; 8 1 -6];
disp('a)');
disp(a + b);
disp('b)');
disp(a - b);
disp('c)');
disp(3*a - 2*b);

%% I, 5
a = [-2 5 12; 1 4 -1; 7 0 6; 11 -3 8];
b = [4 9 2; 3 5 7; 8 1 6];
disp('a)');
disp(a');
disp('b)');
disp(b');

 %% I, 6
a = [1 -7 4; -7 2 0; 4 0 3];
b = [4 -7 1; 0 2 -7; 3 0 4];
disp('a)');
disp(a');
disp('b)');
disp(b');
disp('c)');
c = [
    1*1, 1-1*2+2;
    2-2*1+1, 2*2
];
disp('C =')
disp(c);
disp('C traspuesa =')
disp(c');

disp('d)');
d = [
    cos(1*1), 1-1*2-2;
    2-2*1-1, cos(2*2)
];
disp('D =')
disp(d);
disp('D traspuesta =')
disp(d');

%% II. MATRICES
%% II, 1
a = [-3 2; 1 4];
b = [5 0; 2 -6];
disp(a*b);
disp(b*a);

%% II, 2
a = [1 -2 3; 2 0 5];
b = [3 0; -1 5; 3 -2];
disp(a*b);
disp(b*a);

%% II, 3
a = [3 1; 0 4];
b = [1 2; -2 -6];
c = [2 -5; 3 4];
disp('a)');
disp((a*b)*c);
disp(a*(b*c));
disp('b)');
disp(a*(b+c));
disp(a*b+a*c);
disp('c)');
disp((a + b)*c);
disp(a*c+b*c);
disp('d)');
disp((a*b)');
disp(b'*a');

%% II, 4
a = [-1 -7; 5 2];
b = [2 0 6; -1 5 -4; 3 -5 2];
disp(a*a);
disp(b*b);

%% II, 5
a = [-1 -7; 5 2];
disp(det(a));
b = [2 0 6; -1 5 -4; 3 -5 2];
disp(det(b));
% c = [1 2; 3 4; 0 0];  <- MATRIZ (3X2)
% disp(det(c));         <- SIN DETERMINANTE
d = [1 2 3 4; 0 2 4 6; 0 0 5 4; 0 0 0 7];
disp(det(d));

%% II, 8
a = [0, 9; 2, 4];
b = [1, 2; 3, 4];

disp(a*b);
disp(inv(b)*inv(a));

%% II, 10
a = [1, 2, 3; 3, 2, 1];
x = [0; 1; 2];
m = length( a(:,1) );
n = length( a(1,:) );
disp('AX = ');
disp(a*x);
fprintf('\nmultiplicaciones = %d', m*n);
fprintf('\nsumas = %d\n', (n-1)*m);

%% II, 11
a = [1, 2, 3; 3, 2, 1];
b = [0; 1; 4];
c = [6; 3; 0];
disp(a*(b+c));
disp(a*b+a*c);

%% II, 12
a = [1, 2, 3; 3, 2, 1];
b = [4, 0, 6; 6, 1, 0];
c = [9; 3; 0];
disp((a+b)*c);
disp(a*c+b*c);

%% II, 13
x = [1 -1 2];
disp(x*x');
disp(x'*x);

%% II, 14
a = [1, 2, 3; 3, 2, 1];
b = [9;3;0];
disp((a*b)');
disp(b'*a');

%% II, 15
a = [1, 2; 2, 1];
b = [1, -1; -1, 1];
c = [2, -2; 1, 1];
disp((a*b*c)');
disp(c'*b'*a');