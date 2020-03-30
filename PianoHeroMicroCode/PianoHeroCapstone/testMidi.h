// Play a file from the SD card in looping mode controlliong the tempo.
// Tempo is controlled wither by just setting the Tempo in the SMF object
// or by generating the MIDI ticks in this application.
//
// Example program to demonstrate the use of the MIDFile library
//
// Hardware required:
//  SD card interface - change SD_SELECT for SPI comms
//  LCD 1602 shield - change pins for LCD control
//  Key switches on the LCD shield - connected to an analog pin
// 

#include <SdFat.h>

#include <MD_MIDIFile.h>

// Set to 1 to generate the MIDI ticks in this application
// Set to 0 to allow library to generate clock based on Tempo
#define GENERATE_TICKS  1

// Set to 1 to use the MIDI interface (ie, not debugging to serial port)
#define USE_MIDI  1

#if USE_MIDI // set up for direct MIDI serial output

#define DEBUGS(s)
#define DEBUG(s, x)
#define DEBUGX(s, x)
#define SERIAL_RATE 31250

#else // don't use MIDI to allow printing debug statements

#define DEBUGS(s)     Serial.print(s)
#define DEBUG(s, x)   { Serial.print(F(s)); Serial.print(x); }
#define DEBUGX(s, x)  { Serial.print(F(s)); Serial.print(x, HEX); }
#define SERIAL_RATE 57600

#endif // USE_MIDI

// SD Hardware defines ---------
// SPI select pin for SD card (SPI comms).
// Arduino Ethernet shield, pin 4.
// Default SD chip select is the SPI SS pin (10).
// Other hardware will be different as documented for that hardware.
#define  SD_SELECT  10

// Library objects -------------
//LiquidCrystal LCD(LCD_RS, LCD_ENA, LCD_D4, LCD_D5, LCD_D6, LCD_D7);
SdFat SD;
MD_MIDIFile SMF;
//MD_AButton  LCDKey(LCD_KEYS);

//#define ARRAY_SIZE(a) (sizeof(a)/sizeof(a[0]))

// The in the tune list should be located on the SD card 
// or an error will occur opening the file.
char *loopfile = "b.midi";  // simple and short file

uint8_t lclBPM = 120;


void midiCallback(midi_event *pev)
// Called by the MIDIFile library when a file event needs to be processed
// through the midi communications interface.
// This callback is set up in the setup() function.
{
   

  if ((pev->data[0] >= 0x80) && (pev->data[0] <= 0xe0))
  {
    Serial.write("\nIn callback\n");
    Serial.write(pev->data[0] | pev->channel);
    Serial.write(&pev->data[1], pev->size-1);
  }
  else
    Serial.write(pev->data, pev->size);
}

//#if GENERATE_TICKS
uint16_t tickClock(void)
// Check if enough time has passed for a MIDI tick and work out how many!
{
  static uint32_t lastTickCheckTime, lastTickError;
  uint8_t   ticks = 0;

  uint32_t elapsedTime = lastTickError + micros() - lastTickCheckTime;
  uint32_t tickTime = (60 * 1000000L) / (lclBPM * SMF.getTicksPerQuarterNote());  // microseconds per tick
  tickTime = (tickTime * 4) / (SMF.getTimeSignature() & 0xf); // Adjusted for time signature

  if (elapsedTime >= tickTime)
  {
    ticks = elapsedTime/tickTime;
    lastTickError = elapsedTime - (tickTime * ticks);
    lastTickCheckTime = micros();   // save for next round of checks
  }

  return(ticks);
}
//#endif

void MIDI_Setup(void)
{
  int  err;

  Serial.begin(SERIAL_RATE);

 
  // Initialize SD
  if (!SD.begin(SD_SELECT, SPI_FULL_SPEED))
   // LCDErrMessage("SD init fail!");

  // Initialize MIDIFile
  SMF.begin(&SD);
  SMF.setMidiHandler(midiCallback);
 // SMF.looping(true);

  // use the next file name and play it
  //DEBUG("\nFile: ", loopfile);
  SMF.setFilename(loopfile);
  err = SMF.load();
  if (err != -1)
  {
    char sBuf[20] = "SMF load err ";

    itoa(err, &sBuf[strlen(sBuf)-1], 10);
  //  LCDErrMessage(sBuf);
  }  
}

void MIDI_loop(void)
{

  static bool fBeat = false;
  static uint16_t sumTicks = 0;
  uint32_t ticks = tickClock();
  
  if (ticks > 0)
  {
   // LCDBeat(fBeat);
    SMF.processEvents(ticks);  
    SMF.isEOF();  // side effect to cause restart at EOF if looping
      
    sumTicks += ticks;
    if (sumTicks >= SMF.getTicksPerQuarterNote())
    {
      sumTicks = 0;
      fBeat = !fBeat;
    }    
  }  

}
