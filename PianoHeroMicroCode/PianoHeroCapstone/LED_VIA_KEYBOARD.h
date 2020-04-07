
#ifndef _KEY_LED_
#define _KEY_LED_
#include <Adafruit_NeoPixel.h>
#include "RingBuffer.h"
const uint32_t _RED = 0x00FF0000;
const uint32_t _GREEN = 0x0000FF00;
const uint32_t _BLUE = 0x000000FF;
const byte KEY_LED_OFFSET = 24;
 
#define NUM_LEDS 84
 
#define DATA_PIN 14
Adafruit_NeoPixel pix(NUM_LEDS, DATA_PIN, NEO_GRB + NEO_KHZ800);
static void InitKeyLeds(void){
    pix.begin();
  pix.setBrightness(40);
   
   for(int i = 0; i < 7; i++)
   {
    pix.setPixelColor(i*12, 0x00, 0x00,0x64);
   }
   pix.show();
//   uint32_t color = pix.getPixelColor(0);
 //   char s[40] = {0};
   // sprintf(s,"|%032d\n", (color &0x000000FF));
 //   Serial.write(s);
}

static void RunMidiLeds(byte key, byte vel)
{    
      byte index = (key-KEY_LED_OFFSET) % NUM_LEDS;
      bool keyState = (vel & 0xFF) != 0x00;
      uint32_t color = pix.getPixelColor(index);
      MidiMsg* midiKey = &(midiBuff.buf[index]);
      if(keyState)
      {
       // Serial.write("Key Down\n");
        if((color & _RED)  > 0x40)
        {
          //turn green
            pix.setPixelColor(index, 0x00, 0x64, 0x00);
        }         
        else
        {
          //turn blue
          pix.setPixelColor(index, 0x00, 0x00, 0x64);
        }        
        
      }
      else
      {   
        if((color & _BLUE)  > 0x40)
        {
          //turn off
          pix.setPixelColor(index, 0x00, 0x00,  0x00);

        }
        else
        {
             pix.setPixelColor(index, 0x64, 0x00,  0x00);
        }
      }
      midiKey->vel = vel; 
    
}

static void RunKeyLeds(void){
    int readCount = 0;
     
    MidiMsg* midiKey = 0;
    while(Serial.available() > 2 && readCount < 5)
    {
      byte type = Serial.read();
      byte key = Serial.read();
      byte vel = Serial.read();
    
      byte keyIndex = (key-KEY_LED_OFFSET) % NUM_LEDS;
      midiKey = &(midiBuff.buf[keyIndex]);
      
      bool keyState = (vel & 0xFF) != 0x00;
      uint32_t color = pix.getPixelColor(keyIndex);
      if(keyState)
      {
       // Serial.write("Key Down\n");
        if((color &0x000000FF)  > 0x20)
        {
          //turn green
            pix.setPixelColor(keyIndex, 0x00, 0x64, 0x00);
        }         
        else
        {
          //turn red
          pix.setPixelColor(keyIndex, 0x64, 0x00, 0x00);
        }
      }
      else
      { 
          
        if(midiKey->vel == 0)
        {
          //midi note is not still being held and keyboard key has been released
          //turn off
          pix.setPixelColor(keyIndex, 0x00, 0x00,  0x00);     
        }
        else  
        {
          //turn blue
          pix.setPixelColor(keyIndex, 0x00, 0x00, 0x64);
        }
     
        
        
        /*    
        *tmpP = ((uint8_t)0x00 );
        (*++tmpP) = ((uint8_t)0x00);
        (*++tmpP) =  0x00;    
        */    
      }      
         
      ++readCount;
    }
   
}

static void AllOff()
{
  pix.clear();
}
static void ShowAll()
{
  pix.show();
}
#endif 
