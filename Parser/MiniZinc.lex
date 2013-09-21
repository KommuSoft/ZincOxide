%using QUT.Gppg;

%namespace ZincOxide.Parser

%scannertype Scanner
%scanbasetype ScanBase
%tokentype Tokens

%option stack, minimize, parser, verbose, codepage:raw, out:MiniZincLexer.cs

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
OPVEE       \x5c/
OPWEDGE     /\x5c
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
{ACCENT}      { return (int) Tokens.ACCENT; }
{BAR}         { return (int) Tokens.BAR; }
{BOOLI}       { return (int) Tokens.BOOLI; }
{CACC}        { return (int) Tokens.CACC; }
{CBRK}        { return (int) Tokens.CBRK; }
{CFBA}        { return (int) Tokens.CFBA; }
{CFBR}        { return (int) Tokens.CFBR; }
{COLON}       { return (int) Tokens.COLON; }
{COMMAD}      { return (int) Tokens.COMMAD; }
{COMMA}       { return (int) Tokens.COMMA; }
{DIDENT}      { return (int) Tokens.DIDENT; }
{FLOLI}       { return (int) Tokens.FLOLI; }
{INTLI}       { return (int) Tokens.INTLI; }
{KWANNO}      { return (int) Tokens.KWANNO; }
{KWANN}       { return (int) Tokens.KWANN; }
{KWANY}       { return (int) Tokens.KWANY; }
{KWARRA}      { return (int) Tokens.KWARRA; }
{KWBOOL}      { return (int) Tokens.KWBOOL; }
{KWCASE}      { return (int) Tokens.KWCASE; }
{KWCONS}      { return (int) Tokens.KWCONS; }
{KWDIFF}      { return (int) Tokens.KWDIFF; }
{KWDIV}       { return (int) Tokens.KWDIV; }
{KWELSE}      { return (int) Tokens.KWELSE; }
{KWELSI}      { return (int) Tokens.KWELSI; }
{KWENDI}      { return (int) Tokens.KWENDI; }
{KWENUM}      { return (int) Tokens.KWENUM; }
{KWFLOA}      { return (int) Tokens.KWFLOA; }
{KWFUNC}      { return (int) Tokens.KWFUNC; }
{KWIF}        { return (int) Tokens.KWIF; }
{KWINCL}      { return (int) Tokens.KWINCL; }
{KWIN}        { return (int) Tokens.KWIN; }
{KWINTE}      { return (int) Tokens.KWINTE; }
{KWINT}       { return (int) Tokens.KWINT; }
{KWLET}       { return (int) Tokens.KWLET; }
{KWLIST}      { return (int) Tokens.KWLIST; }
{KWMAXI}      { return (int) Tokens.KWMAXI; }
{KWMINI}      { return (int) Tokens.KWMINI; }
{KWMOD}       { return (int) Tokens.KWMOD; }
{KWNOT}       { return (int) Tokens.KWNOT; }
{KWOF}        { return (int) Tokens.KWOF; }
{KWOP}        { return (int) Tokens.KWOP; }
{KWOUTP}      { return (int) Tokens.KWOUTP; }
{KWPAR}       { return (int) Tokens.KWPAR; }
{KWPRED}      { return (int) Tokens.KWPRED; }
{KWRECO}      { return (int) Tokens.KWRECO; }
{KWSATI}      { return (int) Tokens.KWSATI; }
{KWSET}       { return (int) Tokens.KWSET; }
{KWSOLV}      { return (int) Tokens.KWSOLV; }
{KWSTRI}      { return (int) Tokens.KWSTRI; }
{KWSUBS}      { return (int) Tokens.KWSUBS; }
{KWSUPE}      { return (int) Tokens.KWSUPE; }
{KWSYMD}      { return (int) Tokens.KWSYMD; }
{KWTEST}      { return (int) Tokens.KWTEST; }
{KWTHEN}      { return (int) Tokens.KWTHEN; }
{KWTUPL}      { return (int) Tokens.KWTUPL; }
{KWTYPE}      { return (int) Tokens.KWTYPE; }
{KWUNIO}      { return (int) Tokens.KWUNIO; }
{KWVAR}       { return (int) Tokens.KWVAR; }
{KWWHER}      { return (int) Tokens.KWWHER; }
{KWXOR}       { return (int) Tokens.KWXOR; }
{OPVEE}       { return (int) Tokens.OPVEE; }
{OPWEDGE}     { return (int) Tokens.OPWEDGE; }
{OACC}        { return (int) Tokens.OACC; }
{OBRK}        { return (int) Tokens.OBRK; }
{OFBA}        { return (int) Tokens.OFBA; }
{OFBR}        { return (int) Tokens.OFBR; }
{OPADD}       { return (int) Tokens.OPADD; }
{OPANNOT}     { return (int) Tokens.OPANNOT; }
{OPASSIG}     { return (int) Tokens.OPASSIG; }
{OPCASE}      { return (int) Tokens.OPCASE; }
{OPDIV}       { return (int) Tokens.OPDIV; }
{OPDOT}       { return (int) Tokens.OPDOT; }
{OPEQUAL}     { return (int) Tokens.OPEQUAL; }
{OPEQUIV}     { return (int) Tokens.OPEQUIV; }
{OPGEAEQ}     { return (int) Tokens.OPGEAEQ; }
{OPGRETA}     { return (int) Tokens.OPGRETA; }
{OPIMPLI}     { return (int) Tokens.OPIMPLI; }
{OPINCRE}     { return (int) Tokens.OPINCRE; }
{OPLESEQ}     { return (int) Tokens.OPLESEQ; }
{OPLESTA}     { return (int) Tokens.OPLESTA; }
{OPMUL}       { return (int) Tokens.OPMUL; }
{OPNEQUA}     { return (int) Tokens.OPNEQUA; }
{OPRANGE}     { return (int) Tokens.OPRANGE; }
{OPRIMPL}     { return (int) Tokens.OPRIMPL; }
{OPSUB}       { return (int) Tokens.OPSUB; }
{OPUNDSC}     { return (int) Tokens.OPUNDSC; }
{STRLI}       { return (int) Tokens.STRLI; }
{IDENT}       { return (int) Tokens.IDENT; }
{OTHER}       { throw new ZincOxideParserException("Unrecognized character \"{0}\"",yytext); }

%%
public IEnumerable<Tokens> Tokenize() {
    int tok;
    do {
        tok = yylex();
        yield return (Tokens) tok;
    } while (tok > (int)Tokens.EOF);
}