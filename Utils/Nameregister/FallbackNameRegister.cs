//
//  FallbackNameRegister.cs
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
using ZincOxide.Utils.Abstract;

namespace ZincOxide.Utils.Nameregister {

	/// <summary>
	/// A name register with a fallback function that generates an object for a given name.
	/// </summary>
	/// <typeparam name='T'>
	/// The type of element generated/stored by the name register.
	/// </typeparam>
	public class FallbackNameRegister<T> : NameRegister<T>, IFallbackNameRegister<T> where T : IName {

		#region IFallbackNameRegister`1 implementation
		/// <summary>
		/// The function that given the name register doesn't contain a key, generates an object that is stored in the name register.
		/// </summary>
		/// <value>The fallback.</value>
		public DNameRegisterFallback<T> Fallback {
			get;
			protected set;
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="T:FallbackNameRegister`1"/> class with a specified fallback mechanism.
		/// </summary>
		/// <param name="fallback">A function that generates an object when a specific name cannot be found, optional, by
		/// default <c>null</c> (no fallback).</param>
		/// <remarks>
		/// <para>If the given <paramref name="fallback"/> is not effective, no fallback mechanism is used.</para>
		/// </remarks>
		public FallbackNameRegister (DNameRegisterFallback<T> fallback = null) {
			this.Fallback = fallback;
		}
		#endregion
		#region NameRegister`1 override
		/// <summary>
		/// Checks if the name register contains the given key.
		/// </summary>
		/// <param name="name">The specified key.</param>
		public override bool Contains (string name) {
			if (!base.Contains (name)) {
				try {
					if (this.Fallback != null) {
						this.Fallback (name);
						return true;
					} else {
						return false;
					}
				} catch (ZincOxideNameNotFoundException) {
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Looks up the given name in the name register. If the register contains an object with the given name, the
		/// object is returned. Otherwise the object is generated using the fallback mechanism, stored in register and
		/// returned.
		/// </summary>
		/// <param name="name">The specified key to lookup.</param>
		public override T Lookup (string name) {
			try {
				return base.Lookup (name);
			} catch (ZincOxideNameNotFoundException) {
				if (this.Fallback != null) {
					return this.Fallback (name);
				} else {
					throw;
				}
			}
		}
		#endregion
	}
}

