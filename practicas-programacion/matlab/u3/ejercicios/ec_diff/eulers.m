clear;
clc;
Ti=0.01;
tsim=12;
x(1)=1;
t(1)=0;
for k=1:tsim/Ti
   x(k+1)=x(k)+Ti*(1-exp(x(k)));
   t(k+1)=t(k)+Ti;
end
x0=1;
[t2,x2]=ode45(@(t,x)1-exp(x),[0 tsim], x0);
hold on;
plot(t,x,'LineWidth',2);
hold on;
plot(t2,x2,'r','LineWidth',2);
legend('M .Euler', 'M .Ode45');
grid on;