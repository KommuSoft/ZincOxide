//
//  ProgramDataRepresentation.cs
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
using System.Numerics;

namespace ZincOxide.Environment {

	/// <summary>
	/// An enumeration class to provide information about how integers will be represented.
	/// </summary>
	public enum ProgramIntegerRepresentation : long {
		/// <summary>
		/// Integers will be represented as <see cref="Int16"/> or <see langword="short"/>.
		/// </summary>
		Int16 = 0x0000000000000001,
		/// <summary>
		/// Integers will be represented as <see cref="Int32"/> or <see langword="int"/>.
		/// </summary>
		Int32 = 0x0000000000000002,
		/// <summary>
		/// Integers will be represented as <see cref="Int64"/> or <see langword="long"/>.
		/// </summary>
		Int64 = 0x0000000000000003,
		/// <summary>
		/// Integers will be represented as <see cref="BigInteger"/> with infinite length (bounded by memory limit).
		/// </summary>
		/// <remarks>
		/// <para>Using this setting is not recommended since all operations will be carried out softwarematically.
		/// Only when the problem has dimensional problems, one should use this option.</para>
		/// </remarks>
		Integer = 0x0000000000000004
	}
}

