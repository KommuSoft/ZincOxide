//
//  ZincTyBoxBase.cs
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
	/// An implementation of the <see cref="IZincTyBox"/> interface. A <see cref="ZincBoxBase"/> containing
	/// a <see cref="IZincType"/> instance.
	/// </summary>
	public class ZincTyBoxBase : ZincBoxBase, IZincTyBox {

		private IZincType type;
		#region IZincTyBox implementation
		/// <summary>
		/// Gets the <see cref="IZincType"/> instance stored in the <see cref="IZincTyBox"/>.
		/// </summary>
		/// <value>
		/// The <see cref="IZincType"/> instance stored in the <see cref="IZincTyBox"/>.
		/// </value>
		public IZincType Type {
			get {
				return this.type;
			}
			protected set {
				this.type = value;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincTyBoxBase"/> class with an initial
		/// <see cref="IZincType"/> instance.
		/// </summary>
		/// <param name='type'>
		/// The initial <see cref="IZincType"/> instance.
		/// </param>
		protected ZincTyBoxBase (IZincType type) {
			this.type = type;
		}
		#endregion
		#region IZincIdentContainer implementation
		/// <summary>
		/// Returns a <see cref="T:IEnumerable`1"/> containing the involved
		/// <see cref="IZincIdent"/> instances of the container.
		/// </summary>
		/// <returns>
		/// A <see cref="T:IEnumerable`1"/> containing the involved\
		/// <see cref="IZincIdent"/> instances of the container.
		/// </returns>
		public override IEnumerable<IZincIdent> InvolvedIdents () {
			return this.type.InvolvedIdents ();
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
			this.type = this.type.Replace (identMap) as IZincType;
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
			yield return this.type;
		}
		#endregion
	}
}

