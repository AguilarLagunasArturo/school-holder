/** Librerias **/
import processing.serial.*;
import cc.arduino.*;

/** Variables globales **/
Arduino arduino;
PrintWriter output;
ArrayList<Integer> x_values = new ArrayList<Integer>();
ArrayList<Float> y_values = new ArrayList<Float>();
int potenciometro;

float voltage;
float offset;
int time;
float y_spacing;

float max;
int update;
int y_margin;
int x_margin;
int max_x_points;
String xy;

void setup() {
  println("**** SETTING UP ****");
  //fullScreen();
  size(800, 450);
  background(36);

  printArray(Arduino.list());
  potenciometro = 0;
  arduino = new Arduino(this, Arduino.list()[32], 57600);
  arduino.pinMode(potenciometro, Arduino.INPUT);

  voltage = 0;
  offset = 0;
  time = 0;

  // Variables importantes
  max = 20;                             // Voltage maximo
  update = 10;                          // Frecuencia de actualizacion
  x_margin = 50;                        // Margen en x
  y_margin = 50;                        // Margen en y
  max_x_points = width - (x_margin*2) +1;  // Puntos permitidos a graficar en tiempo real

  y_spacing = (height - y_margin*2) / max;

  // Crea archivo coordenadas
  output = createWriter("coordenadas.txt");
  output.println("0,"+max+","+update+".");

  // Formato y color de lineas
  strokeWeight(1.5);
  stroke(200);
  textSize(15);
}

void draw() {
  background(36);
  fill(200);

  // Retraso de n milisegundos
  delay(update);

  // Se acumula el tiempo
  time += update;

  // Se lee voltage
  voltage = arduino.analogRead(potenciometro) * max / 1023;

  // Generacion de coordenadas en formato string
  xy = time + "," + voltage; 

  // Se escriben coordenadas en archivo .txt
  output.print(xy + ",");

  // Se almacenan las coordenadas para generacion de grafica en tiempo real
  x_values.add(update);
  y_values.add(voltage);

  // Se grafica
  graph(x_values, y_values);
}

// Grficar datos
void graph(ArrayList<Integer> x, ArrayList<Float> y) {
  // Mostrar el punto actual
  text(xy, width/2 - (xy.length() * 5), 35);
  // Base
  noStroke();
  fill(72);
  rect(x_margin, y_margin, width - x_margin*2, height - y_margin*2);
  
  // Color de la grafica
  noStroke();
  if (voltage < (max/2))
    fill(map(voltage, 0, max/2, 255, 20), map(voltage, 0, max/2, 80, 180), 120);
  else
    fill(map(voltage, max/2, max, 20, 255), map(voltage, max/2, max, 180, 80), 120);
  // Graficar puntos
  int x_offset = 0;
  if (x.size() > max_x_points) {
    x_offset = x.size() - max_x_points;
  }
  beginShape();
  vertex(x_margin, height-y_margin);
  for (int i = 0; i < x.size() - x_offset; i++) {
    vertex(x_margin+i, (height-y_margin)-(y.get(i + x_offset)*y_spacing));
  }
  vertex(x_margin + x.size()+ - x_offset -1, height-y_margin);
  endShape(CLOSE);
  
  // Graficar eje y
  graph_y_axis();
}

// Grafica eje y
void graph_y_axis() {
  for (int i = 0; i <= max; i++) {
    fill(200);
    text(i, 10, (height-y_margin) - (y_spacing*i));
    stroke(200, 200, 200, 200);
    strokeWeight(1);
    line(x_margin, (height-y_margin) - (y_spacing*i), width - x_margin-1, (height-y_margin) - (y_spacing*i));
  }
}

// Al presionar tecla salir y guardar
void keyPressed() {
  output.close(); // Cierra el archivo
  exit(); // Programa finaliza
}
