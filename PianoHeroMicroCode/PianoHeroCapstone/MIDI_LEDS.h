//################### MIDI START

#include <MD_MIDIFile.h>

#include "LED_VIA_KEYBOARD.h"
#define GENERATE_TICKS  1

#define USE_MIDI  1   // set to 1 to enable MIDI output, otherwise debug output

#define POT_PIN 19
/*
#if USE_MIDI // set up for direct MIDI serial output

#define DEBUG(x)
#define DEBUGX(x)
#define DEBUGS(s)
//#define SERIAL_RATE 115200

#else // don't use MIDI to allow printing debug statements

#define DEBUG(x)  Serial.print(x)
#define DEBUGX(x) Serial.print(x, HEX)
#define DEBUGS(s) Serial.print(F(s))
//#define SERIAL_RATE 115200

#endif // USE_MIDI
*/
#define WAIT_DELAY    2000 // ms
//;
MD_MIDIFile SMF;
 uint8_t ogTempo =0;
//uint8_t BPM = 120;
//################### MIDI END

#define SERIAL_RATE 115200



void midiCallback(midi_event *pev)
// Called by the MIDIFile library when a file event needs to be processed
// thru the midi communications interface.
// This callback is set up in the setup() function.
{
//Serial.write("IN CALL BACK!!!!!!!!!!!!!!!!!!\n");
  if ((pev->data[0] >= 0x80) && (pev->data[0] <= 0xe0))
  {
   // char s[40] = {0};
   // sprintf(s,"|%08d|%08d|%08d|%08d|\n", pev->data[0], pev->data[1], pev->data[2], pev->data[3]);
   // Serial.write(s);
      if(pev->data[0] == 144 || pev->data[0] == 128)
      {
        RunMidiLeds(pev->data[1], pev->data[2]);
      }

  }
  else{
   //Serial.write("\nIN ELSE CALL BACK!!!!!!!!!!!!!!!!!!\n");
   //Serial.write(pev->data, pev->size);
  }

}
void MidiSilence(void)
// Turn everything off on every channel.
// Some midi files are badly behaved and leave notes hanging, so between songs turn
// off all the notes and sound
{
  midi_event ev;

  // All sound off
  // When All Sound Off is received all oscillators will turn off, and their volume
  // envelopes are set to zero as soon as possible.
  ev.size = 0;
  ev.data[ev.size++] = 0xb0;
  ev.data[ev.size++] = 0;
  ev.data[ev.size++] = 0;
 
   AllOff();
  ResetRingBuff();
  for (ev.channel = 0; ev.channel < 16; ev.channel++)
    midiCallback(&ev);
}



uint16_t GetPotInput(void)
{
  int rawVal = analogRead(POT_PIN);
  uint16_t BPM = 120;
  if(rawVal > 800)
  {
   BPM = (uint16_t)(2 * ogTempo);
  }
  else if(rawVal > 600)
  {
    BPM = (uint16_t)(1.5 * ogTempo);
  }
  else if( rawVal > 400)
  {
    BPM = (uint16_t)(ogTempo);
  }
  else if(rawVal > 200)
  {
    BPM = (uint16_t)(0.75 * ogTempo);
  }
  else
  {
    BPM = (uint16_t)(0.1 * ogTempo);
    //BPM = (uint16_t)(0.5 * ogTempo);
  }
  //printMsg("BPM: %u\n", BPM);
  return BPM;
  //BPM = rawVal % 255;
 // 
}
static uint32_t lastTickCheckTime, lastTickError;
uint16_t tickClock(void)
// Check if enough time has passed for a MIDI tick and work out how many!
{
  
  
  uint8_t   ticks = 0;

  uint32_t elapsedTime = lastTickError + micros() - lastTickCheckTime;
  uint32_t tickTime = (60 * 1000000L) / (GetPotInput() * SMF.getTicksPerQuarterNote());  // microseconds per tick
  tickTime = (tickTime * 4) / (SMF.getTimeSignature() & 0xf); // Adjusted for time signature

  if (elapsedTime >= tickTime)
  {
    ticks = elapsedTime/tickTime;
    lastTickError = elapsedTime - (tickTime * ticks);
    lastTickCheckTime = micros();   // save for next round of checks
  }

  return(ticks);
}


