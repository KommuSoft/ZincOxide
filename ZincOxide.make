

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=.

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
ASSEMBLY = bin/Debug/ZincOxide.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

ZINCOXIDE_EXE_MDB_SOURCE=bin/Debug/ZincOxide.exe.mdb
ZINCOXIDE_EXE_MDB=$(BUILD_DIR)/ZincOxide.exe.mdb
QUT_SHIFTREDUCEPARSER_DLL_SOURCE=lib/QUT.ShiftReduceParser.dll
MONO_OPTIONS_DLL_SOURCE=lib/Mono.Options.dll

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/ZincOxide.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

ZINCOXIDE_EXE_MDB=
QUT_SHIFTREDUCEPARSER_DLL_SOURCE=lib/QUT.ShiftReduceParser.dll
MONO_OPTIONS_DLL_SOURCE=lib/Mono.Options.dll

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(ZINCOXIDE_EXE_MDB) \
	$(QUT_SHIFTREDUCEPARSER_DLL) \
	$(MONO_OPTIONS_DLL)  

BINARIES = \
	$(ZINCOXIDE)  


RESGEN=resgen2

QUT_SHIFTREDUCEPARSER_DLL = $(BUILD_DIR)/QUT.ShiftReduceParser.dll
MONO_OPTIONS_DLL = $(BUILD_DIR)/Mono.Options.dll
ZINCOXIDE = $(BUILD_DIR)/zincoxide

