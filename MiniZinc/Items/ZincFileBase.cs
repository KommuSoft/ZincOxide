//
//  ZincFileBase.cs
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
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Items {

	public abstract class ZincFileBase : ZincIdentScopeBase, IZincFile {

        #region IZincFile implementation
		public abstract IEnumerable<IZincItem> Items {
			get;
		}
        #endregion

		protected ZincFileBase (ZincIdentNameRegister nameRegister = null) : base(nameRegister) {
		}

        #region IValidateable implementation
		public bool Validate () {
			return ValidateableUtils.Validate (this);
		}
        #endregion

        #region IWriteable implementation
		public abstract void Write (TextWriter writer);
        #endregion

        #region IZincIdentContainer implementation
		public abstract IEnumerable<IZincIdent> InvolvedIdents ();
        #endregion

        #region IZincIdentReplaceContainer implementation
		public abstract IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap);
        #endregion

        #region ISoftValidateable implementation
		public abstract IEnumerable<string> SoftValidate ();
        #endregion

        #region IZincFile implementation
		public abstract void AddItem (IZincItem item);

		public abstract void AddItems (IEnumerable<IZincItem> items);
        #endregion

	}

}

