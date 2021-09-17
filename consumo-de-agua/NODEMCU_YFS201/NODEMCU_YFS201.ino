/*
 * Autor:             Arturo Aguilar Lagunas
 * Descripcion:       Programa que muestra el consumo de agua
 * Microcontrolador:  NodeMCU
 * Sensor de flujo:   YF-S201
*/
// ** CONSTANTES **
void ICACHE_RAM_ATTR cuentaPulsos();  // Guarda funcion interrupt 
                                      // en memoria RAM para el NodeMCU
#define FLUJOMETRO D2                 // Pin del sensor
float FACTOR = 7.5;                   // Factor de conversion [Hz] -> [L/min]

// ** VARIABLES **
unsigned long tiempoReferencia = 0;   // Tiempo de referencia [ms]
volatile unsigned int pulsos = 0;     // Pulsos obtenidos del sensor de flujo 
                                      // (esta variable puede cambiar en cualquier momento)
float frecuencia = 0;                 // Frecuencia [Hz]
float flujo = 0;                      // Flujo [L/min]
float volumen = 0;                    // Litros [L]

// ** FUNCIONES **
// Funcion interrupt para contar los pulsos
void cuentaPulsos() { pulsos ++; }

void setup() {
  Serial.begin(115200);               // Baud rate por defecto del NodeMCU
  pinMode(FLUJOMETRO, INPUT);         // Se declara como pin de entrada
  // Se asigna el pin D2 como un interrupt
  attachInterrupt(digitalPinToInterrupt(FLUJOMETRO), cuentaPulsos, RISING);
  interrupts();                       // Habilita interrupts
  tiempoReferencia = millis();        // Se asigna un tiempo de referencia
}

void loop() {
  // Se determina si un segundo ha pasado comparando 
  // el tiempo de referencia con el actual
  if (millis() >= (tiempoReferencia + 1000)){ 
    // Se deshabilita el pin interrupt ya que la variable de tipo 
    // volatile puede cambiar en cualquier momento 
    noInterrupts();
    // En este momento pulsos = frecuencia
    frecuencia = pulsos;
    // Mediante el factor de conversion se obtiene el flujo [L/min]
    flujo = ((float)frecuencia / FACTOR);
    // Se integra el flujo multiplicandolo por la fraccion de tiempo 
    // en minutos que ha pasado desde la ultima muestra
    volumen += flujo * (1.0/60.0);
    // Se muestra en pantalla los resultados obtenidos
    Serial.println("--------------------------------");
    Serial.println("Frecuencia:\t" + String(pulsos) + " [Hz]");
    Serial.println("Flujo:\t" + String(flujo) + " [L/min]");
    Serial.println("Litros:\t" + String(volumen) + " [L]");
    // Se habilita el pin interrupt para que se registren 
    // los pulsos a partir de este momento
    interrupts();
    // Se asigna un nuevo tiempo de referencia
    tiempoReferencia = millis();
    // Se reinician los pulsos igualando la variable a cero
    pulsos = 0;
  }
}
