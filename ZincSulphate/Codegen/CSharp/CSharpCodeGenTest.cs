//
//  JavaCodeGen.cs
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

using System.Collections.Generic;
using System.Linq;
using System.IO;
using NUnit.Framework;
using ZincOxide.Codegen;
using ZincOxide.Codegen.CSharp;

namespace ZincSulphate.Codegen.CSharp {

	[TestFixture ()]
	public class CSharpCodeGenTest {
		private string expectedContent1 = "public interface Test {\n}\n";
		private string expectedName1 = "Test.cs";
		private string expectedContent2 = "namespace just.an {\n\n\tpublic interface OtherTest : Test {\n\t}\n\n}\n";
		private string expectedName2 = "just/an/OtherTest.cs";
		private string expectedContent3 = "namespace just.an {\n\n\tpublic interface OtherTest2 : Test, OtherTest {\n\t}\n\n}\n";
		private string expectedName3 = "just/an/OtherTest2.cs";
		private ICodeFile file;
		private IEnumerable<ICodeFile> files;

		[Test ()]
		public void TestGenerateInterface1 () {
			CodeBuilderCSharp cbj = new CodeBuilderCSharp ();
			ICodeInterface test1 = cbj.NewInterface (null, "Test");
			files = cbj.Generate ();
			Assert.AreEqual (0x01, files.Count ());
			file = files.First ();
			Assert.IsNotNull (file);
			Assert.AreEqual (expectedName1, file.Name);
			Assert.AreEqual (expectedContent1, file.GetText ());
		}

		[Test ()]
		public void TestGenerateInterface2 () {
			CodeBuilderCSharp cbj = new CodeBuilderCSharp ();
			ICodeInterface test1 = cbj.NewInterface (null, "Test");
			Assert.IsNotNull (file);
			ICodePackage justan = cbj.NewPackage ("just.an");
			ICodeInterface test2 = cbj.NewInterface (justan, "OtherTest", test1);
			files = cbj.Generate ();
			Assert.AreEqual (0x02, files.Count ());
			file = files.First ();
			Assert.IsNotNull (file);
			Assert.AreEqual (expectedName1, file.Name);
			Assert.AreEqual (expectedContent1, file.GetText ());
			file = files.Skip (0x01).First ();
			Assert.IsNotNull (file);
			Assert.AreEqual (expectedName2, file.Name);
			Assert.AreEqual (expectedContent2, file.GetText ());
		}

		[Test ()]
		public void TestGenerateInterface3 () {
			CodeBuilderCSharp cbj = new CodeBuilderCSharp ();
			ICodeInterface test1 = cbj.NewInterface (null, "Test");
			ICodePackage justan = cbj.NewPackage ("just.an");
			ICodeInterface test2 = cbj.NewInterface (justan, "OtherTest", test1);
			cbj.NewInterface (justan, "OtherTest2", test1, test2);
			files = cbj.Generate ();
			Assert.AreEqual (0x03, files.Count ());
			file = files.First ();
			Assert.IsNotNull (file);
			Assert.AreEqual (expectedName1, file.Name);
			Assert.AreEqual (expectedContent1, file.GetText ());
			file = files.Skip (0x01).First ();
			Assert.IsNotNull (file);
			Assert.AreEqual (expectedName2, file.Name);
			Assert.AreEqual (expectedContent2, file.GetText ());
			file = files.Skip (0x02).First ();
			Assert.IsNotNull (file);
			Assert.AreEqual (expectedName3, file.Name);
			Assert.AreEqual (expectedContent3, file.GetText ());
		}
	}
}

