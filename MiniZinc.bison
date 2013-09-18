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

%token KWTYPE KWENUM KWINCL KWCONS KWSOLV KWSATI KWMINI KWMAXI KWOUTP KWANNO KWPRED KWTEST KWFUNC KWWHER KWVAR KWPAR KWBOOL KWINT KWFLOA KWSTRI KWANN KWSET KWOF KWARRA KWLIST KWTUPL KWRECO KWANY KWOP KWXOR KWIN KWSUBS KWSUPE KWUNIO KWDIFF KWSYMD KWINTE KWNOT KWDIV KWMOD KWFALS KWTRUE KWIF KWTHEN KWELSI KWELSE KWENDI KWCASE KWLET COMMAD COMMA COLON ACCENT BAR OACC CACC OBRK CBRK OFBR CFBR OFBA CFBA OPASSIG OPUNDSC OPEQUIV OPIMPLI OPRIMPL OPVEE OPWEDGE OPLESTA OPGRETA OPLESEQ OPGEAEQ OPEQUAL OPNEQUA OPRANGE OPINCRE OPANNOT OPADD OPSUB OPMUL OPDOT OPDIV OPCASE BOOLI INTLI FLOLI STRLI IDENT NOISE EOL COMMENT DIDENT EOF

%left OPEQUIV
%left OPIMPLI OPRIMPL
%left OPVEE KWXOR
%left OPWEDGE
%nonassoc OPLESTA OPGRETA OPLESEQ OPGEAEQ OPEQUAL OPASSIG OPNEQUA
%nonassoc KWIN KWSUBS KWSUPE
%left KWUNIO KWDIFF KWSYMD
%nonassoc OPRANGE
%left OPADD OPSUB
%left OPMUL KWDIV KWMOD OPDIV KWINTE
%right OPINCRE

%%

model
    :    EOF                                                 {} /*empty */
    |    itemListO EOF                                    {}
    ;

itemListO
    : item itemList                                        {}
    ;

itemList
    :                                                    {}
    | COMMAD                                            {}
    | item COMMAD itemList                                {}
    ;

item
//    : typeInstSynItem                                    {} MiniZinc
//    | enumItem                                            {} MiniZinc
    : includeItem                                        {}
//    | varDeclItem                                        {}
//    | assignItem                                        {}
//    | constraintItem                                    {}
//    | solveItem                                            {}
//    | outputItem                                        {}
//    | predicateItem                                        {}
//    | testItem                                            {}
//    | functionItem                                        {} MiniZinc
    | annotationItem                                    {}
    ;

//typeInstSynItem                                           MiniZinc
//    : KWTYPE IDENT annotations OPASSIG tiExpr            {}
//    ;

//enumItem                                                   MiniZinc
//    : KWENUM IDENT annotations                            {}
//    | KWENUM IDENT annotations OPASSIG enumCases        {}
//    ;

//enumCases                                                   MiniZinc
//    : OACC CACC                                            {}
//    | OACC enumCaseListO CACC                            {}
//    ;

//enumCaseListO                                               MiniZinc
//    : enumCase enumCaseList                                {}
//    ;

//enumCaseList                                               MiniZinc
//    :                                                    {}
//    | COMMA                                                {}
//    | COMMA enumCase enumCaseList                        {}
//    ;

//enumCase                                                   MiniZinc
//    : IDENT                                                {}
//    | IDENT OBRK tiExprAndIdListO CBRK                    {}
//    ;

//tiExprAndIdListO
//    : tiExprAndId tiExprAndIdList                        {}
//    ;
//
//tiExprAndIdList
//    :                                                     {}
//    | COMMA                                                {}
//    | COMMA tiExprAndId COMMA tiExprAndIdList            {}
//    ;

tiExprAndId
    : tiExpr COLON IDENT                                {}
    ;

includeItem
    : KWINCL STRLI                                        {}
    ;

varDeclItem
    : tiExprAndId annotations                            {}
    | tiExprAndId annotations OPASSIG expr                {}
    ;

assignItem
    : IDENT OPASSIG expr                                {}
    ;

