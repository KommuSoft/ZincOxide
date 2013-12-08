//
//  MiniZincTypeInstanceVariable.cs
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
using ZincOxide.Utils.Maths;

namespace ZincOxide.MiniZinc.Types.Fundamental {

	/// <summary>
	/// Type-instance variables allow parametric polymorphism. They can appear in Zinc predicate and function arguments
	/// return type-instances, in let expressions within predicates and function bodies and in annotation declarations.
	/// If one is used outside a function or predicate or annotation declaration, it is a type-instance error.
	/// </summary>
	/// <remarks>
	/// <para>A type-instance variable consist of a type-instance variable and an optional prefix. Type-instance
	/// variables can be prefixed by <c>par</c>, in which case they match any fixed type-instance. The same
	/// is true if they lack a prefix. Type-instance variables can also be prefixed by <c>any</c>, in
	/// which case they match any first-order type-instance.</para>
	/// <para>A type-instance variable expression tail has this syntax: <c>(any)? $[A-Za-z][A-Za-z0-9_]*</c>.
	/// Some example type-instance variable expressions: <code>
	/// $T
	/// par $U3
	/// any $xyz
	/// </code></para>
	/// <para>Type instance variables are not finite. This because they can be bound to any type-instance, and not all
	/// type-instances are finite.</para>
	/// <para>Type instance variables can not be varified. This is because they can be bound to any type-instance, and
	/// not all type-instances can be varified.</para>
	/// <para>Type instance variables values of equal type-instance variables can be compared. The comparison
	/// used will be the comparison of the underlying type-instances. This is possible because all type-instances have
	/// a built-in ordering.</para>
	/// <para>A variable with a type-instance variable as its type-instance (which can only apprear inside predicate
	/// and function bodies must be initialised)</para>
	/// <para>The following coercions are possible: <c>par $T</c> to <c>any $T</c>.</para>
	/// <para>In MiniZinc, Type-instance variables are not supported in user-defined predicates and functions.
	/// However, many of the built-in operations, e.g. <c>show</c> have signatures that feature type-instance
	/// variables and they work with all valid matching MiniZinc types.</para>
	/// </remarks>
	public class MiniZincTypeInstanceVariable : IMiniZincType {
		/// <summary>
		/// The single instance generated.
		/// </summary>
		public static readonly MiniZincTypeInstanceVariable Instance = new MiniZincTypeInstanceVariable ();

		/// <summary>
		/// Initializes a new instance of the <see cref="MiniZincTypeInstanceVariable"/> class.
		/// </summary>
		private MiniZincTypeInstanceVariable () {
		}

		#region IMiniZincType implementation

		/// <summary>
		/// Returns the enumerable of the depending <see cref="IMiniZincTypeInst"/>.
		/// </summary>
		/// <returns>An <see cref="IEnumerable{T}"/> of the depending types.</returns>
		public IEnumerable<IMiniZincTypeInst> GetDependingTypes () {
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Gets if the type has a finite domain.
		/// </summary>
		/// <value><see cref="ThreeStateValue.True"/> if the type has a finite domain,
		/// <see cref="ThreeStateValue.False"/> otherwise.</value>
		public ThreeStateValue Finite {
			get {
				return ThreeStateValue.False;
			}
		}

		#endregion

		#region IGenericEquals implementation

		/// <summary>
		/// Checks if this zinc type is equal to the given zinc type.
		/// </summary>
		/// <returns><see langword="true"/>, if both types are equal, <see langword="false"/> otherwise.</returns>
		/// <param name="other">The zinc type to compare with.</param>
		public bool GenericEquals (IMiniZincType other) {
			MiniZincTypeInstanceVariable mztiv = other as MiniZincTypeInstanceVariable;
			return (mztiv != null);
		}

		#endregion

	}
}

