//
//  Type.cs
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
using System.CodeDom;
using ZincOxide.Codegen.Abstract.OO.CSharp;
using System.Diagnostics.Contracts;
using ZincOxide.Codegen.Abstract.Typed;

namespace ZincOxide.Codegen.Abstract.OO.CSharp {

	/// <summary>
	/// The representation of a <see cref="IType"/> in C#.
	/// </summary>
	[ContractClass(typeof(CSharpTypeContract))]
	public interface ICSharpType : IType {

		/// <summary>
		/// Get a reference to this type, used for implementation and the creation of code members.
		/// </summary>
		/// <value>A <see cref="CodeTypeReference"/> that refers to this type.</value>
		/// <remarks>
		/// <para>The reference is guaranteed to be effective.</para>
		/// </remarks>
		CodeTypeReference Reference {
			get;
		}
	}
}

