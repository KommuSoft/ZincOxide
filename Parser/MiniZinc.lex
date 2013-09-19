%namespace ZincOxide.Parser
%using System;
%option noparser

KWTYPE type
KWENUM enum
KWINCL include
KWCONS constraint
KWSOLV solve
KWSATI satisfy
KWMINI minimize
KWMAXI maximize
KWOUTP output
KWANNO annotation
KWPRED predicate
KWTEST test
KWFUNC function
KWWHER where
KWVAR var
KWPAR par
KWBOOL bool
KWINT int
KWFLOA float
KWSTRI string
KWANN ann
KWSET set
KWOF of
KWARRA array
KWLIST list
KWTUPL tuple
KWRECO record
KWANY any
KWOP op
KWIN in
KWSUBS subset
KWSUPE superset
KWUNIO union
KWDIFF diff
KWSYMD symdiff
KWINTE intersect
KWXOR xor
KWNOT not
KWDIV div
KWMOD mod
KWFALS false
KWTRUE true
KWIF if
KWTHEN then
KWELSI elseif
KWELSE else
KWENDI endif
KWCASE case
KWLET let
COMMAD ;
COMMA ,
COLON :
ACCENT '
BAR \|
OACC \{
CACC \}
OBRK \(
CBRK \)
OFBR \[
OFBA \[\|
CFBA \|\]
OPASSIG =
OPUNDSC _
OPEQUIV <->
OPIMPLI ->
OPRIMPL <-
OPVEE \\/
OPWEDGE /\\
OPLESTA <
OPGRETA >
OPLESEQ <=
OPGEAEQ >=
OPEQUAL ==
OPNEQUA !=
OPRANGE ..
OPINCRE \+\+
OPANNOT ::
OPADD \+
OPSUB -
OPMUL \*
OPDIV /
OPDOT \.
OPCASE -->
BOOLI true|false
INTLI [0-9]+|0x[0-9A-Fa-f]+|0o[0-7]+
FLOLI [0-9]+\.[0-9]+([Ee][+\-]?[0-9]+)?|[0-9]+[Ee][+\-]?[0-9]+
STRLI \"[^\"]*\"
IDENT [A-Za-z][A-Za-z0-9_]*
DIDENT \$[A-Za-z][A-Za-z0-9_]*
NOISE [ \t]+
EOL   (\r\n?|\n)
COMMENT \%[^%\r\n]*

%%

%%
public void Tokenize(Stream stream) {
    Scanner scnr = new Scanner(file);
    Console.WriteLine("Processing file: " + info.Name);
    do {
        tok = scnr.yylex();
        Console.WriteLine(tok);
    } while (tok > (int)Tokens.EOF);
}