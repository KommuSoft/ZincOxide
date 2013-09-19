//
//  ZincModel.cs
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
using System;
using System.IO;
using System.Collections.Generic;

namespace ZincOxide.MiniZinc {

    public class ZincModel : IWriteable, IZincIdentReplaceContainer {

        private List<ZincIncludeItem> includeItems;
        private List<ZincVarDeclItem> varDeclItems;
        private List<ZincConstraintItem> constraintItems;
        private List<ZincOutputItem> outputItems;

        public IEnumerable<IZincItem> Items {
            get {
                return EnumerableUtils.Append<IZincItem,ZincIncludeItem,ZincVarDeclItem> (this.includeItems, this.varDeclItems);
            }
        }

        public ZincModel () {

        }

        public void AddIncludeItem (ZincIncludeItem item) {
            this.includeItems.Add (item);
        }

        public void AddVarDeclItem (ZincVarDeclItem item) {
            this.varDeclItems.Add (item);
        }

        public void AddConstraintItem (ZincConstraintItem item) {
            this.constraintItems.Add (item);
        }

        public void AddOutputItem (ZincOutputItem item) {
            this.outputItems.Add (item);
        }


        public void AddItems (IEnumerable<IZincItem> items) {
            foreach (IZincItem item in items) {
                this.AddItem (item);
            }
        }

        public void AddItem (IZincItem item) {
            switch (item.Type) {
            case ZincItemType.Include:
                AddIncludeItem (item as ZincIncludeItem);
                break;
            case ZincItemType.VarDecl:
                AddVarDeclItem (item as ZincVarDeclItem);
                break;
            case ZincItemType.Constraint:
                AddConstraintItem (item as ZincConstraintItem);
                break;
            case ZincItemType.Output:
                AddOutputItem (item as ZincOutputItem);
                break;
            default :
                Interaction.Warning ("A ZincItem was found with an unknown type. Probably you are running an outdated version of ZincOxide.");
                break;
            }
        }

        #region IWritable implementation
        public void Write (StreamWriter writer) {
            foreach (IZincItem item in this.Items) {
                item.Write (writer);
                writer.WriteLine (";");
            }
        }
        #endregion

        #region IZincIdentContainer implementation
        public IEnumerable<ZincIdent> InvolvedIdents () {
            foreach (IZincItem item in this.Items) {
                foreach (ZincIdent ident in item.InvolvedIdents()) {
                    yield return ident;
                }
            }
        }
        #endregion

        #region IZincIdentReplaceContainer implementation
        public IZincIdentReplaceContainer Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
            //TODO implement
            return this;
        }
        #endregion



    }

}