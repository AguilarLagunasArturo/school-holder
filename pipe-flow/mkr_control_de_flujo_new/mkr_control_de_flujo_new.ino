/*
  Arduino MKR WIFI 1010
  Sensor de flujo YF-S201
*/
// Librerias
#include "mkr_wifi_config.h"

// Constantes
#define sensores 7
#define relevadores 8

// Pines
int sensor_flujo[sensores] = { 0,  1,  6,  4,  7,  8,  9};
int relevador[relevadores] = { 2,  3,  10, 11, 12, 13, 14, 16};

// Limites de cada sensor.
float gasto_minimo[sensores] = {
  12, 5, 5, 2, 2, 6, 6
  // 14, 5, 5, 2, 2, 8, 7
};

// Estado de secciones.
float problema_en_seccion[relevadores] = {
  false, false, false, false,
  false, false, false, false
};

// Valvulas abiertas.
boolean valvula_cerrada[relevadores] = {
  false, false, false, false,
  false, false, false, false
};

// Variables
volatile int frecuencia[sensores];       // Pulsos obtenidos del sensor
float gasto[sensores];                   // Litros por minuto
unsigned long tiempo_actual;
unsigned long tiempo_auxiliar;

String command = "";

String data = "";                              // Datos a graficar

// Funciones "Interrupt"
void flujo_0() {
  frecuencia[0] ++;
}
void flujo_1() {
  frecuencia[1] ++;
}
void flujo_2() {
  frecuencia[2] ++;
}
void flujo_3() {
  frecuencia[3] ++;
}
void flujo_4() {
  frecuencia[4] ++;
}
void flujo_5() {
  frecuencia[5] ++;
}
void flujo_6() {
  frecuencia[6] ++;
}

void setup() {
  Serial.begin(9600);
  // Se inicializan los pines que utilizaran los sensores de gasto.
  pinMode(sensor_flujo[0], INPUT);
  //digitalWrite(sensor_flujo, HIGH);
  attachInterrupt(digitalPinToInterrupt(sensor_flujo[0]), flujo_0, RISING);
  pinMode(sensor_flujo[1], INPUT);
  //digitalWrite(sensor_flujo, HIGH);
  attachInterrupt(digitalPinToInterrupt(sensor_flujo[1]), flujo_1, RISING);
  pinMode(sensor_flujo[2], INPUT);
  //digitalWrite(sensor_flujo, HIGH);
  attachInterrupt(digitalPinToInterrupt(sensor_flujo[2]), flujo_2, RISING);
  pinMode(sensor_flujo[3], INPUT);
  //digitalWrite(sensor_flujo, HIGH);
  attachInterrupt(digitalPinToInterrupt(sensor_flujo[3]), flujo_3, RISING);
  pinMode(sensor_flujo[4], INPUT);
  //digitalWrite(sensor_flujo, HIGH);
  attachInterrupt(digitalPinToInterrupt(sensor_flujo[4]), flujo_4, RISING);
  pinMode(sensor_flujo[5], INPUT);
  //digitalWrite(sensor_flujo, HIGH);
  attachInterrupt(digitalPinToInterrupt(sensor_flujo[5]), flujo_5, RISING);
  pinMode(sensor_flujo[6], INPUT);
  //digitalWrite(sensor_flujo, HIGH);
  attachInterrupt(digitalPinToInterrupt(sensor_flujo[6]), flujo_6, RISING);
  //sei(); // Permite "Interrupts"

  // Se inicializan los pines que controlaran los relevadores
  for (int i = 0; i < relevadores; i++) {
    pinMode(relevador[i], OUTPUT);
    cerrar_valvula(i, false);
  }

  //checar_relevadores();
  esperar(8);

  // Se inicializa el servidor web
  //wifi_setup();
  //print_wifi_status();

  //asignar_gasto_minimo();
  tiempo_actual = millis();
  tiempo_auxiliar = tiempo_actual;

  for (int i = 0; i < sensores; i++) {
    frecuencia[i] = 0;
  }
}

void loop() {
  leer_serial();
  tiempo_actual = millis();
  // Calcula el flujo (L/min) cada segundo
  if (tiempo_actual >= (tiempo_auxiliar + 1000)) {
    tiempo_auxiliar = tiempo_actual; // <-- Antes estaba al inicio del if
    // Se calcula el gasto obtenido en por sensor
    calcular_gasto();
    // Se revisan que no haya problema en ninguna seccion
    revisar_secciones();
    // Se reparan los problemas en cada seccion
    resolver_problemas();
  }
  // Se crea pagina web
  //web_page();
}

