//
//  ZincNumBoxBase.cs
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
using ZincOxide.MiniZinc.Structures;

namespace ZincOxide.MiniZinc.Boxes {

	/// <summary>
	/// An implementation of the <see cref="IZincNumBox"/> interface. A <see cref="ZincBoxBase"/> containing
	/// a <see cref="IZincNumExp"/> instance.
	/// </summary>
	public class ZincNumBoxBase : ZincBoxBase, IZincNumBox {

		private IZincNumExp numExp;

        #region IZincNumBox implementation
		public IZincNumExp NumericExpression {
			get {
				return this.numExp;
			}
			protected set {
				this.numExp = value;
			}
		}
        #endregion

		#region Constructors
		protected ZincNumBoxBase (IZincNumExp numericExpression) {
			this.NumericExpression = numericExpression;
		}
		#endregion

        #region IZincIdentContainer implementation
		public override IEnumerable<ZincIdent> InvolvedIdents () {
			return this.NumericExpression.InvolvedIdents ();
		}
        #endregion

        #region IZincIdentReplaceContainer implementation
		public override IZincIdentReplaceContainer Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
			this.NumericExpression = this.NumericExpression.Replace (identMap) as IZincNumExp;
			return this;
		}
        #endregion

        #region implemented abstract members of ZincOxide.MiniZinc.Boxes.ZincBoxBase
		public override IEnumerable<IZincElement> Children () {
			yield return this.NumericExpression;
		}
        #endregion


	}
}

