//
//  ZincIdentContainer.cs
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

namespace ZincOxide.MiniZinc.Structures {

	/// <summary>
	/// An interface that contains one or more <see cref="IZincIdent"/> instances.
	/// These identifiers can be enumerated using the <see cref="InvolvedIdents"/> method.
	/// </summary>
	/// <remarks>
	/// <para>The <see cref="IZincIdentReplaceContainer"/> provided a method to replace
	/// identifiers with other ones.</para>
	/// </remarks>
	public interface IZincIdentContainer {

		/// <summary>
		/// Returns a <see cref="T:IEnumerable`1"/> containing the involved
		/// <see cref="IZincIdent"/> instances of the container.
		/// </summary>
		/// <returns>
		/// A <see cref="T:IEnumerable`1"/> containing the involved\
		/// <see cref="IZincIdent"/> instances of the container.
		/// </returns>
		IEnumerable<IZincIdent> InvolvedIdents ();
	}
}