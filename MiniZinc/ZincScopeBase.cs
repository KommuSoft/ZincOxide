//
//  ZincScopeBase.cs
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

namespace ZincOxide.MiniZinc {

	public class ZincScopeBase : ZincIScope {

		private readonly ZincINamespace space = new ZincNamespace ();
		private ZincIScope parent;

		#region ZincIScope implementation
		public ZincINamespace Namespace {
			get {
				return this.space;
			}
		}

		public ZincIScope Parent {
			get {
				return this.parent;
			}
			internal set {
				this.parent = value;
			}
		}
		#endregion

		public ZincScopeBase () {
		}

		#region ZincINamespace implementation
		public void RegisterName (ZincIName namedObject) {
			this.Namespace.RegisterName (namedObject);
		}

		public T Retrieve<T> (string name) where T : ZincIName {
			T val;
			if (this.space.TryRetrieve (name, out val)) {
				return val;
			} else if (this.parent != null) {
				return this.parent.Retrieve<T> (name);
			} else {
				return default(T);
			}
		}

		public bool Contains (string name) {
			return this.space.Contains (name);
		}

		public bool TryRetrieve<T> (string name, out T val) where T : ZincIName {
			if (this.space.TryRetrieve (name, out val)) {
				return true;
			} else if (this.parent != null) {
				return this.parent.TryRetrieve<T> (name, out val);
			} else {
				return false;
			}
		}
		#endregion




	}

}