/*
 *  This specification is for a version of the RealCalc example.
 *  This version creates a abstract syntax tree from the input,
 *  and demonstrates how to use a reference type as the semantic
 *  value type.
 *
 *  The parser class is declared %partial, so that the bulk of
 *  the code can be placed in the separate file RealTreeHelper.cs
 *
 *  Process with > gppg /nolines RealTree.y
 */

%namespace ZincOxide.MiniZinc
%output=MiniZincParser.cs 
%partial 
%sharetokens
%start model

/*
 * The accessibility of the Parser object must not exceed that
 * of the inherited ShiftReduceParser<,>. Thus if you want to include 
 * the *source* of ShiftReduceParser from ShiftReduceParserCode.cs, 
 * then you must either set the compilation flag EXPORT_GPPG or  
 * override the default, public visibility with %visibility internal.
 * If you reference the pre-compiled QUT.ShiftReduceParser.dll then 
 * ShiftReduceParser<> is public and either visibility will work.
 */

%visibility internal

%YYSTYPE RealTree.Node

%token KWTYPE KWENUM KWINCL KWCONS KWSOLV KWSATI KWMINI MWMAXI KWOUTP KWANNO KWPRED KWTEST KWFUNC KWWHER KWVAR KWPAR KWBOOL KWINT KWFLOA KWSTRI KWANN KWSET KWOF KWARRA KWLIST KWTUPL KWRECO KWANY KWOP KWIN KWSUBS KWSUPE KWUNIO KWDIFF KWSYMD KWINTE KWNOT KWDIV KWMOD KWFALS KWTRUE KWIF KWTHEN KWELSI KWELSE KWENDI KWCASE KWLET COMMAD COMMA COLON ACCENT BAR OACC CACC OBRK CBRK OFBR CFBR OFBA CFBA OPASSIG OPUNDSC OPEQUIV OPIMPLI OPRIMPL OPVEE OPWEDGE OPLESTA OPGRETA OPLESEQ OPGEAEQ OPEQUAL OPNEQUA OPRANGE OPINCRE OPANNOT OPADD OPSUB OPMUL OPDIV OPCASE BOOLI INTLI FLOLI STRLI IDENT NOISE EOL COMMENT EOF

%%

model
	:	EOF					 							{} /*empty */
	|	item itemList EOF								{}
	;

itemList
	:													{}
	| COMMAD											{}
	| item COMMAD modelTail								{}
	;

item
	: typeInstSynItem									{}
	| enumItem											{}
	| includeItem										{}
	| varDelcItem										{}
	| assignItem										{}
	| constraintItem									{}
	| solveItem											{}
	| outputItem										{}
	| predicateItem										{}
	| testItem											{}
	| functionItem										{}
	| annotationItem									{}
	;

typeInstSynItem
	: KWTYPE IDENT annotations OPASSIGN tiExpr			{}
	;

enumItem
	: KWENUM IDENT annotations							{}
	| KWENUM IDENT annotations OPASSIGN enumCases		{}
	;

enumCases
	: OACC CACC											{}
	| OACC enumCase enumCaseTail CACC					{}
	;

enumCasesTail
	:													{}
	| COMMA												{}
	| COMMA enumCase enumCasesTail						{}
	;

enumCase
	: IDENT												{}
	| IDENT OBRK tiExprAndId tiExprAndIdList CBRK		{}
	;

tiExprAndIdList
	: 													{}
	| COMMA												{}
	| COMMA tiExprAndId COMMA tiExprAndIdList			{}
	;

tiExprAndId
	: tiExpr COLON IDENT								{}
	;

includeItem
	: KWINCL STRLI										{}
	;

varDeclItem
	: tiExprAndId annotations							{}
	| tiExprAndId annotations OPASSIGN expr				{}
	;

assignItem
	: IDENT OPASSIGN expr								{}
	;

constraintItem
	: KWCONS expr										{}
	;

solveItem
	: KWSOLV annotations KWSATI							{}
	| KWSOLV annotations KWMINI							{}
	| KWSOLV annotations KWMAXI							{}
	;

outputItem
	: KWOUTP expr										{}
	;

