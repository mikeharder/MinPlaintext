@echo off

docker build -t min-plaintext -f %~dp0/Dockerfile %~dp0/../../.. %*
