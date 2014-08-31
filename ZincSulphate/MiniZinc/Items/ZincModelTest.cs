//
//  ZincModelTest.cs
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
using NUnit.Framework;
using ZincOxide.MiniZinc.Structures;
using ZincOxide.MiniZinc.Items;
using ZincOxide.Utils;

namespace ZincSulphate.MiniZinc.Items {

	[TestFixture()]
	public class ZincModelTest {

		[Test()]
		public void TestGenerateModel1 () {
			string model01 = string.Empty;
			string model02 = "par int : size;\n";
			string model03 = "par int : size;\npar array [ par 1 .. size , par 1 .. size ] of par int : d;\n";
			ZincModel zm = new ZincModel ();
			Assert.AreEqual (model01, zm.WriteString ());
			ZincIdent size = new ZincIdent ("size");
			zm.AddItem (new ZincVarDeclItem (new ZincTypeInstExprAndIdent (new ZincTypeInstBaseExpression (new ZincScalarType (ZincScalar.Int)), size)));
			Assert.AreEqual (model02, zm.WriteString ());
			ZincTypeInstBaseExpression range = new ZincTypeInstBaseExpression (new ZincTypeInstRangeExpression (new ZincIntLiteral (1), size));
			ZincIdent d = new ZincIdent ("d");
			zm.AddItem (new ZincVarDeclItem (new ZincTypeInstExprAndIdent (new ZincTypeInstBaseExpression (new ZincTypeInstArrayExpression (new ZincTypeInstBaseExpression (new ZincScalarType (ZincScalar.Int)), range, range)), d)));
			Assert.AreEqual (model03, zm.WriteString ());
		}

		[Test()]
		public void TestGenerateModel2 () {
			string model1 = string.Empty;
			string model2 = "include \"aninclude\";\n";
			ZincModel zm = new ZincModel ();
			Assert.AreEqual (model1, zm.WriteString ());
			zm.AddItem (new ZincIncludeItem ("aninclude"));
			Assert.AreEqual (model2, zm.WriteString ());
		}

	}
}

