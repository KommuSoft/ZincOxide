/*
 *  Process with > gplex ZincOutput.ll
 */

%using QUT.Gppg;

%namespace ZincOxide.Parser

%scannertype ZincOutputLexer
%scanbasetype ScanBase
%tokentype OutputToken

%option stack, minimize, parser, verbose, codepage:raw, out:../ZincOutputLexer.cs

%option codepage:raw

SOLCOM      ----------\n
NOSOL       === NO SOLUTIONS ===\n
NOMSL       === NO MORE SOLUTIONS ===\n
NOBSL       === NO BETTER SOLUTIONS ===\n
SCOM        Search complete:
SMIU        the model instance is unsatisfiable\.
SSSC        the solution set is complete\.
SLSO        the last solution is optimal\.
WARN        Warnings \n
SICP        Search incomplete: \n
LINE        [^\n]*\n
NLN         \n
TWSP        2SP
FRSP        4SP
OTHER       .

%%
{SOLCOM}      { return (int) Token.SOLCOM; }
{NOSOL}       { return (int) Token.NOSOL; }
{NOMSL}       { return (int) Token.NOMSL; }
{NOBSL}       { return (int) Token.NOBSL; }
{SCOM}        { return (int) Token.SCOM; }
{SMIU}        { return (int) Token.SNIU; }
{SSSC}        { return (int) Token.SSSC; }
{SLSO}        { return (int) Token.SLSO; }
{WARN}        { return (int) Token.WARN; }
{SICP}        { return (int) Token.SICP; }
{TWSP}        { return (int) Token.TWSP; }
{FRSP}        { return (int) Token.FRSP; }
{LINE}        { return (int) Token.LINE; }
{NLN}         { return (int) Token.NLN; }
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