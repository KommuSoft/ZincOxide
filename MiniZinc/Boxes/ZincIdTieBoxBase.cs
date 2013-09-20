//
//  ZincIdTieBoxBase.cs
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

namespace ZincOxide.MiniZinc.Boxes {

    public abstract class ZincIdTieBoxBase : ZincIdBoxBase, IZincIdTieBox {

        private IZincTypeInstExpression expression;

        public IZincTypeInstExpression Expression {
            get {
                return this.expression;
            }
            protected set {
                this.expression = value;
            }
        }

        protected ZincIdTieBoxBase (ZincIdent ident, IZincTypeInstExpression expression) : base(ident) {
            this.Expression = expression;
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