constraintItem
    : KWCONS expr                                        {}
    ;

solveItem
    : KWSOLV annotations KWSATI                            {}
    | KWSOLV annotations KWMINI                            {}
    | KWSOLV annotations KWMAXI                            {}
    ;

outputItem
    : KWOUTP expr                                        {}
    ;

//annotationItem                                           TMP
//    : KWANNO IDENT paramsNonTerm                        {}
//    ;

//predicateItem                                               TMP
//    : KWPRED operationItemTail                            {}
//    ;

//testItem                                                   TMP
//    : KWTEST operationItemTail                            {}
//    ;

//functionItem                                               MiniZinc
//    : KWFUNC tiExpr COLON operationItemTail                {}
//    ;

//operationItemTail                                           TMP
//    : IDENT paramsNonTerm annotations                    {}
//    | IDENT paramsNonTerm annotations OPASSIG expr        {}
//    ;

//paramsNonTerm                                               TMP
//    :                                                    {}
//    | OBRK CBRK                                            {}
//    | OBRK tiExprAndId COMMA paramsTail CBRK            {}
//    ;

//paramsTail                                               TMP
//    :                                                    {}
//    | COMMA                                                {}
//    | paramsTail paramsTail                                {}
//    ;

tiExpr
    : OBRK tiExpr COLON IDENT KWWHER expr CBRK            {}
    | baseTiExpr                                        {}
    ;

baseTiExpr
    : varPar baseTiExprTail                                {}
    ;

varPar
    :                                                     {}
    | KWVAR                                                {}
    | KWPAR                                                {}
    ;

baseTiExprTail
    : IDENT                                                {}
    | KWBOOL                                            {}
    | KWINT                                                {}
    | KWFLOA                                            {}
    | KWSTRI                                            {}
    | setTiExprTail                                        {}
    | arrayTiExprTail                                    {}
    | tupleTiExprTail                                    {}
//    | recordTiExprTail                                    {} MiniZinc
    | tiVariableExprTail                                {}
    | KWANN                                                {}
    | opTiExprTail                                        {}
    | OACC CACC                                            {}
    | OACC exprListO CACC                                {}
    | numExpr OPRANGE numExpr                            {}
    ;

exprListO
    : expr exprList                                        {}
    ;

exprList
    :                                                     {}
    | COMMA                                                {}
    | COMMA expr exprList                                {}
    ;

setTiExprTail
    : KWSET KWOF tiExpr
    ;

arrayTiExprTail
    : KWARRA OFBR CFBR KWOF tiExpr                        {}
    | KWARRA OFBR tiExpr tiExprTail CFBR KWOF tiExpr    {}
    | KWLIST KWOF tiExpr                                {}
    ;

tiExprTail
    :                                                    {}
    | COMMA                                                {}
    | COMMA tiExpr tiExprTail                            {}
    ;

tupleTiExprTail
    : KWTUPL OBRK tiExprListO CBRK                        {}
    ;

tiExprListO
    : tiExpr tiExprList                                    {}
    ;

tiExprList
    :                                                    {}
    | COMMA                                                {}
    | COMMA tiExpr tiExprList                            {}
    ;

//recordTiExprTail                                           //MiniZinc
//    : KWRECO OBRK tiExprAndIdListO CBRK                    {}
//    ;

tiVariableExprTail
    : DIDENT                                            {}
    | KWANY DIDENT                                        {}
    ;

opTiExprTail
    : KWOP OBRK tiExpr COLON OBRK CBRK                    {}
    | KWOP OBRK tiExpr COLON OBRK tiExpr tiExprTail CBRK{}
    ;

expr
    : exprAtom exprBinopTail                            {}
    ;

exprAtom
    : exprAtomHead exprAtomTail annotations                {}
    ;

exprBinopTail
    :                                                     {}
    | binOp expr                                        {}
    ;

