//
//  ZincData.cs
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
using System.Linq;
using System.Collections.Generic;
using System.IO;
using ZincOxide.Exceptions;
using ZincOxide.MiniZinc.Structures;

namespace ZincOxide.MiniZinc.Items {

	/// <summary>
	/// A zinc file that stores data about a problem instance. Such file only assigns values to the <c>par</c> variables.
	/// </summary>
	public class ZincData : ZincFileBase {

		#region Fields
		/// <summary>
		/// The inner list of assign items.
		/// </summary>
		private readonly List<ZincAssignItem> assignItems;
		#endregion
		#region IZincFile implementation
		/// <summary>
		/// Gets a list of <see cref="IZincItem"/> instances stored in the <see cref="IZincFile"/>.
		/// </summary>
		/// <value>The items contained in the <see cref="IZincFile"/>.</value>
		public override IEnumerable<IZincItem> Items {
			get {
				return this.assignItems.AsReadOnly ();
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincData"/> class. The file is empty.
		/// </summary>
		public ZincData () {
			this.assignItems = new List<ZincAssignItem> ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincData"/> class with a given list of
		/// <see cref="ZincAssignItem"/> elements.
		/// </summary>
		/// <param name="items">The list of initial <see cref="ZincAssignItem"/> instances.</param>
		public ZincData (IEnumerable<ZincAssignItem> items) {
			this.assignItems = items.ToList ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincData"/> class with a given list of
		/// <see cref="ZincAssignItem"/> elements.
		/// </summary>
		/// <param name="items">The list of initial <see cref="ZincAssignItem"/> instances.</param>
		/// <remarks>
		/// <para>Only the <see cref="IZincItem"/> are withold. The other items are simply ignored.</para>
		/// </remarks>
		public ZincData (IEnumerable<IZincItem> items) : this(items.OfType<ZincAssignItem> ()) {
		}
		#endregion
		#region IWriteable implementation
		/// <summary>
		/// Write the specified writer.
		/// </summary>
		/// <param name="writer">Writer.</param>
		public override void Write (TextWriter writer) {
			foreach (ZincAssignItem item in this.assignItems) {
				item.Write (writer);
				writer.WriteLine (";");
			}
		}
		#endregion
		#region IZincIdentReplaceContainer implementation
		public override IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap) {
			for (int i = 0x00; i < this.assignItems.Count; i++) {
				this.assignItems [i] = this.assignItems [i].Replace (identMap) as ZincAssignItem;
			}
			return this;
		}
		#endregion
		public void AddAssignItem (ZincAssignItem assignItem) {
			if (assignItem != null) {
				this.assignItems.Add (assignItem);
			}
		}
		#region IZincFile implementation
		public override void AddItem (IZincItem item) {
			if (item != null) {
				switch (item.Type) {
				case ZincItemType.Assign:
					this.AddAssignItem (item as ZincAssignItem);
					break;
				default:
					throw new ZincOxideMiniZincException ("Only assign items are valid items in a MiniZinc data file.");
				}
			}
		}

		public override void AddItems (IEnumerable<IZincItem> items) {
			if (items != null) {
				foreach (IZincItem item in items) {
					this.AddItem (item);
				}
			}
		}
		#endregion
		#region ISoftValidateable implementation
		public override IEnumerable<string> SoftValidate () {
			yield break;
		}
		#endregion
	}
}

