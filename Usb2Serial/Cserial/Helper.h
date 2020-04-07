#pragma once
#include <string.h>
#include <stdio.h>
#include <string>

typedef struct MidiMsg {
	byte channel;
	byte key;
	byte vel;
}MidiMsg;

#define MAX_RBUFF 15
typedef struct RingBuffer {
	MidiMsg buf[MAX_RBUFF] = { 0 };
	int stat[MAX_RBUFF] = { 0 };
	int nextWriteIndex = 0;
	int nextReadIndex = 0;
}RingBuffer;

static RingBuffer rBuff;
static void ResetRingBuff(void)
{
	memset(&rBuff, 0, sizeof(rBuff));
}
static void WriteRingBuff(MidiMsg* msg)
{
	rBuff.buf[rBuff.nextWriteIndex] = *msg;
	rBuff.stat[rBuff.nextWriteIndex++] = 1;
	printf("Writing to index %d\n", rBuff.nextWriteIndex-1);
	if (rBuff.nextWriteIndex >= MAX_RBUFF)
	{
		rBuff.nextWriteIndex = 0;
	}
}

static int ReadRingBuff(MidiMsg** msg)
{
	int* i = &rBuff.stat[rBuff.nextReadIndex];
	if (*i != 1)
	{
		int end = rBuff.nextReadIndex++;
		++i;
		while (*i != 1 && end != rBuff.nextReadIndex)
		{
			++i;
			++rBuff.nextReadIndex;
			if (rBuff.nextReadIndex >= MAX_RBUFF)
			{
				i = &rBuff.stat[0];
				rBuff.nextReadIndex = 0;
			}
		}
	}
	if (*i == 1)
	{
		printf("Reading From index %d\n", rBuff.nextReadIndex );
		*msg = &rBuff.buf[rBuff.nextReadIndex++];
		if (rBuff.nextReadIndex >= MAX_RBUFF)
		{
			rBuff.nextReadIndex = 0;
		}
		*i = 0;
		return 1;
	}
	return -1;
}

static int getNum()
{
	int maxSIntDigits = 10;
	char record[128] = { 0 };
	int number = 0;
	int multiplier = 1;
	int greaterThanMax = 0;
	int numberCount = maxSIntDigits;
	int numberArray[10] = { 0 };

	fgets(record, 128, stdin);

	for (int i = 127; i > -1 && greaterThanMax == 0; i--)
	{
		//finds digits in char array and put each one into an int array element
		if (record[i] > 47 && record[i] < 58)
		{
			numberCount--;
			numberArray[numberCount] = record[i] - '0';

			if (numberCount < 0)
			{
				greaterThanMax = 1;
				number = -1;
			}
		}
	}
	if (numberCount == maxSIntDigits || numberArray[0] > 1)
	{
		number = -1;
	}
	else if (!greaterThanMax)
	{
		for (int i = maxSIntDigits - 1; i > numberCount - 1; i--)
		{
			// assembles number from an array			
			number += multiplier * numberArray[i];
			multiplier *= 10;
		}
	}

	return number;
}



static int hexadecimalToDecimal(char hexVal[])
{
	size_t len = strlen(hexVal);

	// Initializing base value to 1, i.e 16^0 
	int base = 1;

	int dec_val = 0;

	// Extracting characters as digits from last character 
	for (size_t i = len - 1; i >= 0; i--)
	{
		// if character lies in '0'-'9', converting  
		// it to integral 0-9 by subtracting 48 from 
		// ASCII value. 
		if (hexVal[i] >= '0' && hexVal[i] <= '9')
		{
			dec_val += (hexVal[i] - 48)*base;

			// incrementing base by power 
			base = base * 16;
		}

		// if character lies in 'A'-'F' , converting  
		// it to integral 10 - 15 by subtracting 55  
		// from ASCII value 
		else if (hexVal[i] >= 'A' && hexVal[i] <= 'F')
		{
			dec_val += (hexVal[i] - 55)*base;

			// incrementing base by power 
			base = base * 16;
		}
	}

	return dec_val;
}