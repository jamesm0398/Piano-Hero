#include "FTP.h"
#include "States.h"
#include "MIDI_LEDS.h"


void OnLoadFile (void* arg)
{
       //clear tcp buffer    
    while(Serial1.available())
    {
      Serial1.read();
    }  
    LoadSetup((SdFat*)arg);
    Serial.write( "SELECTED LOAD\n" );
    state = MASTER_HEADER_STATE;
}
void OnPlay(void* arg)
{
      state = STATE_PROMPT;
      MidiLEDsSetup((SdFat*)arg);
      Serial.write( "SELECTED PLAY\n" );
}


SdFat SD;
void setup(void) {
  delay(150);
    // Setup computer to Teensy serial
  Serial.begin(115200);
  // put your setup code here, to run once:
  if (!SD.begin(10)) {
    Serial.println("initialization failed!");
    return;
  }
  Serial.println("SD initialization done.");
 
  
    //init button pins as inputs 
  pinMode(PLAY_BUTTON_PIN, INPUT_PULLUP); 
  pinMode(LOAD_BUTTON_PIN, INPUT_PULLUP); 
  state = DONE_STATE;
}



void loop() {
  // put your main code here, to run repeatedly:
  int ret = 1;
  if((state > MIN_MIDI_STATE && state < MAX_MIDI_STATE))
  {    
    PlayMachineState();
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
