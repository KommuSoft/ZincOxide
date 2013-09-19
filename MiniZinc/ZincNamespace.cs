//
//  ZincNamespace.cs
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

	public class ZincNamespace : ZincINamespace {

		private readonly Dictionary<string,ZincIName> names;

		public ZincNamespace () {
		}

		#region ZincINamespace implementation
		public void RegisterName (ZincIName namedObject) {
			if (namedObject != null && namedObject.Name != null && namedObject.Name != string.Empty) {
				this.names.Add (namedObject.Name, namedObject);
			}
		}

		public T Retrieve<T> (string name) where T : ZincIName {
			ZincIName zn;
			if (this.names.TryGetValue (name, out zn)) {
				if (zn is T) {
					return (T)zn;
				} else {
					throw new ZincParseException ("Expected \"{0}\" to be of type \"{1}\", but was \"{2}\"", name, typeof(T), zn.GetType ());
				}
			} else {
				throw new ZincParseException ("Element \"{0}\" not in the scope.", name);
			}
		}

		public bool TryRetrieve<T> (string name, out T val) where T : ZincIName {
			ZincIName zn;
			if (this.names.TryGetValue (name, out zn)) {
				if (zn is T) {
					val = (T)zn;
					return true;
				}
			}
			val = default(T);
			return false;
		}

		public bool Contains (string name) {
			return this.names.ContainsKey (name);
		}
		#endregion

	}

}