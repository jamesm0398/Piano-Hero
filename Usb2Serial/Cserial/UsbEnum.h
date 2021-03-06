#pragma once
#include <libusb.h>
#include <iostream>
#include "Helper.h"
using namespace std;

static int GetDeviceWithVidAndPid(libusb_device **list, size_t count,int vid, int pid, libusb_device **ret)
{
	libusb_device *dev;
	for (size_t i = 0; i < count; i++)
	{
		dev = list[i];

		libusb_device_descriptor desc;
		int r = libusb_get_device_descriptor(dev, &desc);
		if (r < 0) {
			cout << "failed to get device descriptor" << endl;			
		}
		if (desc.idVendor == vid && desc.idProduct == pid )
		{
			*ret = dev;
			if (desc.bDeviceClass == LIBUSB_CLASS_PER_INTERFACE)
			{
				//Set_Interfa
			}
			return 1;
		}
	}
	return -1;
}

static void printdev(libusb_device *dev) {
	libusb_device_descriptor desc;
	int r = libusb_get_device_descriptor(dev, &desc);
	if (r < 0) {
		cout << "failed to get device descriptor" << endl;
		return;
	}
	cout << "Number of possible configurations: " << (int)desc.bNumConfigurations << "  ";
	cout << "Device Class: " << hex << (int)desc.bDeviceClass << "  ";
	cout << "VendorID: " << dec << desc.idVendor << "  ";
	cout << "ProductID: " << desc.idProduct << endl;
	libusb_config_descriptor *config;
	r = libusb_get_config_descriptor(dev, 0, &config);
	if (r != 0)
	{
		return;
	}
	cout << "Interfaces: " << (int)config->bNumInterfaces << " ||| ";
	const libusb_interface *inter;
	const libusb_interface_descriptor *interdesc;
	const libusb_endpoint_descriptor *epdesc;
	for (int i = 0; i < (int)config->bNumInterfaces; i++) {
		inter = &config->interface[i];
		cout << "Number of alternate settings: " << inter->num_altsetting << " | ";
		for (int j = 0; j < inter->num_altsetting; j++) {
			interdesc = &inter->altsetting[j];
			cout << "Interface Number: " << (int)interdesc->bInterfaceNumber << " | ";
			cout << "bInterfaceClass: " << (int)interdesc->bInterfaceClass << " | ";
			cout << "Number of endpoints: " << (int)interdesc->bNumEndpoints << " | ";
			for (int k = 0; k < (int)interdesc->bNumEndpoints; k++) {
				epdesc = &interdesc->endpoint[k];
				cout << "Descriptor Type: " << (int)epdesc->bDescriptorType << " | ";
				cout << "EP Address: " << (int)epdesc->bEndpointAddress << " | ";
			}
		}
	}
	cout << endl << endl << endl;
	libusb_free_config_descriptor(config);
}

static int UsbListAndInteract()
{
	libusb_device **devs; //pointer to pointer of device, used to retrieve a list of devices
	libusb_device_handle *dev_handle; //a device handle
	libusb_context *ctx = NULL; //a libusb session
	int r; //for return values
	ssize_t cnt; //holding number of devices in list
	r = libusb_init(&ctx); //initialize a library session
	if (r < 0) {
		cout << "Init Error " << r << endl; //there was an error
		return 1;
	}
	libusb_set_debug(ctx, 3); //set verbosity level to 3, as suggested in the documentation
	cnt = libusb_get_device_list(ctx, &devs); //get the list of devices
	if (cnt < 0) {
		cout << "Get Device Error" << endl; //there was an error
	}
	cout << cnt << " Devices in list." << endl; //print total number of usb devices
	ssize_t i; //for iterating through the list
	for (i = 0; i < cnt; i++) {
		printdev(devs[i]); //print specs of this device
	}
	int vid = 0;
	int pid = 0;
	printf("Enter VId\n");
	vid = getNum();

	printf("Enter PId\n");
	pid = getNum();
	libusb_device *ret = NULL;
	r = GetDeviceWithVidAndPid(devs, cnt, vid, pid, &ret);
	if (r == 1)
	{
		printf("Found device\n");
	}
	else
	{
		printf("Could not find device\n");
		return 1;
	}
	r = libusb_open(ret, &dev_handle);
	// dev_handle = libusb_open_device_with_vid_pid(ctx, (uint16_t)5824, (uint16_t)1155); //these are vendorID and productID I found for my usb device
	if (r < 0)
		cout << "Error " << r << "Cannot open device" << endl;
	else
		cout << "Device Opened" << endl;
	libusb_free_device_list(devs, 1); //free the list, unref the devices in it
	unsigned char *data = new unsigned char[4]; //data to write
	data[0] = 'a'; data[1] = 'b'; data[2] = 'c'; data[3] = 'd'; //some dummy values

	int actual; //used to find out how many bytes were written
	if (libusb_kernel_driver_active(dev_handle, 0) == 1) { //find out if kernel driver is attached
		cout << "Kernel Driver Active" << endl;
		if (libusb_detach_kernel_driver(dev_handle, 0) == 0) //detach it
			cout << "Kernel Driver Detached!" << endl;
	}
	r = libusb_claim_interface(dev_handle, 1); //claim interface 0 (the first) of device (mine had jsut 1)
	if (r < 0) {
		cout << "Cannot Claim Interface" << endl;
		return 1;
	}
	cout << "Claimed Interface" << endl;

	cout << "Data->" << data << "<-" << endl; //just to see the data we want to write : abcd
	cout << "Writing Data..." << endl;
	r = libusb_bulk_transfer(dev_handle, (2 | LIBUSB_ENDPOINT_OUT), data, 4, &actual, 0); //my device's out endpoint was 2, found with trial- the device had 2 endpoints: 2 and 129
	if (r == 0 && actual == 4) //we wrote the 4 bytes successfully
		cout << "Writing Successful!" << endl;
	else
		cout << "Write Error" << endl;

	r = libusb_release_interface(dev_handle, 0); //release the claimed interface
	if (r != 0) {
		cout << "Cannot Release Interface" << endl;
		return 1;
	}
	cout << "Released Interface" << endl;

	libusb_close(dev_handle); //close the device we opened
	libusb_exit(ctx); //needs to be called to end the

	delete[] data; //delete the allocated memory for data
	return 0;
}