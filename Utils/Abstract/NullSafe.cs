//
//  NullSafe.cs
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

namespace ZincOxide.Utils.Abstract {

	/// <summary>
	/// A utility library that can be used to make null checks way easier to handle.
	/// </summary>
	public static class NullSafe {

		/// <summary>
		/// Invokes the given <paramref name="function"/> with the given <paramref name="data"/> safely:
		/// if the given data is <c>null</c>, null is returned as well, otherwise the function is invoked.
		/// </summary>
		/// <returns>The result of the function invocation if the the given data is effective, <c>null</c> otherwise.</returns>
		/// <param name="data">The given data to check and invoke the <paramref name="function"/> with.</param>
		/// <param name="function">The given function to invoke.</param>
		/// <typeparam name="TX">The type of data that is provided.</typeparam>
		/// <typeparam name="TResult">The type of the result of the function: the type of data that must be returned.</typeparam>
		/// <remarks>
		/// <para>For performance issues, the function is assumed to be effective, no check is done.</para>
		/// </remarks>
		public static TResult OrNull <TX,TResult> (this TX data, Func<TX,TResult> function)
			where TX : class
			where TResult : class {
			if (data != null) {
				return function (data);
			} else {
				return null;
			}
		}
	}
}