exprAtomHead
    : builtinUnOp exprAtom                                {}
    | OBRK expr CBRK                                    {}
    | identOrQuotedOp                                    {}
    | OPUNDSC                                            {}
    | BOOLI                                                {}
    | INTLI                                                {}
    | FLOLI                                                {}
    | STRLI                                                {}
    | setLiteral                                        {}
    | setComp                                            {}
    | simpleArrayLiteral                                {}
    | simpleArrayLiteralTwoD                            {}
//    | indexedArrayLiteral                                {} MiniZinc
//    | simpleArrayComp                                    {} MiniZinc
//    | indexedArrayComp                                    {} MiniZinc
    | tupleLiteral                                        {}
//    | recordLiteral                                        {} MiniZinc
//    | enumLiteral                                        {} MiniZinc
//    | annLiteral                                        {}
    | ifThenElseExpr                                    {}
//    | caseExpr                                            {} MiniZinc
    | letExpr                                            {}
    | callExpr                                            {}
    | genCallExpr                                        {}
    ;

exprAtomTail
    : arrayAccessTail exprAtomTail                        {}
    | tupleAccessTail exprAtomTail                        {}
//    | recordAccessTail exprAtomTail                        {} MiniZinc
    ;

numExpr
    : numExprAtom numExprBinopTail                        {}
    ;

numExprAtom
    : numExprAtomHead exprAtomTail annotations            {}
    ;

numExprBinopTail
    :                                                     {}
    | numBinOp numExpr                                    {}
    ;

numExprAtomHead
    : builtinNumUnOp numExprAtom                        {}
    | OBRK numExpr CBRK                                    {}
    | identOrQuotedOp                                    {}
    | INTLI                                                {}
    | FLOLI                                                {}
    | ifThenElseExpr                                    {}
//    | caseExpr                                            {} MiniZinc
    | letExpr                                            {}
    | callExpr                                            {}
    | genCallExpr                                        {}
    ;

builtinOp
    : builtinBinOp                                        {}
    | builtinUnOp                                        {}
    ;

binOp
    : builtinBinOp                                        {}
    | ACCENT IDENT ACCENT                                {}
    ;

builtinBinOp
    : OPEQUIV                                            {}
    | OPIMPLI                                            {}
    | OPRIMPL                                            {}
    | OPVEE                                                {}
    | KWXOR                                                {}
    | OPWEDGE                                            {}
    | OPLESTA                                            {}
    | OPGRETA                                            {}
    | OPLESEQ                                            {}
    | OPGEAEQ                                            {}
    | OPEQUAL                                            {}
    | OPNEQUA                                            {}
    | KWIN                                                {}
    | KWSUBS                                            {}
    | KWSUPE                                            {}
    | KWUNIO                                            {}
    | KWDIFF                                            {}
    | KWSYMD                                            {}
    | OPRANGE                                            {}
    | KWINTE                                            {}
    | OPINCRE                                            {}
    | builtinNumBinOp                                    {}
    ;

builtinUnOp
    : KWNOT                                                {}
    | builtinNumUnOp                                    {}
    ;

numBinOp
    : builtinNumBinOp                                    {}
    | ACCENT IDENT ACCENT                                {}
    ;

builtinNumBinOp
    : OPADD                                                {}
    | OPSUB                                                {}
    | OPMUL                                                {}
    | OPDIV                                                {}
    | KWDIV                                                {}
    | KWMOD                                                {}
    ;

builtinNumUnOp
    : OPSUB                                                {}
    | OPADD                                                {}
    ;

setLiteral
    : OACC CACC                                            {}
    | OACC exprListO CACC                                {}
    ;

setComp
    : OACC expr BAR compTail CACC                        {}
    ;

compTail
    : generatorListO                                    {}
    | generatorListO KWWHER expr                        {}
    ;

generatorListO
    : generator generatorList                            {}
    ;

generatorList
    :                                                    {}
    | COMMA                                                {}
    | COMMA generatorListO                                {}
    ;

generator
    : identListO KWIN expr                                {}
    ;

identListO
    : IDENT identList                                    {}
    ;

identList
    :                                                    {}
    | COMMA                                                {}
    | COMMA IDENT identList                                {}
    ;

