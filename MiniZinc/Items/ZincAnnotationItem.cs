//
//  ZincAnnotationItem.cs
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
	/// A class representing an annotation item in a <see cref="IZincFile"/>. An annotation file contains
	/// an identifier such that the annotation of a certain item is explained by this identifier.
	/// </summary>
	public class ZincAnnotationItem : ZincIdBoxBase, IZincItem {

		#region IZincItem implementation
		/// <summary>
		/// Gets the type of the <see cref="IZincItem"/>.
		/// </summary>
		/// <value>The type of the <see cref="IZincItem"/>.</value>
		/// <remarks>
		/// <para>This property is mainly used to filter without the use
		/// of harmful object oriented structures and to prevent users from inventing more items.</para>
		/// <para>The type of a <see cref="ZincAnnotationItem"/> is <see cref="ZincItemType.Annotation"/>.</para>
		/// </remarks>
		public ZincItemType Type {
			get {
				return ZincItemType.Annotation;
			}
		}
		#endregion
		public ZincAnnotationItem (ZincIdent ident) : base(ident) {
		}

		public override string ToString () {
			return string.Format ("annotation {0} {1}", this.Ident, null);
		}
		#region IWriteable implementation
		public void Write (TextWriter writer) {
			writer.Write (this.ToString ());
		}
		#endregion
	}
}

