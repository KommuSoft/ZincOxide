#!/bin/bash

mono ../../lib/Gplex.exe MiniZinc.ll
mono ../../lib/gppg.exe MiniZinc.yy

mono ../../lib/Gplex.exe ZincOutput.ll
mono ../../lib/gppg.exe ZincOutput.yy
