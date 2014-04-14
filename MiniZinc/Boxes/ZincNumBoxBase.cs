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
		/// <summary>
		/// Gets the <see cref="IZincNumExp"/> stored in the <see cref="IZincNumBox"/>.
		/// </summary>
		/// <value>
		/// The <see cref="IZincNumExp"/> stored in the <see cref="IZincNumBox"/>.
		/// </value>
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
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincNumBoxBase"/> class with a given initial
		/// <see cref="IZincNumExp"/> instance.
		/// </summary>
		/// <param name='numericExpression'>
		/// The initial numeric expression.
		/// </param>
		protected ZincNumBoxBase (IZincNumExp numericExpression) {
			this.NumericExpression = numericExpression;
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
			return this.NumericExpression.InvolvedIdents ();
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
			this.NumericExpression = this.NumericExpression.Replace (identMap) as IZincNumExp;
			return this;
		}
        #endregion

		#region IComposition implementation
		/// <summary>
		/// Gets a list of involved <see cref="IZincElement"/> instances that are the children of
		/// this <see cref="IZincElement"/>.
		/// </summary>
		public override IEnumerable<IZincElement> Children () {
			yield return this.NumericExpression;
		}
        #endregion


	}
}

