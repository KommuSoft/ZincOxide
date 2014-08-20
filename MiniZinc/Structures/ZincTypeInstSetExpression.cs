//
//  ZincTypeInstSetExpression.cs
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
using ZincOxide.MiniZinc.Boxes;
using System.Linq.Expressions;

namespace ZincOxide.MiniZinc.Structures {

	public class ZincTypeInstSetExpression : ZincTieBoxBase, IZincType {

		#region IFinite implementation
		public bool Finite {
			get {
				return this.TypeInstExpression.Finite;
			}
		}
		#endregion
		public bool IsSubType (IZincType type) {
			//TODO
			throw new System.NotImplementedException ();
		}

		public bool Compounded {
			get {
				return true;
			}
		}

		public ZincScalar ScalarType {
			get {
				return this.TypeInstExpression.ScalarType;
			}
		}
		#region Constructors
		public ZincTypeInstSetExpression (IZincTypeInstExpression expression) : base (expression) {
		}
		#endregion
		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="ZincTypeInstSetExpression"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="ZincTypeInstSetExpression"/>.</returns>
		/// <remarks>
		/// <para>The result is a string format according to <c>set of expression</c> where <c>expression</c> is replaced
		/// by the textual representation of the type of elements in the set.</para>
		/// </remarks>
		public override string ToString () {
			return string.Format ("set of {0}", this.TypeInstExpression);
		}
		#endregion
	}
}