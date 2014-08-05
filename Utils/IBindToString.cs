//
//  IBindToString.cs
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

namespace ZincOxide.Utils {

	/// <summary>
	/// An interface used to specify that the instance can be converted to a string that does not only show the content
	/// of the item, but the address or an identifier as well such that in textual output, one can analyze the reference
	/// network.
	/// </summary>
	public interface IBindToString {

		/// <summary>
		/// Generate a string that contains the content of the instances together with an identifier or a memory address.
		/// </summary>
		/// <returns>A string containing both the data and identifier of the instance.</returns>
		/// <remarks>
		/// <para>Since the content can be anything, it's hard to define a unambiguous format. We advice
		/// to use <c>data&amp;identifier</c>.</para>
		/// </remarks>
		string ToBindString ();
	}
}

