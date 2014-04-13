//
//  ZincIdentBoxBase.cs
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

	public abstract class ZincIdBoxBase : ZincBoxBase, IZincIdBox {

		private IZincIdent ident;

        #region IZincIdentBox implementation
		public IZincIdent Ident {
			get {
				return this.ident;
			}
			protected set {
				this.ident = value;
			}
		}
        #endregion


		protected ZincIdBoxBase () {
		}

		protected ZincIdBoxBase (IZincIdent ident) {
			this.Ident = ident;
		}

        #region ZincIdentContainer implementation
		public override IEnumerable<ZincIdent> InvolvedIdents () {
			yield return (ZincIdent)this.ident;//TODO: pull up return class eventually
		}
		#endregion
		#region ZincIdentReplaceContainer implementation
		public override IZincIdentReplaceContainer Replace (IDictionary<ZincIdent,ZincIdent> identMap) {
			this.ident = this.ident.Replace (identMap) as ZincIdent;
			return this;
		}
        #endregion

		public override IEnumerable<IZincElement> Children () {
			yield return this.ident;
		}


	}
}

