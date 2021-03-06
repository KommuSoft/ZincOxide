//
//  ZincVarDeclItem.cs
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
using System.Text;
using System.Collections.Generic;
using System.IO;
using ZincOxide.MiniZinc.Boxes;
using ZincOxide.MiniZinc.Structures;

namespace ZincOxide.MiniZinc.Items {

	/// <summary>
	/// An item in a <see cref="IZincFile"/> that describes a variable declaration.
	/// </summary>
	public class ZincVarDeclItem : ZincAsExTiaBoxBase, IZincItem, IZincIdentDeclaration {

		#region IZincItem implementation
		/// <summary>
		/// Gets the type of the <see cref="IZincItem"/>.
		/// </summary>
		/// <value>The type of the <see cref="IZincItem"/>.</value>
		/// <remarks>
		/// <para>This property is mainly used to filter without the use
		/// of harmful object oriented structures and to prevent users from inventing more items.</para>
		/// <para>The type of a <see cref="ZincVarDeclItem"/> is <see cref="ZincItemType.VarDecl"/>.</para>
		/// </remarks>
		public ZincItemType Type {
			get {
				return ZincItemType.VarDecl;
			}
		}
		#endregion
		#region IZincIdentDeclaration implementation
		/// <summary>
		/// Gets or sets the usage of the identifier (used as a hint for the compiler).
		/// </summary>
		/// <value>A <see cref="ZincIdentUsage"/> value describing the use of the identifier.</value>
		public IZincIdent DeclaredIdentifier {
			get {
				return this.TypeInstExprAndIdent.Ident;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincVarDeclItem"/> class with a given <see cref="ZincTypeInstExprAndIdent"/>
		/// that describes the variable and type to initialize, a <see cref="ZincAnnotation"/> instance that annotates the declaration
		/// and optionally an <see cref="IZincExp"/> instance that describes the value that must be assigned.
		/// </summary>
		/// <param name="tia">A type-identifier tuple that describes the name and the type of the variable.</param>
		/// <param name="anns">The annotations of the variable declaration.</param>
		/// <param name="exp">Optionally, an expression that assigns a value to the variable.</param>
		public ZincVarDeclItem (ZincTypeInstExprAndIdent tia, ZincAnnotations anns = null, IZincExp exp = null) : base(anns,exp,tia) {
			this.TypeInstExprAndIdent.Ident.Usage = ZincIdentUsage.GlobalVariable;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincVarDeclItem"/> class with a given <see cref="ZincTypeInstExprAndIdent"/>
		/// that describes the name and the type of the variable and optionally a <see cref="IZincExp"/> instance that describes
		/// the value that must be assigned to the variable.
		/// </summary>
		/// <param name="tia">A <see cref="ZincTypeInstExprAndIdent"/> instance that describes the name and type of the variable.</param>
		/// <param name="exp">An <see cref="IZincExp"/> instance that describes the value assigned to the variable.</param>
		public ZincVarDeclItem (ZincTypeInstExprAndIdent tia, IZincExp exp) : this(tia,null,exp) {
		}
		#endregion
		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="ZincVarDeclItem"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="ZincVarDeclItem"/>.</returns>
		/// <remarks>
		/// <para>The format of this method is <c>typeinst annotations [= expression]</c> where <c>typeinst</c> describes
		/// the type and the name of the variable, <c>annotations</c> are the annotations of the variable declaration and
		/// optionally <c>expression</c> describes the value that must be assigned to the variable.</para>
		/// </remarks>
		public override string ToString () {
			StringBuilder sb = new StringBuilder ();
			sb.Append (this.TypeInstExprAndIdent);
			if (this.Annotations != null && this.Annotations.Count > 0x00) {
				sb.AppendFormat (" {0}", this.Annotations);
			}
			if (this.Expression != null) {
				sb.AppendFormat (" = {0}", this.Expression);
			}
			return sb.ToString ();
		}
		#endregion
		#region IWriteable implementation
		/// <summary>
		/// Writes a textual representation of this <see cref="ZincVarDeclItem"/> to the given <see cref="TextWriter"/>.
		/// </summary>
		/// <param name="writer">The given <see cref="TextWriter"/> to write the content of this <see cref="ZincVarDeclItem"/> to.</param>
		public void Write (TextWriter writer) {
			writer.Write (this.ToString ());
		}
		#endregion
	}
}

