//
//  ZincTieTieBoxBase.cs
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
using System.Linq;
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Boxes {

    public abstract class ZincTieTiesBoxBase : ZincTieBoxBase, IZincTieTiesBox {

        private IList<IZincTypeInstExpression> expressions;

        #region IZincTieTieBox implementation
        public IList<IZincTypeInstExpression> TypeInstExpressions {
            get {
                return this.expressions;
            }
            protected set {
                this.expressions = value;
            }
        }
        #endregion
        protected ZincTieTiesBoxBase (IZincTypeInstExpression expression1, IList<IZincTypeInstExpression> expressions) : base(expression1) {
            this.TypeInstExpressions = expressions;
        }

        public override IEnumerable<ZincIdent> InvolvedIdents () {
            return EnumerableUtils.Append (base.InvolvedIdents (), this.TypeInstExpressions.SelectMany (x => x.InvolvedIdents ()));
        }

        public override IZincIdentReplaceContainer Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
            for (int i = 0x00; i < this.expressions.Count; i++) {
                this.expressions [i] = this.expressions [i].Replace (identMap) as IZincTypeInstExpression;
            }
            return base.Replace (identMap);
        }

    }

}

