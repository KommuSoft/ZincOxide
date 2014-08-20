//
//  IZincBox.cs
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
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Boxes {

	/// <summary>
	/// An interface of an elementary <see cref="IZincElement"/> that contains data.
	/// </summary>
	/// <remarks>
	/// <para>Boxes do not represent real items. They are merely implementations that group
	/// certain data and define methods on that data.</para>
	/// </remarks>
	public interface IZincBox : IZincElement, IInnerSoftValidateable {

	}
}

