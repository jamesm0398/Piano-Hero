typedef struct MidiMsg {
  byte key = 0;
  byte vel = 0 ;
}MidiMsg;

#define MAX_RBUFF 84
typedef struct RingBuffer {
  MidiMsg buf[MAX_RBUFF];
  int stat[MAX_RBUFF];
  int nextWriteIndex;
  int nextReadIndex;
}RingBuffer;

RingBuffer midiBuff = {0};
RingBuffer keyBuff = {0};

void ResetRingBuff()
{
  memset(&midiBuff, 0, sizeof(midiBuff));
}

/*

 void WriteRingBuff(MidiMsg* msg)
{
  midiBuff.buf[midiBuff.nextWriteIndex] = *msg;
  midiBuff.stat[midiBuff.nextWriteIndex++] = 1;
 // printf("Writing to index %d\n", midiBuff.nextWriteIndex-1);
  if (midiBuff.nextWriteIndex >= MAX_RBUFF)
  {
    midiBuff.nextWriteIndex = 0;
  }
}

MidiMsg* FindKeyStateRingBuff(byte key)
{
  
}

 int ReadRingBuff(MidiMsg** msg)
{
  int* i = &midiBuff.stat[midiBuff.nextReadIndex];
  if (*i != 1)
  {
    int end = midiBuff.nextReadIndex++;
    ++i;
    while (*i != 1 && end != midiBuff.nextReadIndex)
    {
      ++i;
      ++midiBuff.nextReadIndex;
      if (midiBuff.nextReadIndex >= MAX_RBUFF)
      {
        i = &midiBuff.stat[0];
        midiBuff.nextReadIndex = 0;
      }
    }
  }
  if (*i == 1)
  {
    printf("Reading From index %d\n", midiBuff.nextReadIndex );
    *msg = &midiBuff.buf[midiBuff.nextReadIndex++];
    if (midiBuff.nextReadIndex >= MAX_RBUFF)
    {
      midiBuff.nextReadIndex = 0;
    }
    *i = 0;
    return 1;
  }
  return -1;
}*/
