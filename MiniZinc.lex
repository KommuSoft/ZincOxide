%namespace ZincOxide.MiniZinc
%option verbose, summary, noparser

kwAny any
kwType type
kwEnum enum
kwInclude include
kwConstraint constraint
kwSolve solve
kwSatisfy satisfy
kwMinimize minimize
kwMaximize maximize
kwOutput output
kwAnnotation annotation
kwPredicate predicate
kwTest test
kwFunction function
kwWhere where
kwVar var
kwPar par
ident [A-Za-z][A-Za-z0-9_]*

%%

{ident}   Console.WriteLine(yytext);

%%
public static void Main(string[] argp) {
	Console.WriteLine("This is ZincOxide version 0.1 (2013)");
	if (argp.Length == 0) {
		Console.WriteLine("Usage: [options] file");
		Console.WriteLine("Type \"zincoxide /help\" for more information.");
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