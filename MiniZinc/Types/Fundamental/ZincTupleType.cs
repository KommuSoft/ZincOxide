//
//  ZincTupleType.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
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
using System.Runtime.CompilerServices;

namespace ZincOxide.MiniZinc.Types.Fundamental {

	/// <summary>
	/// Tuples are fixed-size hetrogeneous collections. They must contain at least two elements. Unary tuples are not
	/// allowed. Tuples may contain unfixed elements.
	/// </summary>
	/// <remarks>
	/// <para>A tuple base type-inst expression tail has this syntax: <c>tuple (ti-expr, ...)</c>. An example tuple
	/// type-instance expression is <c>tuple (int,var float)</c>. It is a type-instance error to precede a tuple
	/// type-instance expression with <c>var</c>.</para>
	/// <para>A tuple type is finite if all constituent elements are finite types. Otherwise false. The domain
	/// of a tuple type that is a finite type is the Cartesian pr	oduct of the domains of the element types.
	/// For example the domain of tuple (1..2,{3,5}) is {(1,3),(1,5),(2,3),(2,5)}</para>
	/// <para>A tuple type is varifiable if all its constituent elements are varifiable. A tuple is
	/// varified by varifying its constituent elements.</para>
	/// <para>Tuples are ordered lexicographically.</para>
	/// <para>A tuple variable must be initialised at instance-time if any of its constituent elements must be initialized
	/// at instance-time.</para>
	/// <para>The coercions of a tuple are the following: <c>tuple (TI1, TI2, ..., TIn)</c> to <c>tuple (UI1, UI2, ..., UIn)</c>
	/// if all types <c>TIi</c> coerce to <c>UIi</c>.</para>
	/// </remarks>
	public class ZincTupleType {
		private IList<IZincFundamentalTypeInst> itemTypes;

		/// <summary>
		/// Gets the <see cref="IZincFundamentalTypeInst"/> of the tuple at a specified index.
		/// </summary>
		/// <param name="index">The index of the tuple.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is larger or equal to the number of elements of the tuple.</exception>
		[IndexerName ("Element")]
		public IZincFundamentalTypeInst this [int index] {
			get {
				return this.itemTypes [index];
			}
		}

		/// <summary>
		/// Gets or sets the list of item types of the tuple.
		/// </summary>
		/// <value>The list of type-instances of the tuple type.</value>
		/// <exception cref="ArgumentNullException">If the <paramref name="value"/> is not effective.</exception>
		/// <exception cref="ArgumentException">If the given list contains less than two elements.</exception>
		public IList<IZincFundamentalTypeInst> ItemTypes {
			get {
				return this.itemTypes;
			}
			set {
				if (value == null) {
					throw new ArgumentNullException ("value", "The list of item types of a tuple must be effective.");
				}
				if (value.Count <= 0x01) {
					throw new ArgumentException ("The list of items of a tuple must contain at least two elements. Unary tuples are not allowed");
				}
				this.itemTypes = value;
			}
		}

		public ZincTupleType (IList<IZincFundamentalTypeInst> itemTypes) {
			this.ItemTypes = itemTypes;
		}
	}
}

