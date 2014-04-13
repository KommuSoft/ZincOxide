//
//  ZincTypeInstExpressionArray.cs
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
using System.Collections.Generic;
using ZincOxide.MiniZinc.Boxes;
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Structures {

	public class ZincTypeInstArrayExpression : ZincTieTiesBoxBase, IZincType {
		public IZincTypeInstExpression OfType {
			get {
				return this.TypeInstExpression;
			}
		}

		public IList<IZincTypeInstExpression> IndexTypes {
			get {
				return this.TypeInstExpressions;
			}
		}

		#region IFinite implementation

		public bool Finite {
			get {
				return (this.TypeInstExpression.Finite && this.TypeInstExpressions.All (x => x.Finite));
			}
		}

		#endregion

		#region IZincType implementation

		public bool Compounded {
			get {
				return true;
			}
		}

		public ZincScalar ScalarType {
			get {
				//TODO
				return ZincScalar.Bool;
				//return this.TypeInstExpression.ScalarType;
			}
		}

		#endregion

		public ZincTypeInstArrayExpression (IZincTypeInstExpression oftype, IZincTypeInstExpression atta, IZincTypeInstExpression attb) : base (oftype, new IZincTypeInstExpression[] {
			atta,
			attb
		}) {
		}

		public ZincTypeInstArrayExpression (IZincTypeInstExpression oftype, IEnumerable<IZincTypeInstExpression> attributes) : base (oftype, attributes) {
		}

		public ZincTypeInstArrayExpression (IZincTypeInstExpression oftype, params IZincTypeInstExpression[] attributes) : base (oftype, attributes) {
		}

		public override string ToString () {
			return string.Format ("array [ {0} ] of {1}", string.Join (" , ", this.TypeInstExpressions), this.TypeInstExpression);
		}

		#region IZincType implementation

		public bool IsSubType (IZincType type) {
			if (type != null && type is ZincTypeInstArrayExpression) {
				ZincTypeInstArrayExpression zta = (ZincTypeInstArrayExpression)type;
				return (zta.OfType.IsSubType (zta) && this.IndexTypes.All (zta.IndexTypes, (x, y) => x.IsSubType (y)));
			} else {
				return false;
			}
		}

		#endregion

	}
}