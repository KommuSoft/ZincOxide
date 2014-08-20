//
//  ZincTypeInstExpression.cs
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
using System.Collections.Generic;
using ZincOxide.MiniZinc.Boxes;
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Structures {

	public class ZincTypeInstWhereExpression : ZincExIdBoxBase, IZincTypeInstExpression {
		#region Fields
		private ZincTypeInstWhereExpression header;
		#endregion
		#region IFinite implementation
		public bool Finite {
			get {
				return false;//TODO
			}
		}
		#endregion
		#region Properties
		public bool IsSubType (IZincType type) {
			//TODO
			throw new NotImplementedException ();
		}

		public bool Compounded {
			get {
				//TODO
				throw new NotImplementedException ();
			}
		}

		public ZincScalar ScalarType {
			get {
				//TODO
				throw new NotImplementedException ();
			}
		}

		public ZincTypeInstWhereExpression Header {
			get {
				return this.header;
			}
			protected set {
				this.header = value;
			}
		}
		#endregion
		#region Constructors
		public ZincTypeInstWhereExpression (ZincTypeInstWhereExpression header, ZincIdent ident, IZincExp expression) : base (ident, expression) {
		}
		#endregion
		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="ZincTypeInstWhereExpression"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="ZincTypeInstWhereExpression"/>.</returns>
		/// <remarks>
		/// <para>The result is a string format according to <c>type : ident where expression</c> where <c>type</c>, <c>ident</c> and <c>expression</c> are replaced
		/// by the textual representation of the type and the name of the variable and the expression that describes the type further.</para>
		/// </remarks>
		public override string ToString () {
			return string.Format ("( {0} : {1} where {2} )", this.Header, this.Ident, this.Expression);
		}
		#endregion
		#region IZincIdentReplaceContainer implementation
		/// <summary>
		/// Replaces all the instances stored in the given <see cref="T:IDictionary`2"/>
		/// stored as keys to the corresponding values and returns this instance, possibly if this is an
		/// <see cref="IZincIdent"/> itself another <see cref="IZincIdent"/>.
		/// </summary>
		/// <returns>
		/// If this instance is a compound type, a reference to itself. Otherwise a <see cref="IZincIdent"/> if
		/// this instance is a <see cref="IZincIdent"/> itself.
		/// </returns>
		public override IZincIdentReplaceContainer Replace (IDictionary<IZincIdent,IZincIdent> identMap) {
			this.header = this.header.Replace (identMap) as ZincTypeInstWhereExpression;
			this.Expression = this.Expression.Replace (identMap) as IZincExp;
			return base.Replace (identMap);
		}
		#endregion
	}
}

