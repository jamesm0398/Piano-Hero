//################### MIDI START

#include <MD_MIDIFile.h>


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

//################### LED STRIP START
#include "FastLED.h"
 
#define NUM_LEDS 32
 
#define DATA_PIN 15
#define CLOCK_PIN 16
 
CRGB leds[NUM_LEDS];
int order[NUM_LEDS] = {0,30,1};

//################### LED STRIP END


void midiCallback(midi_event *pev)
// Called by the MIDIFile library when a file event needs to be processed
// thru the midi communications interface.
// This callback is set up in the setup() function.
{
//Serial.write("IN CALL BACK!!!!!!!!!!!!!!!!!!\n");
  if ((pev->data[0] >= 0x80) && (pev->data[0] <= 0xe0))
  {
   // Serial.write("IN CALL BACK!!!!!!!!!!!!!!!!!!\n");
    //Serial.write(pev->data[0] | pev->channel);
   // char s[40] = {0};
  //  sprintf(s,"|%08d|%08d|%08d|%08d|\n", pev->data[0], pev->data[1], pev->data[2], pev->data[3]);
   // Serial.write(s);

    int color = pev->data[2] * 2;
    if(color == 0x100)
    {
      color-=1;
    }
    
    byte led = (pev->data[1]-36) % NUM_LEDS;
    leds[led] = CHSV(color, color, color);
    FastLED.show();
   // Serial.write(&pev->data[1], pev->size-1);
  }
  else{
   Serial.write("\nIN ELSE CALL BACK!!!!!!!!!!!!!!!!!!\n");
   Serial.write(pev->data, pev->size);
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
  ev.data[ev.size++] = 120;
  ev.data[ev.size++] = 0;

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
    BPM = (uint16_t)(0.5 * ogTempo);
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
  FastLED.addLeds<WS2801, DATA_PIN, CLOCK_PIN, RGB>(leds, NUM_LEDS);
}

  static bool fBeat = false;
  static uint16_t sumTicks = 0;
 
void PlayMachineState(void)
{

//  static uint16_t currTune = ARRAY_SIZE(tuneList);
  static uint32_t timeStart;
 //static 
  switch (state)
  {
  case STATE_PROMPT:
    Serial.print("\nEnter file name: ");
    state = S_IDLE;
    break;

  case S_IDLE:    // now idle, set up the next tune
    {
      uint8_t len = 0;
      char c; 
      char  fname[20];
      // read until end of line
      do
      {
        while (!Serial.available())
          ;  // wait for the next character
        c = Serial.read();
        fname[len++] = c;
      } while (c != '\n');

      // properly terminate
      --len;
      fname[len++] = '\0';

      Serial.println(fname);
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
      Serial.println(err);
      state = STATE_PROMPT;
    }
    else
    {
      //SMF.dump();
      ogTempo =  SMF.getTempo();
      printMsg("BPM: %u",ogTempo);
      state = S_PLAYING;
      
      printMsg("Starting Play",1);
    }
    break;

  case S_PLAYING: // play the file
   // DEBUGS("\nS_PLAYING");
   // if (!SMF.isEOF())
    {
              // play the file
    //  #if GENERATE_TICKS

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
           //  printMsg("SUM of ticks: %lu\n", sumTicks);
            sumTicks = 0;
            fBeat = !fBeat;
          }    
        } 
        else
        {
         // printMsg("ticks: %lu\n", ticks); 
        }
    //  #else
    //    SMF.getNextEvent();
    //  #endif
      
    }
    if(SMF.isEOF())// else
    {
      printMsg("Ending Play",1);
      state = S_END;
    }
    break;

  case S_END:   // done with this one
  //  DEBUGS("\nS_END");
    MidiSilence();
    SMF.close();

    timeStart = millis();
    state = S_WAIT_BETWEEN;
   // DEBUGS("\nWAIT_BETWEEN");
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
}
