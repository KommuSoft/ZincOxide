//
//  ZincTypeInstSetExpression.cs
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
using ZincOxide.MiniZinc.Boxes;

namespace ZincOxide.MiniZinc.Structures {

    public class ZincTypeInstSetExpression : ZincTieBoxBase, IZincType {

        #region IFinite implementation
        public bool Finite {
            get {
                return this.TypeInstExpression.Finite;
            }
        }
        #endregion

        public ZincTypeInstSetExpression (IZincTypeInstExpression expression) : base(expression) {
        }

        public override string ToString () {
            return string.Format ("set of {0}", this.TypeInstExpression);
        }

    }

}