// Funciones para el control de flujo
void calcular_gasto() {
  for (int i = 0; i < sensores; i++) {
    gasto[i] = float(frecuencia[i]) / 7.5;
    // Imprime con formato: Seccion | Hz | L/min
    // Serial.println("Sensor: " + String(i + 1) + " | Hz: " + frecuencia[i] + " | " + String(gasto[i]) + " L/min");
    data += i == sensores - 1 ? String(gasto[i]) : String(gasto[i]) + ",";
    frecuencia[i] = 0;
  }
  Serial.println("#," + data);
  data = "";
}

void revisar_secciones() {
  for (int i = 0; i < sensores; i++) {
    if (gasto[i] < gasto_minimo[i]) {
      problema_en_seccion[i] = true;
      Serial.println("Problema en seccion " + String(i + 1));
    }
  }
  // Condicion para seccion 8: gasto en 4 entre +- gasto en 5, gasto en 5 entre +- gasto en 4

  //if (!((gasto[2] / 2 > (gasto[4] - 2)) && (gasto[2] / 2 < (gasto[4] + 2)))) {
  //problema_en_seccion[7] = true;
  //}
}

void resolver_problemas() {
  if (problema_en_seccion[0]) {
    cerrar_valvula(0, true);
  }
  if (problema_en_seccion[1]) {
    cerrar_valvula(1, true);
  }
  if (problema_en_seccion[2]) {
    cerrar_valvula(2, true);
  }
  if (problema_en_seccion[3]) {
    if (gasto[3] < gasto[4]) {
      cerrar_valvula(5, true);
    }
  }
  if (problema_en_seccion[4]) {
    cerrar_valvula(3, true);
    //cerrar_valvula(4, true);
  }
  if (problema_en_seccion[5]) {
    cerrar_valvula(6, true);
  }
  if (problema_en_seccion[6]) {
    cerrar_valvula(7, true);
  }
  if (problema_en_seccion[7]) {
    //cerrar_valvula(3, true);
    //cerrar_valvula(4, true);
  }
  //asignar_gasto_minimo();
}

void reset() {
  Serial.println("Reset.");
  esperar(5);
  for (int i = 0; i < relevadores; i++) {
    if (valvula_cerrada[i]) {
      //cerrar_valvula(i, false);
      digitalWrite(relevador[i], HIGH);
      valvula_cerrada[i] = false;
      //
      //Serial.println("Valvula " + String(i + 1) + " abierta.");
    }

    //if (i < sensores) frecuencia[i] = 0;
  }
  esperar(5);
  for (int i = 0; i < relevadores; i++) {
    problema_en_seccion[i] = false;
    frecuencia[i] = 0;
  }
  tiempo_actual = millis();
  tiempo_auxiliar = tiempo_actual;
  Serial.println("End reset.");
}

void cerrar_valvula(int id, boolean cerrar) {
  int cerrados = 0;

  for (int i = 0; i < sensores; i++) {
    if (valvula_cerrada[i]) cerrados ++;
  }

  if (cerrados < 1) {
    // Si se quiere cerrar enviar HIGH sino LOW
    if (cerrar) {
      digitalWrite(relevador[id], LOW);
      valvula_cerrada[id] = true;
      Serial.println("Valvula " + String(id + 1) + " cerrada.");
      reset();
    }
  }

  if (!cerrar) {
    digitalWrite(relevador[id], HIGH);
    valvula_cerrada[id] = false;
    Serial.println("Valvula " + String(id + 1) + " abierta.");
  }
}

void asignar_gasto_minimo() {
  Serial.println("---------------------------");
  for (int i = 0; i < sensores; i++) {
    frecuencia[i] = 0;
  }
  delay(1000);
  for (int i = 0; i < sensores; i++) {
    gasto_minimo[i] = (float(frecuencia[i]) / 7.5) - 4;
    Serial.println("Gasto minimo en seccion " + String(i + 1) + ": " + String(gasto_minimo[i]));
  }

  for (int i = 0; i < sensores; i++) {
    frecuencia[i] = 0;
  }
  Serial.println("---------------------------");
}

