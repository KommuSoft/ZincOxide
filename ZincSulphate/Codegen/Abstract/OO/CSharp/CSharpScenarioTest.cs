//
//  CSharpScenarioTest.cs
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
using NUnit.Framework;
using System;
using ZincOxide.Codegen.Abstract.OO.CSharp;
using ZincOxide.Codegen.Abstract;
using ZincOxide.Codegen.Abstract.OO;
using System.Text;
using ZincOxide.Codegen.Abstract.Imperative;

namespace ZincSulphate.Codegen.Abstract.OO.CSharp {

	[TestFixture()]
	public class CSharpScenarioTest {

		[Test()]
		public void TestTypeMethodExtractions () {
			CSharpCodegenResult cscr = new CSharpCodegenResult (new CodegenEnvironment ());
			IType sbt = cscr.GetStringBuilderType ();
			Assert.IsNotNull (sbt);
			IType st = cscr.GetStringType ();
			Assert.IsNotNull (st);
			IConstructor ic = cscr.GetStringBuilderType ().GetConstructor ();
			Assert.IsNotNull (ic);
			IExpression ice = cscr.GetStringBuilderType ().GetConstructor ().CallCommand ();
			Assert.IsNotNull (ice);
			IMethod im = cscr.GetStringBuilderType ().GetMethod ("Append", st);
			Assert.IsNotNull (im);
			ICommand imc = cscr.GetStringBuilderType ().GetMethod ("Append", st).CallCommand (null);
			Assert.IsNotNull (imc);
		}
	}
}