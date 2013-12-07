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
using KommuSoft.HaskellLibraries;
using ZincOxide.Utils;

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
	public class ZincTupleType : IZincFundamentalType {
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
			private set {
				if (value == null) {
					throw new ArgumentNullException ("value", "The list of item types of a tuple must be effective.");
				}
				if (value.Count <= 0x01) {
					throw new ArgumentException ("The list of items of a tuple must contain at least two elements. Unary tuples are not allowed");
				}
				this.itemTypes = value;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.MiniZinc.Types.Fundamental.ZincTupleType"/> class with the types of elements.
		/// </summary>
		/// <param name="itemTypes">A list of items representing the type-instances of the elements of the tuple.</param>
		public ZincTupleType (IList<IZincFundamentalTypeInst> itemTypes) {
			this.ItemTypes = itemTypes;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.MiniZinc.Types.Fundamental.ZincTupleType"/> class with the type-instances of the elements.
		/// </summary>
		/// <param name="itemTypes">A list of items representing the type-instances of the elements of the tuple.</param>
		public ZincTupleType (params IZincFundamentalTypeInst[] itemTypes) : this ((IList<IZincFundamentalTypeInst>)itemTypes) {
		}

		#region IZincFundamentalType implementation

		/// <summary>
		/// Returns the enumerable of the depending <see cref="IZincFundamentalTypeInst"/>.
		/// </summary>
		/// <returns>An <see cref="IEnumerable{T}"/> of the depending types.</returns>
		public IEnumerable<IZincFundamentalTypeInst> GetDependingTypes () {
			return this.ItemTypes;
		}

		#endregion

		#region IGenericEquals implementation

		/// <summary>
		/// Checks if this zinc type is equal to the given zinc type.
		/// </summary>
		/// <returns><see langword="true"/>, if the types where equal, <see langword="false"/> otherwise.</returns>
		/// <param name="other">The <see cref="IZincFundamentalType"/> to match this type against.</param>
		public bool GenericEquals (IZincFundamentalType other) {
			ZincTupleType ztt = other as ZincTupleType;
			return ztt != null && EnumerableUtils.All (this.itemTypes, ztt.ItemTypes, (x, y) => x.GenericEquals (y));
		}

		#endregion

	}
}

