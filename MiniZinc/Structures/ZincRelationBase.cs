//
//  ZincRelationBase.cs
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

namespace ZincOxide.MiniZinc.Structures {

    public class ZincRelationBase : IZincRelation {

        private IZincType outputType;
        private IList<IZincType> inputTypes;

        #region IArity implementation
        public int Arity {
            get {
                throw new System.NotImplementedException ();
            }
        }
        #endregion

        #region IDimensions implementation
        public int Dimensions {
            get {
                return this.Arity + 0x01;
            }
        }
        #endregion

        public ZincRelationBase () {
        }

        #region IZincRelation implementation
        public bool Match (IEnumerable<IZincType> input) {
            IEnumerator<IZincType> iterator = input.GetEnumerator ();
            foreach (IZincType type in this.inputTypes) {
                if (!iterator.MoveNext () || !type.IsSubType (iterator.Current)) {
                    return false;
                }
            }
            return !iterator.MoveNext ();
        }

        public IZincType OuputType {
            get {
                return this.outputType;
            }
        }

        public IList<IZincType> InputTypes {
            get {
                return this.inputTypes;
            }
        }
        #endregion


    }
}

