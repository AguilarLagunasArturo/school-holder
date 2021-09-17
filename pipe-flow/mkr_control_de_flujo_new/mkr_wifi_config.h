#include <SPI.h>
#include <WiFiNINA.h>
#define ssid "ssid"
#define pass "pass"

//#define ssid "INFINITUM2372_2.4"
//#define pass "uH0L0Ybioa"
int keyIndex  = 0;

int status = WL_IDLE_STATUS;
WiFiServer server(80);

void wifi_setup() {
  // Busca el modulo WiFi
  if (WiFi.status() == WL_NO_SHIELD) {
    Serial.println("Modulo WiFi no existe.");
    while (true);
  }

  // Intenta conectar a WiFi network:
  while ( status != WL_CONNECTED) {
    Serial.print("Conectando a: ");
    Serial.println(ssid);

    // Conecta a WPA/WPA2 network
    status = WiFi.begin(ssid, pass);
    // Espera 10 s por conexion.
    delay(10000);
  }
  server.begin();     // Servidor web en port 80
}

void print_wifi_status() {
  // print the SSID of the network you're attached to:
  Serial.print("SSID: ");
  Serial.println(WiFi.SSID());

  // print your WiFi shield's IP address:
  IPAddress ip = WiFi.localIP();
  Serial.print("IP Address: ");
  Serial.println(ip);

  // print the received signal strength:
  long rssi = WiFi.RSSI();
  Serial.print("Signal strength (RSSI):");
  Serial.print(rssi);
  Serial.println("dBm");

  // print where to go in a browser:
  Serial.print("To see this page: http://");
  Serial.println(ip);
}
