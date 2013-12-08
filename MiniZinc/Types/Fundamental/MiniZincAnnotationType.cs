//
//  MiniZincAnnotationType.cs
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

using System.Collections.Generic;
using ZincOxide.Utils.Maths;

namespace ZincOxide.MiniZinc.Types.Fundamental {

	/// <summary>
	/// The annotation type, <c>ann</c>, can be used to represent arbitrary term structures. It is augmented by
	/// annotation items. An annotation is always unfixed because it may contain unfixed elements. It cannot be
	/// preceded by <c>var</c>.
	/// </summary>
	/// <remarks>
	/// <para>The annotation type is written <c>ann</c>.</para>
	/// <para>The annotation type is not finite, neither varifiable or coercible.</para>
	/// <para>Annotations must be initialised at instance-time.</para>
	/// <para>Annotation types do not have an ordering defined on them.</para>
	/// </remarks>
	public class MiniZincAnnotationType : IMiniZincType {
		/// <summary>
		/// Returns the instance of the MiniZincAnnotationType.
		/// </summary>
		public static readonly MiniZincAnnotationType Instance = new MiniZincAnnotationType ();

		/// <summary>
		/// Gets if the type has a finite domain.
		/// </summary>
		/// <value><see langword="true"/> if the type has a finite domain, <see langword="false"/> otherwise.</value>
		public ThreeStateValue Finite {
			get {
				return ThreeStateValue.False;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MiniZincAnnotationType"/> class.
		/// </summary>
		private MiniZincAnnotationType () {
		}

		#region IMiniZincType implementation

		/// <summary>
		/// Returns the enumerable of the depending <see cref="IMiniZincTypeInst"/>.
		/// </summary>
		/// <returns>An <see cref="IEnumerable{T}"/> of the depending types.</returns>
		public IEnumerable<IMiniZincTypeInst> GetDependingTypes () {
			yield break;
		}

		#endregion

		#region IGenericEquals implementation

		/// <summary>
		/// Checks if this zinc type is equal to the given zinc type.
		/// </summary>
		/// <returns><see langword="true"/>, if both types are equal, <see langword="false"/> otherwise.</returns>
		/// <param name="other">The zinc type to compare with.</param>
		public bool GenericEquals (IMiniZincType other) {
			return (other as MiniZincAnnotationType) != null;
		}

		#endregion

	}
}

