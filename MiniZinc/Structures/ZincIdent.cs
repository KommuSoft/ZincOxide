//
//  ZincIdent.cs
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
using ZincOxide.Utils.Abstract;
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Structures {

	/// <summary>
	/// An implementation of the <see cref="IZincIdent"/> interface.
	/// </summary>
	public class ZincIdent : NameIdBase, IZincIdent {

		#region Fields
		private ZincIdentUsage usage;
		#endregion
		#region IZincIdent implementation
		/// <summary>
		/// Gets or sets the usage of the identifier (used as a hint for the compiler).
		/// </summary>
		/// <value>A <see cref="ZincIdentUsage"/> value describing the use of the identifier.</value>
		public ZincIdentUsage Usage {
			get {
				return this.usage;
			}
			set {
				this.usage = value;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincIdent"/> class with the name and optionally the usage of
		/// the identifier.
		/// </summary>
		/// <param name="name">The name associated with the <see cref="ZincIdent"/>.</param>
		/// <param name="usage">The usage of the identifer, optional, by default <see cref="ZincIdentUsage.Unknown"/>.</param>
		public ZincIdent (string name, ZincIdentUsage usage = ZincIdentUsage.Unknown) : base(name) {
			this.Usage = usage;
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
		public IEnumerable<IZincIdent> InvolvedIdents () {
			yield return this;
		}
		#endregion
		#region IZincIdentReplaceContainer implementation
		/// <summary>
		/// Replaces all the instances stored in the given <see cref="T:IDictionary`1"/>
		/// stored as keys to the corresponding values and returns this instance, possibly if this is an
		/// <see cref="IZincIdent"/> itself another <see cref="IZincIdent"/>.
		/// </summary>
		/// <returns>
		/// If this instance is a compound type, a reference to itself. Otherwise a <see cref="IZincIdent"/> if
		/// this instance is a <see cref="IZincIdent"/> itself.
		/// </returns>
		public IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap) {
			IZincIdent outp;
			if (identMap.TryGetValue (this, out outp)) {
				return outp;
			} else {
				return this;
			}
		}
		#endregion
		#region IBindToString implementation
		/// <summary>
		/// Generate a string that contains the content of the instances together with an identifier or a memory address.
		/// </summary>
		/// <returns>A string containing both the data and identifier of the instance.</returns>
		/// <remarks>
		/// <para>The format is <c>name&amp;id</c>.</para>
		/// </remarks>
		public string ToBindString () {
			return string.Format ("{0}&{1}", this.Name, this.Id);
		}
		#endregion
		#region IInnerSoftValidateable implementation
		public IEnumerable<string> InnerSoftValidate () {
			yield break;
		}
		#endregion
		#region IValidateable implementation
		public bool Validate () {
			return ValidateableUtils.Validate (this);
		}
		#endregion
		#region ISoftValidateable implementation
		public IEnumerable<string> SoftValidate () {
			return ValidateableUtils.CompositionInnerSoftValidate<IZincElement,IZincElement> (this);
		}
		#endregion
		#region IComposition implementation
		/// <summary>
		/// Enumerate the children of this instance. This is done in a hierarchical manner.
		/// </summary>
		public IEnumerable<IZincElement> Children () {
			yield break;
		}
		#endregion
	}
}