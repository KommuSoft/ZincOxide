//
//  ZincAnnotation.cs
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
	/// An implementation of the <see cref="IZincAnnotation"/> interface: an interface to store/describe annotations
	/// in the MiniZinc language.
	/// </summary>
	public class ZincAnnotation : ZincLeafElement, IZincAnnotation {

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincAnnotation"/> class.
		/// </summary>
		public ZincAnnotation () {
		}
		#endregion
		#region implemented abstract members of ZincLeafElement
		/// <summary>
		/// Generates a number of error messages that specify what is wrong with this instance.
		/// </summary>
		/// <returns>A <see cref="T:IEumerable`1"/> that contains a list of error messages describing why the instance is invalid.</returns>
		/// <remarks>
		/// <para>If no error messages are generated, the instance is valid, otherwise the instance is invalid.</para>
		/// </remarks>
		public override IEnumerable<string> InnerSoftValidate () {
			yield break;//TODO
		}
		#endregion
	}
}

