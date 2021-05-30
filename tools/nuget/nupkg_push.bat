@@ECHO OFF
SET NUPKG_FILE=%1
IF "%NUPKG_FILE%"=="" GOTO NO_NUPKG_FILE

SET API_KEY=E4FC0A58-F5B6-4D8A-8CD2-6A09BC1270CD
SET REPO_URL=http://nuget.travelline.lan

SET NUGET=NuGet.exe

REM %NUGET% SetApiKey %API_KEY -s %REPO_URL%

REM TODO: добавить проверку на уже существующий пакет с таким именем и версией
%NUGET% push %NUPKG_FILE% %API_KEY% -src %REPO_URL%
EXIT 0

:NO_NUPKG_FILE
ECHO Usage:
ECHO nupkg_push.bat packed_library.nupkg
EXIT 1