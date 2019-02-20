echo ON
setlocal EnableDelayedExpansion

for /f "tokens=1-3 delims=/ " %%i in ("%date%") do (
     set day=%%i
     set month=%%j
     set year=%%k
)

for /f "tokens=1-3 delims=: " %%i in ("%time%") do (
     set hours=%%i
     set minutes=%%j
     set seconds=%%k
)

set fileName = Process_list.txt 
set batCurrentPath = %cd%
set executionDate = execution time: [%day%\%month%\%year%]

IF NOT EXIST %cd%\Process_list.txt ( echo. 2> Process_list.txt )
	 
tasklist >  %cd%\Process_list.txt
echo execution time: [%day%\%month%\%year% %hours%:%minutes%:%seconds%] >> %cd%\Process_list.txt 


