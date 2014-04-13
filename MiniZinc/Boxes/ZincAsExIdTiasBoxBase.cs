//
//  ZincAsExIdTiasBox.cs
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
using System.Linq;
using ZincOxide.MiniZinc.Structures;
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Boxes {

	public class ZincAsExIdTiasBoxBase : ZincExIdBoxBase, IZincAsExIdTiasBox {

		private IZincAnnotations annotations;
		private IList<ZincTypeInstExprAndIdent> typeInstExpressions;

        #region IZincAsBox implementation
		public IZincAnnotations Annotations {
			get {
				return this.annotations;
			}
			protected set {
				this.annotations = value;
			}
		}
        #endregion

        #region IZincTiasBox implementation
		public IList<ZincTypeInstExprAndIdent> TypeInstAndIdentExpressions {
			get {
				return this.typeInstExpressions;
			}
			protected set {
				this.typeInstExpressions = value;
			}
		}
        #endregion

		protected ZincAsExIdTiasBoxBase (IZincAnnotations annotations, IZincExp expression, ZincIdent ident, IList<ZincTypeInstExprAndIdent> typeInstIdentExpressions) : base(ident,expression) {
			this.Annotations = annotations;
			this.typeInstExpressions = typeInstIdentExpressions;
		}

		protected ZincAsExIdTiasBoxBase (IZincAnnotations annotations, IZincExp expression, ZincIdent ident, params ZincTypeInstExprAndIdent[] typeInstIdentExpressions) : this(annotations,expression,ident,(IList<ZincTypeInstExprAndIdent>)typeInstIdentExpressions) {
		}

		protected ZincAsExIdTiasBoxBase (IZincAnnotations annotations, IZincExp expression, ZincIdent ident, IEnumerable<ZincTypeInstExprAndIdent> typeInstIdentExpressions) : this(annotations,expression,ident,(IList<ZincTypeInstExprAndIdent>)typeInstIdentExpressions.ToArray()) {
		}

		public override IEnumerable<ZincIdent> InvolvedIdents () {
			return EnumerableUtils.Append (base.InvolvedIdents (), this.annotations.InvolvedIdents (), this.typeInstExpressions.SelectMany (x => x.InvolvedIdents ()));
		}

		public override IZincIdentReplaceContainer Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
			this.annotations = this.annotations.Replace (identMap) as ZincAnnotations;
			int n = this.TypeInstAndIdentExpressions.Count;
			for (int i = 0x00; i < n; i++) {
				this.typeInstExpressions [i] = this.typeInstExpressions [i].Replace (identMap) as ZincTypeInstExprAndIdent;
			}
			return base.Replace (identMap);
		}

		public override IEnumerable<IZincElement> Children () {
			return EnumerableUtils.Append (this.annotations, this.typeInstExpressions, base.Children ());
		}


	}

}