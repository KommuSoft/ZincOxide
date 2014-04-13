//
//  ZincBoxBase.cs
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
	/// An abstract implementation of the <see cref="IZincBox"/> interface. This is a <see cref="IZincElement"/>
	/// that contains one or more references to other <see cref="IZincElement"/> items.
	/// </summary>
	public abstract class ZincBoxBase : IZincBox {

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincBoxBase"/> class.
		/// </summary>
		protected ZincBoxBase () {
		}
		#endregion

        #region IValidateable implementation
		/// <summary>
		/// Validate this instance. In case the <see cref="SoftValidate"/> method
		/// returns one or more items, the object is considered to be invalid.
		/// </summary>
		public virtual bool Validate () {
			return ValidateableUtils.Validate (this);
		}
        #endregion

        #region ISoftValidateable implementation
		/// <summary>
		/// Softs the validate.
		/// </summary>
		/// <returns>
		/// The validate.
		/// </returns>
		public virtual IEnumerable<string> SoftValidate () {
			return ValidateableUtils.CompositionInnerSoftValidate<IZincElement,IZincElement> (this);
		}
        #endregion

        #region IComposition implementation
		/// <summary>
		/// Gets a list of involved <see cref="IZincElement"/> instances that are the children of
		/// this <see cref="IZincElement"/>.
		/// </summary>
		public abstract IEnumerable<IZincElement> Children ();
        #endregion

        #region IZincBox implementation
		/// <summary>
		/// Gets an <see cref="T:System.Collections.Generic.IEnumerable`1"/> with error messages.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> with error messages.
		/// </returns>
		/// <remarks>
		/// <para>By default, no error messages are thrown.</para>
		/// </remarks>
		public virtual IEnumerable<string> InnerSoftValidate () {
			yield break;
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
		public abstract IEnumerable<IZincIdent> InvolvedIdents ();
        #endregion

        #region IZincIdentReplaceContainer implementation
		/// <summary>
		/// Replaces all the instances stored in the given <see cref="System.Collections.Generic.IDictionary`1"/>
		/// stored as keys to the corresponding values and returns this instance.
		/// </summary>
		/// <returns>
		/// This instance, for cascading purposes.
		/// </returns>
		public virtual IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap) {
			return this;
		}
        #endregion

	}

}