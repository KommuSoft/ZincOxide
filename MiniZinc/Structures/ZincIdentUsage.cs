//
//  ZincIdentUsage.cs
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

namespace ZincOxide.MiniZinc.Structures {

	/// <summary>
	/// An enum that provides a hint for the use of the identifier.
	/// </summary>
	public enum ZincIdentUsage : byte {
		/// <summary>
		/// The use of the identifier is unknown.
		/// </summary>
		Unknown = 0x00,
		/// <summary>
		/// The identifier is a global variable.
		/// </summary>
		GlobalVariable = 0x01,
		/// <summary>
		/// The identifier is a local variable.
		/// </summary>
		LocalVariable = 0x02,
		/// <summary>
		/// The identifier is a function/predicate.
		/// </summary>
		Function = 0x03,
		/// <summary>
		/// The identifier is an annotation.
		/// </summary>
		Annotation = 0x04
	}
}