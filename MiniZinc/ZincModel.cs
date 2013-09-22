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
using System.Linq;
using System.IO;
using System.Collections.Generic;
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc {

    public class ZincModel : IZincFile {

        private readonly List<ZincIncludeItem> includeItems = new List<ZincIncludeItem> ();
        private readonly List<ZincVarDeclItem> varDeclItems = new List<ZincVarDeclItem> ();
        private readonly List<ZincAssignItem> assignItems = new List<ZincAssignItem> ();
        private readonly List<ZincConstraintItem> constraintItems = new List<ZincConstraintItem> ();
        private readonly List<ZincOutputItem> outputItems = new List<ZincOutputItem> ();

        public bool IsValidZincData {
            get {
                return this.Items.All (x => x is ZincVarDeclItem);
            }
        }

        public bool IsValidZincModel {
            get {
                return true;//TODO: checks on VarDecl-Assign,...
            }
        }

        public IEnumerable<IZincItem> Items {
            get {
                return EnumerableUtils.Append<IZincItem,ZincIncludeItem,ZincVarDeclItem> (this.includeItems, this.varDeclItems);
            }
        }

        public ZincModel () {
        }

        public ZincModel (IEnumerable<IZincItem> items) : this() {
            this.AddItems (items);
        }

        public ZincModel (params IZincItem[] items) : this((IEnumerable<IZincItem>) items) {
        }

        public void AddIncludeItem (ZincIncludeItem item) {
            if (item != null) {
                this.includeItems.Add (item);
            }
        }

        public void AddVarDeclItem (ZincVarDeclItem item) {
            if (item != null) {
                this.varDeclItems.Add (item);
            }
        }

        public void AddConstraintItem (ZincConstraintItem item) {
            if (item != null) {
                this.constraintItems.Add (item);
            }
        }

        public void AddOutputItem (ZincOutputItem item) {
            if (item != null) {
                this.outputItems.Add (item);
            }
        }

        #region IZincFile implementation
        public void AddItems (IEnumerable<IZincItem> items) {
            if (items != null) {
                foreach (IZincItem item in items) {
                    this.AddItem (item);
                }
            }
        }


        public void AddItem (IZincItem item) {
            if (item != null) {
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
                    Interaction.Warning ("A ZincItem was found with an type that cannot be added to a ZincModel. Probably you are running an outdated version of ZincOxide.");
                    break;
                }
            }
        }
        #endregion

        #region IWritable implementation
        public void Write (TextWriter writer) {
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

        public ZincData ConvertToZincData () {
            return new ZincData (this.Items);
        }

        public ZincData ReduceToZincData () {
            return new ZincData (this.assignItems);//TODO: only par items
        }

        public static explicit operator ZincData (ZincModel model) {
            if (model != null) {
                return new ZincData (model.Items);
            } else {
                return null;
            }
        }

        public static ZincData operator ~ (ZincModel model) {
            if (model != null) {
                return model.ReduceToZincData ();
            } else {
                return null;
            }
        }

    }

}