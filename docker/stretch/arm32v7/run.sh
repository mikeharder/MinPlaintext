#!/usr/bin/env bash

docker run -it --rm --network host arm32v7/min-plaintext "$@"
