//
//  ZincTyBoxBase.cs
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

	public class ZincTyBoxBase : ZincBoxBase, IZincTyBox {

		private IZincType type;

        #region IZincTyBox implementation
		public IZincType Type {
			get {
				return this.type;
			}
			protected set {
				this.type = value;
			}
		}
        #endregion

		protected ZincTyBoxBase (IZincType type) {
			this.type = type;
		}

        #region IZincIdentContainer implementation
		public override IEnumerable<IZincIdent> InvolvedIdents () {
			return this.type.InvolvedIdents ();
		}
        #endregion

        #region IZincIdentReplaceContainer implementation
		public override IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap) {
			this.type = this.type.Replace (identMap) as IZincType;
			return this;
		}
        #endregion

		public override IEnumerable<IZincElement> Children () {
			yield return this.type;
		}

	}

}

