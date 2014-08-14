//
//  IZincDataFile.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2014 Willem Van Onsem
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

namespace ZincOxide.MiniZinc.Items {

	/// <summary>
	/// An interface describing a datafile where the values for parameters in a MiniZinc model are stored.
	/// </summary>
	public interface IZincDataFile : IZincFile {

		/// <summary>
		/// Adds the given <paramref name="assignItem"/> to this data file.
		/// </summary>
		/// <param name="assignItem">The given <see cref="ZincAssignItem"/> to add to the data file.</param>
		/// <remarks>
		/// <para>If the given item is not effective, nothing happens.</para>
		/// </remarks>
		void AddAssignItem (ZincAssignItem assignItem);
	}
}

