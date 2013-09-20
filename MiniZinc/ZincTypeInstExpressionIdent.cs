//
//  TypeInstExpressionIdent.cs
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

namespace ZincOxide.MiniZinc {

    public class ZincTypeInstExpressionIdent : ZincIdBoxBase {

        private ZincTypeInstWhereExpression expression;

        public ZincTypeInstWhereExpression Expression {
            get {
                return this.expression;
            }
            set {
                this.expression = value;
            }
        }

        public ZincTypeInstExpressionIdent (ZincTypeInstWhereExpression expression, ZincIdent ident) : base(ident) {
            this.Expression = expression;
        }

        public override string ToString () {
            return string.Format ("{0} : {1}", this.Expression, this.Ident);
        }

        public override IEnumerable<ZincIdent> InvolvedIdents () {
            return EnumerableUtils.Append (this.expression.InvolvedIdents (), base.InvolvedIdents ());
        }

        public override IZincIdentReplaceContainer Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
            this.expression.Replace (identMap);
            return base.Replace (identMap);
        }

    }
}

