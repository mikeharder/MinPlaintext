#!/usr/bin/env bash

docker build -t arm32v7/min-plaintext -f `dirname $0`/Dockerfile `dirname $0`/../../ "$@"
