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

namespace ZincOxide.Codegen.Abstract.OO.CSharp {

	/// <summary>
	/// An already defined type in C# (example <see cref="int"/>, <see cref="DateTime"/> and <see cref="String"/>).
	/// </summary>
	public class TypeReference : NameShadow, ICSharpType {

		#region Fields
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
		/// Initializes a new instance of the <see cref="TypeReference"/> class with a given <see cref="CodeTypeReference"/>
		/// that refers to the correct type.
		/// </summary>
		/// <param name="data">The reference to the associated type.</param>
		internal TypeReference (CodeTypeReference data) {
			this.data = data;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TypeReference"/> class with a given <see cref="System.Type"/>
		/// to which this reference should refer to.
		/// </summary>
		/// <param name="t">The type to which this type reference should refer.</param>
		internal TypeReference (System.Type t) : this(new CodeTypeReference(t)) {
		}
		#endregion
	}
}

