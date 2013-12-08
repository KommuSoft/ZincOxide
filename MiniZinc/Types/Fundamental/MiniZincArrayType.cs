//
//  ZubcArrayType.cs
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
using KommuSoft.HaskellLibraries;

namespace ZincOxide.MiniZinc.Types.Fundamental {

	/// <summary>
	/// Zinc arrays are maps from fixed keys (a.k.a. indices) to values. Keys and values can be of any type. When used
	/// with integers keys, zinc arrays can be used like arrays in languages like Java, but with other types of keys,
	/// they act like associative arrays. Using floats or types containing floats as keys can be dangerous because their
	/// impricise equality comparsion and an implementation may give a warning in this case. The values can hae any
	/// type-instance. Arrays of arrays are allowed.
	/// </summary>
	/// <remarks>
	/// <para>All arrays are one dimensional. However, multi-dimensional arrays can be simulated using a tuple
	/// as index and there is some syntactic sugar to make this easier.</para>
	/// <para>Zinc arrays can be declared in two different ways.
	/// <list type="bullet">
	/// <item><description>Explicitly indexed arrays have index types in the declaration that are
	/// finite types. For example: <code>
	/// array[0..3] of int : a1;
	/// </code>
	/// For such arrays the index type specifies exactly the indices that will be in the array. The
	/// array's index set is the domain of the index type. And if the indices of the value assigned
	/// do not match then it is a run-time error. For example the following assignments cause run-time
	/// errors:<code>
	/// a1 = [0:0, 1:1, 2:2, 3:3, 4:4];        %too many elements
	/// array[1..5,1..10] of var float: a5=[]; %too few elements
	/// </code></description></item>
	/// <item><description>Implicit-indexed arrays have index types in the declaration that are not finite
	/// types. For example:
	/// <code>
	/// array[int] of int : a6;
	/// </code>
	/// No checking of indices occurs when these variables are assigned.</description></item></list></para>
	/// <para>The initialisation of an array can be done in a separate assignment statement, which may be present
	/// in the mode or a separate data file.</para>
	/// <para>Arrays can be accessed. (TODO)</para>
	/// <para>An array's size must be fixed. Its indices must also have fixed type-insts. Its elements may be fixed
	/// or unfixed.</para>
	/// <para>An array base type-inst expression tail has this syntax: <c>array [ ti-expr ] of ti-expr</c>
	/// or <c>list of ti-expr</c> Some example array type-instance expressions:<code>
	/// array[1..10] of int
	/// list of var int
	/// </code></para>
	/// <para>Note that <c>list of T</c> is just syntactical sugar for <c>array[int] of T</c></para>
	/// <para>Because arrays must be fixed-size, it is a type-inst error to precede an array type-inst expression
	/// with <c>var</c>.</para>
	/// <para>Syntactical sugar exiusts for declaring tuple-indexed arrays. For example, the second of the following
	/// two declarations is syntactic sugar for the first.
	/// <code>
	/// array[tuple(1..5, 1..4)] of int: a5;
	/// array[1..5, 1..4]        of int: a5;
	/// </code>
	/// </para>
	/// <para>Arrays are finite if the index types and the element type are all finite types. Otherwise no The domain
	/// of an array type that is finite is the set of all distinct arrays whose index set equals the domain
	/// of the index type and whose elements are of the array element type. For example, the domain of
	/// <c>array[5..6] of 1..2</c> is <c>{[5:1,6:1], [5:1,6:2], [5:2,6:1], [5:2,6:2]}</c>.</para>
	/// <para>No varification exists for an array.</para>
	/// <para>Arrays are ordered lexiographically taking the absence of a value for a given key to be before any
	/// value for that key. For example <c>[1:1, 2:1]</c> is less than <c>[1:1,2:2,3:3]</c> and
	/// <c>[2:0, 3:0, 4:0]</c> is less than <c>[1:1, 2:2, 3:3]</c>.</para>
	/// <para>An explicitly-indexed array variable must be initialised at instance-time only if its elements
	/// must be initialised at instance time. An implicitly-indexed array variable must be initialised at instance-time
	/// so that its length and index set is known.</para>
	/// <para>The following coercions are defined. <c>set of TI</c> to <c>array[1..n] of UI</c> if <c>TI</c>
	/// is coerced to <c>UI</c> where <c>n</c> is the number of elements in the list. The elements of the
	/// resulting array will be in sorted order. This means that elements of fixed sets can be accessed like array
	/// elements, using square brackets. Also <c>array[TIO] of TI</c> is coerced to <c>array[TIO] of UI</c>
	/// if <c>TI</c> is coerced to <c>UI</c> *(i.e. coercion of element type but not the index type).</para>
	/// <para>In MiniZinc, arrays must have indices that are contiguous integer ranges (e.g. <c>0..3</c>,
	/// <c>10..12</c>, or the name of a set variable assigned in the model with a range value), or a tuple
	/// of contiguous integer ranges.</para>
	/// <para>In MiniZinc, arrays must be declared with index types that are explicit ranges, or variables that
	/// are assigned a range value. Because these types are finite, only explicitly-indexed array variables
	/// can be declared in MiniZinc. The one exception is that implictly-indexed arrays are allowed as arguments to
	/// predicates and annotations.</para>
	/// <para>In MiniZinc, arrays can only contain booleans, integers, floats, or sets of integers (all fixed or unfixed)
	/// Furthermore, neither tuple literals nor tuple accesses are supported.</para>
	/// <para>In MiniZinc, array indexed by tuples can only have integers as elements of the tuple.</para>
	/// </remarks>
	public class MiniZincArrayType : IMiniZincType {
		private IMiniZincTypeInst indexType, elementType;

