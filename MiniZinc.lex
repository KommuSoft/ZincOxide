%namespace ZincOxide.MiniZinc
%using System;
%option noparser

KWTYPE type
KWENUM enum
KWINCL include
KWCONS constraint
KWSOLV solve
KWSATI satisfy
KWMINI minimize
MWMAXI maximize
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
public static void Main(string[] argp) {
	Console.WriteLine("This is ZincOxide version 0.1 (2013)");
	if (argp.Length == 0) {
		Console.WriteLine("Usage: [options] file");
		Console.WriteLine("Type \"zincoxide --help\" for more information.");
	}
	DirectoryInfo dirInfo = new DirectoryInfo(".");
	for (int i = 0; i < argp.Length; i++) {
		string name = argp[i];
		FileInfo[] fInfo = dirInfo.GetFiles(name);
		foreach (FileInfo info in fInfo) {
			try {
				int tok;
				FileStream file = new FileStream(info.Name, FileMode.Open); 
				Scanner scnr = new Scanner(file);
				Console.WriteLine("Processing file: " + info.Name);
				do {
					tok = scnr.yylex();
					Console.WriteLine(tok);
				} while (tok > (int)Tokens.EOF);
			} catch (IOException) {
				Console.WriteLine("File " + name + " not found");
			}
		}
	}
}