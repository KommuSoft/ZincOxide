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
using System;
using System.Collections.Generic;

namespace ZincOxide.MiniZinc {

	public abstract class ZincIdentBoxBase : IZincIdentBox {

		private ZincIdent ident;

		#region IZincIdentBox implementation
		public ZincIdent Ident {
			get {
				return this.ident;
			}
			protected set {
				this.ident = value;
			}
		}
		#endregion


		protected ZincIdentBoxBase () {
		}

		protected ZincIdentBoxBase (ZincIdent ident) {
			this.Ident = ident;
		}

		#region ZincIdentContainer implementation
		public virtual IEnumerable<ZincIdent> InvolvedIdents () {
			yield return this.ident;
		}
		public virtual void Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
			this.ident = ZincIdent.Replace (this.ident, identMap);
		}
		#endregion




	}
}

