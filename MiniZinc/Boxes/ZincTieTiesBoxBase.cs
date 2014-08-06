//
//  ZincTieTieBoxBase.cs
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

	/// <summary>
	/// An implementation of the <see cref="IZincTieTiesBox"/> interface. A <see cref="ZincBoxBase"/> that
	/// contains <see cref="IZincTypeInstExpression"/> instances.
	/// </summary>
	public class ZincTieTiesBoxBase : ZincTieBoxBase, IZincTieTiesBox {

		private IList<IZincTypeInstExpression> expressions;
		#region IZincTieTieBox implementation
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
				return this.expressions;
			}
			protected set {
				this.expressions = value;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincTieTiesBoxBase"/> class with a given intial
		/// <see cref="IZincTypeInstExpression"/> instance and a list of <see cref="IZincTypeInstExpression"/>
		/// instances.
		/// </summary>
		/// <param name='expression'>
		/// An intial <see cref="IZincTypeInstExpression"/> instances.
		/// </param>
		/// <param name='expressions'>
		/// An initial <see cref="T:System.Collections.Generic.IList`1"/> instance of
		/// <see cref="IZincTypeInstExpression"/> instances.
		/// </param>
		protected ZincTieTiesBoxBase (IZincTypeInstExpression expression, IList<IZincTypeInstExpression> expressions) : base(expression) {
			this.TypeInstExpressions = expressions;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincTieTiesBoxBase"/> class with a given intial
		/// <see cref="IZincTypeInstExpression"/> instance and a list of <see cref="IZincTypeInstExpression"/>
		/// instances.
		/// </summary>
		/// <param name='expression'>
		/// An intial <see cref="IZincTypeInstExpression"/> instances.
		/// </param>
		/// <param name='expressions'>
		/// An initial array of <see cref="IZincTypeInstExpression"/> instances.
		/// </param>
		protected ZincTieTiesBoxBase (IZincTypeInstExpression expression, params IZincTypeInstExpression[] expressions) : this(expression,(IList<IZincTypeInstExpression>) expressions) {
			this.TypeInstExpressions = expressions;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincTieTiesBoxBase"/> class with a given intial
		/// <see cref="IZincTypeInstExpression"/> instance and a list of <see cref="IZincTypeInstExpression"/>
		/// instances.
		/// </summary>
		/// <param name='expression'>
		/// An intial <see cref="IZincTypeInstExpression"/> instances.
		/// </param>
		/// <param name='expressions'>
		/// An initial <see cref="T:System.Collections.Generic.IEnumerable`1"/> instance of
		/// <see cref="IZincTypeInstExpression"/> instances.
		/// </param>
		protected ZincTieTiesBoxBase (IZincTypeInstExpression expression, IEnumerable<IZincTypeInstExpression> expressions) : this(expression,expressions.ToArray()) {
		}
		#endregion
		#region IZincIdentReplaceContainer implementation
		/// <summary>
		/// Replaces all the instances stored in the given <see cref="T:IDictionary`2"/>
		/// stored as keys to the corresponding values and returns this instance.
		/// </summary>
		/// <param name='identMap'>
		/// A <see cref="T:IDictionary`2"/> that contains pairs if
		/// <see cref="IZincIdent"/> instances. The keys should be replaced by the values of the dictionary.
		/// </param>
		/// <returns>
		/// This instance, for cascading purposes.
		/// </returns>
		public override IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap) {
			for (int i = 0x00; i < this.expressions.Count; i++) {
				this.expressions [i] = this.expressions [i].Replace (identMap) as IZincTypeInstExpression;
			}
			return base.Replace (identMap);
		}
		#endregion
		#region IComposition implementation
		/// <summary>
		/// Gets a list of involved <see cref="IZincElement"/> instances that are the children of
		/// this <see cref="IZincElement"/>.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> instance of
		/// <see cref="IZincElement"/> that are the childrens of this <see cref="IZincBox"/> instance.
		/// </returns>
		public override IEnumerable<IZincElement> Children () {
			return EnumerableUtils.Append (this.TypeInstExpressions, base.Children ());
		}
		#endregion
	}
}