//
//  ZincAsExIdTieTiasBox.cs
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
using ZincOxide.MiniZinc.Structures;
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Boxes {

    public class ZincAsExIdTieTiasBoxBase : ZincAsExIdTiasBoxBase, IZincAsExIdTieTiasBox {

        private IZincTypeInstExpression typeInstExpression;

        #region IZincTieBox implementation
        public IZincTypeInstExpression TypeInstExpression {
            get {
                return this.typeInstExpression;
            }
            protected set {
                this.typeInstExpression = value;
            }
        }
        #endregion

        protected ZincAsExIdTieTiasBoxBase (ZincAnnotations annotations, IZincExp expression, ZincIdent ident, IZincTypeInstExpression typeInstExpression, IList<ZincTypeInstExprAndIdent> typeInstIdentExpressions) : base(annotations,expression,ident,typeInstIdentExpressions) {
            this.typeInstExpression = typeInstExpression;
        }

        protected ZincAsExIdTieTiasBoxBase (ZincAnnotations annotations, IZincExp expression, ZincIdent ident, IZincTypeInstExpression typeInstExpression, params ZincTypeInstExprAndIdent[] typeInstIdentExpressions) : base(annotations,expression,ident,typeInstIdentExpressions) {
            this.typeInstExpression = typeInstExpression;
        }

        protected ZincAsExIdTieTiasBoxBase (ZincAnnotations annotations, IZincExp expression, ZincIdent ident, IZincTypeInstExpression typeInstExpression, IEnumerable<ZincTypeInstExprAndIdent> typeInstIdentExpressions) : base(annotations,expression,ident,typeInstIdentExpressions) {
            this.typeInstExpression = typeInstExpression;
        }

        public override IEnumerable<ZincIdent> InvolvedIdents () {
            return EnumerableUtils.Append (base.InvolvedIdents (), this.typeInstExpression.InvolvedIdents ());
        }

        public override IZincIdentReplaceContainer Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
            this.typeInstExpression.Replace (identMap);
            return base.Replace (identMap);
        }

    }
}

