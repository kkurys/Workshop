@echo off
cls

if exist node_modules echo [..................] / remove: node_modules
if exist node_modules rmdir node_modules /s /q
cls

call npm install
call npm install node-sass
call npm install @angular/cli
call ng build

call ng version