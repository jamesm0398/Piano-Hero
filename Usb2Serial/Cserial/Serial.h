#pragma once
#include<windows.h>
#include<stdio.h>
#include"Helper.h"
#include <mutex>

std::mutex m;
HANDLE OpenSerialCon(LPCWSTR comPort)
{
	HANDLE hComm;

	hComm = CreateFile(comPort,//(LPCWSTR)"\\\\.\\COM8",                //port name
		GENERIC_READ | GENERIC_WRITE, //Read/Write
		0,                            // No Sharing
		NULL,                         // No Security
		OPEN_EXISTING,// Open existing port only
		0,            // Non Overlapped I/O
		NULL);        // Null for Comm Devices

	if (hComm == INVALID_HANDLE_VALUE)
		printf("Error in opening serial port");
	else
		printf("opening serial port successful");

	CloseHandle(hComm);//Closing the Serial Port

	return hComm;
}

static int ComPort(HANDLE* hSerial, int portNum)
{


	// Declare variables and structures
	//HANDLE hSerial;
	DCB dcbSerialParams = { 0 };
	COMMTIMEOUTS timeouts = { 0 };
	
	std::string portName = "\\\\.\\COM";
	portName.append(std::to_string(portNum));
	// Open the highest available serial port number
	fprintf(stderr, "Opening serial port...");
	*hSerial = CreateFileA(
		portName.c_str(), GENERIC_READ | GENERIC_WRITE, 0, NULL,
		OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
	if (*hSerial == INVALID_HANDLE_VALUE)
	{
		fprintf(stderr, "Error\n");
		return 1;
	}
	else fprintf(stderr, "OK\n");

	// Set device parameters (38400 baud, 1 start bit,
	// 1 stop bit, no parity)
	dcbSerialParams.DCBlength = sizeof(dcbSerialParams);
	if (GetCommState(*hSerial, &dcbSerialParams) == 0)
	{
		fprintf(stderr, "Error getting device state\n");
		CloseHandle(*hSerial);
		return 1;
	}

	dcbSerialParams.BaudRate = CBR_256000;
	dcbSerialParams.ByteSize = 8;
	dcbSerialParams.StopBits = ONESTOPBIT;
	dcbSerialParams.Parity = NOPARITY;
	dcbSerialParams.EofChar = '\n';
	if (SetCommState(*hSerial, &dcbSerialParams) == 0)
	{
		fprintf(stderr, "Error setting device parameters\n");
		CloseHandle(*hSerial);
		return 1;
	}

	// Set COM port timeout settings
	timeouts.ReadIntervalTimeout = 10;
	timeouts.ReadTotalTimeoutConstant = 10;
	timeouts.ReadTotalTimeoutMultiplier = 10;
	timeouts.WriteTotalTimeoutConstant = 10;
	timeouts.WriteTotalTimeoutMultiplier = 10;
	if (SetCommTimeouts(*hSerial, &timeouts) == 0)
	{
		fprintf(stderr, "Error setting timeouts\n");
		CloseHandle(*hSerial);
		return 1;
	}

	//// Send specified text (remaining command line arguments)
	//DWORD bytes_written, total_bytes_written = 0;
	//fprintf(stderr, "Sending bytes...");
	//if (!WriteFile(hSerial, bytes_to_send, 5, &bytes_written, NULL))
	//{
	//	fprintf(stderr, "Error\n");
	//	CloseHandle(hSerial);
	//	return 1;
	//}
	//fprintf(stderr, "%d bytes written\n", bytes_written);

	//// Close serial port
	//fprintf(stderr, "Closing serial port...");
	//if (CloseHandle(*hSerial) == 0)
	//{
	//	fprintf(stderr, "Error\n");
	//	return 1;
	//}
	//fprintf(stderr, "OK\n");

	// exit normally
	return 0;
}
MidiMsg* msg;
static int WriteComPort(HANDLE* hSerial, LPVOID buffer, int bufSize) {

		// Send specified text (remaining command line arguments)
	DWORD bytes_written, total_bytes_written = 0;
	/*DWORD error = 0;
	COMSTAT comstat;
	ClearCommError(*hSerial, &error, &comstat);*/
	//m.lock();
	//CancelIoEx(*hSerial, NULL);
	fprintf(stderr, "Sending bytes...");
	if (!WriteFile(*hSerial, buffer, bufSize, &bytes_written, NULL))
	{
		fprintf(stderr, "Error\n");
		//CloseHandle(*hSerial);
		return -2;
	}
	fprintf(stderr, "%d bytes written\n", bytes_written);
		
	///m.unlock();
	return 1;
}
static int WriteMidiComPort(HANDLE* hSerial) {
	int ret = ReadRingBuff(&msg);
	if (ret == 1 && msg->key > 0 && msg->key < 128)
	{
		if (-2 == WriteComPort(hSerial, msg, sizeof(*msg)))
		{
			return -2;
		}
		else
		{
			return ret;
		}
	}
	return 0;
}

static void ReadComPort(HANDLE* hSerial) {
	MidiMsg inMidi = { 0 };
	DWORD total_bytes_read = 0;
	bool ret = ReadFile(*hSerial, &inMidi, 3, &total_bytes_read, NULL);
	if (ret)
	{
		printf("from micro! msg=%x %x %x\n", inMidi.channel, inMidi.key, inMidi.vel);

	}
	else 
	{
		printf("Failed to read from ComPort\n");
	}

}



static bool ReadComPortChars(HANDLE* hSerial, char** msg, DWORD len) {
	
	DWORD total_bytes_read = 0;
	bool ret = ReadFile(*hSerial, (LPVOID)(*msg), len, &total_bytes_read, NULL);
	if (ret && total_bytes_read > 0)
	{
		printf("from micro! msg= %s\n", *msg);
		FILE* fp;
		if (strstr(*msg, "SELECTED PLAY") != NULL)
		{
			fopen_s(&fp, "microMidiInput.txt", "w");
		}
		else
		{
			
			fopen_s(&fp, "microMidiInput.txt", "a");
			if (fp != NULL)
			{
				fwrite(*msg, sizeof(char), len, fp);

			}
		}
		

		fclose(fp);
	}
	else
	{
		printf("Failed to read from ComPort\n");
		ret = false;
	}
	return ret;
}

static void ReadAsyncComPort(HANDLE* hSerial,int* exit, int* exitCond, char** msg, DWORD len) {

	DWORD total_bytes_read = 0;
	bool ret = true;
	char record[128] = { 0 };
	while (ret && *exit != *exitCond)
	{
		
		ret = ReadFile(*hSerial, (LPVOID)(*msg), len, &total_bytes_read, NULL);
		if (ret && total_bytes_read > 0)
		{
			printf("from micro! msg= %s\n", *msg);
			FILE* fp;
			if (strstr(*msg, "SELECTED PLAY") != NULL)
			{
				fopen_s(&fp, "microMidiInput.txt", "w");
			}
			else
			{

				fopen_s(&fp, "microMidiInput.txt", "a");
				if (fp != NULL)
				{
					fwrite(*msg, sizeof(char), strlen(*msg), fp);

				}
			}


			fclose(fp);
			if (strstr(*msg, "_x_\r\n") != NULL)
			{
				WriteComPort(hSerial, exit, sizeof(*exit));
				/*FILE* fp;
				fopen_s(&fp, "microMidiInput.txt", "r");
				if (fp != NULL)
				{
					fwrite(*msg, sizeof(char), len, fp);

				}*/
			}
			memset(*msg, 0, len);
		}
		else
		{
			//printf("Failed to read from ComPort\n");
			//ret = false;
		}
		

		
	}

	
}
static void AsyncGetNum(HANDLE* hSerial, int* num, int* exitCond)
{
	while (*num != *exitCond)
	{
		*num = getNum();
		//WriteComPort(hSerial, num, sizeof(*num));
	}

}
static void AsyncWriteComPort(HANDLE* hSerial, int* num, int* exitCond)
{
	char record[128] = { 0 };
	while (*num != *exitCond)
	{
		fgets(record, 128, stdin);
//		WriteComPort(hSerial, record, strlen(record) * sizeof(char));
	}

}
static bool ConditionalRestComPort(HANDLE* hSerial, const char* rstMsg) {
	int bufLen = 20;
	char* msg = (char*)calloc(bufLen, sizeof(char));
	bool rest = false;
	if (ReadComPortChars(hSerial, &msg, bufLen))
	{
		if (_strcmpi(msg, rstMsg) == 0)
		{
			rest = true;
		}
	}
	else
	{
		rest = true;
	}
	free(msg);
	return rest;
}
static int CloseComPort(HANDLE* hSerial)
{
	// Close serial port
	fprintf(stderr, "Closing serial port...");
	CancelIoEx(*hSerial, NULL);
	if (CloseHandle(*hSerial) == 0)
	{
		fprintf(stderr, "Error\n");
		return 1;
	}
	fprintf(stderr, "OK\n");
	return 0;
}

//static int ComPortRead()
//{
//	// Define buffer
//	char bytes_to_send[7] = {0};
//	
//	// Declare variables and structures
//	HANDLE hSerial;
//	DCB dcbSerialParams = { 0 };
//	COMMTIMEOUTS timeouts = { 0 };
//
//	int portNum = getNum();
//
//	// Open the highest available serial port number
//	fprintf(stderr, "Opening serial port...");
//	hSerial = CreateFileA(
//		"\\\\.\\COM8", GENERIC_READ | GENERIC_WRITE, 0, NULL,
//		OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
//	if (hSerial == INVALID_HANDLE_VALUE)
//	{
//		fprintf(stderr, "Error\n");
//		return 1;
//	}
//	else fprintf(stderr, "OK\n");
//
//	// Set device parameters (38400 baud, 1 start bit,
//	// 1 stop bit, no parity)
//	dcbSerialParams.DCBlength = sizeof(dcbSerialParams);
//	if (GetCommState(hSerial, &dcbSerialParams) == 0)
//	{
//		fprintf(stderr, "Error getting device state\n");
//		CloseHandle(hSerial);
//		return 1;
//	}
//
//	dcbSerialParams.BaudRate = CBR_256000;
//	dcbSerialParams.ByteSize = 8;
//	dcbSerialParams.StopBits = ONESTOPBIT;
//	dcbSerialParams.Parity = NOPARITY;
//	if (SetCommState(hSerial, &dcbSerialParams) == 0)
//	{
//		fprintf(stderr, "Error setting device parameters\n");
//		CloseHandle(hSerial);
//		return 1;
//	}
//
//	// Set COM port timeout settings
//	timeouts.ReadIntervalTimeout = 50;
//	timeouts.ReadTotalTimeoutConstant = 50;
//	timeouts.ReadTotalTimeoutMultiplier = 10;
//	timeouts.WriteTotalTimeoutConstant = 50;
//	timeouts.WriteTotalTimeoutMultiplier = 10;
//	if (SetCommTimeouts(hSerial, &timeouts) == 0)
//	{
//		fprintf(stderr, "Error setting timeouts\n");
//		CloseHandle(hSerial);
//		return 1;
//	}
//
//	// Send specified text (remaining command line arguments)
//	DWORD bytes_written, total_bytes_written = 0;
//	fprintf(stderr, "Sending bytes...");
//	if (!WriteFile(hSerial, bytes_to_send, 5, &bytes_written, NULL))
//	{
//		fprintf(stderr, "Error\n");
//		CloseHandle(hSerial);
//		return 1;
//	}
//	fprintf(stderr, "%d bytes written\n", bytes_written);
//
//	// Close serial port
//	fprintf(stderr, "Closing serial port...");
//	if (CloseHandle(hSerial) == 0)
//	{
//		fprintf(stderr, "Error\n");
//		return 1;
//	}
//	fprintf(stderr, "OK\n");
//
//	// exit normally
//	return 0;
//}