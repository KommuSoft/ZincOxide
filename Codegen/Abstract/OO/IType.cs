//
//  IType.cs
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
using ZincOxide.Utils.Abstract;
using System.Diagnostics.Contracts;

namespace ZincOxide.Codegen.Abstract.OO {

	/// <summary>
	/// An interface describing a type in the object-oriented programming paradigm. In most
	/// object-oriented programming languages, types go beyond classes since for instance
	/// primitive types are not considered to be classes.
	/// </summary>
	[ContractClass(typeof(TypeContract))]
	public interface IType : IName {

		/// <summary>
		/// Obtain the method with the given <paramref name="name"/> and the given <paramref name="parameters"/> types.
		/// </summary>
		/// <returns>A <see cref="IMethod"/> instance representing the queried method, <c>null</c> if such method
		/// does not exists.</returns>
		/// <param name="name">The name of the requested method.</param>
		/// <param name="parameters">The list of the type of the parameters (or generalizations) of the requested method.</param>
		/// <remarks>
		/// <para>In case such method does not exists, an attempt is made to find
		/// a method where the parameters are generalized. If this attempt fails
		/// as well, <c>null</c> is returned.</para>
		/// </remarks>
		IMethod GetMethod (string name, params IType[] parameters);
	}
}

