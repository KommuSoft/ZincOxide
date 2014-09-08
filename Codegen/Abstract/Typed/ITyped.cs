//
//  ITyped.cs
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
using System.Diagnostics.Contracts;

namespace ZincOxide.Codegen.Abstract.Typed {

	/// <summary>
	/// An interface specifying that this instance is typed.
	/// </summary>
	/// <remarks>
	/// <para>For instance a field has a certain type, a method returns a specific value, etc.</para>
	/// </remarks>
	[ContractClass(typeof(TypedContract))]
	public interface ITyped {

		/// <summary>
		/// Get the type of the instance (variable, field,...).
		/// </summary>
		/// <value>The type of the instance (variable, field,...).</value>
		/// <remarks>
		/// <para>If the type is not effective, it is not relevant for the memeber (e.g. untyped variables, <c>void</c> methods).</para>
		/// </remarks>
		IType Type {
			get;
		}
	}
}