FILES = \
	Algebra/AcasBinaryOperatorFlags.cs \
	Algebra/AcasConstant.cs \
	Algebra/AcasExpressionBase.cs \
	Algebra/AcasFunction.cs \
	Algebra/AcasFunctionInstance.cs \
	Algebra/AcasGenericFunction.cs \
	Algebra/AcasIExpression.cs \
	Algebra/AcasOperator.cs \
	Algebra/AcasType.cs \
	Algebra/AcasVariable.cs \
	MiniZinc/ZincPrintUtils.cs \
	Codegen/ICodeClass.cs \
	Codegen/ICodeMethod.cs \
	Codegen/OuputFile.cs \
	Codegen/ICodeInterface.cs \
	Codegen/ICodeBuilder.cs \
	Codegen/ICodePackage.cs \
	Codegen/ICodeFile.cs \
	ZincOxideException.cs \
	Codegen/ZincOxideCodeGenException.cs \
	MiniZinc/ZincOxideMiniZincException.cs \
	Parser/MiniZincParser.cs \
	ProgramResult.cs \
	MiniZinc/Boxes/IZincAsBox.cs \
	MiniZinc/Boxes/IZincExBox.cs \
	MiniZinc/Boxes/IZincIdBox.cs \
	MiniZinc/Boxes/IZincTiaBox.cs \
	MiniZinc/Boxes/IZincAsExTiaBox.cs \
	MiniZinc/Boxes/IZincExIdBox.cs \
	MiniZinc/Boxes/IZincTieBox.cs \
	MiniZinc/Boxes/ZincExBoxBase.cs \
	MiniZinc/Boxes/ZincIdBoxBase.cs \
	MiniZinc/Boxes/ZincExIdBoxBase.cs \
	MiniZinc/Boxes/ZincAsExTiaBoxBase.cs \
	MiniZinc/Boxes/ZincTieBoxBase.cs \
	MiniZinc/Boxes/ZincAsBoxBase.cs \
	MiniZinc/Boxes/IZincIdTieBox.cs \
	MiniZinc/Boxes/ZincIdTieBoxBase.cs \
	Utils/ContextStreamWriter.cs \
	Utils/ContextWriteableUtils.cs \
	Utils/EnumerableUtils.cs \
	Utils/GenerateNameRegister.cs \
	Utils/HeadTail.cs \
	Utils/IContextWriteable.cs \
	Utils/IGenerateNameRegister.cs \
	Utils/IName.cs \
	Utils/INameRegister.cs \
	Utils/IReadable.cs \
	Utils/IReadWriteable.cs \
	Utils/IScope.cs \
	Utils/IValidateable.cs \
	Utils/IWriteable.cs \
	Utils/NameBase.cs \
	Utils/NameRegister.cs \
	Utils/ReadWriteableUtils.cs \
	Codegen/Java/CodeBuilderJava.cs \
	Codegen/Java/CodeClassJava.cs \
	Codegen/Java/CodeInterfaceJava.cs \
	Codegen/Java/CodePackageJava.cs \
	Codegen/Java/JavaUtils.cs \
	Codegen/Base/CodeBuilderBase.cs \
	Codegen/Base/CodeClassBase.cs \
	Codegen/Base/CodeFileBase.cs \
	Codegen/Base/CodeInterfaceBase.cs \
	Codegen/Base/CodePackageBase.cs \
	Codegen/Base/ContextWriteableCodeFile.cs \
	Program.cs \
	MiniZinc/Boxes/ZincTieTiesBoxBase.cs \
	MiniZinc/Boxes/IZincTieTiesBox.cs \
	MiniZinc/Boxes/IZincTiesBox.cs \
	MiniZinc/Boxes/IZincNumBox.cs \
	MiniZinc/Boxes/IZincNumNumBox.cs \
	MiniZinc/Boxes/ZincNumBoxBase.cs \
	MiniZinc/Boxes/ZincNumNumBoxBase.cs \
	Parser/MiniZincLexer.cs \
	Parser/ZincOxideParserException.cs \
	Parser/ParserHelper.cs \
	Codegen/CSharp/CodeBuilderCSharp.cs \
	Codegen/CSharp/CodeClassCSharp.cs \
	Codegen/CSharp/CodeInterfaceCSharp.cs \
	Codegen/CSharp/CodePackageCSharp.cs \
	Codegen/CSharp/CSharpUtils.cs \
	Utils/ISoftValidateable.cs \
	Utils/IMessageBoard.cs \
	Utils/ZincOxideNameNotFoundException.cs \
	Utils/DNameRegisterFallback.cs \
	Utils/IFallbackNameRegister.cs \
	Utils/FallbackNameRegister.cs \
	Utils/IGenerateFallbackNameRegister.cs \
	Utils/GenerateFallbackNameRegister.cs \
	Parser/LexSpan.cs \
	Normalization/PullupVarDeclTransformation.cs \
	Normalization/ReordenDeclarationTransformation.cs \
	Normalization/ITransformation.cs \
	MiniZinc/Boxes/IZincAsExBox.cs \
	MiniZinc/Boxes/ZincAsExBoxBase.cs \
	MiniZinc/Items/IZincItem.cs \
	MiniZinc/Items/ZincAnnotationItem.cs \
	MiniZinc/Items/ZincAssignItem.cs \
	MiniZinc/Items/ZincConstraintItem.cs \
	MiniZinc/Items/ZincIncludeItem.cs \
	MiniZinc/Items/ZincOutputItem.cs \
	MiniZinc/Items/ZincSolveItem.cs \
	MiniZinc/Items/ZincVarDeclItem.cs \
	MiniZinc/Items/IZincFile.cs \
	MiniZinc/Items/ZincData.cs \
	MiniZinc/Items/ZincModel.cs \
	MiniZinc/Structures/IZincExp.cs \
	MiniZinc/Structures/IZincIdentContainer.cs \
	MiniZinc/Structures/IZincIdentReplaceContainer.cs \
	MiniZinc/Structures/IZincIdentScope.cs \
	MiniZinc/Structures/IZincNumExp.cs \
	MiniZinc/Structures/IZincType.cs \
	MiniZinc/Structures/IZincTypeInstExpression.cs \
	MiniZinc/Structures/ZincAnnotation.cs \
	MiniZinc/Structures/ZincAnnotations.cs \
	MiniZinc/Structures/ZincBoolLiteral.cs \
	MiniZinc/Structures/ZincFloatLiteral.cs \
	MiniZinc/Structures/ZincIdent.cs \
	MiniZinc/Structures/ZincIdentNameRegister.cs \
	MiniZinc/Structures/ZincIntLiteral.cs \
	MiniZinc/Structures/ZincScalar.cs \
	MiniZinc/Structures/ZincScalarType.cs \
	MiniZinc/Structures/ZincSolveType.cs \
	MiniZinc/Structures/ZincTypeInstArrayExpression.cs \
	MiniZinc/Structures/ZincTypeInstBaseExpression.cs \
	MiniZinc/Structures/ZincTypeInstExprAndIdent.cs \
	MiniZinc/Structures/ZincTypeInstExpressionIdent.cs \
	MiniZinc/Structures/ZincTypeInstRangeExpression.cs \
	MiniZinc/Structures/ZincTypeInstWhereExpression.cs \
	MiniZinc/Structures/ZincVarPar.cs \
	MiniZinc/Structures/ZincCompound.cs \
	Utils/IId.cs \
	Utils/IdBase.cs \
	Utils/INameId.cs \
	Utils/NameIdBase.cs \
	MiniZinc/Types/ZincFundamentalType.cs \
	MiniZinc/Types/IZincFundamentalType.cs \
	MiniZinc/Types/IZincTypeTransformation.cs \
	MiniZinc/Types/ZincVarification.cs \
	MiniZinc/Types/ZincCoercion.cs \
	Utils/ValidateableUtils.cs \
	MiniZinc/Structures/ZincIdentUsage.cs \
	MiniZinc/Structures/ZincTypeInstSetExpression.cs \
	MiniZinc/Items/ZincPredicateItem.cs \
	MiniZinc/Items/ZincItemType.cs \
	MiniZinc/Items/ZincFileBase.cs \
	MiniZinc/Structures/ZincIdentScopeBase.cs \
	MiniZinc/Boxes/IZincAsExIdTiasBox.cs \
	MiniZinc/Boxes/IZincTiasBox.cs \
	MiniZinc/Items/IZincRelation.cs \
	MiniZinc/Boxes/IZincAsExIdTieTiasBox.cs \
	MiniZinc/Boxes/ZincAsExIdTieTiasBoxBase.cs \
	MiniZinc/Boxes/ZincAsExIdTiasBoxBase.cs \
	MiniZinc/Items/ZincFunctionItem.cs \
	Normalization/PredicateToFunctionTransformation.cs \
	Utils/IArity.cs \
	MiniZinc/Structures/ZincTypeInstTupleExpression.cs \
	MiniZinc/Boxes/ZincTiesBoxBase.cs \
	Utils/IComposition.cs \
	MiniZinc/IZincElement.cs \
	MiniZinc/Boxes/IZincBox.cs \
	Utils/IInnerSoftValidateable.cs \
	MiniZinc/Boxes/ZincBoxBase.cs \
	MiniZinc/Structures/ZincNumExpLiteralBase.cs \
	MiniZinc/Boxes/IZincTyBox.cs \
	MiniZinc/Boxes/ZincTyBoxBase.cs \
	Utils/IFinite.cs \
	Codegen/ICodeProperty.cs \
	Codegen/CodePropertyAccess.cs \
	Codegen/ICodeMixin.cs \
	Codegen/Base/CodePropertyBase.cs \
	Codegen/Java/CodePropertyJava.cs \
	Codegen/CSharp/CodePropertyCSharp.cs \
	Utils/IDimensions.cs \
	MiniZinc/Builtins/ZincBuiltinRelationAttribute.cs \
	MiniZinc/Builtins/ZincBuiltinRelationRegister.cs \
	MiniZinc/Structures/IZincRelation.cs \
	MiniZinc/Structures/ZincRelationBase.cs \
	MiniZinc/Structures/ZincRelationRegister.cs \
	Environment/ProgramEnvironment.cs \
	Environment/ProgramTask.cs \
	Environment/programVerbosity.cs \
	Environment/Interaction.cs \
	Parser/ScanBase.cs \
	Codegen/HigherOrder/ProblemFileGenerator.cs \
	Codegen/HigherOrder/SolutionFileGenerator.cs \
	Codegen/HigherOrder/IFileGenerator.cs \
	MiniZinc/Types/Fundamental/ZincTFScalar.cs \
	MiniZinc/Types/Fundamental/ZincTFSet.cs \
	MiniZinc/Types/Fundamental/IZincTF.cs \
	Utils/IGenericEquals.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	Manpage.txt \
	Samples/jobshop.mzn \
	Samples/jobshop2x2.data \
	Parser/specs/MiniZinc.ll \
	Parser/specs/MiniZinc.yy \
	Parser/specs/cc.sh \
	Codegen \
	Algebra \
	MiniZinc \
	Parser \
	Samples \
	MiniZinc/Boxes \
	Utils \
	Codegen/Java \
	Codegen/Base \
	Codegen/CSharp \
	Transformation \
	Heuristics \
	Normalization \
	Parser/specs \
	MiniZinc/Builtins \
	MiniZinc/Items \
	MiniZinc/Structures \
	Codegen/HigherOrder \
	MiniZinc/Types \
	Complexity \
	Environment \
	AbstractGraph \
	zincoxide.in 

