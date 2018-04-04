@echo off

docker build -t minplaintext:2.0 -f %~dp0/Dockerfile %~dp0/../.. %*
