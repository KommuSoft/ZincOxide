
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
ASSEMBLY = bin/Debug/ZincSulphate.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../bin/Debug/ZincOxide.exe
BUILD_DIR = bin/Debug

ZINCSULPHATE_DLL_MDB_SOURCE=bin/Debug/ZincSulphate.dll.mdb
ZINCSULPHATE_DLL_MDB=$(BUILD_DIR)/ZincSulphate.dll.mdb
ZINCOXIDE_EXE_SOURCE=../bin/Debug/ZincOxide.exe
ZINCOXIDE_EXE_MDB_SOURCE=../bin/Debug/ZincOxide.exe.mdb
QUT_SHIFTREDUCEPARSER_DLL_SOURCE=../lib/QUT.ShiftReduceParser.dll
MONO_OPTIONS_DLL_SOURCE=../lib/Mono.Options.dll
HASKELLLIBRARIES_DLL_SOURCE=../mono-utils/bin/Debug/HaskellLibraries.dll
HASKELLLIBRARIES_DLL_MDB_SOURCE=../mono-utils/bin/Debug/HaskellLibraries.dll.mdb
HASKELLLIBRARIES_DLL_MDB=$(BUILD_DIR)/HaskellLibraries.dll.mdb
FSHARP_POWERPACK_DLL_SOURCE=../mono-utils/lib/FSharp.PowerPack.dll

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/ZincSulphate.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../bin/Release/ZincOxide.exe
BUILD_DIR = bin/Release

ZINCSULPHATE_DLL_MDB=
ZINCOXIDE_EXE_SOURCE=../bin/Debug/ZincOxide.exe
ZINCOXIDE_EXE_MDB_SOURCE=../bin/Debug/ZincOxide.exe.mdb
QUT_SHIFTREDUCEPARSER_DLL_SOURCE=../lib/QUT.ShiftReduceParser.dll
MONO_OPTIONS_DLL_SOURCE=../lib/Mono.Options.dll
HASKELLLIBRARIES_DLL_SOURCE=../mono-utils/bin/Release/HaskellLibraries.dll
HASKELLLIBRARIES_DLL_MDB=
FSHARP_POWERPACK_DLL_SOURCE=../mono-utils/lib/FSharp.PowerPack.dll

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(ZINCSULPHATE_DLL_MDB) \
	$(ZINCOXIDE_EXE) \
	$(ZINCOXIDE_EXE_MDB) \
	$(QUT_SHIFTREDUCEPARSER_DLL) \
	$(MONO_OPTIONS_DLL) \
	$(HASKELLLIBRARIES_DLL) \
	$(HASKELLLIBRARIES_DLL_MDB) \
	$(FSHARP_POWERPACK_DLL)  

LINUX_PKGCONFIG = \
	$(ZINCSULPHATE_PC)  


RESGEN=resgen2

ZINCOXIDE_EXE = $(BUILD_DIR)/ZincOxide.exe
ZINCOXIDE_EXE_MDB = $(BUILD_DIR)/ZincOxide.exe.mdb
QUT_SHIFTREDUCEPARSER_DLL = $(BUILD_DIR)/QUT.ShiftReduceParser.dll
MONO_OPTIONS_DLL = $(BUILD_DIR)/Mono.Options.dll
HASKELLLIBRARIES_DLL = $(BUILD_DIR)/HaskellLibraries.dll
FSHARP_POWERPACK_DLL = $(BUILD_DIR)/FSharp.PowerPack.dll
ZINCSULPHATE_PC = $(BUILD_DIR)/zincsulphate.pc

FILES = \
	FundamentalTypeTest.cs \
	Codegen/CSharp/CSharpCodeGenTest.cs \
	Codegen/Java/JavaCodeGenTest.cs \
	MiniZinc/Items/ZincModelTest.cs \
	Parser/MiniZincLexerTest.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	zincsulphate.pc.in 

REFERENCES =  \
	System \
	-pkg:nunit

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



$(eval $(call emit-deploy-target,ZINCOXIDE_EXE))
$(eval $(call emit-deploy-target,ZINCOXIDE_EXE_MDB))
$(eval $(call emit-deploy-target,QUT_SHIFTREDUCEPARSER_DLL))
$(eval $(call emit-deploy-target,MONO_OPTIONS_DLL))
$(eval $(call emit-deploy-target,HASKELLLIBRARIES_DLL))
$(eval $(call emit-deploy-target,HASKELLLIBRARIES_DLL_MDB))
$(eval $(call emit-deploy-target,FSHARP_POWERPACK_DLL))
$(eval $(call emit-deploy-wrapper,ZINCSULPHATE_PC,zincsulphate.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'


$(ASSEMBLY_MDB): $(ASSEMBLY)
$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ZINCSULPHATE_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ZINCOXIDE_EXE),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ZINCOXIDE_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(QUT_SHIFTREDUCEPARSER_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(MONO_OPTIONS_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(HASKELLLIBRARIES_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(HASKELLLIBRARIES_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(FSHARP_POWERPACK_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(libdir)/pkgconfig'
	$(call cp,$(ZINCSULPHATE_PC),$(DESTDIR)$(libdir)/pkgconfig)
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ZINCSULPHATE_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ZINCOXIDE_EXE),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ZINCOXIDE_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(QUT_SHIFTREDUCEPARSER_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(MONO_OPTIONS_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(HASKELLLIBRARIES_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(HASKELLLIBRARIES_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(FSHARP_POWERPACK_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ZINCSULPHATE_PC),$(DESTDIR)$(libdir)/pkgconfig)
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
