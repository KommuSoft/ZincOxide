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

	public class ZincData : ZincFileBase {

		private readonly List<ZincAssignItem> assignItems = new List<ZincAssignItem> ();

        #region IZincFile implementation
		public override IEnumerable<IZincItem> Items {
			get {
				return this.assignItems;
			}
		}
        #endregion

		public ZincData () {
		}

		public ZincData (IEnumerable<IZincItem> items) {
		}

        #region IWriteable implementation
		public override void Write (TextWriter writer) {
			foreach (ZincAssignItem item in this.assignItems) {
				item.Write (writer);
				writer.WriteLine (";");
			}
		}
        #endregion

        #region IZincIdentContainer implementation
		public override IEnumerable<ZincIdent> InvolvedIdents () {
			return this.assignItems.SelectMany (x => x.InvolvedIdents ());
		}
        #endregion

        #region IZincIdentReplaceContainer implementation
		public override IZincIdentReplaceContainer Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
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

