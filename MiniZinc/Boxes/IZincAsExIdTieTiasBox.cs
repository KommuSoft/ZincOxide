//
//  IZincAsExIdTieTiasBox.cs
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

namespace ZincOxide.MiniZinc.Boxes {

	/// <summary>
	/// A <see cref="IZincBox"/> interface that contains <see cref="IZincAnnotations"/>, <see cref="IZincExp"/>, <see cref="IZincIdent"/>, <see cref="IZincTypeInstExpression"/> and <see cref="IZincTypeInstExprAndIdent"/> instances.
	/// The last type can occur in multiple instances.
	/// </summary>
	public interface IZincAsExIdTieTiasBox : IZincBox, IZincAsBox, IZincAsExBox, IZincAsExIdTiasBox, IZincExBox, IZincExIdBox, IZincIdBox, IZincIdTieBox, IZincTiasBox, IZincTieBox {
	}
}