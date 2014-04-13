//
//  IZincTiasBox.cs
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

namespace ZincOxide.MiniZinc.Boxes {

	/// <summary>
	/// An <see cref="IZincBox"/> interface that contains multiple <see cref="IZincTypeInstExprAndIdent"/> instances stored in a <see cref="T:System.Collections.Generic.IList`1"/>.
	/// </summary>
	public interface IZincTiasBox : IZincBox {

		/// <summary>
		/// Gets the <see cref="T:System.Collection.Generic.IList`1"/> with <see cref="IZincTypeInstExprAndIdent"/> instances stored in the <see cref="IZincTiasBox"/>.
		/// </summary>
		/// <value>
		/// The <see cref="T:System.Collection.Generic.IList`1"/> with <see cref="IZincTypeInstExprAndIdent"/> instances stored in the <see cref="IZincTiasBox"/>.
		/// </value>
		IList<IZincTypeInstExprAndIdent> TypeInstAndIdentExpressions {
			get;
		}

	}

}