//
//  IDimensions.cs
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
	/// An interface describing that this instance has a number of dimensions.
	/// </summary>
	public interface IDimensions {

		/// <summary>
		/// Gets the number of dimensions of this instance.
		/// </summary>
		/// <value>
		/// The number of dimensions of this instances.
		/// </value>
		int Dimensions {
			get;
		}

	}

}

