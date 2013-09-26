%using QUT.Gppg;

%namespace ZincOxide.Parser

%scannertype MiniZincLexer
%scanbasetype ScanBase
%tokentype Token

%option stack, minimize, parser, verbose, codepage:raw, out:../MiniZincLexer.cs

%option codepage:raw

KWTYPE      type
KWENUM      enum
KWINCL      include
KWCONS      constraint
KWSOLV      solve
KWSATI      satisfy
KWMINI      minimize
KWMAXI      maximize
KWOUTP      output
KWANNO      annotation
KWPRED      predicate
KWTEST      test
KWFUNC      function
KWWHER      where
KWVAR       var
KWPAR       par
KWBOOL      bool
KWINT       int
KWFLOA      float
KWSTRI      string
KWANN       ann
KWSET       set
KWOF        of
KWARRA      array
KWLIST      list
KWTUPL      tuple
KWRECO      record
KWANY       any
KWOP        op
KWIN        in
KWSUBS      subset
KWSUPE      superset
KWUNIO      union
KWDIFF      diff
KWSYMD      symdiff
KWINTE      intersect
KWXOR       xor
KWNOT       not
KWDIV       div
KWMOD       mod
KWIF        if
KWTHEN      then
KWELSI      elseif
KWELSE      else
KWENDI      endif
KWCASE      case
KWLET       let
COMMAD      ;
COMMA       ,
COLON       :
ACCENT      '
BAR         \x7c
OACC        \x7b
CACC        \x7d
OBRK        \x28
CBRK        \x29
OFBR        \x5b
CFBR        \x5d
OFBA        \x5b\x7c
CFBA        \x7c\x5d
OPASSIG     =
OPUNDSC     _
OPEQUIV     <->
OPIMPLI     ->
OPRIMPL     <-
OPVEE       \x5c\x5c/
OPWEDGE     /\x5c\x5c
OPLESTA     <
OPGRETA     >
OPLESEQ     <=
OPGEAEQ     >=
OPEQUAL     ==
OPNEQUA     !=
OPRANGE     \x2e\x2e
OPINCRE     \x2b\x2b
OPANNOT     ::
OPADD       \x2b
OPSUB       -
OPMUL       \x2a
OPDIV       /
OPDOT       \x2e
OPCASE      -->
BOOLI       true|false
INTLI       [0-9]+|0x[0-9A-Fa-f]+|0o[0-7]+
FLOLI       [0-9]+\x2e[0-9]+([Ee][\x2b\x2d]?[0-9]+)?|[0-9]+[Ee][\x2b\x2d]?[0-9]+
STRLI       \x22[^\x22]*\x22
IDENT       [A-Za-z][A-Za-z0-9_]*
DIDENT      \x24[A-Za-z][A-Za-z0-9_]*
NOISE       [ \t\r\n]+
COMMENT     \x25[^\x25\r\n]*
OTHER       .

