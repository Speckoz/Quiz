@echo off
title Api

color 5

echo ======================  INICIANDO API  ========================
echo ======================  FAZENDO BUILD  ========================
dotnet build

::echo ======================  RODANDO TESTES  ========================
::cd ..
::cd Quiz.API.Tests
::dotnet test

echo ======================  RODANDO API  ========================
cd ..
cd Quiz.API
dotnet run
pause
