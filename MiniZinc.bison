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

%token KWTYPE KWENUM KWINCL KWCONS KWSOLV KWSATI KWMINI MWMAXI KWOUTP KWANNO KWPRED KWTEST KWFUNC KWWHER KWVAR KWPAR KWBOOL KWINT KWFLOA KWSTRI KWANN KWSET KWOF KWARRA KWLIST KWTUPL KWRECO KWANY KWOP KWIN KWSUBS KWSUPE KWUNIO KWDIFF KWSYMD KWINTE KWNOT KWDIV KWMOD KWFALS KWTRUE KWIF KWTHEN KWELSI KWELSE KWENDI KWCASE KWLET COMMAD COMMA COLON ACCENT BAR OACC CACC OBRK CBRK OFBR CFBR OFBA CFBA OPASSIG OPUNDSC OPEQUIV OPIMPLI OPRIMPL OPVEE OPWEDGE OPLESTA OPGRETA OPLESEQ OPGEAEQ OPEQUAL OPNEQUA OPRANGE OPINCRE OPANNOT OPADD OPSUB OPMUL OPDOT OPDIV OPCASE BOOLI INTLI FLOLI STRLI IDENT NOISE EOL COMMENT EOF

%%

model
	:	EOF					 							{} /*empty */
	|	itemListO EOF									{}
	;

itemListO
	: item itemList										{}
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
	| IDENT OBRK tiExprAndIdListO CBRK					{}
	;

tiExprAndIdListO
	: tiExprAndId tiExprAndIdList						{}
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
	| OACC exprListO CACC								{}
	| numExpr OPRANGE numExpr							{}
	;

exprListO
	: expr exprList										{}
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
	| OACC exprListO CACC								{}
	;

setComp
	: OACC expr BAR compTail CACC						{}
	;

compTail
	: generatorListO									{}
	| generatorListO KWWHER expr						{}
	;

generatorListO
	: generator generatorList							{}
	;

generatorList
	:													{}
	| COMMA												{}
	| COMMA generatorListO								{}
	;

generator
	: identListO KWIN expr								{}
	;

identListO
	: ident identList									{}
	;

identList
	:													{}
	| COMMA												{}
	| COMMA ident identList								{}
	;

simpleArrayLiteral
	: OPENFB CLOSEFB									{}
	| OPENFB exprListO CLOSEFB							{}
	;

simpleArrayLiteralTwoD
	: OFBA exprListListO CFBA							{}
	| OFBA CFBA											{}
	;

exprListListO
	: exprList exprListList								{}
	;

exprListList
	:													{}
	| BAR												{}
	| BAR exprListO exprListList						{}
	;

simpleArrayComp
	: OFBR expr BAR compTail CFBR						{}
	;

indexedArrayLiteral
	: OFBR CFBR											{}
	| OFBR indexExprListO CFBR							{}
	;

indexExprListO
	: indexExpr indexExprList							{}
	;

indexExprList
	: 													{}
	| COMMA												{}
	| COMMA indexExpr indexExprList						{}
	;

indexExpr
	: expr COLON expr									{}
	;

indexedArrayComp
	: OFBR indexExpr BAR compTail CFBR					{}
	;

arrayAccessTail
	: OFBR exprListO CFBR								{}
	;

tupleLiteral
	: OBRA exprListO CBRA								{}
	;

tupleAccessTail
	: OPDOT INTLIT										{}
	;

recordLiteral
	: OBRA namedExprListO CBRA							{}
	;

namedExprListO
	: namedExpr namedExprList							{}
	;

namedExprList
	:													{}
	| COMMA												{}
	| COMMA namedExpr namedExprList						{}
	;

namedExpr
	: IDENT COLON expr									{}
	;

recordAccessTail
	: OPDOT IDENT										{}
	;

enumLiteral
	: IDENT OBRA namedExprListO CBRA					{}
	| IDENT OBRA exprListO CBRA							{}
	| IDENT 											{}
	;

annLiteral
	: IDENT												{}
	| IDENT OPENBR exprListO CLOSEBR					{}
	;

ifThenElseExpr
	: KWIF expr KWTHEN expr ifThenElseTail KWELSE expr KWENDI	{}
	;

ifThenElseTail
	: 													{}
	| ELSEIFKW expr THENKW expr ifThenElseTail			{}
	;

caseExpr
	: KWCASE expr OACC caseExprCaseListO CACC			{}
	;

caseExprCaseListO
	: caseExprCase caseExprCaseList						{}
	;

caseExprCaseList
	:													{}
	| COMMA												{}
	| COMMA caseExprCase caseExprCaseList				{}
	;

caseExprCase
	: IDENT OPCASE expr									{}
	;

callExpr
	: identOrQuotedOp									{}
	| identOrQuotedOp OBRA expListO CBRA				{}
	;

letExpr
	: KWLET OACC valDelcItemListO CACC KWIN expr		{}
	;

valDelcItemListO
	: valDelcItem valDelcItemList						{}
	;

valDelcItemListO
	:													{}
	| COMMA												{}
	| COMMA varDecItem valDelcItemListO					{}
	;

genCallExpr
	: identOrQuotedOp OBRA compTail CBRA OBRA expr CBRA	{}
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
	