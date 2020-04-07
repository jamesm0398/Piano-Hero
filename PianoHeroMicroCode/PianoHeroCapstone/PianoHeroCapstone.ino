#include "FTP.h"
#include "States.h"
#include "MIDI_LEDS.h"

//#include "LED_VIA_KEYBOARD.h"
void OnLoadFile (void* arg)
{
       //clear tcp buffer    
    while(Serial1.available())
    {
      Serial1.read();
    }  
    LoadSetup((SdFat*)arg);
   // Serial.write( "SELECTED LOAD\n" );
    state = MASTER_HEADER_STATE;
}
void OnPlay(void* arg)
{
         //clear serial buffer    
    while(Serial.available())
    {
      Serial.read();
    }  
      state = STATE_PROMPT;
      MidiLEDsSetup((SdFat*)arg);
     // Serial.write( "SELECTED PLAY\n" );
}


SdFat SD;
void setup(void) {
  delay(150);
    // Setup computer to Teensy serial
  Serial.begin(115200);
  // put your setup code here, to run once:
  if (!SD.begin(10)) {
    Serial.println("SD fail");
    return;
  }
  Serial.println("SD Good");
 
  
    //init button pins as inputs 
  pinMode(PLAY_BUTTON_PIN, INPUT_PULLUP); 
  pinMode(LOAD_BUTTON_PIN, INPUT_PULLUP); 
  state = DONE_STATE;
  
}



void loop() {
  // put your main code here, to run repeatedly:
  int ret = 1;
 
  
  char incomingBytes[20] = {0};
  //Detect if play button was pressed in app
    if(Serial1.available()>0)
    {
      char* buf = incomingBytes;
      while(Serial1.available()&& strlen(incomingBytes) < 20)
      {
        *buf = Serial1.read();
        ++buf;
      }       

      if(strstr(incomingBytes,"PLAY") != NULL)
      {
        PlayMachineState();
      }
     if(strstr(incomingBytes,"STOP") != NULL)
      {
        LoadStateMachine();
      }
    }
  
  
  if((state > MIN_MIDI_STATE && state < MAX_MIDI_STATE))
  {    
    ret = PlayMachineState();
  }
  else if(state > MIN_FTP_STATE && state < MAX_FTP_STATE)
  {
    ret = LoadStateMachine();  
  }

    
  if(state == DONE_STATE)
  {        

    DetectButtonPress(PLAY_BUTTON_PIN, &OnPlay, (void*)&SD);    
    DetectButtonPress(LOAD_BUTTON_PIN, &OnLoadFile, (void*)&SD);
  }

  if(ret == 0)
  {
    //reset state and or all hardware?
    Serial.write( "Error returning to DONE_STATE\n" );
    state = DONE_STATE;
  }

}
