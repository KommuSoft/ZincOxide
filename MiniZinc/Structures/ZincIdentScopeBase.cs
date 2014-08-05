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

	/// <summary>
	/// A basic implementation of the <see cref="IZincIdentScope"/> interface: a scope where identifiers are defined
	/// and where identifiers should be binded to the appropriate identifier.
	/// </summary>
	public abstract class ZincIdentScopeBase : IZincIdentScope {

		#region Fields
		/// <summary>
		/// The name registers that stores the defined identifiers in the scope.
		/// </summary>
		private ZincIdentNameRegister nameRegister;
		#endregion
		#region IFallbackNameRegister implementation
		/// <summary>
		/// Gets the function used to retrieve an identifier if such identifier is not stored in this scope. Basically
		/// the register of the level above is used.
		/// </summary>
		/// <value>The function used to retrieve an identifier if such identifier is not stored in this scope.</value>
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

		public void CloseScope () {
			throw new System.NotImplementedException ();
		}
		#endregion
	}
}

