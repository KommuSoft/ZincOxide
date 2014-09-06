//
//  TypeReference.cs
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
using ZincOxide.Utils.Abstract;
using System.Collections.Generic;

namespace ZincOxide.Codegen.Abstract.OO.CSharp {

	/// <summary>
	/// An already defined type in C# (example <see cref="int"/>, <see cref="DateTime"/> and <see cref="string"/>).
	/// </summary>
	public class TypeReference : TypeBase, ICSharpType {

		#region Fields
		private readonly Type type;
		private readonly CodeTypeReference data;
		#endregion
		#region implemented abstract members of NameShadow
		/// <summary>
		/// Gets the name of this C# class.
		/// </summary>
		/// <value>The name of this C# class.</value>
		public override string Name {
			get {
				return this.data.GetType ().Name;
			}
		}
		#endregion
		#region implemented abstract members of Type
		/// <summary>
		/// Get a reference to this type, used for implementation and the creation of code members.
		/// </summary>
		/// <value>A <see cref="CodeTypeReference"/> that refers to this type.</value>
		public CodeTypeReference Reference {
			get {
				return this.data;
			}
		}
		#endregion
		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="TypeReference"/> class with a given <see cref="System.Type"/>
		/// to which this reference should refer to.
		/// </summary>
		/// <param name="type">The type to which this type reference should refer.</param>
		internal TypeReference (System.Type type) {
			this.type = type;
			this.data = new CodeTypeReference (type);
		}
		#endregion
		#region IType implementation
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
		/// <para>Only effective types of the <see cref="ICSharpType"/> type are accepted.</para>
		/// </remarks>
		public override IMethod GetMethod (string name, IEnumerable<IType> parameters) {

			return null;
		}
		#endregion
	}
}

