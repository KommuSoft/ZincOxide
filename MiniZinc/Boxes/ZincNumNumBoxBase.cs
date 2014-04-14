//
//  ZincNumNumBoxBase.cs
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
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Boxes {

	/// <summary>
	/// An implementation of the <see cref="IZincNumNumBox"/> interface. A <see cref="ZincBoxBase"/> that contains
	/// two <see cref="IZincNumExp"/> instances.
	/// </summary>
	public class ZincNumNumBoxBase : ZincNumBoxBase, IZincNumNumBox {

		private IZincNumExp numExp2;

        #region IZincNumNumBox implementation
		/// <summary>
		/// Gets the second <see cref="IZincNumExp"/> stored in the <see cref="IZincNumNumBox"/>.
		/// </summary>
		/// <value>
		/// The second <see cref="IZincNumExp"/> stored in the <see cref="IZincNumNumBox"/>.
		/// </value>
		public IZincNumExp NumericExpression2 {
			get {
				return this.numExp2;
			}
			protected set {
				this.numExp2 = value;
			}
		}
        #endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.MiniZinc.Boxes.ZincNumNumBoxBase"/> class with
		/// two given initial <see cref="IZincNumExp"/> instances.
		/// </summary>
		/// <param name='numericExpression'>
		/// The first <see cref="IZincNumExp"/> instance.
		/// </param>
		/// <param name='numericExpression2'>
		/// The second <see cref="IZincNumExp"/> instance.
		/// </param>
		protected ZincNumNumBoxBase (IZincNumExp numericExpression, IZincNumExp numericExpression2) : base(numericExpression) {
			this.NumericExpression2 = numericExpression2;
		}
		#endregion

        #region IZincIdentContainer implementation
		/// <summary>
		/// Returns a <see cref="T:System.Collections.Generic.IEnumerable`1"/> containing the involved
		/// <see cref="IZincIdent"/> instances of the container.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerable`1"/> containing the involved
		/// <see cref="IZincIdent"/> instances of the container.
		/// </returns>
		public override IEnumerable<IZincIdent> InvolvedIdents () {
			return EnumerableUtils.Append (this.NumericExpression.InvolvedIdents (), this.NumericExpression2.InvolvedIdents ());
		}
        #endregion

        #region IZincIdentReplaceContainer implementation
		/// <summary>
		/// Replaces all the instances stored in the given <see cref="System.Collections.Generic.IDictionary`1"/>
		/// stored as keys to the corresponding values and returns this instance.
		/// </summary>
		/// <returns>
		/// This instance, for cascading purposes.
		/// </returns>
		public override IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap) {
			this.NumericExpression2 = this.NumericExpression2.Replace (identMap) as IZincNumExp;
			return base.Replace (identMap);
		}
        #endregion

		#region IComposition implementation
		/// <summary>
		/// Gets a list of involved <see cref="IZincElement"/> instances that are the children of
		/// this <see cref="IZincElement"/>.
		/// </summary>
		public override IEnumerable<IZincElement> Children () {
			return EnumerableUtils.Append (this.NumericExpression2, base.Children ());
		}
		#endregion

	}

}