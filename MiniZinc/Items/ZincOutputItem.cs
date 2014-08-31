//
//  ZincOutputItem.cs
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
	/// An item in a <see cref="IZincFile"/> that describes which parts of the model are interesting and thus must be
	/// printed. The format is described by an expression.
	/// </summary>
	public class ZincOutputItem : ZincExBoxBase, IZincItem {

		#region IZincItem implementation
		/// <summary>
		/// Gets the type of the <see cref="IZincItem"/>.
		/// </summary>
		/// <value>The type of the <see cref="IZincItem"/>.</value>
		/// <remarks>
		/// <para>This property is mainly used to filter without the use
		/// of harmful object oriented structures and to prevent users from inventing more items.</para>
		/// <para>The type of a <see cref="ZincOutputItem"/> is <see cref="ZincItemType.Output"/>.</para>
		/// </remarks>
		public ZincItemType Type {
			get {
				return ZincItemType.Output;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOutputItem"/> class with a given expression that
		/// describes how the solution of the given instance by formatted.
		/// </summary>
		/// <param name="expression">An expression that describes the expected output format.</param>
		public ZincOutputItem (IZincExp expression) : base(expression) {
		}
		#endregion
		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="ZincOutputItem"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="ZincOutputItem"/>.</returns>
		/// <remarks>
		/// <para>The format of this method is <c>output expression</c> where the expression
		/// describes how a solution of an optimization problem should be formatted.</para>
		/// </remarks>
		public override string ToString () {
			return string.Format ("output {0}", this.Expression);
		}
		#endregion
		#region IWriteable implementation
		/// <summary>
		/// Writes a textual representation of this <see cref="ZincOutputItem"/> to the given <see cref="TextWriter"/>.
		/// </summary>
		/// <param name="writer">The given <see cref="TextWriter"/> to write the content of this <see cref="ZincOutputItem"/> to.</param>
		public void Write (TextWriter writer) {
			writer.Write (this.ToString ());
		}
		#endregion
	}
}

