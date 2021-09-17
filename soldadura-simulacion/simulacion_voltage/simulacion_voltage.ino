int potenciometro = 14;   // PIN A0
int voltage_maximo = 30;  // Máximo voltage permitido
float voltage = 0;        // Voltage recibido

void setup(){
  Serial.begin(9600);             // Inicia conexión serial
  pinMode(potenciometro, INPUT);  // Se establece pin como entrada de datos
}

void loop(){
  // Se espera una décima de segundo
  delay(100);
  // Lee voltage entre 0 y voltage_maximo
  voltage = float(analogRead(potenciometro)) * voltage_maximo / 1023;
  Serial.println(String(voltage) + " V");
}
