clc;
s = %s;
num = 2;
den  = s*(s*(s+1)*(s+2)+2.4);
g = syslin('c', num/den)
evans(g)
sgrid()

// kp = 1.2
// ki = 0.0435
// kd = 0.8

// kp = 1.2
// ki = 0.041
// kd = 0.79

// kp = 1.2
// ki = 0.02
// kd = 0.712

// kp = 1.2
// ki = 0.01
// kd = 0.675

// kp = 1.2
// ki = 0.005
// kd = 0.655
