//
//  ZincPredicateItem.cs
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
using System.Collections.Generic;
using System.IO;
using System.Text;
using ZincOxide.MiniZinc.Boxes;
using ZincOxide.MiniZinc.Structures;

namespace ZincOxide.MiniZinc.Items {

    public class ZincPredicateItem : ZincAsExIdTiasBoxBase, IZincItem, IZincRelation {

        #region IZincItem implementation
        public ZincItemType Type {
            get {
                return ZincItemType.Predicate;
            }
        }
        #endregion

        #region IZincRelation implementation
        public int Arity {
            get {
                if (this.TypeInstAndIdentExpressions != null) {
                    return this.TypeInstAndIdentExpressions.Count;
                } else {
                    return 0x00;
                }
            }
        }
        #endregion

        public ZincPredicateItem (ZincIdent ident, IList<ZincTypeInstExprAndIdent> parameters, ZincAnnotations annotations, IZincExp body = null) : base(annotations,body,ident,parameters) {
            ident.Usage = ZincIdentUsage.Function;
        }

        public ZincPredicateItem (ZincIdent ident, IEnumerable<ZincTypeInstExprAndIdent> parameters, ZincAnnotations annotations, IZincExp body = null) : base(annotations,body,ident,parameters) {
            ident.Usage = ZincIdentUsage.Function;
        }

        public override string ToString () {
            StringBuilder sb = new StringBuilder ("predicate ");
            sb.Append (this.Ident);
            if (this.TypeInstAndIdentExpressions != null && this.TypeInstAndIdentExpressions.Count > 0x00) {
                sb.Append (" (");
                sb.Append (string.Join (" , ", this.TypeInstAndIdentExpressions));
                sb.Append (" )");
            }
            if (this.Annotations != null && this.Annotations.Count > 0x00) {
                sb.Append (' ');
                sb.Append (this.Annotations);
            }
            if (this.Expression != null) {
                sb.Append (" = ");
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

