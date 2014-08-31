//
//  Content.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2014 Willem Van Onsem
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
using ZincOxide.Parser;

namespace ZincSulphate {

	public static class Content {

		private const string str0_00 = "% (square) job shop scheduling in MiniZinc";
		private const string str0_01 = "int: size;                                  % size of problem";
		private const string str0_02 = "array [1..size,1..size] of int: d;          % task durations";
		private const string str0_03 = "int: total = sum(i,j in 1..size) (d[i,j]);  % total duration";
		private const string str0_04 = "array [1..size,1..size] of var 0..total: s; % start times";
		private const string str0_05 = "var 0..total: end;                          % total end time";
		private const string str0_06 = "predicate no_overlap(var int:s1, int:d1, var int:s2, int:d2) =";
		private const string str0_07 = "s1 + d1 <= s2 \\/ s2 + d2 <= s1;";
		private const string str0_08 = "constraint";
		private const string str0_09 = "forall(i in 1..size) (";
		private const string str0_10 = "forall(j in 1..size-1) (";
		private const string str0_11 = "s[i,j] + d[i,j] <= s[i,j+1]) /\\";
		private const string str0_12 = "s[i,size] + d[i,size] <= end /\\";
		private const string str0_13 = "forall(j,k in 1..size where j < k) (";
		private const string str0_14 = "no_overlap(s[j,i], d[j,i], s[k,i], d[k,i])";
		private const string str0_15 = ")";
		private const string str0_16 = ");";
		private const string str0_17 = "solve minimize end;";
		private const string str1_0 = "type =\tenum";
		private const string str1_1 = "= { } ,  \t: include = = constraint solve satisfy solve minimize solve maximize";
		private const string str1_2 = "output annotation predicate test function    :           =(,) (:where) var par bool int float string";
		private const string str1_3 = "ann {,} .. set of array of [,] of list of tuple (,) record (,) any $blahblah op (:(,))()_() <-> ->";
		private const string str1_4 = @"<- \/ xor /\ < > <= >= == = != in subset superset union diff symdiff  .. intersect ++ not ' ' + - * / div mod + - false true 9845 0xdeadbeaf465";
		private const string str1_5 = "0o04165247 0457411.1475214 0.565586451E12 4722.15415e-15 564145E5 145e+9 \"literal/string\" {,}{|}, where , in [ ] [| |] [ | ] [,] (,) . (,) :";
		private const string str1_6 = "if then elseif then else endif case --> let in anidentifier";
		private const string str1_7 = "'builtin' ::";
		private const string str2_0 = "% (square) job shop scheduling in MiniZinc";
		private const string str2_1 = "int: size;                                  % size of problem";
		private const string str2_2 = "array [1..size,1..size] of int: d;          % task durations";
		private const string str2_3 = "int: total = sum(i,j in 1..size) (d[i,j]);  % total duration";
		private const string str2_4 = "array [1..size,1..size] of var 0..total: s; % start times";
		private const string str2_5 = "var 0..total: end;                          % total end time";
		private const string str2_6 = "solve minimize end;";
		public const int NItems0 = 8;
		public static readonly Token[] Tokens0 = new Token[] {
			Token.KWINT, Token.COLON, Token.IDENT, Token.COMMAD,
			Token.KWARRA, Token.OFBR, Token.INTLI, Token.OPRANGE, Token.IDENT, Token.COMMA, Token.INTLI, Token.OPRANGE, Token.IDENT, Token.CFBR, Token.KWOF, Token.KWINT, Token.COLON, Token.IDENT, Token.COMMAD,
			Token.KWINT, Token.COLON, Token.IDENT, Token.OPASSIG, Token.IDENT, Token.OBRK, Token.IDENT, Token.COMMA, Token.IDENT, Token.KWIN, Token.INTLI, Token.OPRANGE, Token.IDENT, Token.CBRK, Token.OBRK, Token.IDENT, Token.OFBR, Token.IDENT, Token.COMMA, Token.IDENT, Token.CFBR, Token.CBRK, Token.COMMAD,
			Token.KWARRA, Token.OFBR, Token.INTLI, Token.OPRANGE, Token.IDENT, Token.COMMA, Token.INTLI, Token.OPRANGE, Token.IDENT, Token.CFBR, Token.KWOF, Token.KWVAR, Token.INTLI, Token.OPRANGE, Token.IDENT, Token.COLON, Token.IDENT, Token.COMMAD,
			Token.KWVAR, Token.INTLI, Token.OPRANGE, Token.IDENT, Token.COLON, Token.IDENT, Token.COMMAD,
			Token.KWPRED, Token.IDENT, Token.OBRK, Token.KWVAR, Token.KWINT, Token.COLON, Token.IDENT, Token.COMMA, Token.KWINT, Token.COLON, Token.IDENT, Token.COMMA, Token.KWVAR, Token.KWINT, Token.COLON, Token.IDENT, Token.COMMA, Token.KWINT, Token.COLON, Token.IDENT, Token.CBRK, Token.OPASSIG,
			Token.IDENT, Token.OPADD, Token.IDENT, Token.OPLESEQ, Token.IDENT, Token.OPVEE, Token.IDENT, Token.OPADD, Token.IDENT, Token.OPLESEQ, Token.IDENT, Token.COMMAD,
			Token.KWCONS,
			Token.IDENT, Token.OBRK, Token.IDENT, Token.KWIN, Token.INTLI, Token.OPRANGE, Token.IDENT, Token.CBRK, Token.OBRK,
			Token.IDENT, Token.OBRK, Token.IDENT, Token.KWIN, Token.INTLI, Token.OPRANGE, Token.IDENT, Token.OPSUB, Token.INTLI, Token.CBRK, Token.OBRK,
			Token.IDENT, Token.OFBR, Token.IDENT, Token.COMMA, Token.IDENT, Token.CFBR, Token.OPADD, Token.IDENT, Token.OFBR, Token.IDENT, Token.COMMA, Token.IDENT, Token.CFBR, Token.OPLESEQ, Token.IDENT, Token.OFBR, Token.IDENT, Token.COMMA, Token.IDENT, Token.OPADD, Token.INTLI, Token.CFBR, Token.CBRK, Token.OPWEDGE,
			Token.IDENT, Token.OFBR, Token.IDENT, Token.COMMA, Token.IDENT, Token.CFBR, Token.OPADD, Token.IDENT, Token.OFBR, Token.IDENT, Token.COMMA, Token.IDENT, Token.CFBR, Token.OPLESEQ, Token.IDENT, Token.OPWEDGE,
			Token.IDENT, Token.OBRK, Token.IDENT, Token.COMMA, Token.IDENT, Token.KWIN, Token.INTLI, Token.OPRANGE, Token.IDENT, Token.KWWHER, Token.IDENT, Token.OPLESTA, Token.IDENT, Token.CBRK, Token.OBRK,
			Token.IDENT, Token.OBRK, Token.IDENT, Token.OFBR, Token.IDENT, Token.COMMA, Token.IDENT, Token.CFBR, Token.COMMA, Token.IDENT, Token.OFBR, Token.IDENT, Token.COMMA, Token.IDENT, Token.CFBR, Token.COMMA, Token.IDENT, Token.OFBR, Token.IDENT, Token.COMMA, Token.IDENT, Token.CFBR, Token.COMMA, Token.IDENT, Token.OFBR, Token.IDENT, Token.COMMA, Token.IDENT, Token.CFBR, Token.CBRK,
			Token.CBRK,
			Token.CBRK, Token.COMMAD,
			Token.KWSOLV, Token.KWMINI, Token.IDENT, Token.COMMAD, Token. EOF
		};
		public static readonly Token[] Tokens1 = new Token[] {
			Token.KWTYPE, Token.OPASSIG, Token.KWENUM,//3
			Token.OPASSIG, Token.OACC, Token.CACC, Token.COMMA, Token.COLON, Token.KWINCL, Token.OPASSIG, Token.OPASSIG, Token.KWCONS, Token.KWSOLV, Token.KWSATI, Token.KWSOLV, Token.KWMINI, Token.KWSOLV, Token.KWMAXI,//18
			Token.KWOUTP, Token.KWANNO, Token.KWPRED, Token.KWTEST, Token.KWFUNC, Token.COLON, Token.OPASSIG, Token.OBRK, Token.COMMA, Token.CBRK, Token.OBRK, Token.COLON, Token.KWWHER, Token.CBRK, Token.KWVAR, Token.KWPAR, Token.KWBOOL, Token.KWINT, Token.KWFLOA, Token.KWSTRI,//38
			Token.KWANN, Token.OACC, Token.COMMA, Token.CACC, Token.OPRANGE, Token.KWSET, Token.KWOF, Token.KWARRA, Token.KWOF, Token.OFBR, Token.COMMA, Token.CFBR, Token.KWOF, Token.KWLIST, Token.KWOF, Token.KWTUPL, Token.OBRK, Token.COMMA, Token.CBRK, Token.KWRECO, Token.OBRK, Token.COMMA, Token.CBRK, Token.KWANY, Token.DIDENT, Token.KWOP, Token.OBRK, Token.COLON, Token.OBRK, Token.COMMA, Token.CBRK, Token.CBRK, Token.OBRK, Token.CBRK, Token.OPUNDSC, Token.OBRK, Token.CBRK, Token.OPEQUIV, Token.OPIMPLI,//77
			Token.OPRIMPL, Token.OPVEE, Token.KWXOR, Token.OPWEDGE, Token.OPLESTA, Token.OPGRETA, Token.OPLESEQ, Token.OPGEAEQ, Token.OPEQUAL, Token.OPASSIG, Token.OPNEQUA, Token.KWIN, Token.KWSUBS, Token.KWSUPE, Token.KWUNIO, Token.KWDIFF, Token.KWSYMD, Token.OPRANGE, Token.KWINTE, Token.OPINCRE, Token.KWNOT, Token.ACCENT, Token.ACCENT, Token.OPADD, Token.OPSUB, Token.OPMUL, Token.OPDIV, Token.KWDIV, Token.KWMOD, Token.OPADD, Token.OPSUB, Token.BOOLI, Token.BOOLI, Token.INTLI, Token.INTLI,
			Token.INTLI, Token.FLOLI, Token.FLOLI, Token.FLOLI, Token.FLOLI, Token.FLOLI, Token.STRLI, Token.OACC, Token.COMMA, Token.CACC, Token.OACC, Token.BAR, Token.CACC, Token.COMMA, Token.KWWHER, Token.COMMA, Token.KWIN, Token.OFBR, Token.CFBR, Token.OFBA, Token.CFBA, Token.OFBR, Token.BAR, Token.CFBR, Token.OFBR, Token.COMMA, Token.CFBR, Token.OBRK, Token.COMMA, Token.CBRK, Token.OPDOT, Token.OBRK, Token.COMMA, Token.CBRK, Token.COLON,
			Token.KWIF, Token.KWTHEN, Token.KWELSI, Token.KWTHEN, Token.KWELSE, Token.KWENDI, Token.KWCASE, Token.OPCASE, Token.KWLET, Token.KWIN, Token.IDENT,
			Token.ACCENT, Token.IDENT, Token.ACCENT, Token.OPANNOT, Token.EOF
		};

