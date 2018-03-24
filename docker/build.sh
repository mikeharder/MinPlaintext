#!/usr/bin/env bash

docker build -t minplaintext -f `dirname $0`/Dockerfile `dirname $0`/.. "$@"
