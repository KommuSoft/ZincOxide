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

	/// <summary>
	/// An implementation of the <see cref="IZincAsExIdTiasBox"/>, a <see cref="ZincBoxBase"/>
	/// that stores <see cref="IZincExp"/>, <see cref="IZincIdent"/>, <see cref="IZincAnnotations"/>
	/// ans <see cref="IZincTypeInstExprAndIdent"/> instances.
	/// </summary>
	public class ZincAsExIdTiasBoxBase : ZincExIdBoxBase, IZincAsExIdTiasBox {

		private IZincAnnotations annotations;
		private IList<IZincTypeInstExprAndIdent> typeInstExpressions;

        #region IZincAsBox implementation
		/// <summary>
		/// Gets the <see cref="IZincAnnotations"/> instance stored in the <see cref="IZincBox"/>.
		/// </summary>
		/// <value>
		/// The <see cref="IZincAnnotations"/> instance stored in the <see cref="IZincBox"/>.
		/// </value>
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
		/// <summary>
		/// Gets the <see cref="T:System.Collection.Generic.IList`1"/> with <see cref="IZincTypeInstExprAndIdent"/>
		/// instances stored in the <see cref="IZincTiasBox"/>.
		/// </summary>
		/// <value>
		/// The <see cref="T:System.Collection.Generic.IList`1"/> with <see cref="IZincTypeInstExprAndIdent"/>
		/// instances stored in the <see cref="IZincTiasBox"/>.
		/// </value>
		public IList<IZincTypeInstExprAndIdent> TypeInstAndIdentExpressions {
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
		/// Initializes a new instance of the <see cref="ZincAsExIdTiasBoxBase"/> class
		/// with a given initial <see cref="IZincAnnotations"/>, <see cref="IZincExp"/>, <see cref="IZincIdent"/>
		/// instances.
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
		protected ZincAsExIdTiasBoxBase (IZincAnnotations anns, IZincExp expr, IZincIdent id) : base(id,expr) {
			this.Annotations = anns;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincAsExIdTiasBoxBase"/> class
		/// with a given initial <see cref="IZincAnnotations"/>, <see cref="IZincExp"/>, <see cref="IZincIdent"/> and
		/// <see cref="IZincTypeInstExprAndIdent"/> instances.
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
		/// <param name='tias'>
		/// The given initial <see cref="IZincTypeInstExprAndIdent"/> instances.
		/// </param>
		protected ZincAsExIdTiasBoxBase (IZincAnnotations anns, IZincExp expr, IZincIdent id, IList<IZincTypeInstExprAndIdent> tias) : base(id,expr) {
			this.Annotations = anns;
			this.typeInstExpressions = tias;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincAsExIdTiasBoxBase"/> class
		/// with a given initial <see cref="IZincAnnotations"/>, <see cref="IZincExp"/>, <see cref="IZincIdent"/> and
		/// <see cref="IZincTypeInstExprAndIdent"/> instances.
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
		/// <param name='tias'>
		/// The given initial <see cref="IZincTypeInstExprAndIdent"/> instances.
		/// </param>
		protected ZincAsExIdTiasBoxBase (IZincAnnotations anns, IZincExp expr, IZincIdent id, params IZincTypeInstExprAndIdent[] tias) : this(anns,expr,id,(IList<IZincTypeInstExprAndIdent>)tias) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincAsExIdTiasBoxBase"/> class
		/// with a given initial <see cref="IZincAnnotations"/>, <see cref="IZincExp"/>, <see cref="IZincIdent"/> and
		/// <see cref="IZincTypeInstExprAndIdent"/> instances.
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
		/// <param name='tias'>
		/// The given initial <see cref="IZincTypeInstExprAndIdent"/> instances.
		/// </param>
		protected ZincAsExIdTiasBoxBase (IZincAnnotations anns, IZincExp expr, IZincIdent id, IEnumerable<IZincTypeInstExprAndIdent> tias) : this(anns,expr,id,(IList<IZincTypeInstExprAndIdent>)tias.ToArray()) {
		}
		#endregion

		#region IZincIdentContainer implementation
		/// <summary>
		/// Returns a <see cref="T:System.Collections.Generic.IEnumerable`1"/> containing the
		/// involved <see cref="IZincIdent"/> instances of the container.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerable`1"/> containing the involved
		/// <see cref="IZincIdent"/> instances of the container.
		/// </returns>
		public override IEnumerable<IZincIdent> InvolvedIdents () {
			return EnumerableUtils.Append (base.InvolvedIdents (), this.annotations.InvolvedIdents (), this.typeInstExpressions.SelectMany (x => x.InvolvedIdents ()));
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
			this.annotations = this.annotations.Replace (identMap) as ZincAnnotations;
			int n = this.TypeInstAndIdentExpressions.Count;
			for (int i = 0x00; i < n; i++) {
				this.typeInstExpressions [i] = this.typeInstExpressions [i].Replace (identMap) as ZincTypeInstExprAndIdent;
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
			return EnumerableUtils.Append (this.annotations, this.typeInstExpressions, base.Children ());
		}
		#endregion

	}

}