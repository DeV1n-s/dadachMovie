@echo off
set rootDir=%cd%
set VueDir=%rootDir%\ClientApp
cd %VueDir%
call npm install
call npm run build
cd %rootDir%
call dotnet run
pause