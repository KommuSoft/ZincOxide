//
//  IFallbackNameRegister.cs
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
using ZincOxide.Utils.Abstract;

namespace ZincOxide.Utils.Nameregister {

	/// <summary>
	/// An interface specifying a name register with a fallback mechanism.
	/// </summary>
	/// <typeparam name='T'>
	/// The type of element generated/stored by the name register.
	/// </typeparam>
	public interface IFallbackNameRegister<T> : INameRegister<T> where T : IName {

		/// <summary>
		/// Gets the fallback mechanism associated with this <see cref="T:IFallbackNameRegister`1"/>.
		/// </summary>
		/// <value>A <see cref="T:DNameRegisterFallback`1"/> instance that represents
		/// the fallback mechanism of this name register, not effective if no fallback mechanism
		/// exists.</value>
		DNameRegisterFallback<T> Fallback {
			get;
		}
	}
}

