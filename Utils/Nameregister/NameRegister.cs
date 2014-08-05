//
//  NameRegister.cs
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
using ZincOxide.Exceptions;
using ZincOxide.Utils.Abstract;

namespace ZincOxide.Utils.Nameregister {

	public class NameRegister<T> : INameRegister<T> where T : IName {

		private readonly Dictionary<string,T> dictionary = new Dictionary<string, T> ();
		#region INameRegister implementation
		public void Register (T value) {
			if (value != null) {
				string key = value.Name;
				if (!this.dictionary.ContainsKey (key)) {
					this.dictionary.Add (key, value);
				}
			}
		}

		/// <summary>
		/// Checks if the name register contains the given key.
		/// </summary>
		/// <param name="name">The specified key.</param>
		public virtual bool Contains (string name) {
			return (this.dictionary.ContainsKey (name));
		}

		/// <summary>
		/// Looks up the given name in the name register. If the register contains an object with the given name, the
		/// object is returned. Otherwise the object is generated using the fallback mechanism, stored in register and
		/// returned.
		/// </summary>
		/// <param name="name">The specified key to lookup.</param>
		public virtual T Lookup (string name) {
			T val;
			if (this.dictionary.TryGetValue (name, out val)) {
				return val;
			} else {
				throw new ZincOxideNameNotFoundException ("Name \"{0}\" not found in the name register.", name);
			}
		}
		#endregion
	}
}

