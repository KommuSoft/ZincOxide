//
//  IZincItem.cs
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
using ZincOxide.MiniZinc.Structures;
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Items {

	/// <summary>
	/// An interface specifying a generic item in a <see cref="IZincFile"/>. An item is a <see cref="IZincElement"/>
	/// and must support the <see cref="IWriteable"/> interface: the content must be serializable to a MiniZinc file.
	/// </summary>
	public interface IZincItem : IWriteable, IZincElement {

		/// <summary>
		/// Gets the type of the <see cref="IZincItem"/>.
		/// </summary>
		/// <value>The type of the <see cref="IZincItem"/>.</value>
		/// <remarks>
		/// <para>This property is mainly used to filter without the use
		/// of harmful object oriented structures and to prevent users from inventing more items.</para>
		/// </remarks>
		ZincItemType Type {
			get;
		}
	}
}