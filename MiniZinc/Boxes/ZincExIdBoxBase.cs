//
//  ZincIdentExpressionBoxBase.cs
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
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Boxes {

    public abstract class ZincExIdBoxBase : ZincIdBoxBase, IZincExIdBox {

        private IZincExpression expression;

        #region IZincExpressionBox implementation
        public IZincExpression Expression {
            get {
                return this.expression;
            }
            protected set {
                this.expression = value;
            }
        }
        #endregion


        protected ZincExIdBoxBase () : base() {
        }

        protected ZincExIdBoxBase (ZincIdent ident) : base(ident) {
        }

        protected ZincExIdBoxBase (IZincExpression expression) : base() {
            this.Expression = expression;
        }

        protected ZincExIdBoxBase (ZincIdent ident, IZincExpression expression) : base(ident) {
            this.expression = expression;
        }

        public override IEnumerable<ZincIdent> InvolvedIdents () {
            return EnumerableUtils.Append (base.InvolvedIdents (), this.Expression.InvolvedIdents ());
        }

        public override IZincIdentReplaceContainer Replace (IDictionary<ZincIdent,ZincIdent> identMap) {
            this.expression = this.expression.Replace (identMap) as IZincExpression;
            return base.Replace (identMap);
        }

    }

}

