@echo off

docker build -t minplaintext -f %~dp0/Dockerfile %~dp0/.. %*
