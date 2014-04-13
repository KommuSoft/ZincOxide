//
//  MiniZincLexerTest.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.IO;
using NUnit.Framework;
using ZincOxide.Parser;

namespace ZincSulphate.Parser {

	[TestFixture()]
	public class MiniZincLexerTest {

		private const string str0 = "type =\tenum";
		private const string str1 = "= { } ,  \t: include = = constraint solve satisfy solve minimize solve maximize";
		private const string str2 = "output annotation predicate test function    :           =(,) (:where) var par bool int float string";
		private const string str3 = "ann {,} .. set of array of [,] of list of tuple (,) record (,) any $blahblah op (:(,))()_() <-> ->";
		private const string str4 = @"<- \/ xor /\ < > <= >= == = != in subset superset union diff symdiff  .. intersect ++ not ' ' + - * / div mod + - false true 9845 0xdeadbeaf465";
		private const string str5 = "0o04165247 0457411.1475214 0.565586451E12 4722.15415e-15 564145E5 145e+9 \"literal/string\" {,}{|}, where , in [ ] [| |] [ | ] [,] (,) . (,) :";
		private const string str6 = "if then elseif then else endif case --> let in anidentifier";
		private const string str7 = "'builtin' ::";
		private Token[] tokens = new Token[] {
			Token.KWTYPE,Token.OPASSIG, Token.KWENUM,//3
			Token.OPASSIG, Token.OACC, Token.CACC, Token.COMMA, Token.COLON, Token.KWINCL, Token.OPASSIG, Token.OPASSIG, Token.KWCONS, Token.KWSOLV, Token.KWSATI, Token.KWSOLV, Token.KWMINI, Token.KWSOLV, Token.KWMAXI,//18
			Token.KWOUTP, Token.KWANNO, Token.KWPRED, Token.KWTEST, Token.KWFUNC, Token.COLON, Token.OPASSIG, Token.OBRK, Token.COMMA, Token.CBRK, Token.OBRK, Token.COLON, Token.KWWHER, Token.CBRK, Token.KWVAR, Token.KWPAR, Token.KWBOOL, Token.KWINT, Token.KWFLOA, Token.KWSTRI,//38
			Token.KWANN, Token.OACC, Token.COMMA, Token.CACC, Token.OPRANGE, Token.KWSET, Token.KWOF, Token.KWARRA, Token.KWOF, Token.OFBR, Token.COMMA, Token.CFBR, Token.KWOF, Token.KWLIST, Token.KWOF, Token.KWTUPL, Token.OBRK, Token.COMMA, Token.CBRK, Token.KWRECO, Token.OBRK, Token.COMMA, Token.CBRK,Token.KWANY, Token.DIDENT, Token.KWOP, Token.OBRK, Token.COLON, Token.OBRK, Token.COMMA, Token.CBRK, Token.CBRK, Token.OBRK, Token.CBRK, Token.OPUNDSC, Token.OBRK, Token.CBRK, Token.OPEQUIV, Token.OPIMPLI,//77
			Token.OPRIMPL, Token.OPVEE, Token.KWXOR, Token.OPWEDGE, Token.OPLESTA, Token.OPGRETA, Token.OPLESEQ, Token.OPGEAEQ, Token.OPEQUAL, Token.OPASSIG, Token.OPNEQUA, Token.KWIN, Token.KWSUBS, Token.KWSUPE, Token.KWUNIO, Token.KWDIFF, Token.KWSYMD, Token.OPRANGE, Token.KWINTE, Token.OPINCRE, Token.KWNOT, Token.ACCENT, Token.ACCENT, Token.OPADD, Token.OPSUB, Token.OPMUL, Token.OPDIV, Token.KWDIV, Token.KWMOD, Token.OPADD, Token.OPSUB, Token.KWFALS, Token.KWTRUE, Token.INTLI, Token.INTLI,
			Token.INTLI, Token.FLOLI, Token.FLOLI, Token.FLOLI, Token.FLOLI, Token.STRLI, Token.OACC, Token.COLON, Token.CACC, Token.OACC, Token.BAR, Token.CACC, Token.COMMA, Token.KWWHER, Token.COMMA, Token.KWIN, Token.OFBA, Token.CFBA
		};

		[Test()]
		public void TestLexer1 () {
			byte[] data;
			using (MemoryStream ms = new MemoryStream()) {
				using (TextWriter tw = new StreamWriter (ms)) {
					tw.WriteLine (str0);
					tw.WriteLine (str1);
					tw.WriteLine (str2);
					tw.WriteLine (str3);
					tw.WriteLine (str4);
					tw.WriteLine (str5);
					tw.WriteLine (str6);
					tw.WriteLine (str7);
				}
				data = ms.GetBuffer ();
			}
			using (MemoryStream ms = new MemoryStream(data)) {
				MiniZincLexer scnr = new MiniZincLexer (ms);
				int index = 0x00;
				foreach (Token tok in scnr.Tokenize ()) {
					Console.WriteLine ("{0}/{1}", index, tok);
					Assert.AreEqual (tokens [index], tok);
					index++;
				}
			}

		}
	}
}

