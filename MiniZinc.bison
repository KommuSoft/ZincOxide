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

%token KWTYPE KWENUM KWINCL KWCONS KWSOLV KWSATI KWMINI MWMAXI KWOUTP KWANNO KWPRED KWTEST KWFUNC KWWHER KWVAR KWPAR KWBOOL KWINT KWFLOA KWSTRI KWANN KWSET KWOF KWARRA KWLIST KWTUPL KWRECO KWANY KWOP KWIN KWSUBS KWSUPE KWUNIO KWDIFF KWSYMD KWINTE KWNOT KWDIV KWMOD KWFALS KWTRUE KWIF KWTHEN KWELSI KWELSE KWENDI KWCASE KWLET COMMAD COMMA COLON ACCENT BAR OACC CACC OBRK CBRK OFBR CFBR OPASSIG OPUNDSC OPEQUIV OPIMPLI OPRIMPL OPVEE OPWEDGE OPLESTA OPGRETA OPLESEQ OPGEAEQ OPEQUAL OPNEQUA OPRANGE OPINCRE OPANNOT OPADD OPSUB OPMUL OPDIV OPCASE INTLI FLOLI STRLI IDENT NOISE EOL COMMENT EOF

%%

model
	:	EOF					 							{} /*empty */
	|	item modelTail EOF								{}
	;

modelTail
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
	| BOOLKW											{}
	| INTKW												{}
	| FLOATKW											{}
	| setTiExprTail										{}
	| arrayTiExprTail									{}
	| tiVariableExprTail								{}
	| OPENAC expr COMMA exprTail CLOSEAC				{}
	| numExpr INTERVAL numExpr							{}
	;

exprTail
	: 													{}
	| COMMA												{}
	| expr COMMA expTail								{}
	;

expr
	: exprAtom exprBinopTail							{}
	;

exprAtom
	: exprAtomHead exprAtomTail Annotations				{}
	;

exprBinopTail
	: 													{}
	| binOp expr										{}
	;

exprAtomHead
	: builtinUnOp exprAtom								{}
	| OPENBR expr CLOSBR								{}
	| IDENT												{}
	| UNDERSCORE										{}
	| BOOLLIT											{}
	| INTLIT											{}
	| FLOATLIT											{}
	| setLiteral										{}
	| simpleArrayLiteral								{}
	| simpleArrayLiteralTwoD							{}
	| ifThenElseExpr									{}
	| caseExpr											{}
	| letExpr											{}
	| callExpr											{}
	| genCallExpr										{}
	;

exprAtomTail
	: arrayAccessTail exprAtomTail						{}
	;

numExpr
	: numExprAtom numExprBinopTail						{}
	;

numExprAtom
	: numExprAtomHead exprAtomTail annotation			{}
	;

numExprBinopTail
	: 													{}
	| numBinOp numExpr									{}
	;

numExprAtomHead
	: builtinNumUnOp numExprAtom						{}
	| OPENBR numExpr CLOSBR								{}
	| identOrQuotedOp									{}
	| INTLIT											{}
	| FLOATLIT											{}
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
	: EQUIV												{}
	| IMPL												{}
	| RIMPL												{}
	| VEE												{}
	| XORKW												{}
	| WEDGE												{}
	| LT												{}
	| GT												{}
	| LE												{}
	| GE												{}
	| EQ												{}
	| ASSIGNMENT										{}
	| NEQ												{}
	| INKW												{}
	| SUBSETKW											{}
	| SUPERSETKW										{}
	| UNIONKW											{}
	| DIFFKW											{}
	| SYMDIFFKW											{}
	| INTERVAL											{}
	| INTERSECTKW										{}
	| INCREMENT											{}
	| builtinNumBinOp									{}
	;

builtinUnOp
	: NOTKW												{}
	| builtinNumUnOp									{}
	;

numBinOp
	: builtinNumBinOp									{}
	| ACCENT IDENT ACCENT								{}
	;

builtinNumBinOp
	: ADDOP												{}
	| SUBOP												{}
	| MULOP												{}
	| DIVOP												{}
	| DIVKW												{}
	| MODKW												{}
	;

builtinNumUnOp
	: ADDOP												{}
	| SUBOP												{}
	;

identOrQuotedOp
	: IDENT												{}
	| ACCENT builtinOp ACCENT							{}
	;

setLiteral
	: OPENAC expr COMMA exprTail CLOSEAC					{}
	;

exprTail
	: 													{}
	| COMMA												{}
	| expr COMMA exprTail								{}
	;

simpleArrayLiteral
	: OPENFB CLOSEFB									{}
	| OPENFB expr COMMA exprTail CLOSEFB				{}
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



%%
/*
 * All the code is in the helper file RealTreeHelper.cs
 */ 
	