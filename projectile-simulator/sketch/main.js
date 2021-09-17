// Proyectil
var diameter = 50;
var position = [];
var velocity = 25;
var angle = 70;
var g = 9.81;
var t_max = 0;
var x_max = 0;
var y_max = 0;
var current_time = 0;
var delta = 0;
// Canvas
var canvas;
var marginX;
var marginY;
var margin = 10 + diameter;
var width;
var height;
var velocity_slider;
var angle_slider;
var go_button;
var reset_button;

function setup() {
  marginX = windowWidth * 0.20;
  marginY = windowHeight * 0.25;
  width = windowWidth - marginX;
  height = windowHeight - marginY;
  canvas = createCanvas(width, height);
  canvas.parent('sketch-holder');
  velocity_slider = createSlider(0, 100, 25);
  velocity_slider.parent('velocity-holder');
  angle_slider = createSlider(0, 90, 70);
  angle_slider.parent('angle-holder');
  go_button = createButton("Lanzar");
  reset_button = createButton("Reiniciar");
  go_button.size(100);
  reset_button.size(100);
  go_button.parent('button-holder');
  reset_button.parent('button-holder');

  textSize(20);
  strokeWeight(2);

  // Proyectil
  position[0] = 0;
  position[1] = 0;
  angleMode(DEGREES);
  t_max = 2*velocity*sin(angle)/g;
  x_max = getX(t_max);;
  y_max = getY(t_max);
  reset_button.mousePressed(resetSketch);
  go_button.mousePressed(launch);
}

function draw() {
  background(200);
  fill(72);
  text("Velocidad inicial: " + velocity + " m/s", margin/2, margin/2);
  text("Ángulo: " + angle + " °", margin/2, margin);
  text("Tiempo de vuelo: " + t_max.toFixed(2) + " s", margin/2, margin*3/2);
  text("X max: " + x_max.toFixed(2) + " m", margin/2, margin*2);
  text("Y max: " + y_max.toFixed(2) + " m", margin/2, margin*5/2);
  translate(margin, height - margin);
  path();
  projectile(getX(current_time), getY(current_time), diameter);
  if (current_time <= t_max){
    current_time += delta;
  }
  else{
    delta = 0;
  }
  translate(-margin, -height + margin);
  rect(0, height - margin + diameter/2, width, margin);
}

function maxX() {
  return velocity*cos(angle)*t_max;
}

function maxY() {
  return pow(velocity*sin(angle), 2)/(2*g);
}

function getX(t) {
  return velocity*cos(angle)*t;
}

function getY(t) {
  return (velocity*sin(angle)*t)-(g*pow(t, 2))/2;
}

function path(){
  var t_aux;
  for(var i = 0; i < 100; i++){
    t_aux = map(i, 0, 99, 0, t_max)
    point(getX(t_aux)*5, -getY(t_aux)*5);
  }
}

function projectile(x, y, d){
  if (!launched){
    velocity = velocity_slider.value();
    angle = angle_slider.value();
  }
  t_max = 2*velocity*sin(angle)/g;
  x_max = maxX(t_max);;
  y_max = maxY(t_max);
  fill(126, 126, 126);
  ellipse(x*5, -y*5, d, d);
}
var launched = false;
function launch() {
  delta = 0.018;
  launched = true;
}

function resetSketch(){
  console.log("Reset.");
  location.reload();
}

function windowResized() {
  marginX = windowWidth * 0.20;
  marginY = windowHeight * 0.25;
  width = windowWidth - marginX;
  height = windowHeight - marginY;
  resizeCanvas(width, height);
}
