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

%output=../MiniZincParser.cs 
%namespace ZincOxide.Parser
%parsertype MiniZincParser

%using ZincOxide.MiniZinc;
%using ZincOxide.Utils;

%tokentype Token

%visibility public

%partial 
%union {
    public HeadTail<IZincItem> hti;
    public HeadTail<IZincTypeInstExpression> httie;
    public IZincItem i;
    public IZincType t;
    public ZincVarPar vp;
    public ZincIdent id;
    public IZincTypeInstExpression tie;
    public ZincTypeInstExprAndIdent tia;
    public IZincNumExp ne;
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


%YYSTYPE StateStructure
%YYLTYPE LexSpan

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

%type <hti> itemList itemListO
%type <httie> tiExprListO tiExprList
%type <i> item includeItem varDeclItem
%type <t> baseTiExprTail arrayTiExprTail
%type <vp> varPar
%type <id> ident
%type <tie> tiExpr baseTiExpr
%type <tia> tiExprAndId
%type <ne> numExp

%%

/*#region Items  */
model
    : itemListO EOF                            {this.result = new ZincModel($1);}
    ;

itemListO
    : item itemList                            {$$ = $1&$2;}
    ;

itemList
    :                                          {$$ = (HeadTail<IZincItem>) null;}
    | COMMAD                                   {$$ = (HeadTail<IZincItem>) null;}
    | COMMAD item itemList                     {$$ = $2&$3;}
    | COMMAD error itemList                    {$$ = $3; Interaction.ParsingError(@2,"I cannot parse the ZincItem, I will ignore it.");}
    ;

item
    : includeItem                              {$$ = $1;}
    | varDeclItem                              {$$ = $1;}
    ;

includeItem
    : KWINCL STRLI                             {$$ = new ZincIncludeItem(@2.LiteralString());}
    ;

varDeclItem
    : tiExprAndId annotations                  {$$ = new ZincVarDeclItem($1);}
    | tiExprAndId annotations OPASSIG expr     {$$ = new ZincVarDeclItem($1);}//TODO
    ;

tiExprAndId
    : tiExpr COLON ident                       {$$ = new ZincTypeInstExprAndIdent($1,$3);}
    ;

varPar
    :                                          {$$ = ZincVarPar.Par;}
    | KWVAR                                    {$$ = ZincVarPar.Var;}
    | KWPAR                                    {$$ = ZincVarPar.Par;}
    ;
/*#endregion  */

/*#region Type-Inst Expressions  */
tiExpr
    : baseTiExpr                               {$$ = $1;}
    ;

baseTiExpr
    : varPar baseTiExprTail                    {$$ = new ZincTypeInstBaseExpression($1,$2);}
    ;

baseTiExprTail
    : KWBOOL                                   {$$ = new ZincScalarType(ZincScalar.Bool);}
    | KWINT                                    {$$ = new ZincScalarType(ZincScalar.Int);}
    | KWFLOA                                   {$$ = new ZincScalarType(ZincScalar.Float);}
    | arrayTiExprTail                          {$$ = $1;}
    | numExp OPRANGE numExp                    {$$ = new ZincTypeInstRangeExpression($1,$3);}
    ;

arrayTiExprTail
    : KWARRA OFBR tiExprListO CFBR KWOF tiExpr {$$ = new ZincTypeInstArrayExpression($6,$3);}
    ;

tiExprListO
    : tiExpr tiExprList                        {$$ = $1&$2;}
    ;

tiExprList
    :                                          {$$ = (HeadTail<IZincTypeInstExpression>) null;}
    | COMMA                                    {$$ = (HeadTail<IZincTypeInstExpression>) null;}
    | COMMA tiExpr tiExprList                  {$$ = $2&$3;}
    ;
/*#endregion  */

/*#region Expressions  */
expr
    :                                          {}
    ;

numExp
    : INTLI                                    {$$ = new ZincIntLiteral(@1.ToString());}
    | ident                                    {$$ = $1;}
    ;
/*#endregion  */

/*#region Miscellaneous Elements  */
ident
    : IDENT                                    {$$ = new ZincIdent(@1.ToString());}
    ;

annotations
    :                                          {}
    ;
/*#endregion  */

%%