		public static MemoryStream GenerateContent0 () {
			byte[] data;
			using (MemoryStream ms = new MemoryStream()) {
				using (TextWriter tw = new StreamWriter (ms)) {
					tw.WriteLine (str0_00);
					tw.WriteLine (str0_01);
					tw.WriteLine (str0_02);
					tw.WriteLine (str0_03);
					tw.WriteLine (str0_04);
					tw.WriteLine (str0_05);
					tw.WriteLine (str0_06);
					tw.WriteLine (str0_07);
					tw.WriteLine (str0_08);
					tw.WriteLine (str0_09);
					tw.WriteLine (str0_10);
					tw.WriteLine (str0_11);
					tw.WriteLine (str0_12);
					tw.WriteLine (str0_13);
					tw.WriteLine (str0_14);
					tw.WriteLine (str0_15);
					tw.WriteLine (str0_16);
					tw.WriteLine (str0_17);
				}
				data = ms.GetBuffer ();
			}
			return new MemoryStream (data);
		}

		public static MemoryStream GenerateContent1 () {
			byte[] data;
			using (MemoryStream ms = new MemoryStream()) {
				using (TextWriter tw = new StreamWriter (ms)) {
					tw.WriteLine (str1_0);
					tw.WriteLine (str1_1);
					tw.WriteLine (str1_2);
					tw.WriteLine (str1_3);
					tw.WriteLine (str1_4);
					tw.WriteLine (str1_5);
					tw.WriteLine (str1_6);
					tw.WriteLine (str1_7);
				}
				data = ms.GetBuffer ();
			}
			return new MemoryStream (data);
		}

		public static MemoryStream GenerateContent2 () {
			byte[] data;
			using (MemoryStream ms = new MemoryStream()) {
				using (TextWriter tw = new StreamWriter (ms)) {
					tw.WriteLine (str2_0);
					tw.WriteLine (str2_1);
					tw.WriteLine (str2_2);
					tw.WriteLine (str2_3);
					tw.WriteLine (str2_4);
					tw.WriteLine (str2_5);
					tw.WriteLine (str2_6);
				}
				data = ms.GetBuffer ();
			}
			return new MemoryStream (data);
		}
	}
}

