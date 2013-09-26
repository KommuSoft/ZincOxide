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

%using ZincOxide.MiniZinc.Items;
%using ZincOxide.MiniZinc.Structures;
%using ZincOxide.Utils;

%tokentype Token

%visibility public

%partial 
%union {
    public HeadTail<IZincItem> hti;
    public HeadTail<ZincAnnotation> hta;
    public HeadTail<IZincTypeInstExpression> httie;
    public HeadTail<ZincTypeInstExprAndIdent> httia;
    public IZincItem i;
    public IZincType t;
    public IZincExp e;
    public ZincAnnotations at;
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
%type <httia> params
%type <i> item includeItem varDeclItem assignItem constraintItem solveItem outputItem predicateItem functionItem
%type <t> baseTiExprTail arrayTiExprTail setTiExprTail
%type <vp> varPar
%type <id> ident
%type <tie> tiExpr baseTiExpr
%type <tia> tiExprAndId
%type <ne> numExp
%type <e> expr
%type <at> annotations

%%

/*#region Items  */
model
    : itemListO EOF                                                     {this.result = new ZincModel($1);}
    ;

itemListO
    : item itemList                                                     {$$ = $1&$2;}
    ;

itemList
    :                                                                   {$$ = (HeadTail<IZincItem>) null;}
    | COMMAD                                                            {$$ = (HeadTail<IZincItem>) null;}
    | COMMAD item itemList                                              {$$ = $2&$3;}
    | COMMAD error itemList                                             {$$ = $3; Interaction.ParsingError(@2,"I cannot parse the ZincItem, I will ignore it.");}
    ;

item
    : includeItem                                                       {$$ = $1;}
    | varDeclItem                                                       {$$ = $1;}
    | assignItem                                                        {$$ = $1;}
    | constraintItem                                                    {$$ = $1;}
    | solveItem                                                         {$$ = $1;}
    | outputItem                                                        {$$ = $1;}
    | predicateItem                                                     {$$ = $1;}
    | functionItem                                                      {$$ = $1;}
    ;

tiExprAndId
    : tiExpr COLON ident                                                {$$ = new ZincTypeInstExprAndIdent($1,$3);}
    ;

includeItem
    : KWINCL STRLI                                                      {$$ = new ZincIncludeItem(@2.LiteralString());}
    ;

varDeclItem
    : tiExprAndId annotations                                           {$$ = new ZincVarDeclItem($1,$2);}
    | tiExprAndId annotations OPASSIG expr                              {$$ = new ZincVarDeclItem($1,$2,$4);}
    ;

assignItem
    : ident OPASSIG expr                                                {$$ = new ZincAssignItem($1,$3);}
    ;

constraintItem
    : KWCONS expr                                                       {$$ = new ZincConstraintItem($2);}
    ;

solveItem
    : KWSOLV annotations KWSATI                                         {$$ = new ZincSolveItem($2);}
    | KWSOLV annotations KWMAXI expr                                    {$$ = new ZincSolveItem($2,ZincSolveType.Maximize,$4);}
    | KWSOLV annotations KWMINI expr                                    {$$ = new ZincSolveItem($2,ZincSolveType.Minimize,$4);}
    ;

outputItem
    : KWOUTP expr                                                       {$$ = new ZincOutputItem($2);}
    ;

predicateItem
    : KWPRED ident params annotations                                   {$$ = new ZincPredicateItem($2,$3,$4);}
    | KWPRED ident params annotations OPASSIG expr                      {$$ = new ZincPredicateItem($2,$3,$4,$6);}
    ;

functionItem
    : KWFUNC tiExpr COLON ident params annotations                      {$$ = new ZincFunctionItem($2,$4,$5,$6);}
    | KWFUNC tiExpr COLON ident params annotations OPASSIG expr         {$$ = new ZincFunctionItem($2,$4,$5,$6,$8);}
    ;

params
    :                                                                   {$$ = (HeadTail<ZincTypeInstExprAndIdent>) null;}
    | COMMA                                                             {$$ = (HeadTail<ZincTypeInstExprAndIdent>) null;}
    | tiExprAndId COMMA params                                          {$$ = $1&$3;}
    ;
/*#endregion  */

/*#region Type-Inst Expressions  */
tiExpr
    : baseTiExpr                                                        {$$ = $1;}
    ;

varPar
    :                                                                   {$$ = ZincVarPar.Par;}
    | KWVAR                                                             {$$ = ZincVarPar.Var;}
    | KWPAR                                                             {$$ = ZincVarPar.Par;}
    ;

baseTiExpr
    : varPar baseTiExprTail                                             {$$ = new ZincTypeInstBaseExpression($1,$2);}
    ;

baseTiExprTail
    : KWBOOL                                                            {$$ = new ZincScalarType(ZincScalar.Bool);}
    | KWINT                                                             {$$ = new ZincScalarType(ZincScalar.Int);}
    | KWFLOA                                                            {$$ = new ZincScalarType(ZincScalar.Float);}
    | setTiExprTail                                                     {$$ = $1;}
    | arrayTiExprTail                                                   {$$ = $1;}
    | tupleTiExprTail                                                   {$$ = $1;}
    | numExp OPRANGE numExp                                             {$$ = new ZincTypeInstRangeExpression($1,$3);}
    ;

setTiExprTail
    : KWSET OFBR tiExpr                                                 {$$ = new ZincTypeInstSetExpression($3);}
    ;

arrayTiExprTail
    : KWARRA OFBR tiExprListO CFBR KWOF tiExpr                          {$$ = new ZincTypeInstArrayExpression($6,$3);}
    ;

tupleTiExprTail
    : KWTUP OBRK tiExprListO CBRK                                       {$$ = new ZincTypeInstTupleExpression($3);}
    ;

tiExprListO
    : tiExpr tiExprList                                                 {$$ = $1&$2;}
    ;

tiExprList
    :                                                                   {$$ = (HeadTail<IZincTypeInstExpression>) null;}
    | COMMA                                                             {$$ = (HeadTail<IZincTypeInstExpression>) null;}
    | COMMA tiExpr tiExprList                                           {$$ = $2&$3;}
    ;
/*#endregion  */

/*#region Expressions  */
expr
    : numExp                                                            {$$ = $1;}
    ;

%left OPEQUIV
%left OPIMPLI OPRIMPL
%left OPVEE KWXOR
%left OPWEDGE

numExp
    : OBRK numExp CBRK                                                  {$$ = $2;}
    | ident                                                             {$$ = $1;}
    | INTLI                                                             {$$ = new ZincIntLiteral(@1.ToString());}
    | numExpr OPINCRE numExpr                                           {}
    | numExpr OPINCRE numExpr                                           {}
    | numExpr OPVEE numExpr                                             {}
    | numExpr KWXOR numExpr                                             {}
    | numExpr OPWEDGE numExpr                                           {}
    | numExpr OPLESTA numExpr                                           {}
    | numExpr OPGRETA numExpr                                           {}
    | numExpr OPLESEQ numExpr                                           {}
    | numExpr OPGEAEQ numExpr                                           {}
    | numExpr OPEQUAL numExpr                                           {}
    | numExpr OPASSIG numExpr                                           {}
    | numExpr OPNEQUA numExpr                                           {}
    | numExpr KWSUBS numExpr                                            {}
    | numExpr KWSUPE numExpr                                            {}
    | numExpr KWIN numExpr                                              {}
    | numExpr KWSUBS numExpr                                            {}
    | numExpr KWSUPE numExpr                                            {}
    | numExpr KWUNIO numExpr                                            {}
    | numExpr KWDIFF numExpr                                            {}
    | numExpr KWSYMD numExpr                                            {}
    | numExpr OPRANGE numExpr                                           {}
    | numExpr OPSUB numExpr                                             {}
    | numExpr OPADD numExpr                                             {}
    | numExpr KWINTE numExpr                                            {}
    | numExpr OPDIV numExpr                                             {}
    | numExpr KWMOD numExpr                                             {}
    | numExpr OPMUL numExpr                                             {}
    | numExpr OPINCRE numExpr                                           {}
    ;
/*#endregion  */

/*#region Miscellaneous Elements  */
ident
    : IDENT                                                             {$$ = new ZincIdent(@1.ToString());}
    ;

annotations
    :                                                                   {$$ = new ZincAnnotations();}
    ;
/*#endregion  */

%%