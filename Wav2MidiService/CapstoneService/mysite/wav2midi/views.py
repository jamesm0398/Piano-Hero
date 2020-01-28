from rest_framework.views import APIView
from rest_framework.parsers import MultiPartParser, FormParser
from django.core.files.storage import FileSystemStorage
from django.http import HttpResponse
from rest_framework.response import Response
from rest_framework import status
import subprocess, os
import wav2midi

from .serializers import FileSerializer

class FileView(APIView):

	parser_classes = (MultiPartParser, FormParser)
	
	def post(self, request, *args, **kwargs):
	
		file_serializer = FileSerializer(data=request.data)
		print(request.data)
		if file_serializer.is_valid():
			myfile = request.FILES['file']
			fs = FileSystemStorage()
			filename = fs.save(myfile.name, myfile)
			#file_serializer.save()
			p1 = subprocess.Popen(["onsets_frames_transcription_transcribe", "--model_dir=\"D:\\env\\train\\checkpoint\"", os.path.dirname(wav2midi.__file__)+"\\..\\media\\"+filename],stdout=subprocess.PIPE) 
			p1.communicate()
			file_path = os.path.dirname(wav2midi.__file__)+"\\..\\media\\"+filename+".midi"
			FilePointer = open(file_path, 'rb')
			response = HttpResponse(FilePointer)
			response['Content-Disposition'] = "attachment; filename="+filename+".midi"
			return response
			#return Response(response, status=status.HTTP_201_CREATED)
		else:
			return Response(file_serializer.errors, status=status.HTTP_400_BAD_REQUEST)