void MidiLEDsSetup(SdFat*  SD)
{
 /*  if (!SD->begin(SD_SELECT, SPI_FULL_SPEED))
  {
    Serial.write("Failed to mount SD card\n");
   // DEBUG("\nSD init fail!");
   // digitalWrite(SD_ERROR_LED, HIGH);
    while (true) ;
  }
*/
  // Initialize MIDIFile
  SMF.begin(SD);
  SMF.setMidiHandler(midiCallback);
  //SMF.setSysexHandler(sysexCallback);
  InitKeyLeds();
  
}

  static bool fBeat = false;
  static uint16_t sumTicks = 0;
 
int PlayMachineState(void)
{
  int ret = 1;
//  static uint16_t currTune = ARRAY_SIZE(tuneList);
  static uint32_t timeStart;
 //static 
  switch (state)
  {
  case STATE_PROMPT:
    //Serial.print("\nEnter file name: ");
    state = S_IDLE;
    break;

  case S_IDLE:    // now idle, set up the next tune
    {            
      char fname[20] = {0};
    
      strcpy(fname, "a.midi");    
     
      SMF.setFilename(fname);
      state = STATE_OPEN;
    }
    break;
  case STATE_OPEN:
  int err;
    err = SMF.load();
    if (err != -1)
    {
      Serial.print("SMF load Error ");
      printMsg("\n!!!!!!!!!\n SMF error %d \n!!!!!!!!!\n",err);
     // Serial.println(err);
      state = STATE_PROMPT;
      ret = 0;
    }
    else
    {
      
      //SMF.dump();
      ogTempo =  SMF.getTempo();
     
      state = S_PLAYING;
      MidiSilence();
      sumTicks = 0;
      fBeat = false;
     // printMsg("Starting Play",1);
      AllOff();
      ResetRingBuff();
    }
    break;

  case S_PLAYING: // play the file  
    {
            
        
    RunKeyLeds();
        
        uint32_t ticks = tickClock();
        //
        if (ticks > 0)
        {
        //  printMsg("In IF!!!!!!! ticks: %lu\n", ticks);
          //LCDBeat(fBeat);
          //if (SMF.getNextEvent()){}
    SMF.processEvents(ticks);  
          //SMF.isEOF();
        //  SMF.isEOF();  // side effect to cause restart at EOF if looping
        //  LCDbpm();
          
          sumTicks += ticks;
          if (sumTicks >= SMF.getTicksPerQuarterNote())
          {
           
            sumTicks = 0;
            fBeat = !fBeat;
          }    
        } 
        else
        {
         // printMsg("ticks: %lu\n", ticks); 
        }
       
      if(SMF.isEOF())// else
      {
      //  Serial.println("end of file\n");
       // printMsg("Ending Play",1);
        state = S_END;
      }
      
    }

    break;

  case S_END:   // done with this one
    // printMsg("\nS_END",1);
   // Serial.println("before midi silence\n");
    MidiSilence();
    SMF.close();

    timeStart = millis();
    state = DONE_STATE;//S_WAIT_BETWEEN;
   // Serial.println("Done song\n");
    //printMsg("\nDone",1);
    break;

  case S_WAIT_BETWEEN:    // signal finish LED with a dignified pause
   // digitalWrite(READY_LED, HIGH);
    if (millis() - timeStart >= WAIT_DELAY)
      state = DONE_STATE;
    break;

  default:
    state = S_IDLE;
    break;
  }
  //Serial.write("led print\n");
  ShowAll();
  return ret;
}
