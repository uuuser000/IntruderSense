#include <BLEDevice.h>
#include <BLEServer.h>
#include <BLEUtils.h>
#include <BLE2902.h>

BLEServer* pServer = NULL;                        
BLECharacteristic* pCharacteristic_1 = NULL;      
BLE2902 *pBLE2902_1;                              

bool deviceConnected = false;
bool oldDeviceConnected = false;

uint32_t doorval = 0;
uint32_t oldval = 255;

uint32_t elapsed = 0;

#define SERVICE_UUID          "a9948246-ba48-4c22-bff9-91c570df0b27"
#define CHARACTERISTIC_UUID_1 "f2ed52f9-6787-427c-801a-3f702739e744"
#define ssid "ISDS"


class MyServerCallbacks: public BLEServerCallbacks {
    void onConnect(BLEServer* pServer) {
      deviceConnected = true;
       };

    void onDisconnect(BLEServer* pServer) {
      oldval=255;
      deviceConnected = false;
    }
};

void setup() {
  pinMode(3, OUTPUT);
  pinMode(2, OUTPUT);
  pinMode(LED_BUILTIN, OUTPUT);
  pinMode(4, INPUT_PULLUP);
  Serial.begin(9600);

  BLEDevice::init(ssid);

 
  pServer = BLEDevice::createServer();
  pServer->setCallbacks(new MyServerCallbacks());

  BLEService *pService = pServer->createService(SERVICE_UUID);


  pCharacteristic_1 = pService->createCharacteristic(
                      CHARACTERISTIC_UUID_1,
                      BLECharacteristic::PROPERTY_NOTIFY
                    );                   
  pService->start();
  BLEAdvertising *pAdvertising = BLEDevice::getAdvertising();
  pAdvertising->addServiceUUID(SERVICE_UUID);
  pAdvertising->setScanResponse(false);
  pAdvertising->setMinPreferred(0x0); 
  BLEDevice::startAdvertising();
  Serial.println("Waiting a client connection to notify...");
}

//uint32_t ledctr = 0;
uint32_t ledst = 0;


void led() {
      if (ledst == 0) {
      ledst=1;
      digitalWrite(2, HIGH);  
    } else {
      ledst=0;
      digitalWrite(2, LOW);  
    }
}

void loop() {

if (deviceConnected == true) {
  digitalWrite(2, HIGH);  
} else {
    led();
    delay(500);
}
  


     if (digitalRead(4) == HIGH) {
    doorval=1;
    digitalWrite(LED_BUILTIN, LOW);  
    digitalWrite(3, HIGH);  
   } else {
     doorval=0;
    digitalWrite(LED_BUILTIN, HIGH);  
     digitalWrite(3, LOW);  
   }         

    if (deviceConnected) {
      
    if (oldval == doorval) {
      if (elapsed > 20) {
      elapsed=0;
      oldval = doorval;
      pCharacteristic_1->setValue(doorval);
      pCharacteristic_1->notify();
      } else {
        elapsed++;
      }
    } else {
      oldval = doorval;
      pCharacteristic_1->setValue(doorval);
      pCharacteristic_1->notify();
    }


      

      delay(100);
    }
    if (!deviceConnected && oldDeviceConnected) {
      delay(500);
      pServer->startAdvertising(); 
      Serial.println("start advertising");
      oldDeviceConnected = deviceConnected;
    }
    if (deviceConnected && !oldDeviceConnected) {
      oldDeviceConnected = deviceConnected;
    }
}