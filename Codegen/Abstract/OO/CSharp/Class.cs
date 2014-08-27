//
//  Class.cs
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
using System.Collections.Generic;
using ZincOxide.Utils.Abstract;
using System.CodeDom;
using System.Diagnostics.Contracts;

namespace ZincOxide.Codegen.Abstract.OO.CSharp {

	/// <summary>
	/// The representation of an <see cref="IClass"/> in C#.
	/// </summary>
	public class Class : NameShadow, IClass {

		#region Fields
		private readonly CodeTypeDeclaration data;
		#endregion
		#region implemented abstract members of NameShadow
		/// <summary>
		/// Gets the name of this C# class.
		/// </summary>
		/// <value>The name of this C# class.</value>
		public override string Name {
			get {
				return data.Name;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Class"/> class, used to describe and alter a class in C#.
		/// </summary>
		/// <param name="data">The data that represents the class.</param>
		internal Class (CodeTypeDeclaration data) {
			Contract.Requires (data != null);
			Contract.Ensures (this.data != null);
			this.data = data;
		}
		#endregion
		#region IClass implementation
		/// <summary>
		/// Generate a field stored in this class.
		/// </summary>
		/// <param name='name'>The name of the field to be added.</param>
		/// <returns>A <see cref="IField"/> instance describing the generated field.</returns>
		public IField GenerateField (string name) {
			CodeMemberField cmf = new CodeMemberField (typeof(object), name);
			this.data.Members.Add (cmf);
			return new Field (cmf);
		}
		#endregion
		#region IClass implementation
		public void AddConstructor (params IField[] fields) {
			this.AddConstructor ((IEnumerable<IField>)fields);
		}

		public void AddConstructor (IEnumerable<IField> fields) {
			CodeConstructor cc = new CodeConstructor ();
			this.data.Members.Add (cc);
		}
		#endregion
	}
}

