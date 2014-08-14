//
//  ZincTypeInstRangeExpression.cs
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
using System;
using ZincOxide.MiniZinc.Boxes;

namespace ZincOxide.MiniZinc.Structures {

	public class ZincTypeInstRangeExpression : ZincNumNumBoxBase, IZincType {

		#region IFinite implementation
		public bool Finite {
			get {
				return true;
			}
		}
		#endregion
		public bool IsSubType (IZincType type) {
			//TODO: implement
			return false;
		}

		public bool Compounded {
			get {
				return false;
			}
		}

		public ZincScalar ScalarType {
			get {
				return ZincScalar.Int;
			}
		}

		public ZincTypeInstRangeExpression (IZincNumExp numexp1, IZincNumExp numexp2) : base (numexp1, numexp2) {
		}
		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="ZincTypeInstRangeExpression"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="ZincTypeInstRangeExpression"/>.</returns>
		/// <remarks>
		/// <para>The result is a string format according to <c>from .. to</c> where <c>from</c> and <c>to</c> are replaced
		/// by the textual representation of the <see cref="NumericExpression"/> instances describing the range.</para>
		/// </remarks>
		public override string ToString () {
			return string.Format ("{0} .. {1}", this.NumericExpression, this.NumericExpression2);
		}
		#endregion
	}
}

