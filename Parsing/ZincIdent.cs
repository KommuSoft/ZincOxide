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
using System;
using System.Collections.Generic;

namespace ZincOxide.MiniZinc {

	public class ZincIdent : NameBase, IZincIdentContainer {

		public ZincIdent (string name) : base(name) {
		}

		#region IZincIdentContainer implementation
		public IEnumerable<ZincIdent> InvolvedIdents () {
			yield return this;
		}
		public ZincIdent Replace (IDictionary<ZincIdent, ZincIdent> identMap) {
			ZincIdent outp;
			if (identMap.TryGetValue (this, out outp)) {
				return outp;
			} else {
				return this;
			}
		}
		#endregion

		public static IZincIdentContainer Replace<T> (T value, IDictionary<ZincIdent,ZincIdent> identMap) where T : IZincIdentContainer {
			if (value != null) {
				if (value is ZincIdent) {
					ZincIdent zi = value as ZincIdent;
					return Replace (zi, identMap);
				} else {
					value.Replace (identMap);
				}
			}
			return value;
		}

	}

}