//
//  ZincAsBoxBase.cs
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

    public abstract class ZincAsBoxBase : IZincAsBox {

        private ZincAnnotations annotations;

        #region IZincExpressionBox implementation
        public ZincAnnotations Annotations {
            get {
                return this.annotations;
            }
            protected set {
                this.annotations = value;
            }
        }
        #endregion


        protected ZincAsBoxBase () {
        }

        protected ZincAsBoxBase (ZincAnnotations annotations) {
            this.Annotations = annotations;
        }

        #region IZincIdentContainer implementation
        public virtual IEnumerable<ZincIdent> InvolvedIdents () {
            return this.Annotations.InvolvedIdents ();
        }
        #endregion

        #region IZincIdentReplaceContainer implementation
        public virtual IZincIdentReplaceContainer Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
            this.annotations = this.annotations.Replace (identMap) as ZincAnnotations;
            return this;
        }
        #endregion

    }
}

