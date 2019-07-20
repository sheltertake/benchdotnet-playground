0) remove paging/restart pc/stop antivirus/docker desktop

1) measure cpu 
	CpuStress.exe 10k 9k 7/8
	RAM 
		2.8 occupata
		5 disponibile

2) dotmemory Api
http://localhost:5000/api/value/V/10
http://localhost:5000/api/value/V/10
http://localhost:5000/api/value/V/10
GC sometimes trigger

http://localhost:5000/api/value/V/2000
http://localhost:5000/api/value/V/2000
http://localhost:5000/api/value/V/2000
GC automatic trigger - from 4 to 2

FGC -> 0
--

http://localhost:5000/api/value/S/100
FGC 100
http://localhost:5000/api/value/S/200
300
http://localhost:5000/api/value/S/2000
2.2 -> FGC -> 2? -> yes
--
http://localhost:5000/api/value/V/10
http://localhost:5000/api/value/V/20
http://localhost:5000/api/value/V/40
GC seems almost always
FGC -> 2
--
Dic -> disponibile 4.2
http://localhost:5000/api/value/D/1/500
http://localhost:5000/api/value/D/2/1000
3.4 -> disponibile 4.2? !!!
http://localhost:5000/api/value/D/3/1000
System.OutOfMemoryException: Exception of type 'System.OutOfMemoryException' was thrown.
FGC
http://localhost:5000/api/value/D/3/1000
System.OutOfMemoryException: Exception of type 'System.OutOfMemoryException' was thrown.
http://localhost:5000/api/value/D/3/500
4GB
---