REFERENCES =  \
	System \
	System.Core \
	System.Data \
	-pkg:nunit

DLL_REFERENCES =  \
	lib/QUT.ShiftReduceParser.dll \
	lib/Mono.Options.dll

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

#Targets
all-local: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES)  $(top_srcdir)/config.make



$(eval $(call emit-deploy-target,QUT_SHIFTREDUCEPARSER_DLL))
$(eval $(call emit-deploy-target,MONO_OPTIONS_DLL))
$(eval $(call emit-deploy-wrapper,ZINCOXIDE,zincoxide,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

# Targets for Custom commands
DEBUG|X86_BeforeBuild:
	(cd Parser/specs/ && bash cc.sh)

RELEASE|X86_BeforeBuild:
	(cd Parser/specs/ && bash cc.sh)


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
	$(call cp,$(ZINCOXIDE_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(QUT_SHIFTREDUCEPARSER_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(MONO_OPTIONS_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(bindir)'
	$(call cp,$(ZINCOXIDE),$(DESTDIR)$(bindir))
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ZINCOXIDE_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(QUT_SHIFTREDUCEPARSER_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(MONO_OPTIONS_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ZINCOXIDE),$(DESTDIR)$(bindir))
	make post-uninstall-local-hook prefix=$(prefix)
