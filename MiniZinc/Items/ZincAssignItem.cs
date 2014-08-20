//
//  ZincAssignItem.cs
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
using System.IO;
using ZincOxide.MiniZinc.Boxes;
using ZincOxide.MiniZinc.Structures;

namespace ZincOxide.MiniZinc.Items {

	/// <summary>
	/// An assignment item in a <see cref="IZincFile"/>. An assignment is a tuple containing the identifier
	/// to which the assignment is done together with an expression describing how the value should be calculated.
	/// </summary>
	public class ZincAssignItem : ZincExIdBoxBase, IZincItem {

		#region IZincItem implementation
		/// <summary>
		/// Gets the type of the <see cref="IZincItem"/>.
		/// </summary>
		/// <value>The type of the <see cref="IZincItem"/>.</value>
		/// <remarks>
		/// <para>This property is mainly used to filter without the use
		/// of harmful object oriented structures and to prevent users from inventing more items.</para>
		/// <para>The type of a <see cref="ZincAssignItem"/> is <see cref="ZincItemType.Assign"/>.</para>
		/// </remarks>
		public ZincItemType Type {
			get {
				return ZincItemType.Assign;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincAssignItem"/> class with a given identifier and expression.
		/// </summary>
		/// <param name="ident">The identifier of the variable to which the assignment is made.</param>
		/// <param name="expression">The expression that describes how the value to assign must be calculated.</param>
		public ZincAssignItem (ZincIdent ident, IZincExp expression) : base(ident,expression) {
		}
		#endregion
		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="ZincAssignItem"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="ZincAssignItem"/>.</returns>
		/// <remarks>
		/// <para>The format of this method is <c>identifier = expression</c> where the identifier is the identifier to
		/// assign the value to and expression a description on how to calculate that value.</para>
		/// </remarks>
		public override string ToString () {
			return string.Format ("{0} = {1}", this.Ident, this.Expression);
		}
		#endregion
		#region IWriteable implementation
		/// <summary>
		/// Writes a textual representation of this <see cref="ZincAssignItem"/> to the given <see cref="TextWriter"/>.
		/// </summary>
		/// <param name="writer">The given <see cref="TextWriter"/> to write the content of this <see cref="ZincAssignItem"/> to.</param>
		public void Write (TextWriter writer) {
			writer.Write (this.ToString ());
		}
		#endregion
	}
}

