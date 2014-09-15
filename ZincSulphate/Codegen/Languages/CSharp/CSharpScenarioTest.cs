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
using System.Text;
using ZincOxide.Codegen.Abstract.Imperative;
using ZincOxide.Codegen.Abstract.Typed;
using ZincOxide.Codegen.Abstract.Result;
using ZincOxide.Codegen.Languages.CSharp;
using ZincOxide.Codegen.Abstract.OO;
using ZincOxide.Environment;

namespace ZincSulphate.Codegen.Languages.CSharp {

	[TestFixture()]
	public class CSharpScenarioTest {

		[Test()]
		public void TestTypeBool () {
			CSharpCodegenResult cscr = new CSharpCodegenResult (new CodegenEnvironment ());
			IType it = cscr.GetBooleanType ();
			Assert.IsNotNull (it);
		}

		[Test()]
		public void TestTypeFloat () {
			CSharpCodegenResult cscr = new CSharpCodegenResult (new CodegenEnvironment ());
			IType it = cscr.GetFloatType ();
			Assert.IsNotNull (it);
			it = cscr.GetFloatType (ProgramFloatRepresentation.Double);
			Assert.IsNotNull (it);
			it = cscr.GetFloatType (ProgramFloatRepresentation.Fraction);
			Assert.IsNotNull (it);
			it = cscr.GetFloatType (ProgramFloatRepresentation.Single);
			Assert.IsNotNull (it);
		}

		[Test()]
		public void TestTypeInteger () {
			CSharpCodegenResult cscr = new CSharpCodegenResult (new CodegenEnvironment ());
			IType it = cscr.GetIntegerType ();
			Assert.IsNotNull (it);
			it = cscr.GetIntegerType (ProgramIntegerRepresentation.Int16);
			Assert.IsNotNull (it);
			it = cscr.GetIntegerType (ProgramIntegerRepresentation.Int32);
			Assert.IsNotNull (it);
			it = cscr.GetIntegerType (ProgramIntegerRepresentation.Int64);
			Assert.IsNotNull (it);
			it = cscr.GetIntegerType (ProgramIntegerRepresentation.Integer);
			Assert.IsNotNull (it);
		}

		[Test()]
		public void TestTypeStringBuilder () {
			CSharpCodegenResult cscr = new CSharpCodegenResult (new CodegenEnvironment ());
			IType it = cscr.GetStringBuilderType ();
			Assert.IsNotNull (it);
		}

		[Test()]
		public void TestTypeString () {
			CSharpCodegenResult cscr = new CSharpCodegenResult (new CodegenEnvironment ());
			IType it = cscr.GetStringType ();
			Assert.IsNotNull (it);
		}

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
			im = cscr.GetStringBuilderType ().GetMethod ("ToString");
			Assert.IsNotNull (im);
			imc = cscr.GetStringBuilderType ().GetMethod ("ToString").CallCommand (null);
			Assert.IsNotNull (imc);
		}
	}
}