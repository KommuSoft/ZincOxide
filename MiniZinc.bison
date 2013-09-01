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

%token IDENT ITEMSEP OPENBR CLOSBR VARKW PARKW WHEREKW BOOLKW INTKW FLOATKW COLON COMMA ACCENT UNDERSCORE BOOLLIT INTLIT FLOATLIT EQUIV IMPL RIMPL VEE XORKW WEDGE LT GT LE GE EQ ASSIGNMENT NEQ INKW SUBSETKW SUPERSETKW UNIONKW DIFFKW SYMDIFFKW INTERVAL INTERSECTKW INCREMENT NOTKW ADDOP SUBOP MULOP DIVOP DIVKW MODKW EOF

%%

model
	:	EOF					 							{} /*empty */
	|	item modelTail EOF								{}
	;

item
	: IDENT												{}
	;

modelTail
	:													{}
	| ITEMSEP											{}
	|  item ITEMSEP modelTail							{}
	;

tiExpr
	: OPENBR tiExpr COLON IDENT WHEREKW expr CLOSKW		{}
	| baseTiExpr										{}
	;

baseTiExpr
	: varPar baseTiExprTail								{}
	;

varPar
	: 													{}
	| VARKW												{}
	| PARKW												{}
	;

baseTiExprTail
	: IDENT												{}
	| BOOLKW											{}
	| INTKW												{}
	| FLOATKW											{}
	| setTiExprTail										{}
	| arrayTiExprTail									{}
	| tiVariableExprTail								{}
	| OPENAC expr COMMA exprTail CLOSAC					{}
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
	| setComp											{}
	| simpleArrayLiteral								{}
	| simpleArrayLiteralTwoD							{}
	| indexedArrayLiteral								{}
	| simpleArrayComp									{}
	| indexedArrayComp									{}
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
	: OPENAC expr KOMMA exprTail CLOSAC					{}
	;


%%
/*
 * All the code is in the helper file RealTreeHelper.cs
 */ 
	