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

		protected ZincNumExpLiteralBase () {
		}
		#region IInnerSoftValidateable implementation
		public virtual IEnumerable<string> InnerSoftValidate () {
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
		public virtual IEnumerable<IZincElement> Children () {
			yield break;
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
		public virtual IEnumerable<IZincIdent> InvolvedIdents () {
			yield break;
		}
		#endregion
		#region IZincIdentReplaceContainer implementation
		public virtual IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap) {
			return this;
		}
		#endregion
	}
}

