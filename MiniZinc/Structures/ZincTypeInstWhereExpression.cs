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
		private ZincTypeInstWhereExpression header;

		#region IFinite implementation

		public bool Finite {
			get {
				return false;//TODO
			}
		}

		#endregion

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

		public ZincTypeInstWhereExpression (ZincTypeInstWhereExpression header, ZincIdent ident, IZincExp expression) : base (ident, expression) {
		}

		public override string ToString () {
			return string.Format ("( {0} : {1} where {2} )", this.Header, this.Ident, this.Expression);
		}

		public override IEnumerable<IZincIdent> InvolvedIdents () {
			return EnumerableUtils.Append (this.Header.InvolvedIdents (), base.InvolvedIdents (), this.Expression.InvolvedIdents ());
		}

		public override IZincIdentReplaceContainer Replace (IDictionary<IZincIdent,IZincIdent> identMap) {
			this.header = this.header.Replace (identMap) as ZincTypeInstWhereExpression;
			this.Expression = this.Expression.Replace (identMap) as IZincExp;
			return base.Replace (identMap);
		}
	}
}