%%
{COMMENT}     {}
{NOISE}       {}
{ACCENT}      { return (int) Token.ACCENT; }
{BAR}         { return (int) Token.BAR; }
{BOOLI}       { return (int) Token.BOOLI; }
{CACC}        { return (int) Token.CACC; }
{CBRK}        { return (int) Token.CBRK; }
{CFBA}        { return (int) Token.CFBA; }
{CFBR}        { return (int) Token.CFBR; }
{COLON}       { return (int) Token.COLON; }
{COMMAD}      { return (int) Token.COMMAD; }
{COMMA}       { return (int) Token.COMMA; }
{DIDENT}      { return (int) Token.DIDENT; }
{FLOLI}       { return (int) Token.FLOLI; }
{INTLI}       { return (int) Token.INTLI; }
{KWANNO}      { return (int) Token.KWANNO; }
{KWANN}       { return (int) Token.KWANN; }
{KWANY}       { return (int) Token.KWANY; }
{KWARRA}      { return (int) Token.KWARRA; }
{KWBOOL}      { return (int) Token.KWBOOL; }
{KWCASE}      { return (int) Token.KWCASE; }
{KWCONS}      { return (int) Token.KWCONS; }
{KWDIFF}      { return (int) Token.KWDIFF; }
{KWDIV}       { return (int) Token.KWDIV; }
{KWELSE}      { return (int) Token.KWELSE; }
{KWELSI}      { return (int) Token.KWELSI; }
{KWENDI}      { return (int) Token.KWENDI; }
{KWENUM}      { return (int) Token.KWENUM; }
{KWFLOA}      { return (int) Token.KWFLOA; }
{KWFUNC}      { return (int) Token.KWFUNC; }
{KWIF}        { return (int) Token.KWIF; }
{KWINCL}      { return (int) Token.KWINCL; }
{KWIN}        { return (int) Token.KWIN; }
{KWINTE}      { return (int) Token.KWINTE; }
{KWINT}       { return (int) Token.KWINT; }
{KWLET}       { return (int) Token.KWLET; }
{KWLIST}      { return (int) Token.KWLIST; }
{KWMAXI}      { return (int) Token.KWMAXI; }
{KWMINI}      { return (int) Token.KWMINI; }
{KWMOD}       { return (int) Token.KWMOD; }
{KWNOT}       { return (int) Token.KWNOT; }
{KWOF}        { return (int) Token.KWOF; }
{KWOP}        { return (int) Token.KWOP; }
{KWOUTP}      { return (int) Token.KWOUTP; }
{KWPAR}       { return (int) Token.KWPAR; }
{KWPRED}      { return (int) Token.KWPRED; }
{KWRECO}      { return (int) Token.KWRECO; }
{KWSATI}      { return (int) Token.KWSATI; }
{KWSET}       { return (int) Token.KWSET; }
{KWSOLV}      { return (int) Token.KWSOLV; }
{KWSTRI}      { return (int) Token.KWSTRI; }
{KWSUBS}      { return (int) Token.KWSUBS; }
{KWSUPE}      { return (int) Token.KWSUPE; }
{KWSYMD}      { return (int) Token.KWSYMD; }
{KWTEST}      { return (int) Token.KWTEST; }
{KWTHEN}      { return (int) Token.KWTHEN; }
{KWTUPL}      { return (int) Token.KWTUPL; }
{KWTYPE}      { return (int) Token.KWTYPE; }
{KWUNIO}      { return (int) Token.KWUNIO; }
{KWVAR}       { return (int) Token.KWVAR; }
{KWWHER}      { return (int) Token.KWWHER; }
{KWXOR}       { return (int) Token.KWXOR; }
{OPVEE}       { return (int) Token.OPVEE; }
{OPWEDGE}     { return (int) Token.OPWEDGE; }
{OACC}        { return (int) Token.OACC; }
{OBRK}        { return (int) Token.OBRK; }
{OFBA}        { return (int) Token.OFBA; }
{OFBR}        { return (int) Token.OFBR; }
{OPADD}       { return (int) Token.OPADD; }
{OPANNOT}     { return (int) Token.OPANNOT; }
{OPASSIG}     { return (int) Token.OPASSIG; }
{OPCASE}      { return (int) Token.OPCASE; }
{OPDIV}       { return (int) Token.OPDIV; }
{OPDOT}       { return (int) Token.OPDOT; }
{OPEQUAL}     { return (int) Token.OPEQUAL; }
{OPEQUIV}     { return (int) Token.OPEQUIV; }
{OPGEAEQ}     { return (int) Token.OPGEAEQ; }
{OPGRETA}     { return (int) Token.OPGRETA; }
{OPIMPLI}     { return (int) Token.OPIMPLI; }
{OPINCRE}     { return (int) Token.OPINCRE; }
{OPLESEQ}     { return (int) Token.OPLESEQ; }
{OPLESTA}     { return (int) Token.OPLESTA; }
{OPMUL}       { return (int) Token.OPMUL; }
{OPNEQUA}     { return (int) Token.OPNEQUA; }
{OPRANGE}     { return (int) Token.OPRANGE; }
{OPRIMPL}     { return (int) Token.OPRIMPL; }
{OPSUB}       { return (int) Token.OPSUB; }
{OPUNDSC}     { return (int) Token.OPUNDSC; }
{STRLI}       { return (int) Token.STRLI; }
{IDENT}       { return (int) Token.IDENT; }
{OTHER}       { throw new ZincOxideParserException("Unrecognized character \"{0}\"",yytext); }

/* ------------------------------------------ */
%{
    yylloc = new LexSpan(tokLin, tokCol, tokELin, tokECol, tokPos, tokEPos, buffer);
%}
/* ------------------------------------------ */

%%
public IEnumerable<Token> Tokenize() {
    int tok;
    do {
        tok = yylex();
        yield return (Token) tok;
    } while (tok > (int)Token.EOF);
}