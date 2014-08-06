//
//  ZincIdentExpressionBoxBase.cs
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
	/// An implementation of the <see cref="IZincExIdBox"/>. A <see cref="ZincBoxBase"/> containing
	/// <see cref="IZincExp"/> and <see cref="IZincIdent"/> instances.
	/// </summary>
	public class ZincExIdBoxBase : ZincIdBoxBase, IZincExIdBox {

		private IZincExp expression;
		#region IZincExBox implementation
		/// <summary>
		/// Gets the <see cref="IZincExp"/> stored of the <see cref="IZincExBox"/>.
		/// </summary>
		/// <value>
		/// The stored <see cref="IZincExp"/> of the <see cref="IZincExBox"/>.
		/// </value>
		public IZincExp Expression {
			get {
				return this.expression;
			}
			protected set {
				this.expression = value;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincExIdBoxBase"/> class without any given initial
		/// instances.
		/// </summary>
		protected ZincExIdBoxBase () : base() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincExIdBoxBase"/> class with a given initial
		/// <see cref="IZincIdent"/> instance.
		/// </summary>
		/// <param name='ident'>
		/// The initial <see cref="IZincIdent"/> instance to store.
		/// </param>
		protected ZincExIdBoxBase (IZincIdent ident) : base(ident) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincExIdBoxBase"/> class with a given initial
		/// <see cref="IZincExp"/> instance.
		/// </summary>
		/// <param name='expression'>
		/// The initial <see cref="IZincExp"/> instance to store.
		/// </param>
		protected ZincExIdBoxBase (IZincExp expression) : base() {
			this.Expression = expression;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincExIdBoxBase"/> class with given initial
		/// <see cref="IZincIdent"/> and <see cref="IZincExp"/> instances.
		/// </summary>
		/// <param name='ident'>
		/// The initial <see cref="IZincIdent"/> instance to store.
		/// </param>
		/// <param name='expression'>
		/// The initial <see cref="IZincExp"/> instance to store.
		/// </param>
		protected ZincExIdBoxBase (IZincIdent ident, IZincExp expression) : base(ident) {
			this.expression = expression;
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
		public override IZincIdentReplaceContainer Replace (IDictionary<IZincIdent,IZincIdent> identMap) {
			this.expression = this.expression.Replace (identMap) as IZincExp;
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
			return EnumerableUtils.Append (this.Expression, base.Children ());
		}
		#endregion
	}
}