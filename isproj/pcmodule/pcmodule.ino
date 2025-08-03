#include "BLEDevice.h"


static BLEUUID serviceUUID("a9948246-ba48-4c22-bff9-91c570df0b27");
static BLEUUID    charUUID_1("f2ed52f9-6787-427c-801a-3f702739e744");
#define id "is38kfy"


static boolean doConnect = false;
static boolean connected = false;
static boolean doScan = false;

// Define pointer for the BLE connection
static BLEAdvertisedDevice* myDevice;
BLERemoteCharacteristic* pRemoteChar_1;






uint32_t doorval;
uint32_t oldval=255;
uint32_t elapsed=0;

static void notifyCallback(BLERemoteCharacteristic* pBLERemoteCharacteristic,
                            uint8_t* pData,
                            size_t length,
                            bool isNotify) {
  if(pBLERemoteCharacteristic->getUUID().toString() == charUUID_1.toString()) {


    doorval = pData[0];
    for(int i = 1; i<length; i++) {
      doorval = doorval | (pData[i] << i*8);
    }
  
//if (!(oldval == doorval)) {
      //oldval = doorval;
    //  Serial.print(id);
     //Serial.print("|");
   //   Serial.println(doorval+1);
   // }



  }
}









class MyClientCallback : public BLEClientCallbacks {
  void onConnect(BLEClient* pclient) {
  }

  void onDisconnect(BLEClient* pclient) {
    connected = false;
    Serial.println("onDisconnect");
    //Serial.print(id);
    //Serial.println("|0");
   // oldval=255;
  }
};









bool connectToServer() {
  Serial.print("Forming a connection to ");
  Serial.println(myDevice->getAddress().toString().c_str());
  BLEClient*  pClient  = BLEDevice::createClient();
  Serial.println(" - Created client");
 pClient->setClientCallbacks(new MyClientCallback());
  pClient->connect(myDevice);  
  Serial.println(" - Connected to server");
  BLERemoteService* pRemoteService = pClient->getService(serviceUUID);
  if (pRemoteService == nullptr) {
    Serial.print("Failed to find our service UUID: ");
    Serial.println(serviceUUID.toString().c_str());
    pClient->disconnect();
    return false;
  }
  Serial.println(" - Found our service");

  connected = true;
  pRemoteChar_1 = pRemoteService->getCharacteristic(charUUID_1);
  
  if(connectCharacteristic(pRemoteService, pRemoteChar_1) == false)
    connected = false;
  

  if(connected == false) {
    pClient-> disconnect();
    Serial.println("At least one characteristic UUID not found");
    return false;
  }
  return true;
}










bool connectCharacteristic(BLERemoteService* pRemoteService, BLERemoteCharacteristic* l_BLERemoteChar) {
  // Obtain a reference to the characteristic in the service of the remote BLE server.
  if (l_BLERemoteChar == nullptr) {
    Serial.print("Failed to find one of the characteristics");
    Serial.print(l_BLERemoteChar->getUUID().toString().c_str());
    return false;
  }
  Serial.println(" - Found characteristic: " + String(l_BLERemoteChar->getUUID().toString().c_str()));

  if(l_BLERemoteChar->canNotify())
    l_BLERemoteChar->registerForNotify(notifyCallback);

  return true;
}









class MyAdvertisedDeviceCallbacks: public BLEAdvertisedDeviceCallbacks {

  void onResult(BLEAdvertisedDevice advertisedDevice) {
    Serial.print("BLE Advertised Device found: ");
    Serial.println(advertisedDevice.toString().c_str());
  

    if (advertisedDevice.haveServiceUUID() && advertisedDevice.isAdvertisingService(serviceUUID)) {
      BLEDevice::getScan()->stop();
      myDevice = new BLEAdvertisedDevice(advertisedDevice);
      doConnect = true;
      doScan = true;
    }
  } 
};









void setup() {
  Serial.begin(9600);
  Serial.println("Starting Arduino BLE Client application...");
  BLEDevice::init("");
  BLEScan* pBLEScan = BLEDevice::getScan();
  pBLEScan->setAdvertisedDeviceCallbacks(new MyAdvertisedDeviceCallbacks());
  pBLEScan->setInterval(1349);
  pBLEScan->setWindow(449);
  pBLEScan->setActiveScan(true);
  pBLEScan->start(5, false);
} 








void loop() {
  if (doConnect == true) {
    if (connectToServer()) {
      Serial.println("We are now connected to the BLE Server.");
    } else {
      Serial.println("We have failed to connect to the server; there is nothin more we will do.");
    }
    doConnect = false;
  }
  if (connected) {
    




    if (oldval == doorval) {
      if (elapsed > 10) {
        elapsed=0;
        oldval = doorval;
      Serial.print(id);
      Serial.print("|");
      Serial.println(doorval+1);
      } else {
        elapsed++;
      }
    } else {

      oldval = doorval;
      Serial.print(id);
      Serial.print("|");
      Serial.println(doorval+1);
    }

      
      delay(100);



  }else if(doScan){
    
    BLEDevice::getScan()->start(1); 
  }

if (!connected) {
doScan=true;
oldval=255;
elapsed=0;
 Serial.print(id);
  Serial.println("|0");
delay(1000);
}


  
}