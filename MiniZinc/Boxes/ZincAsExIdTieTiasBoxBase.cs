//
//  ZincAsExIdTieTiasBox.cs
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
	/// An implementation of the <see cref="IZincAsExIdTieTiasBox"/> interface. A <see cref="ZincBoxBase"/>
	/// containing <see cref="IZincAnnotations"/>, <see cref="IZincExp"/>, <see cref="IZincIdent"/>,
	/// <see cref="IZincTypeInstExpression"/> and <see cref="IZincTypeInstExprAndIdent"/> instances.
	/// </summary>
	public class ZincAsExIdTieTiasBoxBase : ZincAsExIdTiasBoxBase, IZincAsExIdTieTiasBox {

		private IZincTypeInstExpression typeInstExpression;
		#region IZincTieBox implementation
		/// <summary>
		/// Gets the <see cref="IZincTypeInstExpression"/> instance stored in the <see cref="IZincTieBox"/>.
		/// </summary>
		/// <value>
		/// The <see cref="IZincTypeInstExpression"/> instance stored in the <see cref="IZincTieBox"/>.
		/// </value>
		public IZincTypeInstExpression TypeInstExpression {
			get {
				return this.typeInstExpression;
			}
			protected set {
				this.typeInstExpression = value;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincAsExIdTieTiasBoxBase"/> class
		/// with a given initial <see cref="IZincAnnotations"/>, <see cref="IZincExp"/>, <see cref="IZincIdent"/>,
		/// <see cref="IZincTypeInstExpression"/> and <see cref="IZincTypeInstExprAndIdent"/> instances.
		/// </summary>
		/// <param name='anns'>
		/// The given initial <see cref="IZincAnnotations"/> instance.
		/// </param>
		/// <param name='expr'>
		/// The given initial <see cref="IZincExp"/> instance.
		/// </param>
		/// <param name='id'>
		/// The given initial <see cref="IZincIdent"/> instance.
		/// </param>
		/// <param name='tie'>
		/// The given initial <see cref="IZincTypeInstExpression"/> instance.
		/// </param>
		/// <param name='tias'>
		/// The given initial <see cref="IZincTypeInstExprAndIdent"/> instances.
		/// </param>
		protected ZincAsExIdTieTiasBoxBase (ZincAnnotations anns, IZincExp expr, ZincIdent id, IZincTypeInstExpression tie, IList<ZincTypeInstExprAndIdent> tias) : base(anns,expr,id,tias) {
			this.typeInstExpression = tie;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincAsExIdTieTiasBoxBase"/> class
		/// with a given initial <see cref="IZincAnnotations"/>, <see cref="IZincExp"/>, <see cref="IZincIdent"/>,
		/// <see cref="IZincTypeInstExpression"/> and <see cref="IZincTypeInstExprAndIdent"/> instances.
		/// </summary>
		/// <param name='anns'>
		/// The given initial <see cref="IZincAnnotations"/> instance.
		/// </param>
		/// <param name='expr'>
		/// The given initial <see cref="IZincExp"/> instance.
		/// </param>
		/// <param name='id'>
		/// The given initial <see cref="IZincIdent"/> instance.
		/// </param>
		/// <param name='tie'>
		/// The given initial <see cref="IZincTypeInstExpression"/> instance.
		/// </param>
		/// <param name='tias'>
		/// The given initial <see cref="IZincTypeInstExprAndIdent"/> instances.
		/// </param>
		protected ZincAsExIdTieTiasBoxBase (ZincAnnotations anns, IZincExp expr, ZincIdent id, IZincTypeInstExpression tie, params ZincTypeInstExprAndIdent[] tias) : base(anns,expr,id,tias) {
			this.typeInstExpression = tie;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincAsExIdTieTiasBoxBase"/> class
		/// with a given initial <see cref="IZincAnnotations"/>, <see cref="IZincExp"/>, <see cref="IZincIdent"/>,
		/// <see cref="IZincTypeInstExpression"/> and <see cref="IZincTypeInstExprAndIdent"/> instances.
		/// </summary>
		/// <param name='anns'>
		/// The given initial <see cref="IZincAnnotations"/> instance.
		/// </param>
		/// <param name='expr'>
		/// The given initial <see cref="IZincExp"/> instance.
		/// </param>
		/// <param name='id'>
		/// The given initial <see cref="IZincIdent"/> instance.
		/// </param>
		/// <param name='tie'>
		/// The given initial <see cref="IZincTypeInstExpression"/> instance.
		/// </param>
		/// <param name='tias'>
		/// The given initial <see cref="IZincTypeInstExprAndIdent"/> instances.
		/// </param>
		protected ZincAsExIdTieTiasBoxBase (ZincAnnotations anns, IZincExp expr, ZincIdent id, IZincTypeInstExpression tie, IEnumerable<ZincTypeInstExprAndIdent> tias) : base(anns,expr,id,tias) {
			this.typeInstExpression = tie;
		}
		#endregion
		#region IZincIdentReplaceContainer implementation
		/// <summary>
		/// Replaces all the instances stored in the given <see cref="T:IDictionary`2"/>
		/// stored as keys to the corresponding values and returns this instance.
		/// </summary>
		/// <param name='identMap'>
		/// A <see cref="T:System.Collections.Generic.IDictionary`2"/> that contains pairs if
		/// <see cref="IZincIdent"/> instances. The keys should be replaced by the values of the dictionary.
		/// </param>
		/// <returns>
		/// This instance, for cascading purposes.
		/// </returns>
		public override IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap) {
			this.typeInstExpression.Replace (identMap);
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
			return EnumerableUtils.Append (this.TypeInstExpression, base.Children ());
		}
		#endregion
	}
}

