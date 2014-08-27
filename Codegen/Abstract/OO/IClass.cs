//
//  IClass.cs
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
	/// An interface describing a language-invariant class: a description of a group of instances.
	/// </summary>
	public interface IClass : IName {

		/// <summary>
		/// Generate a field stored in this class.
		/// </summary>
		/// <param name='name'>The name of the field to be added.</param>
		/// <returns>A <see cref="IField"/> instance describing the generated field.</returns>
		IField GenerateField (string name);

		/// <summary>
		/// Add a public constructor to the class that instantiates the given fields.
		/// </summary>
		/// <param name="fields">A list of fields that are all instantiated by the constructor.</param>
		/// <remarks>
		/// <para>The order of the constructor parameters is the same as the order of the given list.</para>
		/// <para>Fields not belonging to the class, not effective of from the wrong type are ignored.</para>
		/// </remarks>
		void AddConstructor (params IField[] fields);

		/// <summary>
		/// Add a public constructor to the class that instantiates the given fields.
		/// </summary>
		/// <param name="fields">A list of fields that are all instantiated by the constructor.</param>
		/// <remarks>
		/// <para>The order of the constructor parameters is the same as the order of the given list.</para>
		/// <para>Fields not belonging to the class, not effective of from the wrong type are ignored.</para>
		/// </remarks>
		void AddConstructor (IEnumerable<IField> fields);
	}
}

