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

namespace ZincOxide.MiniZinc {

	public class ZincTypeInstExpression : ZincIdentBoxBase {

		private ZincTypeInstExpression header;
		private IZincExpression expression;

		public ZincTypeInstExpression Header {
			get {
				return this.header;
			}
			protected set {
				this.header = value;
			}
		}

		public IZincExpression Expression {
			get {
				return this.expression;
			}
			protected set {
				this.expression = value;
			}
		}

		public ZincTypeInstExpression (ZincTypeInstExpression header, ZincIdent ident, IZincExpression expression) : base(ident) {
		}

		public override string ToString () {
			return string.Format ("( {0} : {1} where {2} )", this.Header, this.Ident, this.Expression);
		}

		public override IEnumerable<ZincIdent> InvolvedIdents () {
			return EnumerableUtils.Append (this.Header.InvolvedIdents (), base.InvolvedIdents (), this.Expression.InvolvedIdents ());
		}

		public override ZincIdentBoxBase Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
			this.header = (ZincTypeInstExpression)this.header.Replace (identMap);
			this.expression = (IZincExpression)this.expression.Replace (identMap);
			return base.Replace (identMap);
		}

	}
}