annotationItem
	: KWANNO IDENT params								{}
	;

predicateItem
	: KWPRED operationItemTail							{}
	;

testItem
	: KWTEST operationItemTail							{}
	;

functionItem
	: KWFUNC tiExpr COLON operationItemTail				{}
	;

operationItemTail
	: IDENT params annotations							{}
	| IDENT params annotations OPASSIGN expr			{}
	;

params
	:													{}
	| OBRK CBRK											{}
	| OBRK tiExprAndId COMMA paramsTail CBRK			{}
	;

paramsTail
	:													{}
	| COMMA												{}
	| paramsTail paramsTail								{}
	;

tiExpr
	: OBRK tiExpr COLON IDENT KWWHER expr CBRK			{}
	| baseTiExpr										{}
	;

baseTiExpr
	: varPar baseTiExprTail								{}
	;

varPar
	: 													{}
	| KWVAR												{}
	| KWPAR												{}
	;

baseTiExprTail
	: IDENT												{}
	| KWBOOL											{}
	| KWINT												{}
	| KWFLOAT											{}
	| KWSTRING											{}
	| setTiExprTail										{}
	| arrayTiExprTail									{}
	| tupleTiExprTail									{}
	| recordtiExprTail									{}
	| tiVariableExprTail								{}
	| KWANN												{}
	| opTiExprTail										{}
	| OACC CACC											{}
	| OACC expr exprList CACC							{}
	| numExpr OPRANGE numExpr							{}
	;

exprList
	: 													{}
	| COMMA												{}
	| COMMA expr exprList								{}
	;

setTiExprTail
	: KWSET KWOF tiExpr
	;

arrayTiExprTail
	: KWARRA OFBR CFBR KWOF tiExpr						{}
	| KWARRA OFBR tiExpr tiExprTail CFBR KWOF tiExpr	{}
	| KWLIST KWOF tiExpr								{}
	;

tiExprTail
	:													{}
	| COMMA												{}
	| COMMA tiExpr tiExprTail							{}
	;

tupleTiExprTail
	: KWTUPL OBRK CBRK									{}
	| KWTUPL OBRK tiExpr tiExprTail CBRK				{}
	;

tiVariableExprTail
	: DIDENT											{}
	| KWANY DIDENT										{}
	;

opTiExprTail
	: KWOP OBRK tiExpr COLON OBRK CBRK					{}
	| KWOP OBRK tiExpr COLON OBRK tiExpr tiExprTail CBRK	{}
	;

expr
	: exprAtom exprBinopTail							{}
	;

exprAtom
	: exprAtomHead exprAtomTail annotations				{}
	;

exprBinopTail
	: 													{}
	| binOp expr										{}
	;

exprAtomHead
	: builtinUnOp exprAtom								{}
	| OBRK expr CBRK									{}
	| identOrQuotedOp									{}
	| OPUNDSC											{}
	| BOOLI												{}
	| INTLI												{}
	| FLOLI												{}
	| STRLI												{}
	| setLiteral										{}
	| setComp											{}
	| simpleArrayLiteral								{}
	| simpleArrayLiteralTwoD							{}
	| indexedArrayLiteral								{}
	| simpleArrayComp									{}
	| indexedArrayComp									{}
	| tupleLiteral										{}
	| recordLiteral										{}
	| enumLiteral										{}
	| annLiteral										{}
	| ifThenElseExpr									{}
	| caseExpr											{}
	| letExpr											{}
	| callExpr											{}
	| genCallExpr										{}
	;

exprAtomTail
	: arrayAccessTail exprAtomTail						{}
	| tupleAccessTail expAtomTail						{}
	| recordAccessTail exprAtomTail						{}
	;

numExpr
	: numExprAtom numExprBinopTail						{}
	;

numExprAtom
	: numExprAtomHead exprAtomTail annotations			{}
	;

numExprBinopTail
	: 													{}
	| numBinOp numExpr									{}
	;

