#ifndef _STATES_
#define _STATES_ 1
#include <SdFat.h>

enum STATES { MIN_FTP_STATE, MASTER_HEADER_STATE, CONTENT_HEADER_STATE, CONTENT_STATE, DONE_STATE, INVALID_STATE,
              PLAY_STATE, MAX_FTP_STATE,
              MIN_MIDI_STATE, S_IDLE, S_PLAYING, S_END, S_WAIT_BETWEEN, STATE_OPEN, STATE_PROMPT, MAX_MIDI_STATE};
STATES state; 
#define PLAY_BUTTON_PIN 9
#define LOAD_BUTTON_PIN 8
#define  SD_SELECT  10

#define DEBUG_MSG 1
void printMsg(const char* format, int arg ...);
void printMsg(const char* format, int arg ...)
{
 #if DEBUG_MSG == 1
    char s[strlen(format)+20];
    sprintf(s, format, arg);
    Serial.write( s );
 #endif
}

typedef void (*BHandler)(void*) ;

void DetectButtonPress(int buttonPin, BHandler bH, void *arg)
{
  int buttonState = digitalRead(buttonPin);
  if(buttonState == LOW)
  {
    (*bH)(arg);
  }
}



#endif
/*#define MIN_FTP_STATE 0

#define MASTER_HEADER_STATE 1
#define CONTENT_HEADER_STATE 2
#define CONTENT_STATE 3
#define DONE_STATE 4
#define INVALID_STATE 5
#define PLAY_STATE 6

#define MAX_FTP_STATE 7
#define MIN_MIDI_STATE 8

#define S_IDLE 9
#define S_PLAYING 8 
#define S_END 9 
#define S_WAIT_BETWEEN 10
#define STATE_OPEN 11
#define STATE_PROMPT 12

int current_state;
*/
