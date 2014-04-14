//
//  ZincIdentBoxBase.cs
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
	/// An implementation of a <see cref="IZincIdBox"/> interface. A <see cref="ZincBoxBase"/> that stores an
	/// <see cref="IZincIdent"/> instance.
	/// </summary>
	public abstract class ZincIdBoxBase : ZincBoxBase, IZincIdBox {

		private IZincIdent ident;

        #region IZincIdBox implementation
		/// <summary>
		/// The <see cref="IZincIdent"/> stored in the <see cref="IZincIdBox"/>.
		/// </summary>
		/// <value>
		/// The <see cref="IZincIdent"/> stored in the <see cref="IZincIdBox"/>.
		/// </value>
		public IZincIdent Ident {
			get {
				return this.ident;
			}
			protected set {
				this.ident = value;
			}
		}
        #endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincExIdBoxBase"/> class without a given initial
		/// <see cref="IZincIdent"/> instances.
		/// </summary>
		protected ZincIdBoxBase () {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincExIdBoxBase"/> class with a given initial
		/// <see cref="IZincIdent"/> instances.
		/// </summary>
		/// <param name='ident'>
		/// The initial <see cref="IZincIdent"/> instance to store.
		/// </param>
		protected ZincIdBoxBase (IZincIdent ident) {
			this.Ident = ident;
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
			yield return this.ident;
		}
        #endregion

        #region IZincIdentReplaceContainer implementation
		/// <summary>
		/// Replaces all the instances stored in the given <see cref="System.Collections.Generic.IDictionary`1"/>
		/// stored as keys to the corresponding values and returns this instance.
		/// </summary>
		/// <param name='identMap'>
		/// A <see cref="T:System.Collections.Generic.IDictionary`2"/> that contains pairs if
		/// <see cref="IZincIdent"/> instances. The keys should be replaced by the values of the dictionary.
		/// </param>
		/// <returns>
		/// This instance, for cascading purposes.
		/// </returns>
		public override IZincIdentReplaceContainer Replace (IDictionary<IZincIdent,IZincIdent> identMap) {
			this.ident = this.ident.Replace (identMap) as ZincIdent;
			return this;
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
			yield return this.ident;
		}
		#endregion

	}

}