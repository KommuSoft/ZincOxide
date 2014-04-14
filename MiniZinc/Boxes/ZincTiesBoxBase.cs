//
//  ZincTiesBoxBase.cs
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
using ZincOxide.MiniZinc.Structures;

namespace ZincOxide.MiniZinc.Boxes {

	/// <summary>
	/// An implementation of the <see cref="IZincTiesBox"/> interface. A <see cref="ZincBoxBase"/> that contains
	/// an <see cref="T:System.Collections.Generic.IList`1"/> instance of <see cref="IZincTypeInstExpression"/>
	/// instances.
	/// </summary>
	public class ZincTiesBoxBase : ZincBoxBase, IZincTiesBox {

		private IList<IZincTypeInstExpression> typeInstExpressions;

        #region IZincTiesBox implementation
		/// <summary>
		/// Gets an <see cref="T:System.Collections.Generic.IList`1"/> that contains the
		/// <see cref="IZincTypeInstExpression"/> instances stored in the <see cref="IZincTiesBox"/>.
		/// </summary>
		/// <value>
		/// An <see cref="T:System.Collections.Generic.IList`1"/> that contains the
		/// <see cref="IZincTypeInstExpression"/> instances stored in the <see cref="IZincTiesBox"/>.
		/// </value>
		public IList<IZincTypeInstExpression> TypeInstExpressions {
			get {
				return this.typeInstExpressions;
			}
			protected set {
				this.typeInstExpressions = value;
			}
		}
        #endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincTiesBoxBase"/> class
		/// with an intial list of <see cref="IZincTypeInstExpression"/> instances.
		/// </summary>
		/// <param name='typeInstExpressions'>
		/// An initial <see cref="T:System.Collections.Generic.IList`1"/> instance of
		/// <see cref="IZincTypeInstExpression"/> instances.
		/// </param>
		protected ZincTiesBoxBase (IList<IZincTypeInstExpression> typeInstExpressions) {
			this.typeInstExpressions = typeInstExpressions;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincTiesBoxBase"/> class
		/// with an intial list of <see cref="IZincTypeInstExpression"/> instances.
		/// </summary>
		/// <param name='typeInstExpressions'>
		/// An initial <see cref="T:System.Collections.Generic.IEnumerable`1"/> instance of
		/// <see cref="IZincTypeInstExpression"/> instances.
		/// </param>
		protected ZincTiesBoxBase (IEnumerable<IZincTypeInstExpression> typeInstExpressions) : this(typeInstExpressions.ToList()) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincTiesBoxBase"/> class
		/// with an intial array of <see cref="IZincTypeInstExpression"/> instances.
		/// </summary>
		/// <param name='typeInstExpressions'>
		/// An initial array of <see cref="IZincTypeInstExpression"/> instances.
		/// </param>
		protected ZincTiesBoxBase (params IZincTypeInstExpression[] typeInstExpressions) : this((IList<IZincTypeInstExpression>) typeInstExpressions) {
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
			return this.typeInstExpressions.SelectMany (x => x.InvolvedIdents ());
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
			int n = this.typeInstExpressions.Count;
			for (int i = 0x00; i < n; i++) {
				this.typeInstExpressions [i] = this.typeInstExpressions [i].Replace (identMap) as IZincTypeInstExpression;
			}
			return base.Replace (identMap);
		}
        #endregion

		#region IComposition implementation
		/// <summary>
		/// Gets a list of involved <see cref="IZincElement"/> instances that are the children of
		/// this <see cref="IZincElement"/>.
		/// </summary>
		public override IEnumerable<IZincElement> Children () {
			return this.typeInstExpressions;
		}
		#endregion

	}

}