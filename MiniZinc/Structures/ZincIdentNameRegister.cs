//
//  ZincNameRegister.cs
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

using ZincOxide.Exceptions;
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Structures {

	public class ZincIdentNameRegister : GenerateFallbackNameRegister<ZincIdent> {
		private ZincIdentNameRegister parent;

		public ZincIdentNameRegister Parent {
			get {
				return this.parent;
			}
			set {
				this.parent = value;
			}
		}

		public ZincIdentNameRegister (ZincIdentNameRegister parent) : base (null, x => new ZincIdent (x)) {
			this.Fallback = checkUpperNameRegister;
		}

		private ZincIdent checkUpperNameRegister (string name) {
			if (this.parent != null) {
				return this.parent.Lookup (name);
			} else {
				throw new ZincOxideNameNotFoundException ("No upper scope contains \"{0}\".", name);
			}
		}
	}
}