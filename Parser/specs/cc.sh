#!/bin/bash

mono ../../lib/Gplex.exe MiniZinc.ll
mono ../../lib/gppg.exe /gplex MiniZinc.yy
