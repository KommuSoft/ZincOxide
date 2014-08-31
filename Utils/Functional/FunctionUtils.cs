//
//  FunctionUtils.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2014 Willem Van Onsem
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
using System.Threading.Tasks;

namespace ZincOxide.Utils.Functional {

	/// <summary>
	/// A utility class to combine functions, currying, etc.
	/// </summary>
	public static class FunctionUtils {

		/// <summary>
		/// Generate an <see cref="T:Action`1"/> instance where a virtual parameter is introduced.
		/// </summary>
		/// <param name="initial">The initial action without parameter that must be parameterized.</param>
		/// <typeparam name="T">The type of the virtual parameter that must be added.</typeparam>
		public static Action<T> Parameterize<T> (this Action initial) {
			return x => initial ();
		}
	}
}

