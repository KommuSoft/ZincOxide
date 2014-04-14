//
//  ZincIdentScopeBase.cs
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
using ZincOxide.Utils.Nameregister;

namespace ZincOxide.MiniZinc.Structures {

	public abstract class ZincIdentScopeBase : IZincIdentScope {

		private ZincIdentNameRegister nameRegister;

        #region IFallbackNameRegister implementation
		public DNameRegisterFallback<ZincIdent> Fallback {
			get {
				if (this.nameRegister != null) {
					return this.nameRegister.Fallback;
				} else {
					return null;
				}
			}
		}
        #endregion

        #region IZincIdentScope implementation
		public ZincIdentNameRegister NameRegister {
			get {
				return this.nameRegister;
			}
		}
        #endregion

		protected ZincIdentScopeBase (ZincIdentNameRegister nameRegister = null) {
			this.nameRegister = nameRegister;
		}

        #region INameRegister implementation
		public void Register (ZincIdent value) {
			this.nameRegister.Register (value);
		}

		public bool Contains (string name) {
			return this.nameRegister.Contains (name);
		}

		public ZincIdent Lookup (string name) {
			return this.nameRegister.Lookup (name);
		}
        #endregion

	}

}

