//
//  ZincLeafElement.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2014 Willem Van Onsem
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
using System;
using System.Collections.Generic;
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Structures {

	/// <summary>
	/// A basic implementation of a <see cref="IZincElement"/> describing an element that doesn't have children.
	/// </summary>
	public abstract class ZincLeafElement : IZincElement {
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincLeafElement"/> class: a <see cref="IZincElement"/> that
		/// has no children.
		/// </summary>
		public ZincLeafElement () {
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
		public virtual IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap) {
			return this;
		}
		#endregion
		#region IZincIdentContainer implementation
		/// <summary>
		/// Returns a <see cref="T:IEnumerable`1"/> containing the
		/// involved <see cref="IZincIdent"/> instances of the container.
		/// </summary>
		/// <returns>
		/// A <see cref="T:IEnumerable`1"/> containing the involved
		/// <see cref="IZincIdent"/> instances of the container.
		/// </returns>
		public virtual IEnumerable<IZincIdent> InvolvedIdents () {
			yield break;
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
		public virtual IEnumerable<IZincElement> Children () {
			yield break;
		}
		#endregion
		#region ISoftValidateable implementation
		/// <summary>
		/// Generates a number of error messages that specify what is wrong with this instance.
		/// </summary>
		/// <returns>A <see cref="T:IEumerable`1"/> that contains a list of error messages describing why the instance is invalid.</returns>
		/// <remarks>
		/// <para>If no error messages are generated, the instance is valid, otherwise the instance is invalid.</para>
		/// </remarks>
		public virtual IEnumerable<string> SoftValidate () {
			return this.InnerSoftValidate ();
		}
		#endregion
		#region IValidateable implementation
		/// <summary>
		/// Checks if the given instance is valid.
		/// </summary>
		/// <returns>True if the instance is valid, otherwise false.</returns>
		public virtual bool Validate () {
			return ValidateableUtils.Validate (this);
		}
		#endregion
		#region IInnerSoftValidateable implementation
		/// <summary>
		/// Generates a number of error messages that specify what is wrong with this instance.
		/// </summary>
		/// <returns>A <see cref="T:IEumerable`1"/> that contains a list of error messages describing why the instance is invalid.</returns>
		/// <remarks>
		/// <para>If no error messages are generated, the instance is valid, otherwise the instance is invalid.</para>
		/// </remarks>
		public abstract IEnumerable<string> InnerSoftValidate ();
		#endregion
	}
}

