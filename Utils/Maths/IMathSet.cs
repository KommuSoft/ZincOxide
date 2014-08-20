//
//  IMathSet.cs
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

namespace ZincOxide.Utils.Maths {

	/// <summary>
	/// An interface describing a mathematical definition of a set.
	/// </summary>
	/// <remarks>
	/// <para>
	/// A set has subset and superset relations towards other sets of the same kind.
	/// </para>
	/// </remarks>
	public interface IMathSet<TElement, TSet> where TSet : IMathSet<TElement,TSet> {

		/// <summary>
		/// Determines whether this instance is subset the specified other.
		/// </summary>
		/// <returns>
		/// <c>true</c> if this instance is subset the specified other; otherwise, <c>false</c>.
		/// </returns>
		/// <param name='other'>
		/// If set to <c>true</c> other.
		/// </param>
		bool IsSubset (TSet other);

		/// <summary>
		/// Determines whether this instance is superset the specified other.
		/// </summary>
		/// <returns>
		/// <c>true</c> if this instance is superset the specified other; otherwise, <c>false</c>.
		/// </returns>
		/// <param name='other'>
		/// If set to <c>true</c> other.
		/// </param>
		bool IsSuperset (TSet other);

	}

}