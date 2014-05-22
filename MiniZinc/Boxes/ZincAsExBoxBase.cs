//
//  ZincAsExBoxBase.cs
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
	/// An implementation of the <see cref="IZincAsExBox"/> interface. A <see cref="ZincBoxBase"/> that contains
	/// a <see cref="IZincExp"/> instance and a <see cref="IZincAnnotations"/> instance.
	/// </summary>
	public class ZincAsExBoxBase : ZincExBoxBase, IZincAsExBox {		//TODO: make abstract
		private IZincAnnotations annotations;
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
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.MiniZinc.Boxes.ZincAsExBoxBase"/> class
		/// without any initial value.
		/// </summary>
		protected ZincAsExBoxBase () : base() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.MiniZinc.Boxes.ZincAsExBoxBase"/> class
		/// with a given initial <see cref="IZincAnnotations"/> instance.
		/// </summary>
		/// <param name='anns'>
		/// The given initial <see cref="IZincAnnotations"/> instance.
		/// </param>
		protected ZincAsExBoxBase (IZincAnnotations anns) : base() {
			this.Annotations = anns;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.MiniZinc.Boxes.ZincAsExBoxBase"/> class
		/// with a given initial <see cref="IZincAnnotations"/> and <see cref="IZincExp"/> instance.
		/// </summary>
		/// <param name='anns'>
		/// The given initial <see cref="IZincAnnotations"/> instance.
		/// </param>
		/// <param name='expr'>
		/// The given initial <see cref="IZincExp"/> instance.
		/// </param>
		protected ZincAsExBoxBase (IZincAnnotations anns, IZincExp expr) : base(expr) {
			this.Annotations = anns;
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
			return EnumerableUtils.Append (this.Annotations.InvolvedIdents (), base.InvolvedIdents ());
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
			this.Annotations = this.Annotations.Replace (identMap) as ZincAnnotations;
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
			return EnumerableUtils.Append (this.annotations, base.Children ());
		}
		#endregion
	}
}