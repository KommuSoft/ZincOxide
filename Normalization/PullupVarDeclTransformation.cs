//
//  PullupVarDeclTransformation.cs
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
	/// A class representing a transformation where the declaration of variables is pulled up to the front of
	/// the given <see cref="IZincFile"/>.
	/// </summary>
	public class PullupVarDeclTransformation : ITransformation {

		/// <summary>
		/// Initializes a new instance of the <see cref="PullupVarDeclTransformation"/> class.
		/// </summary>
		public PullupVarDeclTransformation () {
		}
		#region ITransformation implementation
		/// <summary>
		/// Transforms the given <see cref="IZincFile"/> by pulling up the declarations of all variables.
		/// </summary>
		/// <param name="file">The given file to modify.</param>
		public void Transform (IZincFile file) {
			throw new System.NotImplementedException ();
		}
		#endregion
	}
}