//
//  ZincSolveItem.cs
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
using System.Text;
using ZincOxide.MiniZinc.Boxes;
using ZincOxide.MiniZinc.Structures;

namespace ZincOxide.MiniZinc.Items {

	/// <summary>
	/// An item in a <see cref="IZincFile"/> that describes what is the task that should be carried out
	/// The options are finding a solution that satisfies the hard constraints, or minimize/maximize a given
	/// expression. The solve item can be annotated as well.
	/// </summary>
	public class ZincSolveItem : ZincAsExBoxBase, IZincItem {

		private ZincSolveType solveType;
		#region IZincItem implementation
		/// <summary>
		/// Gets the type of the <see cref="IZincItem"/>.
		/// </summary>
		/// <value>The type of the <see cref="IZincItem"/>.</value>
		/// <remarks>
		/// <para>This property is mainly used to filter without the use
		/// of harmful object oriented structures and to prevent users from inventing more items.</para>
		/// <para>The type of a <see cref="ZincSolveItem"/> is <see cref="ZincItemType.Solve"/>.</para>
		/// </remarks>
		public ZincItemType Type {
			get {
				return ZincItemType.Solve;
			}
		}
		#endregion
		/// <summary>
		/// Gets the type of the task to carry out.
		/// </summary>
		/// <value>The type of the task.</value>
		/// <remarks>
		/// <para>There are three possible options: satisfy, minimize and maximize.</para>
		/// <para>If the task is to minimze or maximize a certain aspect, an expression must be given.</para>
		/// </remarks>
		public ZincSolveType SolveType {
			get {
				return this.solveType;
			}
			private set {
				this.solveType = value;
			}
		}
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincSolveItem"/> class with a given <see cref="ZincAnnotations"/>
		/// instance. The task is set to <see cref="ZincSolveType.Satisfy"/> and the no <see cref="IZincExp"/> is given.
		/// </summary>
		/// <param name="annotations">The annotations provided for the <see cref="ZincSolveType.Satisfy"/> task.</param>
		/// <remarks>
		/// <para>The task is set to <see cref="ZincSolveType.Satisfy"/>.</para>
		/// <para>No expression is given as the <see cref="ZincSolveType.Satisfy"/> does not require one.</para>
		/// </remarks>
		public ZincSolveItem (ZincAnnotations annotations) : this(annotations,ZincSolveType.Satisfy,null) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincSolveItem"/> class with a given <see cref="ZincSolveType"/>,
		/// an <see cref="IZincExp"/> that must be minimized/maximized and some <see cref="ZincAnnotations"/>.
		/// </summary>
		/// <param name="annotations">The annotations provided for the task.</param>
		/// <param name="solveType">The task that must be carried out.</param>
		/// <param name="expression">The <see cref="IZincExp"/> that must be minized/maximized.</param>
		public ZincSolveItem (ZincAnnotations annotations, ZincSolveType solveType, IZincExp expression) : base(annotations,expression) {
			this.SolveType = solveType;
		}
		#endregion
		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="ZincSolveItem"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="ZincSolveItem"/>.</returns>
		/// <remarks>
		/// <para>The format of this method is <c>solve annotations type expression</c> where the annotations
		/// annotate the solve item, the <c>type</c> is <c>satisfy</c>, <c>minimize</c> and <c>maximize</c>. and
		/// <c>expression</c> the expression to be minimized/maximized.</para>
		/// </remarks>
		public override string ToString () {
			StringBuilder sb = new StringBuilder ("solve ");
			if (this.Annotations != null && this.Annotations.Count > 0x00) {
				sb.Append (this.Annotations);
				sb.Append (' ');
			}
			sb.Append (ZincPrintUtils.SolveTypeLiteral (this.SolveType));
			if (this.SolveType != ZincSolveType.Satisfy) {
				sb.Append (' ');
				sb.Append (this.Expression);
			}

			return sb.ToString ();
		}
		#endregion
		#region IWriteable implementation
		/// <summary>
		/// Writes a textual representation of this <see cref="ZincSolveItem"/> to the given <see cref="TextWriter"/>.
		/// </summary>
		/// <param name="writer">The given <see cref="TextWriter"/> to write the content of this <see cref="ZincSolveItem"/> to.</param>
		public void Write (TextWriter writer) {
			writer.Write (this.ToString ());
		}
		#endregion
	}
}

