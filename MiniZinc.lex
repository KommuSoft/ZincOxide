%namespace ZincOxide.MiniZinc
%option verbose, summary, noparser

BOOLLIT	true|false
INTLIT	[0-9]+|0x[0-9a-fA-F]+|0o[0-7]+
FLOATLIT [0-9]+\.[0-9]+|[0-9]+\.[0-9]+[Ee][-+]?[0-9]+|[0-9]+[Ee][-+]?[0-9]+
IDENT [A-Za-z][A-Za-z0-9_]*
ITEMSEP ;
OPENBR (
CLOSBR )
VARKW var
PARKW par
WHEREKW where
BOOLKW bool
INTKW int
FLOATKW float
COLON :
COMMA ,
ACCENT '
UNDERSCORE _
EQUIV
IMPL
RIMPL
VEE
XORKW
WEDGE
LT
GT
LE
GE
EQ
ASSIGNMENT
NEQ
INKW
SUBSETKW
SUPERSETKW
UNIONKW
DIFFKW
SYMDIFFKW
INTERVAL
INTERSECTKW
INCREMENT
NOTKW
ADDOP
SUBOP
MULOP
DIVOP
DIVKW
MODKW
OPENAC
CLOSEAC
CLOSKW
OPENFB
CLOSEFB
BAR
IFKW
THENKW
ELSEKW
ENDIFKW
ELSEIFKW
CASEKW
ARROW
EXPR
LETKW let
EOF

%%

{IDENT}   Console.WriteLine(yytext);

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
				Console.WriteLine("File: " + info.Name);
				do {
					tok = scnr.yylex();
				} while (tok > (int)Tokens.EOF);
			} catch (IOException) {
				Console.WriteLine("File " + name + " not found");
			}
		}
	}
}