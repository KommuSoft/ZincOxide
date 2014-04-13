//
//  ZincTiesBoxBase.cs
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
using System.Linq;
using System.Collections.Generic;
using ZincOxide.MiniZinc.Structures;

namespace ZincOxide.MiniZinc.Boxes {

    public class ZincTiesBoxBase : ZincBoxBase, IZincTiesBox {

        private IList<IZincTypeInstExpression> typeInstExpressions;

        #region IZincTiesBox implementation
        public IList<IZincTypeInstExpression> TypeInstExpressions {
            get {
                return this.typeInstExpressions;
            }
            protected set {
                this.typeInstExpressions = value;
            }
        }
        #endregion

        protected ZincTiesBoxBase (IList<IZincTypeInstExpression> typeInstExpressions) {
            this.typeInstExpressions = typeInstExpressions;
        }

        protected ZincTiesBoxBase (IEnumerable<IZincTypeInstExpression> typeInstExpressions) : this(typeInstExpressions.ToList()) {
        }

        protected ZincTiesBoxBase (params IZincTypeInstExpression[] typeInstExpressions) : this((IList<IZincTypeInstExpression>) typeInstExpressions) {
        }

        #region IZincIdentContainer implementation
        public override IEnumerable<ZincIdent> InvolvedIdents () {
            return this.typeInstExpressions.SelectMany (x => x.InvolvedIdents ());
        }
        #endregion

        #region IZincIdentReplaceContainer implementation
        public override IZincIdentReplaceContainer Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
            int n = this.typeInstExpressions.Count;
            for (int i = 0x00; i < n; i++) {
                this.typeInstExpressions [i] = this.typeInstExpressions [i].Replace (identMap) as IZincTypeInstExpression;
            }
            return base.Replace (identMap);
        }
        #endregion

        public override IEnumerable<IZincElement> Children () {
            return this.typeInstExpressions;
        }

    }

}

