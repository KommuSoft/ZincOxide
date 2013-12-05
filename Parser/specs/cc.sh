#!/bin/bash

shopt -s expand_aliases
source ~/.bashrc

mono ../../lib/Gplex.exe MiniZinc.ll
mono ../../lib/gppg.exe MiniZinc.yy
