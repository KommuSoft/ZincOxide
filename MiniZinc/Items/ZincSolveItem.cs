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

namespace ZincOxide.MiniZinc.Items {

    public class ZincSolveItem : ZincAsExBoxBase, IZincItem {

        private ZincSolveType solveType;

        #region IZincItem implementation
        public ZincItemType Type {
            get {
                return ZincItemType.Solve;
            }
        }
        #endregion

        public ZincSolveType SolveType {
            get {
                return this.solveType;
            }
            private set {
                this.solveType = value;
            }
        }

        public ZincSolveItem (ZincAnnotations annotations) : this(annotations,ZincSolveType.Satisfy,null) {

        }

        public ZincSolveItem (ZincAnnotations annotations, ZincSolveType solveType, IZincExp expression) : base(annotations,expression) {
            this.SolveType = solveType;
        }

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

        #region IWriteable implementation
        public void Write (TextWriter writer) {
            writer.Write (this.ToString ());
        }
        #endregion

    }
}