		/// <summary>
		/// The index type of the array.
		/// </summary>
		/// <value>The index type of the array.</value>
		/// <exception cref="ArgumentNullException">If <paramref name="value"/> is not effective.</exception>
		/// <exception cref="ArgumentException">If <paramref name="value"/> is varified.</exception>
		public IMiniZincTypeInst IndexType {
			get {
				return this.indexType;
			}
			private set {
				if (value == null) {
					throw new ArgumentNullException ("value", "The index type must be effective.");
				} else if (value.Instantiation == ZincVarPar.Var) {
					throw new ArgumentException ("The index type must be parameterized, not variable.");
				}
				this.indexType = value;
			}
		}

		/// <summary>
		/// The element type of the array.
		/// </summary>
		/// <value>The element type of the array.</value>
		/// <exception cref="ArgumentNullException">If <paramref name="value"/> is not effective.</exception>
		public IMiniZincTypeInst ElementType {
			get {
				return this.elementType;
			}
			private set {
				if (value == null) {
					throw new ArgumentException ("the element type must be effective.");
				}
				this.elementType = value;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MiniZincArrayType"/> class with
		/// a given type instance for the index and the elements.
		/// </summary>
		/// <param name="indexType">The type of the index of the array.</param>
		/// <param name="elementType">The type of the elements in the array.</param>
		/// <exception cref="ArgumentNullException">If <paramref name="indexType"/> or
		/// <paramref name="elementType"/> is not effective.</exception>
		/// <exception cref="ArgumentException">If the <paramref name="indexType"/> is varified.</exception>
		public MiniZincArrayType (IMiniZincTypeInst indexType, IMiniZincTypeInst elementType) {
			this.IndexType = indexType;
			this.ElementType = elementType;
		}

		#region IGenericEquals implementation

		/// <summary>
		/// Checks if this zinc type is equal to the given zinc type.
		/// </summary>
		/// <returns><see langword="true"/>, if both types are equal, <see langword="false"/> otherwise.</returns>
		/// <param name="other">The zinc type to compare with.</param>
		public bool GenericEquals (IMiniZincType other) {
			MiniZincArrayType zat = other as MiniZincArrayType;
			return zat != null && this.IndexType.GenericEquals (zat.IndexType) && this.ElementType.GenericEquals (zat.ElementType);
		}

		#endregion

		/// <summary>
		/// Returns the enumerable of the depending <see cref="IZincFundamentalTypeInst"/>.
		/// </summary>
		/// <returns>An <see cref="IEnumerable{T}"/> of the depending types.</returns>
		public IEnumerable<IMiniZincTypeInst> GetDependingTypes () {
			return DataList.Append (DataList.Prepend (this.IndexType, this.IndexType.GetDependingTypes ()),
				DataList.Prepend (this.ElementType, this.ElementType.GetDependingTypes ()));
		}
	}
}

