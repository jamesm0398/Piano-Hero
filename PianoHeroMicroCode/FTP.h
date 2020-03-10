#include "States.h"

#include "SdFat.h"

#define BUFF_LEN 54
#define HEADER_LEN 13
#define GOOD_RESPONSE 0xF0
#define BAD_RESPONSE 0xFF

long totalBodyLen = 0;
long bodySectionLen = 0;

byte buff[BUFF_LEN+HEADER_LEN+1] = {0};


File FTPFile;


int LoadStateMachine(int* state_ptr);
void WriteResponse(int32_t resp);
int CheckByteForValue(int offSet, byte value, byte* header);

int interpHeader(long* contentLen, byte* header);
int ReadXBytesBlock(long len,  int state ,long* headerLen);
void LoadSetup();
int LoadStateMachine(int* state_ptr);
SdFat* FTP_SD;
void LoadSetup(SdFat* sd)
{
  Serial1.begin(115200);
  delay(150);
  while(Serial1.available()){
    Serial1.read();
  }  
  const char* fileName = "a.midi";
  sd->remove(fileName);
  FTPFile = sd->open(fileName, O_WRITE | O_CREAT | O_TRUNC);//FILE_WRITE);////(O_RDWR | O_AT_END));
  if (!FTPFile)
  {
    Serial.println("File is not good.");
    return;
  }
  else
  {
    Serial.println("File is good.");
  }

  FTP_SD = sd;
}

int ReadXBytesBlock(long len,  int state ,long* headerLen)
{
  int ret = 1;
  //if (Serial1.available() >= 0)
  {
    printMsg("ReadXBytesBlock needs : %d\n", len); 
    unsigned long timeStamp = millis();
    //unsigned long diff = 0;
    while(Serial1.available() < len)
    {
      
      
      if((millis() - timeStamp) > 10000)
      {
        printMsg("ReadXBytesBlock timed out after : %d(millsecs)\n",  millis() - timeStamp); 
        WriteResponse(BAD_RESPONSE);
        return 0;
      }
    };//{printMsg("ReadXBytesBlock has : %d, needs %d\n", Serial1.available(),len);}
     printMsg("Serial available greater than : %d\n", len); 
    int j = 0;
    while (j < len)
    {
      buff[j] = Serial1.read();   
      //Serial.write(buff[j]);        
      ++j;
    }
    if( state == CONTENT_STATE)
    {
      byte* tmp = buff;
      j = 0;
      while(j < len)
      {
        FTPFile.write(*tmp);
        Serial.write(*tmp);
        ++tmp;
        ++j;
      }
      
    }
    else if (state == MASTER_HEADER_STATE && interpHeader(headerLen, buff) == 0)
    {
      Serial.write( "invalid state interp returned 0" );            
      WriteResponse(BAD_RESPONSE);  
      ret = 0;
    }
    else if (state == CONTENT_HEADER_STATE && interpHeader(headerLen, buff) == 0)
    {
      Serial.write( "invalid state interp returned 0" );            
      WriteResponse(BAD_RESPONSE);  
      ret = 0;
    }
    else{
     // Serial.write("in the else\n");
    }
    WriteResponse(GOOD_RESPONSE);
  }
 //  printMsg("\nret : %d\n", ret); 
  return ret;
}

int interpHeader(long* contentLen, byte* header)
{
  *contentLen = 0;
  int err = 1;
  err &= CheckByteForValue(0, 0xFF, buff);
  err &= CheckByteForValue(1, 0x00, buff);
  err &= *(header + 2) == 8;

  int shiftAmount = (*(header + 2) * 8) - 8;
  for (int i = 10; i > 2; --i) {
    (*contentLen) += header[i] << shiftAmount;
    shiftAmount -= 8;
  }
  err &= CheckByteForValue(11, 0xFF, buff);
  err &= CheckByteForValue(12, 0x00, buff);

printMsg("\nsize : %d \n", *contentLen); 
  return err;
}



int CheckByteForValue(int offSet, byte value, byte* header)
{
  int ret = 1;
  if (*(header + offSet) != value)
  {
    printMsg("Expected : %d Got : %d\n", value, *(header + offSet)); 
    ret = 0;
  }
  return ret;
}

void WriteResponse(int32_t resp)
{
  Serial1.write(resp);
  Serial1.write(resp);
  Serial1.write(resp);
  Serial1.write(resp);
}

int LoadStateMachine()
{

  int result = 1;
  //int state = *state_ptr;
   switch (state ) 
   {
      case MASTER_HEADER_STATE:
      {
        // printMsg("In Master header state: %d\n", 1); 
        if(0 == ReadXBytesBlock(HEADER_LEN,  MASTER_HEADER_STATE , &totalBodyLen))
        {
          result = 0;
          state = INVALID_STATE;
          break;    
        }     
        else
        {
           printMsg("Total body len: %d\n", totalBodyLen); 
        }
        state = CONTENT_HEADER_STATE;
      }    
      case CONTENT_HEADER_STATE:
      {
        if(0 == ReadXBytesBlock(HEADER_LEN,  CONTENT_HEADER_STATE, &bodySectionLen))
        {
          result = 0;
          state = INVALID_STATE;
          break;
        }          
        state = CONTENT_STATE;
      } 
      case CONTENT_STATE:
      {        
        printMsg("Content Len: %d\n", bodySectionLen); 
        if(0 == ReadXBytesBlock(bodySectionLen,  CONTENT_STATE, &bodySectionLen))
        {
          result = 0;
          state = INVALID_STATE;
          break;
        }
        
        totalBodyLen-= bodySectionLen;
        
        if(totalBodyLen <= 0)
        {
           FTPFile.close();
           Serial.write("File Done\n");
           state = DONE_STATE;
        }
        else{
          state = CONTENT_HEADER_STATE;          
        }
        break;
      }
      case INVALID_STATE:
      {
        Serial.write("Reset state\n");
        result = 0;
        break;
      }
      default:
        //state = INVALID_STATE;
        //Serial.write("THis state dones not exist in FTP \n");
        break;
   }
  // *state_ptr = state;
   return result;
}
