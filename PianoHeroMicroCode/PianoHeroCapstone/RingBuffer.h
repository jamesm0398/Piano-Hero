typedef struct MidiMsg {
  byte channel = 0;
  byte key = 0;
  byte vel = 0 ;
}MidiMsg;

#define MAX_RBUFF 84
typedef struct RingBuffer {
  MidiMsg buff[MAX_RBUFF];
  int stat[MAX_RBUFF];
  int nextWriteIndex;
  int nextReadIndex;
}RingBuffer;

RingBuffer midiBuff = {0};
RingBuffer keyBuff = {0};
/*
void WriteRingBuff(struct MidiMsg* msg)
{
  rBuff.buf[rBuff.nextWriteIndex] = *msg;
  rBuff.stat[rBuff.nextWriteIndex++] = 1;
  if (rBuff.nextWriteIndex >= MAX_RBUFF)
  {
    rBuff.nextWriteIndex = 0;
  }
}

int ReadRingBuff(struct MidiMsg** msg)
{
  int* i = &rBuff.stat[rBuff.nextReadIndex];
  if (*i == 1)
  {
    *msg = &rBuff.buf[rBuff.nextReadIndex++];
    if (rBuff.nextReadIndex >= MAX_RBUFF)
    {
      rBuff.nextReadIndex = 0;
    }
    *i = 0;
    return 1;
  }
  return -1;
}*/
