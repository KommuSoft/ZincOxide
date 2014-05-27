//
//  ZincIncludeItem.cs
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
using System.IO;
using ZincOxide.MiniZinc.Structures;
using ZincOxide.Utils.Abstract;
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Items {

	/// <summary>
	/// A <see cref="IZincItem"/> that is used to include packages that define functions, etc. in other <see cref="IZincFile"/> instances.
	/// </summary>
	public class ZincIncludeItem : NameBase, IZincItem {

		#region IZincItem implementation
		/// <summary>
		/// Gets the type of the <see cref="IZincItem"/>.
		/// </summary>
		/// <value>The type of the <see cref="IZincItem"/>.</value>
		/// <remarks>
		/// <para>This property is mainly used to filter without the use
		/// of harmful object oriented structures and to prevent users from inventing more items.</para>
		/// <para>The type of a <see cref="ZincIncludeItem"/> is <see cref="ZincItemType.Include"/>.</para>
		/// </remarks>
		public ZincItemType Type {
			get {
				return ZincItemType.Include;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincIncludeItem"/> class with the given name of the included zinc file.
		/// </summary>
		/// <param name="name">The given name of the included zinc file.</param>
		public ZincIncludeItem (string name) : base(name) {
		}
		#endregion
		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="ZincIncludeItem"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="ZincIncludeItem"/>.</returns>
		/// <remarks>
		/// <para>The format of this method is <c>include "name"</c> where the name is the name of the included zinc file.</para>
		/// </remarks>
		public override string ToString () {
			return string.Format ("include {0}", ZincPrintUtils.StringLiteral (this.Name));
		}
		#endregion
		#region IWriteable implementation
		/// <summary>
		/// Writes a textual representation of this <see cref="ZincIncludeItem"/> to the given <see cref="TextWriter"/>.
		/// </summary>
		/// <param name="writer">The given <see cref="TextWriter"/> to write the content of this <see cref="ZincIncludeItem"/> to.</param>
		public void Write (TextWriter writer) {
			writer.Write (this.ToString ());
		}
		#endregion
		#region IZincIdentContainer implementation
		/// Returns a <see cref="T:System.Collections.Generic.IEnumerable`1"/> containing the involved
		/// <see cref="IZincIdent"/> instances of the container.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerable`1"/> containing the involved\
		/// <see cref="IZincIdent"/> instances of the container.
		/// </returns>
		public IEnumerable<IZincIdent> InvolvedIdents () {
			yield break;
		}
		#endregion
		#region IZincIdentReplaceContainer implementation
		/// Replaces all the instances stored in the given <see cref="System.Collections.Generic.IDictionary`1"/>
		/// stored as keys to the corresponding values and returns this instance, possibly if this is an
		/// <see cref="IZincIdent"/> itself another <see cref="IZincIdent"/>.
		/// </summary>
		/// <returns>
		/// If this instance is a compound type, a reference to itself. Otherwise a <see cref="IZincIdent"/> if
		/// this instance is a <see cref="IZincIdent"/> itself.
		/// </returns>
		public IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap) {
			return this;
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
		/// Generates a number of error messages that specify what is wrong with this instance.
		/// </summary>
		/// <returns>A <see cref="T:IEumerable`1"/> that contains a list of error messages describing why the instance is invalid.</returns>
		/// <remarks>
		/// <para>If no error messages are generated, the instance is valid, otherwise the instance is invalid.</para>
		/// </remarks>
		public IEnumerable<string> SoftValidate () {
			return ValidateableUtils.CompositionInnerSoftValidate<IZincElement,IZincElement> (this);
		}
		#endregion
		#region IComposition implementation
		public IEnumerable<IZincElement> Children () {
			yield break;
		}
		#endregion
	}
}

