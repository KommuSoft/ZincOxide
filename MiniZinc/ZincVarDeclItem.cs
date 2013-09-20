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

namespace ZincOxide.MiniZinc {

    public class ZincVarDeclItem : ZincAsExTiaBoxBase, IZincItem {

        #region IZincItem implementation
        public ZincItemType Type {
            get {
                return ZincItemType.VarDecl;
            }
        }
        #endregion

        public ZincVarDeclItem (ZincTypeInstExprAndIdent tia, ZincAnnotations anns = null, IZincExpression exp = null) : base(anns,exp,tia) {
        }

        public ZincVarDeclItem (ZincTypeInstExprAndIdent tia, IZincExpression exp) : this(tia,null,exp) {
        }

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

        #region IWriteable implementation
        public void Write (StreamWriter writer) {
            writer.Write (this.ToString ());
        }
        #endregion

    }
}

