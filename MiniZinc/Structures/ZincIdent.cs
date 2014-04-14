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
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Structures {

	public class ZincIdent : NameIdBase, IZincIdent {

		private ZincIdentUsage usage;

		public ZincIdentUsage Usage {
			get {
				return this.usage;
			}
			set {
				this.usage = value;
			}
		}

		public ZincIdent (string name, ZincIdentUsage usage = ZincIdentUsage.Unknown) : base(name) {
			this.Usage = usage;
		}

        #region IZincIdentContainer implementation
		public IEnumerable<IZincIdent> InvolvedIdents () {
			yield return this;
		}
        #endregion

		#region IZincIdentReplaceContainer implementation
		public IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap) {
			IZincIdent outp;
			if (identMap.TryGetValue (this, out outp)) {
				return outp;
			} else {
				return this;
			}
		}
		#endregion

		public string ToBindString () {
			return string.Format ("{0}&{1}", this.Name, this.Id);
		}

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
		public IEnumerable<IZincElement> Children () {
			yield break;
		}
        #endregion












	}

}