void checar_relevadores() {
  for (int i = 0; i < relevadores; i++) {
    delay(2000);
    Serial.println("Relevador " + String(i + 1));
    cerrar_valvula(i, true); // cerrar
    delay(2000);
    cerrar_valvula(i, false); // abrir
  }
}

void esperar(int t) {
  // Se esperan 15s para que el agua fluya por la tuberia.
  for (int i = 0; i < t; i++) {
    delay(1000);
    Serial.println("Esperando " + String(t - i) + "...");
  }
}

void leer_serial() {
  if (Serial.available() > 0) {
    // Lee los byte
    //serial_byte = Serial.read();
    command = Serial.readString();
    command.trim();
    // Imprime resultado
    //Serial.println(serial_byte, DEC);
    if (command == "r") {
      reset();
    };
  }
}

void web_page() {
  // listen for incoming clients
  WiFiClient client = server.available();
  if (client) {
    //Serial.println("new client");
    String currentLine = "";
    // an http request ends with a blank line
    boolean currentLineIsBlank = true;
    while (client.connected()) {
      if (client.available()) {
        char c = client.read();
        //Serial.write(c);
        // if you've gotten to the end of the line (received a newline
        // character) and the line is blank, the http request has ended,
        // so you can send a reply
        if (c == '\n' && currentLineIsBlank) {
          // send a standard http response header
          client.println("HTTP/1.1 200 OK");
          client.println("Content-Type: text/html");
          client.println("Connection: close");  // the connection will be closed after completion of the response
          client.println();
          client.println("<!DOCTYPE HTML><html> <head> <title>Control de Flujo</title> </head> <style> button{ width: 35%; height: 40px; margin: 5px; border-radius: 5px; border: none; font-size: 16px; background-color: #C9D9E6; color: #182526; } body{ background-color: #FFF; margin: 0px; margin-top: 80px; padding: 0px; } h2, h4 { color: #FFF; margin: 15px; } hr{ width: 70%; display: block; height: 1px; border: 0; border-top: 1px solid #ccc; } ul { position: fixed; top: 0; list-style-type: none; margin: 0; padding: 0; overflow: hidden;] } li { float: left; } li, a{ color: white; padding: 24px 16px; text-align: center; text-decoration: none; } li a:hover { background-color: #4a727a; } span{ font-size: 16px; padding-right: 15%; font-weight: bold; color: white; } .title{ font-weight: bold; font-size: 24px; color: white; margin-left: 25%; } .link{ font-size: 24px; color: white; float: right; padding-right: 0px; margin-right: 25%; } .header{ width: 100%; background-color: #54878C; } .footer{ bottom: 0; padding-top: 5px; padding-bottom: 5px; margin-top: 50px; width: 100%; background-color: #4B787D; text-align: right; } @media (min-width:320px) { /* smartphones, portrait iPhone, portrait 480x320 phones (Android) */ button{ width: 70%; height: 100px; font-size: 40px; margin: 30px; } body{ background-color: #FFF; margin: 0px; margin-top: 300px; padding: 0px; } li, a{ padding: 100px 16px; } .title{ font-size: 46px; margin-left: 5%; } .link{ font-size: 46px; margin-right: 5%; } span{ font-size: 26px; padding-right: 5%; } } @media (min-width:992px) { /* smartphones, portrait iPhone, portrait 480x320 phones (Android) */ button{ width: 35%; height: 40px; margin: 5px; border-radius: 5px; border: none; font-size: 16px; } body{ background-color: #FFF; margin: 0px; margin-top: 80px; padding: 0px; } li, a{ color: white; padding: 24px 16px; text-align: center; text-decoration: none; } span{ font-size: 16px; padding-right: 15%; font-weight: bold; color: white; } .title{ font-weight: bold; font-size: 24px; color: white; margin-left: 25%; } .link{ font-size: 24px; color: white; float: right; padding-right: 0px; margin-right: 25%; } } </style> <body> <ul class='header'> <li class='title'>Control de flujo</li> <li class='link'><a href='https://github.com/AguilarLagunasArturo/pipe-flow'>Sobre el proyecto</a></li> </ul> <center> <br> <button class='S1_1' type='submit' onmousedown=location.href='/S1_1\'>Abrir secci&oacute;n 1</button> <button class='S1_0' type='submit' onmousedown=location.href='/S1_0\'>Cerrar secci&oacute;n 1</button><hr> <button class='S2_1' type='submit' onmousedown=location.href='/S2_1\'>Abrir secci&oacute;n 2</button> <button class='S2_0' type='submit' onmousedown=location.href='/S2_0\'>Cerrar secci&oacute;n 2</button><hr> <button class='S3_1' type='submit' onmousedown=location.href='/S3_1\'>Abrir secci&oacute;n 3</button> <button class='S3_0' type='submit' onmousedown=location.href='/S3_0\'>Cerrar secci&oacute;n 3</button><hr> <button class='S4_1' type='submit' onmousedown=location.href='/S4_1\'>Abrir secci&oacute;n 4</button> <button class='S4_0' type='submit' onmousedown=location.href='/S4_0\'>Cerrar secci&oacute;n 4</button><hr> <button class='S5_1' type='submit' onmousedown=location.href='/S5_1\'>Abrir secci&oacute;n 5</button> <button class='S5_0' type='submit' onmousedown=location.href='/S5_0\'>Cerrar secci&oacute;n 5</button> <hr> <button class='S6_1' type='submit' onmousedown=location.href='/S6_1\'>Abrir secci&oacute;n 6</button> <button class='S6_0' type='submit' onmousedown=location.href='/S6_0\'>Cerrar secci&oacute;n 6</button>  <hr> <button class='S7_1' type='submit' onmousedown=location.href='/S7_1\'>Abrir secci&oacute;n 7</button> <button class='S7_0' type='submit' onmousedown=location.href='/S7_0\'>Cerrar secci&oacute;n 7</button><hr> <button class='S8_1' type='submit' onmousedown=location.href='/S8_1\'>Abrir secci&oacute;n 8</button> <button class='S8_0' type='submit' onmousedown=location.href='/S8_0\'>Cerrar secci&oacute;n 8</button><hr> <button class='R' type='submit' onmousedown=location.href='/R\'>Reiniciar sistema</button> <div class='footer'> <span>Sistema de tuber&iacute;as automatizado</span> </div> </center> </body></html>");
          //client.println("<meta http-equiv='refresh' content='30'/>");
          break;
        }
        if (c == '\n') {
          // you're starting a new line
          currentLineIsBlank = true;
        } else if (c != '\r') {
          // you've gotten a character on the current line
          currentLineIsBlank = false;
          currentLine += c;
        }
      }

      if (currentLine.endsWith("GET /S1_0")) {
        cerrar_valvula(0, true);
      } else if (currentLine.endsWith("GET /S1_1")) {
        cerrar_valvula(0, false);
      } else if (currentLine.endsWith("GET /S2_0")) {
        cerrar_valvula(1, true);
      } else if (currentLine.endsWith("GET /S2_1")) {
        cerrar_valvula(1, false);
      } else if (currentLine.endsWith("GET /S3_0")) {
        cerrar_valvula(2, true);
      } else if (currentLine.endsWith("GET /S3_1")) {
        cerrar_valvula(2, false);
      } else if (currentLine.endsWith("GET /S4_0")) {
        cerrar_valvula(5, true);
      } else if (currentLine.endsWith("GET /S4_1")) {
        cerrar_valvula(5, false);
      } else if (currentLine.endsWith("GET /S5_0")) {
        cerrar_valvula(4, true);
      } else if (currentLine.endsWith("GET /S5_1")) {
        cerrar_valvula(4, false);
      } else if (currentLine.endsWith("GET /S6_0")) {
        cerrar_valvula(6, true);
      } else if (currentLine.endsWith("GET /S6_1")) {
        cerrar_valvula(6, false);
      } else if (currentLine.endsWith("GET /S7_0")) {
        cerrar_valvula(7, true);
      } else if (currentLine.endsWith("GET /S7_1")) {
        cerrar_valvula(7, false);
      } else if (currentLine.endsWith("GET /S8_0")) {
        cerrar_valvula(3, true);
      } else if (currentLine.endsWith("GET /S8_1")) {
        cerrar_valvula(3, false);
      } else if (currentLine.endsWith("GET /R")) {
        reset();
      }
    }
    // give the web browser time to receive the data
    delay(1);

    // close the connection:
    client.stop();
    //Serial.println("client disonnected");
  }
}
