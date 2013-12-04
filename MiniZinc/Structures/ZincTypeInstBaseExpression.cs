//
//  ZincTypeInstBaseExpression.cs
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
using ZincOxide.MiniZinc.Boxes;

namespace ZincOxide.MiniZinc.Structures {

	public class ZincTypeInstBaseExpression : ZincTyBoxBase, IZincTypeInstExpression {
		private ZincVarPar varPar;

		public ZincVarPar VarPar {
			get {
				return this.varPar;
			}
			protected set {
				this.varPar = value;
			}
		}

		public bool IsSubType (IZincType type) {
			return this.Type.IsSubType (type);
		}

		public bool Compounded {
			get {
				return this.Type.Compounded;
			}
		}

		public ZincScalar ScalarType {
			get {
				return this.Type.ScalarType;
			}
		}

		#region IFinite implementation

		public bool Finite {
			get {
				return this.Type.Finite;
			}
		}

		#endregion

		public ZincTypeInstBaseExpression (ZincVarPar varPar, IZincType type) : base (type) {
			this.VarPar = varPar;
			this.Type = type;
		}

		public ZincTypeInstBaseExpression (IZincType type) : this (ZincVarPar.Par, type) {
		}

		public ZincTypeInstBaseExpression (IZincType type, ZincVarPar varPar = ZincVarPar.Par) : this (varPar, type) {
		}

		public override string ToString () {
			return string.Format ("{0} {1}", ZincPrintUtils.VarParLiteral (this.VarPar), this.Type);
		}
	}
}

