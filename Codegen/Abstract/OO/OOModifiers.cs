//
//  OOModifiers.cs
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

namespace ZincOxide.Codegen.Abstract.OO {

	/// <summary>
	/// Modifiers used to specify how members/elements in an object-oriented language are handled/implemented.
	/// </summary>
	[Flags]
	public enum OOModifiers : ulong {

		#region Access
		/// <summary>
		/// A mask to filter out access out of a <see cref="OOModifiers"/>.
		/// </summary>
		AccessMask = 0xff0000,
		/// <summary>
		/// The member is publicly available.
		/// </summary>
		Public = 0x080000,
		/// <summary>
		/// The member is protected: only deriving types can access.
		/// </summary>
		Protected = 0x040000,
		/// <summary>
		/// The member is only available to the assembly.
		/// </summary>
		Internal = 0x020000,
		/// <summary>
		/// The member is privately.
		/// </summary>
		Private = 0x010000,
		#endregion
		#region Specification
		/// <summary>
		/// A mask to filter out specifications out of a <see cref="OOModifiers"/>.
		/// </summary>
		SpecificationMask = 0xff00,
		/// <summary>
		/// The member is read-only: the value can't be override.
		/// </summary>
		Readonly = 0x0800,
		/// <summary>
		/// The member serves as an input value.
		/// </summary>
		In = 0x0400,
		/// <summary>
		/// The member serves as an output value.
		/// </summary>
		Out = 0x0200,
		/// <summary>
		/// The member is communicated by reference.
		/// </summary>
		Ref = 0x0100,
		#endregion
		#region Implementation
		/// <summary>
		/// A mask to filter out implementation issues out of a <see cref="OOModifiers"/>.
		/// </summary>
		ImplementationMask = 0xff,
		/// <summary>
		/// The member is abstract: no implementation is provided.
		/// </summary>
		Abstract = 0x10,
		/// <summary>
		/// The member is virtual: children members can override the member.
		/// </summary>
		/// <seealso cref="Override"/>
		Virtual = 0x08,
		/// <summary>
		/// The member is static, one does not need an instance to access it.
		/// </summary>
		Static = 0x04,
		/// <summary>
		/// The member is final: no "child" members are allowed.
		/// </summary>
		Final = 0x02,
		/// <summary>
		/// The member is an override of a "parent" member.
		/// </summary>
		Override = 0x01
		#endregion
	}
}

