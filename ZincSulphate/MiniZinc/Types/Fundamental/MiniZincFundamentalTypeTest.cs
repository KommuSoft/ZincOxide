//
//  MiniZincFundamentalTypeTest.cs
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
using System;
using ZincOxide.MiniZinc.Types.Fundamental;

namespace ZincSulphate.Fundamental {

	[TestFixture ()]
	public class MiniZincFundamentalTypeTest {
		[Test ()]
		public void TestScalarTypeEntry () {
			Assert.IsTrue (MiniZincScalarTypeEntry.Boolean.GenericEquals (MiniZincScalarTypeEntry.Boolean));
			Assert.IsFalse (MiniZincScalarTypeEntry.Boolean.GenericEquals (MiniZincScalarTypeEntry.Float));
			Assert.IsFalse (MiniZincScalarTypeEntry.Boolean.GenericEquals (MiniZincScalarTypeEntry.Integer));
			Assert.IsFalse (MiniZincScalarTypeEntry.Boolean.GenericEquals (MiniZincScalarTypeEntry.String));
			Assert.IsFalse (MiniZincScalarTypeEntry.Float.GenericEquals (MiniZincScalarTypeEntry.Boolean));
			Assert.IsTrue (MiniZincScalarTypeEntry.Float.GenericEquals (MiniZincScalarTypeEntry.Float));
			Assert.IsFalse (MiniZincScalarTypeEntry.Float.GenericEquals (MiniZincScalarTypeEntry.Integer));
			Assert.IsFalse (MiniZincScalarTypeEntry.Float.GenericEquals (MiniZincScalarTypeEntry.String));
			Assert.IsFalse (MiniZincScalarTypeEntry.Integer.GenericEquals (MiniZincScalarTypeEntry.Boolean));
			Assert.IsFalse (MiniZincScalarTypeEntry.Integer.GenericEquals (MiniZincScalarTypeEntry.Float));
			Assert.IsTrue (MiniZincScalarTypeEntry.Integer.GenericEquals (MiniZincScalarTypeEntry.Integer));
			Assert.IsFalse (MiniZincScalarTypeEntry.Integer.GenericEquals (MiniZincScalarTypeEntry.String));
			Assert.IsFalse (MiniZincScalarTypeEntry.String.GenericEquals (MiniZincScalarTypeEntry.Boolean));
			Assert.IsFalse (MiniZincScalarTypeEntry.String.GenericEquals (MiniZincScalarTypeEntry.Float));
			Assert.IsFalse (MiniZincScalarTypeEntry.String.GenericEquals (MiniZincScalarTypeEntry.Integer));
			Assert.IsTrue (MiniZincScalarTypeEntry.String.GenericEquals (MiniZincScalarTypeEntry.String));
			Assert.IsTrue (MiniZincScalarTypeEntry.Boolean.GenericEquals ((MiniZincScalarTypeEntry)MiniZincScalarType.Boolean));
			Assert.IsFalse (MiniZincScalarTypeEntry.Boolean.GenericEquals ((MiniZincScalarTypeEntry)MiniZincScalarType.Float));
			Assert.IsFalse (MiniZincScalarTypeEntry.Boolean.GenericEquals ((MiniZincScalarTypeEntry)MiniZincScalarType.Integer));
			Assert.IsFalse (MiniZincScalarTypeEntry.Boolean.GenericEquals ((MiniZincScalarTypeEntry)MiniZincScalarType.String));
			Assert.IsFalse (MiniZincScalarTypeEntry.Float.GenericEquals ((MiniZincScalarTypeEntry)MiniZincScalarType.Boolean));
			Assert.IsTrue (MiniZincScalarTypeEntry.Float.GenericEquals ((MiniZincScalarTypeEntry)MiniZincScalarType.Float));
			Assert.IsFalse (MiniZincScalarTypeEntry.Float.GenericEquals ((MiniZincScalarTypeEntry)MiniZincScalarType.Integer));
			Assert.IsFalse (MiniZincScalarTypeEntry.Float.GenericEquals ((MiniZincScalarTypeEntry)MiniZincScalarType.String));
			Assert.IsFalse (MiniZincScalarTypeEntry.Integer.GenericEquals ((MiniZincScalarTypeEntry)MiniZincScalarType.Boolean));
			Assert.IsFalse (MiniZincScalarTypeEntry.Integer.GenericEquals ((MiniZincScalarTypeEntry)MiniZincScalarType.Float));
			Assert.IsTrue (MiniZincScalarTypeEntry.Integer.GenericEquals ((MiniZincScalarTypeEntry)MiniZincScalarType.Integer));
			Assert.IsFalse (MiniZincScalarTypeEntry.Integer.GenericEquals ((MiniZincScalarTypeEntry)MiniZincScalarType.String));
			Assert.IsFalse (MiniZincScalarTypeEntry.String.GenericEquals ((MiniZincScalarTypeEntry)MiniZincScalarType.Boolean));
			Assert.IsFalse (MiniZincScalarTypeEntry.String.GenericEquals ((MiniZincScalarTypeEntry)MiniZincScalarType.Float));
			Assert.IsFalse (MiniZincScalarTypeEntry.String.GenericEquals ((MiniZincScalarTypeEntry)MiniZincScalarType.Integer));
			Assert.IsTrue (MiniZincScalarTypeEntry.String.GenericEquals ((MiniZincScalarTypeEntry)MiniZincScalarType.String));
		}
	}
}

