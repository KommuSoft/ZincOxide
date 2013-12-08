//
//  NUnitTestClass.cs
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
using ZincOxide.Utils.Maths;

namespace ZincSulphate.Maths {

	[TestFixture ()]
	public class ThreeStateValueTest {
		[Test ()]
		public void TestAnd () {
			Assert.AreEqual (ThreeStateValue.False, ThreeStateValue.False & ThreeStateValue.False);
			Assert.AreEqual (ThreeStateValue.False, ThreeStateValue.False & ThreeStateValue.Unknown);
			Assert.AreEqual (ThreeStateValue.False, ThreeStateValue.False & ThreeStateValue.True);
			Assert.AreEqual (ThreeStateValue.False, ThreeStateValue.Unknown & ThreeStateValue.False);
			Assert.AreEqual (ThreeStateValue.Unknown, ThreeStateValue.Unknown & ThreeStateValue.Unknown);
			Assert.AreEqual (ThreeStateValue.Unknown, ThreeStateValue.Unknown & ThreeStateValue.True);
			Assert.AreEqual (ThreeStateValue.False, ThreeStateValue.True & ThreeStateValue.False);
			Assert.AreEqual (ThreeStateValue.Unknown, ThreeStateValue.True & ThreeStateValue.Unknown);
			Assert.AreEqual (ThreeStateValue.True, ThreeStateValue.True & ThreeStateValue.True);
		}

		[Test ()]
		public void TestOr () {
			Assert.AreEqual (ThreeStateValue.False, ThreeStateValue.False | ThreeStateValue.False);
			Assert.AreEqual (ThreeStateValue.Unknown, ThreeStateValue.False | ThreeStateValue.Unknown);
			Assert.AreEqual (ThreeStateValue.True, ThreeStateValue.False | ThreeStateValue.True);
			Assert.AreEqual (ThreeStateValue.Unknown, ThreeStateValue.Unknown | ThreeStateValue.False);
			Assert.AreEqual (ThreeStateValue.Unknown, ThreeStateValue.Unknown | ThreeStateValue.Unknown);
			Assert.AreEqual (ThreeStateValue.True, ThreeStateValue.Unknown | ThreeStateValue.True);
			Assert.AreEqual (ThreeStateValue.True, ThreeStateValue.True | ThreeStateValue.False);
			Assert.AreEqual (ThreeStateValue.True, ThreeStateValue.True | ThreeStateValue.Unknown);
			Assert.AreEqual (ThreeStateValue.True, ThreeStateValue.True | ThreeStateValue.True);
		}
	}
}

