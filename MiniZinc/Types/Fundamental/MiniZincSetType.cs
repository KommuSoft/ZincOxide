//
//  ZincTFSet.cs
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
using ZincOxide.Utils.Maths;
using System.Diagnostics.Contracts;

namespace ZincOxide.MiniZinc.Types.Fundamental {

	/// <summary>
	/// A set is a collection with no duplicates.
	/// </summary>
	/// <remarks>
	/// <para>The type-ins of a set's elements must be fixed. This is because current solvers are not powerful
	/// enough to handle sets containing decision variables. Sets may contain any type and may be fixed or
	/// unfixed. If a set is unfixed, its elements must be finite. Unless it occurs in one the following contexts:
	/// <list type="bullet">
	/// <item><description>The argument of a predicate, function or annotations.</description></item>
	/// <item><description>The declaration of a variable or let local variable with an assigned value.</description></item>
	/// </list></para>
	/// <para>A set based type-inst expression tail has this syntax: <c>set of </c> followed by a type-instance expression.</para>
	/// <para>The type is finite if the set elements are finite types. Otherwise, no. The domain of a set type that is a finite
	/// type is the powerset of the domain of its element types.</para>
	/// <para>Sets are ordered using the lexicographical ordering on the corresponding characteristics arrays. For example:
	/// <code>
	/// {} &lt; {2} &lt; {1,3}
	/// </code>
	/// Since sets have no inherent ordening themselves. The sets are first sorted.
	/// </para>
	/// <para>A fixed set variable must be initialized at instance-time. An unfixed set variable need not be.</para>
	/// <para>The varification of a set is defined as: <c>par set of TI</c> to <c>var set of TI</c>
	/// and <c>var set of TI</c> to <c>var set of TI</c>.</para>
	/// <para>The coercion of a set is defined as: <c>par set of TI</c> to <c>par set of UI</c> and
	/// <c>par set of TI</c> to <c>var set of UI</c> and <c>var set of TI</c> to <c>var set of UI</c> if
	/// <c>TI</c> can be coerced to <c>UI</c>.</para>
	/// <para>Fixed sets can be automatically coerced to arrays. This means that array acces can be used on fixed sets.
	/// <c>S[1]</c> is the smallest element in a fixed set <c>S</c> while <c>S[card(S)]</c> is the largest.</para>
	/// <para>In MiniZinc, sets can only contain booleans, integers, and floats. Sets of integers may be fixed
	/// unfixed. Other sets must be fixed.</para>
	/// </remarks>
	/// <example>
	/// Some example set type-instance expressions:
	/// <code>
	/// set of int
	/// var set of bool
	/// </code>
	/// </example>
	public class MiniZincSetType : IMiniZincCollectionType {

		#region Fields
		private IMiniZincTypeInst elementType;
		#endregion
		/// <summary>
		/// The element's type of the set.
		/// </summary>
		/// <value>The element's type of the set.</value>
		/// <exception cref="ArgumentNullException">If the given argument is <see langword="null"/>.</exception>
		public IMiniZincTypeInst ElementType {
			get {
				return this.elementType;
			}
			private set {
				if (value == null) {
					throw new ArgumentNullException ("value", "The element type of a set must be effective.");
				} else {
					if (value == null) {
						throw new ArgumentNullException ("The given element type of the set is not effective.");
					}
					Contract.EndContractBlock ();
					this.elementType = value;
				}
			}
		}
		#region IMiniZincType implementation
		/// <summary>
		/// Gets if the type has a finite domain.
		/// </summary>
		/// <value><see langword="true"/> if the type has a finite domain, <see langword="false"/> otherwise.</value>
		public ThreeStateValue Finite {
			get {
				return elementType.Finite;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="MiniZincSetType"/> class with
		/// a given element's type.
		/// </summary>
		/// <param name="elementType">The element's type of the set.</param>
		/// <exception cref="ArgumentNullException">If the given <paramref name="elementType"/> is <see langword="null"/>.</exception>
		public MiniZincSetType (IMiniZincTypeInst elementType) {
			this.ElementType = elementType;
		}
		#endregion
		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current set type.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current set type.</returns>
		public override string ToString () {
			return string.Format ("set of [{0}]", this.elementType);
		}
		#endregion
		#region IGenericEquals implementation
		/// <summary>
		/// Checks if this zinc type is equal to the given zinc type.
		/// </summary>
		/// <returns><see langword="true"/>, if the types where equal, <see langword="false"/> otherwise.</returns>
		/// <param name="other">The <see cref="IZincFundamentalType"/> to match this type against.</param>
		public bool GenericEquals (IMiniZincType other) {
			var zst = other as MiniZincSetType;
			if (zst != null) {
				return this.elementType.GenericEquals (zst.elementType);
			}
			return false;
		}
		#endregion
		#region IMiniZincType implementation
		/// <summary>
		/// Returns the enumerable of the depending <see cref="IMiniZincTypeInst"/> instances.
		/// </summary>
		/// <returns>An <see cref="T:IEnumerable`1"/> enumerating the depending <see cref="IMiniZincTypeInst"/> instances.</returns>
		public IEnumerable<IMiniZincTypeInst> GetDependingTypes () {
			return DataList.Prepend (this.ElementType, this.ElementType.GetDependingTypes ());
		}
		#endregion
	}
}

