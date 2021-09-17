float voltage;
float offset;
int time;
int y_spacing;

float max;
int update;
float noise;
int y_margin;
int x_margin;
int max_x_points;

ArrayList<Integer> x_values = new ArrayList<Integer>();
ArrayList<Float> y_values = new ArrayList<Float>();

String xy;
PrintWriter output;

void setup() {
  //fullScreen();
  size(800, 450);
  voltage = 0;
  offset = 0;
  time = 0;

  // Variables importantes
  max = 20;                             // Voltage maximo
  update = 10;
  noise = 0.005;                         // Variabilidad
  x_margin = 50;                        // Margen en x
  y_margin = 50;                       // Margen en y
  max_x_points = width - (x_margin*2);  // Puntos permitidos a graficar en tiempo real

  y_spacing = floor((height - y_margin*2) / max);

  // Crea archivo coordenadas
  output = createWriter("coordenadas.txt");
  output.println("0,"+max+","+update+".");

  // Formato y color de lineas
  strokeWeight(1.5);
  stroke(200);
  textSize(16);
}

void draw() {
  background(36);
  fill(200);

  // Retraso de n segundos
  delay(update);

  // Genera voltage y se acumula tiempo
  voltage = noise(offset) * max;
  time += update;

  // Generacion de coordenadas en formato string
  xy = time + "," + voltage; 

  // Se escriben coordenadas en archivo .txt
  output.print(xy + ",");

  // Se almacenan las coordenadas para generacion de grafica en tiempo real
  x_values.add(update);
  y_values.add(voltage);

  // Se genera variabilidad en el voltage
  offset += noise;

  // Se grafica
  graph(x_values, y_values);
}

// Grficar datos
void graph(ArrayList<Integer> x, ArrayList<Float> y) {
  // Show current point
  text(xy, width/2 - (xy.length() * 5), 35);
  // comparacion println(second() + " - " + time/1000); 

  // Graph y axis
  graph_y_axis();

  // Graph points
  noStroke();
  fill(72);
  rect(x_margin, y_margin, width - x_margin*2, height - y_margin*2);
  int x_offset = 0;
  //fill(map(voltage, 0, max, 250, 0), map(voltage, 0, max, 100, 255), map(voltage, 0, max, 10, 200));
  if(voltage < (max/2))
    fill(map(voltage, 0, max/2, 255, 20), map(voltage, 0, max/2, 80, 180), 120);
  else
    fill(map(voltage, max/2, max, 20, 255), map(voltage, max/2, max, 180, 80), 120);
  beginShape();
  if (x.size() > max_x_points)
    x_offset = x.size() - max_x_points;
  
  vertex(x_margin, height-y_margin);
  for (int i = 0; i < x.size() - x_offset; i++) {
    vertex(x_margin+i, (height-y_margin)-(y.get(i + x_offset)*y_spacing));
  }
  vertex(x_margin + x.size() - x_offset, height-y_margin);
  endShape();
}

// Grafica eje xy
void graph_y_axis() {
  for (int i = 0; i <= max; i++) {
    text(i + "V", 0, (height-y_margin) - (y_spacing*i));
  }
}

// Al presionar tecla salir y guardar
void keyPressed() {
  output.close(); // Cierra el archivo
  exit(); // Programa finaliza
}
