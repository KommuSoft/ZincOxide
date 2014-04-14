//
//  IFinite.cs
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

namespace ZincOxide.Utils.Abstract {

	/// <summary>
	/// An interface that describes a certain set where one can check whether that set is finite or not.
	/// </summary>
	/// <remarks>
	/// <para>The set does not have to be an explicit collection. For instance a rectangle is an implicit set
	/// of points.</para>
	/// </remarks>
	public interface IFinite {

		/// <summary>
		/// Gets a value indicating whether the cardinality of items contained by this instance is finite.
		/// </summary>
		/// <value>
		/// <c>true</c> if the cardinality of this instance is finite; otherwise, <c>false</c>.
		/// </value>
		bool Finite {
			get;
		}

	}
}