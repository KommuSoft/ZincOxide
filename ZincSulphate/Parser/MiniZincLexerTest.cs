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
using System.IO;
using NUnit.Framework;

namespace ZincSulphate.Parser {

    [TestFixture()]
    public class MiniZincLexerTest {

        [Test()]
        public void TestLexer1 () {
            using (MemoryStream ms = new MemoryStream()) {
                TextWriter tw = new StreamWriter (ms);
                tw.WriteLine ("type =\tenum");
                tw.WriteLine ("= { } ,  \t: include = = constraint solve satisfy solve minimize solve maximize");
                tw.WriteLine ("output annotation predicate test function    :           =(,) (:where) var par bool int float string");
                tw.WriteLine ("ann {,} .. set of array of [,] of list of tuple (,) record (,) any $blahblah op (:(,))()_() <-> ->");
                tw.WriteLine (@"<- \/ xor /\ < > <= >= == = != in subset superset union diff symdiff  .. intersect ++ not ' ' + - * / div mod + - false true 9845 0xdeadbeaf465");
                tw.WriteLine ("0o04165247 0457411.1475214 0.565586451E12 4722.15415e-15 564145E5 145e+9 \"literal/string\" {,}{|}, where , in [ ] [| |] [ | ] [,] (,) . (,) :");
                tw.WriteLine ("if then elseif then else endif case --> let in anidentifier");
                tw.WriteLine ("'builtin' ::");
                //TODO finish test
            }
        }
    }
}

