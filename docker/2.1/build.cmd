@echo off

docker build -t minplaintext:2.1 -f %~dp0/Dockerfile %~dp0/../.. %*
