//
//  ReordenDeclarationTransformation.cs
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
using ZincOxide.MiniZinc.Items;

namespace ZincOxide.Normalization {

	/// <summary>
	/// A transformation that has the purposes to reorder <see cref="IZincItem"/> instances in the <see cref="IZincFile"/>
	/// such that the declaration statements are stratified.
	/// </summary>
	public class ReordenDeclarationTransformation : ITransformation {

		/// <summary>
		/// Initializes a new instance of the <see cref="ReordenDeclarationTransformation"/> class.
		/// </summary>
		public ReordenDeclarationTransformation () {

		}
		#region ITransformation implementation
		/// <summary>
		/// Transforms the given <see cref="IZincFile"/> by reordening the <see cref="IZincItem"/> instances such that
		/// the resulting file is stratified.
		/// </summary>
		/// <param name="file">The <see cref="IZincFile"/> to be transformed.</param>
		public void Transform (IZincFile file) {
			throw new System.NotImplementedException ();
		}
		#endregion
	}
}