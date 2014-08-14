//
//  ZincTypeInstAndIdent.cs
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

	public class ZincTypeInstExprAndIdent : ZincIdTieBoxBase, IZincTypeInstExprAndIdent {

		#region Constructors
		public ZincTypeInstExprAndIdent (IZincTypeInstExpression expr, ZincIdent ident) : base(ident,expr) {
		}
		#endregion
		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="ZincTypeInstExprAndIdent"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="ZincTypeInstExprAndIdent"/>.</returns>
		/// <remarks>
		/// <para>The result is a string format according to <c>type : ident</c> where <c>type</c> and <c>ident</c> are replaced
		/// by the textual representation of respectively the types of the variable and the identifier.</para>
		/// </remarks>
		public override string ToString () {
			return string.Format ("{0} : {1}", this.TypeInstExpression, this.Ident);
		}
		#endregion
	}
}

