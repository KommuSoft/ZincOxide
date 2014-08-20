//
//  IZincTF.cs
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
using ZincOxide.Utils.Abstract;

namespace ZincOxide.MiniZinc.Types.Fundamental {

	/// <summary>
	/// A class representing a fundamental type of the MiniZinc language.
	/// </summary>
	public interface IMiniZincType : IGenericEquals<IMiniZincType> {
		/// <summary>
		/// Gets if the type has a finite domain.
		/// </summary>
		/// <value><see cref="ThreeStateValue.True"/> if the type has a finite domain,
		/// <see cref="ThreeStateValue.False"/> otherwise.</value>
		ThreeStateValue Finite {
			get;
		}

		/// <summary>
		/// Returns the enumerable of the depending <see cref="IMiniZincTypeInst"/>.
		/// </summary>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1"/> of the depending types.</returns>
		IEnumerable<IMiniZincTypeInst> GetDependingTypes ();
	}
}

