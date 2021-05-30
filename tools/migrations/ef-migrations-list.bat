@ECHO OFF

cd ..\..\src\Infrastructure.Migrations
dotnet ef migrations list || goto handle_error
exit /B 0

GOTO handle_error

:handle_error
EXIT /B %ERRORLEVEL%