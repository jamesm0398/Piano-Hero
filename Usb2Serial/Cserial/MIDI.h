#pragma once

#include <conio.h>     /* include for kbhit() and getch() functions https://cpp.hotexamples.com/site/file?hash=0x73f2670a723a3b40616dd30ad6c0bc483c05eb024315d5b7c51e8407df959287&fullName=wine-master/dlls/winmm/midi.c&project=thomcom/wine*/
#include <stdio.h>     /* for printf() function */
#include <stddef.h>
#include <windows.h>   /* required before including mmsystem.h */
#include <mmsystem.h>  /* multimedia functions (such as MIDI) for Windows */
#include "Helper.h"

#define MYCBINST 0x4CAFE5A8 /* not used with window or thread callbacks */
#define WHATEVER 0xFEEDF00D

static UINT      cbmsg = 0;
static DWORD_PTR cbval1 = WHATEVER;
static DWORD_PTR cbval2 = 0;
static DWORD_PTR cbinst = MYCBINST;



static void CALLBACK callback_func(HWAVEOUT hwo, UINT uMsg,
	DWORD_PTR dwInstance,
	DWORD_PTR dwParam1, DWORD_PTR dwParam2)
{
	MidiMsg msg = { 0 };
	msg.channel = dwParam1 & 0xff;
	msg.key = (dwParam1 >> 8) & 0xff;
	msg.vel = (dwParam1 >> 16) & 0xff;
	WriteRingBuff(&msg);
	
	printf("Callback! msg=%d %d %d\n", msg.channel, msg.key, msg.vel);
	cbmsg = uMsg;
	cbval1 = dwParam1;   /* mhdr or 0 */
	cbval2 = dwParam2;   /* always 0 */
	cbinst = dwInstance; /* MYCBINST, see midiOut/StreamOpen */
}

static int findMidiInput(MIDIHDR* hdr, HMIDIIN* handle)
{
	UINT numMidi = midiInGetNumDevs();
	printf("number of midi devices : %d\n", numMidi);

	//HMIDIIN handle = 0;
	//LPHMIDIIN ptrhandle = NULL;
	//*ptrhandle = handle;

	MMRESULT r = midiInOpen(handle, numMidi-1, (DWORD_PTR)callback_func, (DWORD_PTR)MYCBINST, CALLBACK_FUNCTION);
	
	if (MMSYSERR_NOERROR != r) {
		printf("error opening midi in, closing midi in\n");
		r = midiInClose(*handle);
		if (MMSYSERR_NOERROR != r) {
			printf("error closing midi in\n");
		}
	}
	MIDIINCAPSA capsA;
	midiInGetDevCapsA(numMidi-1, &capsA, sizeof(capsA));
	printf("Name : %s, manufacturer=%d, product=%d, support=%X\n", capsA.szPname, capsA.wMid, capsA.wPid, capsA.dwSupport);

	int len = 7000;
	hdr->lpData = (LPSTR)calloc(len, sizeof(CHAR));
	hdr->dwBufferLength = len;
	hdr->dwFlags = MHDR_DONE;
	hdr->dwUser = 0x56FA552C;
	hdr->dwBytesRecorded = 5;
	midiInPrepareHeader(*handle, hdr, sizeof(*hdr));
	midiInAddBuffer(*handle, hdr, sizeof(*hdr));
	midiInStart(*handle);

	return 1;
}

static void CloseMidiInput(MIDIHDR* hdr, HMIDIIN* handle)
{
	MMRESULT r = 0;
	
	r = midiInReset(*handle);
	if (MMSYSERR_NOERROR != r) {
		printf("error midiInReset failed: %d\n", r);
	}
	r = midiInUnprepareHeader(*handle, hdr, sizeof(*hdr));
	if (MMSYSERR_NOERROR != r) {
		printf("error midiInUnprepareHeader failed: %d\n",r);
	}
	r = midiInClose(*handle);
	if (MMSYSERR_NOERROR != r) {
		printf("error closing midi in: %d\n", r);
	}
}