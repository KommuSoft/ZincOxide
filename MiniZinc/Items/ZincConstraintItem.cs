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

namespace ZincOxide.MiniZinc.Items {

    public class ZincConstraintItem : ZincExBoxBase, IZincItem {

        #region IZincItem implementation
        public ZincItemType Type {
            get {
                return ZincItemType.Constraint;
            }
        }
        #endregion

        public ZincConstraintItem (IZincExp expr) : base(expr) {
        }

        public override string ToString () {
            return string.Format ("constraint {0}", this.Expression);
        }

        #region IWriteable implementation
        public void Write (TextWriter writer) {
            writer.Write (this.ToString ());
        }
        #endregion

    }
}

