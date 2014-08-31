//
//  ZincNumExpLiteralBase.cs
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
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Structures {

	public class ZincNumExpLiteralBase : IZincNumExp {

		#region Constructors
		protected ZincNumExpLiteralBase () {
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
		public virtual IEnumerable<string> InnerSoftValidate () {
			yield break;
		}
		#endregion
		#region IValidateable implementation
		/// <summary>
		/// Checks if the given instance is valid.
		/// </summary>
		/// <returns>True if the instance is valid, otherwise false.</returns>
		public bool Validate () {//TODO: document
			return ValidateableUtils.Validate (this);
		}
		#endregion
		#region ISoftValidateable implementation
		/// <summary>
		/// Enumerates a list of error messages specifying why the instance is not valid.
		/// </summary>
		/// <returns>A <see cref="T:IEnumerable`1"/> containing the error messages describing why the instance is not valid.</returns>
		/// <remarks>
		/// <para>If no error messages are emitted, the instance is valid, otherwise the instance is invalid.</para>
		/// </remarks>
		public IEnumerable<string> SoftValidate () {
			return ValidateableUtils.CompositionInnerSoftValidate<IZincElement,IZincElement> (this);
		}
		#endregion
		#region IComposition implementation
		/// <summary>
		/// Gets a list of involved <see cref="IZincElement"/> instances that are the children of
		/// this <see cref="IZincElement"/>.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> instance of
		/// <see cref="IZincElement"/> that are the childrens of this <see cref="IZincElement"/> instance.
		/// </returns>
		public virtual IEnumerable<IZincElement> Children () {
			yield break;
		}
		#endregion
		#region IZincIdentReplaceContainer implementation
		/// <summary>
		/// Replaces all the instances stored in the given <see cref="T:IDictionary`2"/>
		/// stored as keys to the corresponding values and returns this instance, possibly if this is an
		/// <see cref="IZincIdent"/> itself another <see cref="IZincIdent"/>.
		/// </summary>
		/// <returns>
		/// If this instance is a compound type, a reference to itself. Otherwise a <see cref="IZincIdent"/> if
		/// this instance is a <see cref="IZincIdent"/> itself.
		/// </returns>
		public virtual IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap) {
			return this;
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
		public virtual IEnumerable<IZincIdent> InvolvedIdents () {
			return ZincElementUtils.InvolvedIdents (this);
		}
		#endregion
	}
}

