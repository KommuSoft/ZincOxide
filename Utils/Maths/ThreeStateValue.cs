//
//  EmptyEnumeration.cs
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

namespace ZincOxide.Utils.Maths {

	/// <summary>
	/// An enumeration type that represents three state logic values: true, false and unknown.
	/// </summary>
	public enum ThreeStateValue : byte {
		/// <summary>
		/// The given proposition is true.
		/// </summary>
		True = 0x03,
		/// <summary>
		/// The given proposition is false.
		/// </summary>
		Unknown = 0x01,
		/// <summary>
		/// It is unknown (or not computable) if the proposition is true or false.
		/// </summary>
		False = 0x00
	}
}

