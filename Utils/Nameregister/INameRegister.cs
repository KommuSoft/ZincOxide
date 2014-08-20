//
//  INameRegister.cs
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
using System.Collections.Generic;

namespace ZincOxide.Utils.Nameregister {

	/// <summary>
	/// A basic name register that stores (registers) objects that are named and can lookup such elements.
	/// </summary>
	/// <typeparam name='T'>
	/// The type of element generated/stored by the name register.
	/// </typeparam>
	public interface INameRegister<T> where T : IName {

		/// <summary>
		/// Register the given <paramref name="value"/> in the register such that the instance can be looked up later.
		/// </summary>
		/// <param name="value">The given value to register.</param>
		void Register (T value);

		/// <summary>
		/// Check if the name register contains an entry for the given <paramref name="name"/>.
		/// </summary>
		/// <param name="name">The given name to check for.</param>
		bool Contains (string name);

		/// <summary>
		/// perform a lookup operation on the given <paramref name="name"/> and retrieve the object. If not found
		/// other mechanism can be applied or a <see cref="ZincOxideNameNotFoundException"/> exception is thrown.
		/// </summary>
		/// <param name="name">The name of the object to look for.</param>
		/// <exception cref="ZincOxideNameNotFoundException">If the given <paramref name="name"/> cannot be found
		/// in the register and all fallback mechanisms are exhausted.</exception>
		T Lookup (string name);

		/// <summary>
		/// Enumerate all the elements stored in the name register (at this level, without using fallbacks, etc.).
		/// </summary>
		/// <returns>
		/// An <see cref="T:IEnumerable`1"/> instance that enumerates all the elements stored in this name register.
		/// </returns>
		IEnumerable<T> Elements ();
	}
}