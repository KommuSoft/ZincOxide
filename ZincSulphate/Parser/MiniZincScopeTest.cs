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
using System.IO;
using NUnit.Framework;
using ZincOxide.Parser;
using ZincOxide.MiniZinc.Items;
using System.Linq;
using ZincOxide.MiniZinc.Structures;
using System;

namespace ZincSulphate {

	[TestFixture]
	public class MiniZincScopeTest {

		[Test()]
		public void TestScope0 () {
			using (MemoryStream ms = Content.GenerateContent0 ()) {
				MiniZincLexer scnr = new MiniZincLexer (ms);
				MiniZincParser pars = new MiniZincParser (scnr);
				pars.Parse ();
				ZincModel model = pars.Result;
				Assert.IsNotNull (model);
				model.CloseScope (null);
				ZincIdentNameRegister zinr = model.NameRegister;
				//Console.WriteLine ("end");
			}

		}
	}
}

