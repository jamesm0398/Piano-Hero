#include "Serial.h"

#include "MIDI.h"
//#include "UsbEnum.h"
#include <thread>
#include <future>

#define DEBUG 0

/*static void print_devs(libusb_device **devs)
{
	libusb_device *dev;
	int i = 0, j = 0;
	uint8_t path[8];
	printf("------------------------------------------------\n");
	while ((dev = devs[i++]) != NULL) {
		struct libusb_device_descriptor desc;
		int r = libusb_get_device_descriptor(dev, &desc);
		if (r < 0) {
			fprintf(stderr, "failed to get device descriptor");
			return;
		}
		
		printf("%d VId %04x:PId %04x (bus num %d, device addr %d) class: %04x, subClass: %04x",
			i, desc.idVendor, desc.idProduct,
			libusb_get_bus_number(dev), libusb_get_device_address(dev), desc.bDeviceClass, desc.bDeviceSubClass);
		

		r = libusb_get_port_numbers(dev, path, sizeof(path));
		if (r > 0) {
			printf(" path: %d", path[0]);
			for (j = 1; j < r; j++)
				printf(".%d", path[j]);
		}
		printf("\n");
	}
}

int main(void)
*/

int main(int argc, char* argv[])
{
	int done = 0;
	MIDIHDR hdr;
	HMIDIIN midiHandle;
	HANDLE hSerial;
	bool useStdin = false;

	int func = -1;
	int port = -1;

	if (argc == 3)
	{
		func = atoi(argv[1]);
		port = atoi(argv[2]);
	}
	else {
		useStdin = true;
	}
	
	
	while (!done)
	{
		printf("exit : 0, ComPort : 1, Usb : 2, Midi : 3, Midi 2 Com : 4\n");
		
		if (useStdin)
		{
			func = getNum();
		}

		switch (func)
		{
		case 0:
			done = 1;
			break;
		case 1:
			ComPort(&hSerial, port);
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
			if (useStdin)
			{
				printf("Enter port number: ");
				port = getNum();
			}
			ComPort(&hSerial, port);
			findMidiInput(&hdr,&midiHandle);
#if DEBUG == 0
			if (ConditionalRestComPort(&hSerial,"SD fail\r\n" ))
			{
				CloseMidiInput(&hdr, &midiHandle);
				CloseComPort(&hSerial);
				printf("Rest comPort and MIdi\n");
				break;
			}
#endif
			int bufLen = 7000;
			char* msg = (char*)calloc(bufLen, sizeof(char));
			/*while (!ReadComPortChars(&hSerial, &msg, bufLen))
			{}
			while (!ReadComPortChars(&hSerial, &msg, bufLen))
			{
			}*/
			ResetRingBuff();
			
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

			if (!useStdin)
			{
				done = true;
			}
			break;
		}
		default:
			break;
		}

	}
	


	

	return 0;
}
