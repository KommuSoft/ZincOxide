//
//  ZincScalarType.cs
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
using System.Collections.Generic;

namespace ZincOxide.MiniZinc.Structures {

    public sealed class ZincScalarType : IZincType {

        private readonly ZincScalar scalar;

        public ZincScalar Scalar {
            get {
                return this.scalar;
            }
        }

        public ZincScalarType (ZincScalar scalar) {
            this.scalar = scalar;
        }

        public override string ToString () {
            return ZincPrintUtils.ScalarLiteral (this.Scalar);
        }

        public static implicit operator ZincScalarType (ZincScalar scalar) {
            return new ZincScalarType (scalar);
        }

        public override int GetHashCode () {
            return this.scalar.GetHashCode ();
        }

        public override bool Equals (object obj) {
            if (obj is ZincScalarType) {
                ZincScalarType zst = obj as ZincScalarType;
                return (this.scalar == zst.scalar);
            }
            return false;
        }

        #region IZincIdentContainer implementation
        public IEnumerable<ZincIdent> InvolvedIdents () {
            yield break;
        }
        #endregion

        #region IZincIdentReplaceContainer implementation
        public IZincIdentReplaceContainer Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
            return this;
        }
        #endregion




    }

}