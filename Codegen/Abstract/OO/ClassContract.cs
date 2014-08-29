//
//  ClassContract.cs
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
	/// A contract class that specifies the contracts attached to a <see cref="IClass"/> implementation.
	/// </summary>
	[ContractClassFor(IClass)]
	public abstract class ClassContract : NameShadow, IClass {

		
		#region IName implementation
		/// <summary>
		/// Get the name of the class.
		/// </summary>
		/// <value>The name of the class.</value>
		public string Name {
			get {
				Contract.Ensures (Contract.Result<string> () != null);
				return default(string);
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ClassContract"/> class.
		/// </summary>
		protected ClassContract () {
		}
		#endregion
		#region IClass implementation
		/// <summary>
		/// Generate a field contained in this class.
		/// </summary>
		/// <param name='type'>The type of the field.</param>
		/// <param name='name'>The name of the field to be added.</param>
		/// <returns>A <see cref="IField"/> instance describing the generated field.</returns>
		public IField GenerateField (IType type, string name) {
			Contract.Requires (type != null);
			Contract.Requires (name != null);
			Contract.Ensures (Contract.Result<IField> () != null);
			return default(IField);
		}

		/// <summary>
		/// Generate a method contained in this class.
		/// </summary>
		/// <returns>A <see cref="IMethod"/> that represents the generated method and can be altered.</returns>
		/// <param name="returnType">A <see cref="IType"/> that specifies the return type of the method, <c>null</c> if the return type is <c>void</c> (or irrelevant).</param>
		/// <param name="name">The name of the method to be generated.</param>
		/// <param name="fields">A list of parameters that should be defined by the method.</param>
		public IMethod GenerateMethod (IType returnType, string name, params IType[] fields) {
			Contract.Requires (name != null);
			Contract.Ensures (Contract.Result<IMethod> () != null);
			return default(IMethod);
		}

		/// <summary>
		/// Generate a method contained in this class that returns nothing, or where the return data is irrelevant.
		/// </summary>
		/// <returns>A <see cref="IMethod"/> that represents the generated method and can be altered.</returns>
		/// <param name="name">The name of the method to be generated.</param>
		/// <param name="fields">A list of parameters that should be defined by the method.</param>
		public IMethod GenerateMethod (string name, params IType[] fields) {
			Contract.Requires (name != null);
			Contract.Ensures (Contract.Result<IMethod> () != null);
			return default(IMethod);
		}

		/// <summary>
		/// Add a public constructor to the class that instantiates the given fields.
		/// </summary>
		/// <param name="modifiers">A modifier value that specifies how the constructor should be implemented, optional, by default public access.</param>
		/// <param name="fields">A list of fields that are all instantiated by the constructor.</param>
		/// <remarks>
		/// <para>The order of the constructor parameters is the same as the order of the given list.</para>
		/// <para>Fields not belonging to the class, not effective of from the wrong type are ignored.</para>
		/// <para>The constructor simply sets the fields to the given value, no consistency checks are performed.</para>
		/// </remarks>
		public void AddConstructor (OOModifiers modifiers, params IField[] fields) {
		}

		/// <summary>
		/// Add a public constructor to the class that instantiates the given fields.
		/// </summary>
		/// <param name="fields">A list of fields that are all instantiated by the constructor.</param>
		/// <param name="modifiers">A modifier value that specifies how the constructor should be implemented.</param>
		/// <remarks>
		/// <para>The order of the constructor parameters is the same as the order of the given list.</para>
		/// <para>Fields not belonging to the class, not effective of from the wrong type are ignored.</para>
		/// <para>The constructor simply sets the fields to the given value, no consistency checks are performed.</para>
		/// </remarks>
		public void AddConstructor (System.Collections.Generic.IEnumerable<IField> fields, OOModifiers modifiers) {
		}

		/// <summary>
		/// Add a constructor to the class where all fields are included as parameters.
		/// </summary>
		/// <param name="modifiers">A modifier value that specifies how the constructor should be implemented.</param>
		/// <remarks>
		/// <para>The order is determined by the order in which fields were added to the class.</para>
		/// <para>The constructor simply sets the fields to the given value, no consistency checks are performed.</para>
		/// <para>This method is not declarative: adding fields to the class after calling this method
		/// will not modify the constructor.</para>
		/// </remarks>
		public void AddFieldConstructor (OOModifiers modifiers) {
		}
		#endregion
	}
}

