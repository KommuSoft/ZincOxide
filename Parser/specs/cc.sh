#!/bin/bash

shopt -s expand_aliases
source ~/.bashrc

mono /home/kommusoft/Libraries/gppg-distro-1.5.0/binaries/Gplex.exe MiniZinc.ll
mono /home/kommusoft/Libraries/gppg-distro-1.5.0/binaries/gppg.exe MiniZinc.yy
