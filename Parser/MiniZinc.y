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

%output=MiniZincParser.cs 
%namespace ZincOxide.Parser
%tokentype Token

%visibility public

%YYLTYPE LexSpan
%partial 
%union {
    public HeadTail<IZincItem> hti;
    public ZincVarDeclItem vdi;
    public ZincIncludeItem ii;
    public IZincType t;
}

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


%YYSTYPE Object

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



%%
/*
 * All the code is in the helper file RealTreeHelper.cs
 */ 