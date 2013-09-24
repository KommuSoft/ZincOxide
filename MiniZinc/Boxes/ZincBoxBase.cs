//
//  ZincBoxBase.cs
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

    public abstract class ZincBoxBase : IZincBox {

        protected ZincBoxBase () {
        }

        #region IValidateable implementation
        public virtual bool Validate () {
            return ValidateableUtils.Validate (this);
        }
        #endregion

        #region ISoftValidateable implementation
        public virtual IEnumerable<string> SoftValidate () {
            return ValidateableUtils.CompositionInnerSoftValidate<IZincElement,IZincElement> (this);
        }
        #endregion

        #region IComposition implementation
        public abstract IEnumerable<IZincElement> Children ();
        #endregion

        #region IZincBox implementation
        public virtual IEnumerable<string> InnerSoftValidate () {
            yield break;
        }
        #endregion

        #region IZincIdentContainer implementation
        public abstract IEnumerable<ZincIdent> InvolvedIdents ();
        #endregion

        #region IZincIdentReplaceContainer implementation
        public virtual IZincIdentReplaceContainer Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
            return this;
        }
        #endregion






    }

}

