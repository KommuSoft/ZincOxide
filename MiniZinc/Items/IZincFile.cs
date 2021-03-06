//
//  ZincFile.cs
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
using ZincOxide.MiniZinc.Structures;
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Items {

	/// <summary>
	/// An interface describing a Zinc file. A zinc file is a collection of <see cref="IZincItem"/> instances.
	/// A <see cref="IZincFile"/> can be written to a stream, and has nearly all properties of a <see cref="IZincItem"/>
	/// instance.
	/// </summary>
	public interface IZincFile : IWriteable, IZincScopeElement {

		/// <summary>
		/// Gets a list of <see cref="IZincItem"/> instances stored in the <see cref="IZincFile"/>.
		/// </summary>
		/// <value>The items contained in the <see cref="IZincFile"/>.</value>
		IEnumerable<IZincItem> Items {
			get;
		}

		/// <summary>
		/// Adds an <see cref="IZincItem"/> to this <see cref="IZincFile"/>.
		/// </summary>
		/// <param name="item">The <see cref="IZincItem"/> to add to the file.</param>
		void AddItem (IZincItem item);

		/// <summary>
		/// Adds a given list of items to this <see cref="IZincFile"/>.
		/// </summary>
		/// <param name="items">The list of items to be added to this <see cref="IZincFile"/>.</param>
		void AddItems (IEnumerable<IZincItem> items);
	}
}

