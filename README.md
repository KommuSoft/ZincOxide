ZincOxide
=========
A hyperheuristic generator based on a problem class specification written in MiniZinc.

More information about the current state of the project can be found on http://willemvanonsem.ulyssis.be/zincoxide

Structure
=========
The package consist out of two main parts: **ZincOxide** and **ZincSulphate**. **ZincOxide** is the actual program
while **ZincSulphate** is a set of test and testdata.

Install
=======
One can install the program by performing a recursive clone:

```
git clone --recursive https://github.com/KommuSoft/ZincOxide.git
```

One can use the configure and Makefile to compile the software:
```
cd ZincOxide
./configure
make
```

To increase portability, the source code of the software that is used to compile the program is compiled as well.