simpleArrayLiteral
    : OFBR CFBR                                            {}
    | OFBR exprListO CFBR                                {}
    ;

simpleArrayLiteralTwoD
    : OFBA exprListListO CFBA                            {}
    | OFBA CFBA                                            {}
    ;

exprListListO
    : exprList exprListList                                {}
    ;

exprListList
    :                                                    {}
    | BAR                                                {}
    | BAR exprListO exprListList                        {}
    ;

//simpleArrayComp                                           MiniZinc
//    : OFBR expr BAR compTail CFBR                        {}
//    ;

//indexedArrayLiteral                                       MiniZinc
//    : OFBR CFBR                                            {}
//    | OFBR indexExprListO CFBR                            {}
//    ;

//indexExprListO                                           MiniZinc
//    : indexExpr indexExprList                            {}
//    ;

//indexExprList                                               MiniZinc
//    :                                                     {}
//    | COMMA                                                {}
//    | COMMA indexExpr indexExprList                        {}
//    ;

//indexExpr                                                   MiniZinc
//    : expr COLON expr                                    {}
//    ;

//indexedArrayComp                                           MiniZinc
//    : OFBR indexExpr BAR compTail CFBR                    {}
//    ;

arrayAccessTail
    : OFBR exprListO CFBR                                {}
    ;

tupleLiteral
    : OPASSIG exprListO CBRK                            {}
    ;

tupleAccessTail
    : OPDOT INTLI                                        {}
    ;

//recordLiteral                                               MiniZinc
//    : OBRK namedExprListO CBRK                            {}
//    ;

//namedExprListO                                           TMP
//    : namedExpr namedExprList                            {}
//    ;

//namedExprList                                               TMP
//    :                                                    {}
//    | COMMA                                                {}
//    | COMMA namedExpr namedExprList                        {}
//    ;

//namedExpr                                                   TMP
//    : IDENT COLON expr                                    {}
//    ;

//recordAccessTail                                           MiniZinc
//    : OPDOT IDENT                                        {}
//    ;

//enumLiteral                                               MiniZinc
//    : IDENT OBRK namedExprListO CBRK                    {}
//    | IDENT OBRK exprListO CBRK                            {}
//    | IDENT                                             {}
//    ;

annLiteral
    : IDENT                                                {}
    | IDENT OBRK exprListO CBRK                            {}
    ;

ifThenElseExpr
    : KWIF expr KWTHEN expr ifThenElseTail KWELSE expr KWENDI    {}
    ;

ifThenElseTail
    :                                                     {}
    | KWELSI expr KWTHEN expr ifThenElseTail            {}
    ;

//caseExpr                                                   MiniZinc
//    : KWCASE expr OACC caseExprCaseListO CACC            {}
//    ;

//caseExprCaseListO                                           MiniZinc
//    : caseExprCase caseExprCaseList                        {}
//    ;

//caseExprCaseList                                           MiniZinc
//    :                                                    {}
//    | COMMA                                                {}
//    | COMMA caseExprCase caseExprCaseList                {}
//    ;

//caseExprCase                                               MiniZinc
//    : IDENT OPCASE expr                                    {}
//    ;

callExpr
    : identOrQuotedOp                                    {}
    | identOrQuotedOp OBRK exprListO CBRK                {}
    ;

letExpr
    : KWLET OACC varDeclItemListO CACC KWIN expr        {}
    ;

varDeclItemListO
    : varDeclItem varDeclItemList                        {}
    ;

varDeclItemList
    :                                                    {}
    | COMMA                                                {}
    | COMMA varDeclItem varDeclItemList                    {}
    ;

genCallExpr
    : identOrQuotedOp OBRK compTail CBRK OBRK expr CBRK    {}
    ;

identOrQuotedOp
    : IDENT                                                {}
    | ACCENT builtinOp ACCENT                            {}
    ;

annotations
    :                                                    {}
    | OPANNOT annotation annotations                    {}
    ;

annotation
    : exprAtomHead exprAtomTail                            {}
    ;

%%
/*
 * All the code is in the helper file RealTreeHelper.cs
 */ 