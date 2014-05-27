//
//  ZincConstraintItem.cs
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
	/// A Zinc item that is part of a <see cref="IZincFile"/> that describes a certain constraint. The constraint
	/// is an expression, that is typed as a boolean, that must be true in every configuration of the problem.
	/// </summary>
	public class ZincConstraintItem : ZincExBoxBase, IZincItem {

		#region IZincItem implementation
		/// <summary>
		/// Gets the type of the <see cref="IZincItem"/>.
		/// </summary>
		/// <value>The type of the <see cref="IZincItem"/>.</value>
		/// <remarks>
		/// <para>This property is mainly used to filter without the use
		/// of harmful object oriented structures and to prevent users from inventing more items.</para>
		/// <para>The type of a <see cref="ZincConstraintItem"/> is <see cref="ZincItemType.Constraint"/>.</para>
		/// </remarks>
		public ZincItemType Type {
			get {
				return ZincItemType.Constraint;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincConstraintItem"/> class with a given <see cref="IZincExp"/>
		/// that contains an expression that must always be satisfied.
		/// </summary>
		/// <param name="expr">The given expression that must be satisfied by any solution.</param>
		public ZincConstraintItem (IZincExp expr) : base(expr) {
		}
		#endregion
		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="ZincConstraintItem"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="ZincConstraintItem"/>.</returns>
		/// <remarks>
		/// <para>The format of this method is <c>constraint expression</c> where the expression
		/// describes what conditions must be hold for a solution to be feasible.</para>
		/// </remarks>
		public override string ToString () {
			return string.Format ("constraint {0}", this.Expression);
		}
		#endregion
		#region IWriteable implementation
		/// <summary>
		/// Writes a textual representation of this <see cref="ZincConstraintItem"/> to the given <see cref="TextWriter"/>.
		/// </summary>
		/// <param name="writer">The given <see cref="TextWriter"/> to write the content of this <see cref="ZincConstraintItem"/> to.</param>
		public void Write (TextWriter writer) {
			writer.Write (this.ToString ());
		}
		#endregion
	}
}

