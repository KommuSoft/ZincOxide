//
//  ZincTypeInstExpressionBoxBase.cs
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

namespace ZincOxide.MiniZinc.Boxes {

    public class ZincTieBoxBase : ZincBoxBase, IZincTieBox {

        private IZincTypeInstExpression typeInstExpression;

        public IZincTypeInstExpression TypeInstExpression {
            get {
                return this.typeInstExpression;
            }
            protected set {
                this.typeInstExpression = value;
            }
        }

        protected ZincTieBoxBase (IZincTypeInstExpression typeInstExpression) {
            this.TypeInstExpression = typeInstExpression;
        }

        #region IZincIdentContainer implementation
        public virtual IEnumerable<ZincIdent> InvolvedIdents () {
            return this.TypeInstExpression.InvolvedIdents ();
        }
        #endregion

        #region IZincIdentReplaceContainer implementation
        public virtual IZincIdentReplaceContainer Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
            this.TypeInstExpression = this.TypeInstExpression.Replace (identMap) as IZincTypeInstExpression;
            return this;
        }
        #endregion

        public override IEnumerable<IZincElement> Children () {
            yield return this.typeInstExpression;
        }

    }
}

