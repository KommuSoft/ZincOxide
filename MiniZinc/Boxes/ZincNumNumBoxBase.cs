//
//  ZincNumNumBoxBase.cs
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

    public class ZincNumNumBoxBase : ZincNumBoxBase, IZincNumNumBox {

        private IZincNumExp numExp2;

        #region IZincNumNumBox implementation
        public IZincNumExp NumericExpression2 {
            get {
                return this.numExp2;
            }
            protected set {
                this.numExp2 = value;
            }
        }
        #endregion

        protected ZincNumNumBoxBase (IZincNumExp numericExpression, IZincNumExp numericExpression2) : base(numericExpression) {
            this.NumericExpression2 = numericExpression2;
        }

        public override IEnumerable<ZincIdent> InvolvedIdents () {
            return EnumerableUtils.Append (this.NumericExpression.InvolvedIdents (), this.NumericExpression2.InvolvedIdents ());
        }

        public override IZincIdentReplaceContainer Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
            this.NumericExpression2 = this.NumericExpression2.Replace (identMap) as IZincNumExp;
            return base.Replace (identMap);
        }

        public override IEnumerable<IZincElement> Children () {
            return EnumerableUtils.Append (this.NumericExpression2, base.Children ());
        }

    }
}

