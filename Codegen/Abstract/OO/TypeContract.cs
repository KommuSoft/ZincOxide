//
//  ITypeContract.cs
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
using ZincOxide.Utils.Abstract;
using System.Collections.Generic;

namespace ZincOxide.Codegen.Abstract.OO {

	/// <summary>
	/// A contract class for a <see cref="IType"/>, an interface describing a type in the object-oriented programming
	/// paradigm.
	/// </summary>
	[ContractClassFor(typeof(IType))]
	public class TypeContract : NameShadow, IType {

		#region IName implementation
		/// <summary>
		/// Get the name of the type.
		/// </summary>
		/// <value>The name of the type.</value>
		public override string Name {
			get {
				Contract.Ensures (Contract.Result<string> () != null);
				return default(string);
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="TypeContract"/> class.
		/// </summary>
		protected TypeContract () {
		}
		#endregion
		#region IType implementation
		/// <summary>
		/// Obtain the constructor with the given <paramref name="parameters"/> types.
		/// </summary>
		/// <returns>A <see cref="IConstructor"/> instance representing the queried constructor, <c>null</c> if such constructor
		/// does not exists.</returns>
		/// <param name="parameters">The list of the type of the parameters (or generalizations) of the requested constructors.</param>
		/// <remarks>
		/// <para>In case such constructor does not exists, an attempt is made to find
		/// a constructor where the parameters are generalized. If this attempt fails
		/// as well, <c>null</c> is returned.</para>
		/// </remarks>
		public IConstructor GetConstructor (params IType[] parameters) {
			return default(IConstructor);
		}

		/// <summary>
		/// Obtain the constructor with the given <paramref name="parameters"/> types.
		/// </summary>
		/// <returns>A <see cref="IConstructor"/> instance representing the queried constructor, <c>null</c> if such constructor
		/// does not exists.</returns>
		/// <param name="parameters">The list of the type of the parameters (or generalizations) of the requested constructors.</param>
		/// <remarks>
		/// <para>In case such constructor does not exists, an attempt is made to find
		/// a constructor where the parameters are generalized. If this attempt fails
		/// as well, <c>null</c> is returned.</para>
		/// </remarks>
		public IConstructor GetConstructor (IEnumerable<IType> parameters) {
			return default(IConstructor);
		}

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
		public IMethod GetMethod (string name, params IType[] parameters) {
			return default(IMethod);
		}

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
		public IMethod GetMethod (string name, IEnumerable<IType> parameters) {
			return default(IMethod);
		}
		#endregion
	}
}

