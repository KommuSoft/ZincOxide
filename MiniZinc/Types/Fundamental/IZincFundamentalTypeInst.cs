//
//  IZincTypeInst.cs
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

namespace ZincOxide.MiniZinc.Types.Fundamental {

	/// <summary>
	/// A type instance for a fundamental type.
	/// </summary>
	public interface IZincFundamentalTypeInst : IZincFundamentalType {
		/// <summary>
		/// Gets or sets the instantiation of the type instance.
		/// </summary>
		/// <value>The instantiation of the type instance.</value>
		ZincVarPar Instantiation {
			get;
		}

		/// <summary>
		/// Checks if this fundamental type-instance can be varified to the given fundamental type-instance.
		/// </summary>
		/// <returns><see langword="true"/> if this instance can be varified the specified one; otherwise, <see langword="false"/>.</returns>
		/// <param name="other">The other fundamental type-instance.</param>
		bool CanVarify (IZincFundamentalTypeInst other);

		/// <summary>
		/// Checks if this fundamental type-instance can be coerced to the given fundamental type-instance.
		/// </summary>
		/// <returns><see langword="true"/> if this instance can be coerced the specified one; otherwise, <see langword="false"/>.</returns>
		/// <param name="other">The other fundamental type-instance.</param>
		bool CanCoerce (IZincFundamentalTypeInst other);
	}
}

