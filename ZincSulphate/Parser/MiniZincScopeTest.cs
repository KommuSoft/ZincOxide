//
//  MiniZincScopeTest.cs
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using ZincOxide.MiniZinc.Items;
using ZincOxide.MiniZinc.Structures;
using ZincOxide.Parser;

namespace ZincSulphate {

	[TestFixture]
	public class MiniZincScopeTest {

		[Test()]
		public void TestScope0 () {
			MemoryStream ms = Content.GenerateContent0 ();
			MiniZincLexer scnr = new MiniZincLexer (ms);
			MiniZincParser pars = new MiniZincParser (scnr);
			pars.Parse ();
			ZincModel model = pars.Result;
			Assert.IsNotNull (model);
			model.CloseScope (null);
			//TODO: finish test
		}

		[Test()]
		public void TestScope2 () {
			MemoryStream ms = Content.GenerateContent2 ();
			MiniZincLexer scnr = new MiniZincLexer (ms);
			MiniZincParser pars = new MiniZincParser (scnr);
			pars.Parse ();
			ZincModel model = pars.Result;
			Assert.IsNotNull (model);
			model.CloseScope (null);
			ZincIdentNameRegister zinr = model.NameRegister;
			List<IZincIdent> iz = zinr.Elements ().ToList ();
			List<string> izn = iz.Select (x => x.Name).ToList ();
			Assert.AreEqual (4, izn.Count);
			Assert.Contains ("size", izn);
			Assert.Contains ("d", izn);
			Assert.Contains ("total", izn);
			Assert.Contains ("end", izn);
			Assert.AreEqual (6, model.Items.Count ());
			Assert.AreEqual (5, model.Items.OfType<ZincVarDeclItem> ().Count ());
			Assert.AreEqual (1, model.Items.OfType<ZincSolveItem> ().Count ());
			Assert.IsTrue (model.Items.OfType<ZincVarDeclItem> ().Any (x => x.DeclaredIdentifier == iz [0x00]));
			Assert.IsTrue (model.Items.OfType<ZincVarDeclItem> ().Any (x => x.DeclaredIdentifier == iz [0x01]));
			Assert.IsTrue (model.Items.OfType<ZincVarDeclItem> ().Any (x => x.DeclaredIdentifier == iz [0x02]));
			Assert.IsTrue (model.Items.OfType<ZincVarDeclItem> ().Any (x => x.DeclaredIdentifier == iz [0x03]));
			;
		}
	}
}

