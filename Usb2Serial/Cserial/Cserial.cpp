#include "Serial.h"

#include "MIDI.h"
#include "UsbEnum.h"
#include <thread>
#include <future>


int main(int argc, char* argv[])
{
	int done = 0;
	MIDIHDR hdr;
	HMIDIIN midiHandle;
	HANDLE hSerial;
	while (!done)
	{
		printf("exit : 0, ComPort : 1, Usb : 2, Midi : 3, Midi 2 Com : 4\n");
		int in = atoi(argv[1]);
		switch (in)
		{
		case 0:
			done = 1;
			break;
		case 1:
			ComPort(&hSerial);
			WriteMidiComPort(&hSerial);
			CloseComPort(&hSerial);
			break;
		case 2:
			//UsbListAndInteract();
			break;
		case 3:
			findMidiInput(&hdr, &midiHandle);
			/*while (true)
			{
				if (hdr.lpData != NULL && strlen(hdr.lpData) > 0)
				{
					printf("Data: %s\n", hdr.lpData);
				}
			}*/
			break;
		case 4:
		{
			ComPort(&hSerial);
			findMidiInput(&hdr,&midiHandle);
			
			if (ConditionalRestComPort(&hSerial,"SD fail\r\n" ))
			{
				CloseMidiInput(&hdr, &midiHandle);
				CloseComPort(&hSerial);
				printf("Rest comPort and MIdi\n");
				break;
			}
			int bufLen = 7000;
			char* msg = (char*)calloc(bufLen, sizeof(char));
			/*while (!ReadComPortChars(&hSerial, &msg, bufLen))
			{}
			while (!ReadComPortChars(&hSerial, &msg, bufLen))
			{
			}*/
			
			
			int exit = 0;
			int exitCond = 1;
			printf("enter 1 to exit\n");
			//std::thread rComT(ReadAsyncComPort,  &hSerial, &exit, &exitCond, &msg, bufLen);
			//d::thread wComT(AsyncWriteComPort, &hSerial, &exit, &exitCond);
			std::thread inputT(AsyncGetNum, &hSerial, &exit, &exitCond);
			while (exit != exitCond)
			{
				int wroteVal = WriteMidiComPort(&hSerial);
				if (wroteVal == 1)
				{
					//ReadComPortChars(&hSerial, &msg, bufLen);
					//ReadComPort(&hSerial);
				}
				
			}
			
			
			putc('\n', stdin);
			inputT.join();
			CloseMidiInput(&hdr, &midiHandle);
			
			CloseComPort(&hSerial);
			//rComT.join();
			//wComT.join();
			free(msg);
			break;
		}
		default:
			break;
		}

	}
	


	

	return 0;
}
