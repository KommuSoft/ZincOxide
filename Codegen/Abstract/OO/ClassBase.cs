//
//  ClassBase.cs
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

namespace ZincOxide.Codegen.Abstract.OO {

	/// <summary>
	/// A basic implementation of the <see cref="IClass"/> interface, used for programming convenience.
	/// </summary>
	public abstract class ClassBase : NameShadow, IClass {

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ClassBase"/> class, since not much is known, nothing is done.
		/// </summary>
		protected ClassBase () {
		}
		#endregion
		#region IClass implementation
		/// <summary>
		/// Generate a field stored in this class.
		/// </summary>
		/// <param name='name'>The name of the field to be added.</param>
		/// <returns>A <see cref="IField"/> instance describing the generated field.</returns>
		public abstract IField GenerateField (string name);

		/// <summary>
		/// Add a public constructor to the class that instantiates the given fields.
		/// </summary>
		/// <param name="modifiers">A modifier value that specifies how the constructor should be implemented.</param>
		/// <param name="fields">A list of fields that are all instantiated by the constructor.</param>
		/// <remarks>
		/// <para>The order of the constructor parameters is the same as the order of the given list.</para>
		/// <para>Fields not belonging to the class, not effective of from the wrong type are ignored.</para>
		/// <para>The constructor simply sets the fields to the given value, no consistency checks are performed.</para>
		/// </remarks>
		public void AddConstructor (OOModifiers modifiers = OOModifiers.Public, params IField[] fields) {
			this.AddConstructor ((IEnumerable<IField>)fields, modifiers);
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
		public abstract void AddConstructor (IEnumerable<IField> fields, OOModifiers modifiers = OOModifiers.Public);

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
		public abstract void AddFieldConstructor (OOModifiers modifiers = OOModifiers.Public);
		#endregion
	}
}