numExprAtomHead
	: builtinNumUnOp numExprAtom						{}
	| OBRK numExpr CBRK									{}
	| identOrQuotedOp									{}
	| INTLI												{}
	| FLOLI												{}
	| ifThenElseExpr									{}
	| caseExpr											{}
	| letExpr											{}
	| callExpr											{}
	| genCallExpr										{}
	;

builtinOp
	: builtinBinOp										{}
	| builtinUnOp										{}
	;

binOp
	: builtinBinOp										{}
	| ACCENT IDENT ACCENT								{}
	;

builtinBinOp
	: EOPEQUIV											{}
	| OPIMPLI											{}
	| OPRIMPL											{}
	| OPVEE												{}
	| OPWEDGE											{}
	| OPLESTA											{}
	| OPGRETA											{}
	| OPLESEQ											{}
	| OPGEAEQ											{}
	| OPEQUAL											{}
	| OPNEQUA											{}
	| OPRANGE											{}
	| OPINCRE											{}
	| OPASSIG											{}
	| KWIN												{}
	| KWSUBS											{}
	| KWSUPE											{}
	| KWUNIO											{}
	| KWDIFF											{}
	| KWSYMD											{}
	| KWINTE											{}
	| builtinNumBinOp									{}
	;

builtinUnOp
	: KWNOT												{}
	| builtinNumUnOp									{}
	;

numBinOp
	: builtinNumBinOp									{}
	| ACCENT IDENT ACCENT								{}
	;

builtinNumBinOp
	: OPADD												{}
	| OPSUB												{}
	| OPMUL												{}
	| OPDIV												{}
	| KWDIV												{}
	| KWMOD												{}
	;

builtinNumUnOp
	: OPSUB												{}
	| OPADD												{}
	;

setLiteral
	: OACC CACC											{}
	| OACC expr exprList CACC							{}
	;

setComp
	: OACC expr BAR compTail CACC						{}
	;

compTail
	: generator generatorTail							{}
	| generator generatorTail KWWHER expr				{}
	;

generatorTail
	:													{}
	| COMMA												{}
	| COMMA generator generatorTail						{}
	;

generator
	: ident identTail KWIN expr							{}

identTail
	:													{}
	| COMMA												{}
	| COMMA ident identTail								{}
	;

simpleArrayLiteral
	: OPENFB CLOSEFB									{}
	| OPENFB expr exprList CLOSEFB						{}
	;

simpleArrayLiteralTwoD
	: OPENFB BAR simpleArrayLiteralTwoDTail BAR CLOSEFB	{}
	| OPENFB BAR BAR CLOSEFB							{}
	;

simpleArrayLiteralTwoDTail
	:													{}
	| BAR												{}
	| exprTail BAR simpleArrayLiteralTwoDTail			{}
	;

array-acces-tail
	: OPENFB exprTail CLOSEFB							{}
	;

annLiteral
	: IDENT												{}
	| IDENT OPENBR exprTail CLOSEBR						{}
	;

ifThenElseExpr
	: IFKW expr THENKW expr ifThenElseTail ELSEKW expr ENDIFKW	{}
	;

ifThenElseTail
	: 													{}
	| ELSEIFKW expr THENKW expr ifThenElseTail			{}
	;

caseExpr
	: CASEKW expr OPENAC caseExprCase caseExprCaseTail CLOSEAC {}
	;

caseExprCaseTail
	: 													{}
	| COMMA												{}
	| COMMA caseExprCase caseExprCaseTail				{}

caseExprCase
	: IDENT ARROW EXPR									{}
	;

letExpr
	: LETKW OPENAC valDelcItem varDelcItemTail CLOSEAC INKW expr	{}
	;

varDecItemTail
	:													{}
	| COMMA												{}
	| COMMA varDecItem varDecItemTail					{}
	;

callExpr
	: identOrQuotedOp									{}
	| identOrQuotedOp OPENBR exprTail CLOSEBR			{}
	;

identOrQuotedOp
	: IDENT												{}
	| ACCENT builtinOp ACCENT							{}
	;

annotations
	:													{}
	| OPANNOT annotation annotations					{}
	;

annotation
	: exprAtomHead exprAtomTail							{}
	;

%%
/*
 * All the code is in the helper file RealTreeHelper.cs
 */ 
	