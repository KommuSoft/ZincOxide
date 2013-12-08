//
//  MiniZincScalarType.cs
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

namespace ZincOxide.MiniZinc.Types.Fundamental {

	/// <summary>
	/// One of the scalar types of a MiniZinc program.
	/// </summary>
	public class MiniZincScalarTypeEntry : IMiniZincType {
		/// <summary>
		/// The scalar type represented.
		/// </summary>
		public readonly MiniZincScalarType ScalarType;

		/// <summary>
		/// Initializes a new instance of the <see cref="MiniZincScalarTypeEntry"/> class with the given scalar type.
		/// </summary>
		/// <param name="scalarType">The scalar type that will be represented by the <see cref="IMiniZincType"/>.</param>
		public MiniZincScalarTypeEntry (MiniZincScalarType scalarType) {
			this.ScalarType = scalarType;
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
			MiniZincScalarTypeEntry mzste = other as MiniZincScalarTypeEntry;
			return mzste != null && this.ScalarType == mzste.ScalarType;
		}

		#endregion

	}
}

