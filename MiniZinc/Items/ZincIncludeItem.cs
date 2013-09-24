//
//  ZincIncludeItem.cs
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
using System.IO;
using ZincOxide.MiniZinc.Structures;
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Items {

    public class ZincIncludeItem : NameBase, IZincItem {

        #region IZincItem implementation
        public ZincItemType Type {
            get {
                return ZincItemType.Include;
            }
        }
        #endregion

        public ZincIncludeItem (string name) : base(name) {
        }

        public override string ToString () {
            return string.Format ("include {0}", ZincPrintUtils.StringLiteral (this.Name));
        }

        #region IWriteable implementation
        public void Write (TextWriter writer) {
            writer.Write (this.ToString ());
        }
        #endregion

        #region IZincIdentContainer implementation
        public IEnumerable<ZincIdent> InvolvedIdents () {
            yield break;
        }
        #endregion

        #region IZincIdentReplaceContainer implementation
        public IZincIdentReplaceContainer Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
            return this;
        }
        #endregion

        #region IInnerSoftValidateable implementation
        public IEnumerable<string> InnerSoftValidate () {
            yield break;
        }
        #endregion

        #region IValidateable implementation
        public bool Validate () {
            return ValidateableUtils.Validate (this);
        }
        #endregion

        #region ISoftValidateable implementation
        public IEnumerable<string> SoftValidate () {
            return ValidateableUtils.CompositionInnerSoftValidate<IZincElement,IZincElement> (this);
        }
        #endregion

        #region IComposition implementation
        public IEnumerable<IZincElement> Children () {
            yield break;
        }
        #endregion

    }
}

