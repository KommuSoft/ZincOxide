//
//  ZincTypeInstExprAndIdentAnnotationsExpressionBoxBase.cs
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
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Boxes {

    public class ZincAsExTiaBoxBase : ZincAsExBoxBase, IZincAsExTiaBox {

        private ZincTypeInstExprAndIdent typeInstAndIdent;

        #region IZincTiaBox implementation
        public ZincTypeInstExprAndIdent TypeInstExprAndIdent {
            get {
                return this.typeInstAndIdent;
            }
            protected set {
                this.typeInstAndIdent = value;
            }
        }
        #endregion

        protected ZincAsExTiaBoxBase (ZincAnnotations anns, IZincExp expr, ZincTypeInstExprAndIdent tia) : base(anns,expr) {
            this.TypeInstExprAndIdent = tia;
        }

        public override System.Collections.Generic.IEnumerable<ZincIdent> InvolvedIdents () {
            return EnumerableUtils.Append (base.InvolvedIdents (), this.TypeInstExprAndIdent.InvolvedIdents ());
        }

        public override IZincIdentReplaceContainer Replace (System.Collections.Generic.IDictionary<ZincIdent, ZincIdent> identMap) {
            this.TypeInstExprAndIdent = this.TypeInstExprAndIdent.Replace (identMap) as ZincTypeInstExprAndIdent;
            return base.Replace (identMap);
        }

    }

}

