//
//  ZincCompoundType.cs
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

namespace ZincOxide {

	public class ZincCompoundType : ZincType {

		private ZincCompound compound;
		private ZincType innerType;

		public ZincCompound Compound {
			get {
				return compound;
			}
			set {
				compound = value;
			}
		}

		public ZincType InnerType {
			get {
				return innerType;
			}
			set {
				if (value == null) {
					throw new ArgumentException ("InnerType must be effective.", "InnerType");
				} else {
					ZincType cur = value;
					while (cur != this && cur != null && (cur is ZincCompoundType)) {
						ZincCompoundType czt = (ZincCompoundType)cur;
						cur = czt.InnerType;
					}
					if (cur == this) {
						throw new ArgumentException ("Innertypes cannot be cyclic.", "InnerType");
					}
					innerType = value;
				}
			}
		}

		public ZincCompoundType (ZincCompound compound, ZincType innerType) {
			this.Compound = compound;
			this.InnerType = innerType;
		}

		public override string ToString () {
			return string.Format ("{0}({1})", this.Compound, this.InnerType);
		}

		public override int GetHashCode () {
			int hash = 0x02 * this.compound.GetHashCode () + 0x05;
			return hash ^ (hash * this.innerType.GetHashCode ());
		}

		public override bool Equals (object obj) {
			if (obj is ZincCompoundType) {
				ZincCompoundType zct = (ZincCompoundType)obj;
				return Object.Equals (this.Compound, zct.Compound) && Object.Equals (this.InnerType, zct.InnerType);
			} else {
				return false;
			}
		}

	}
}

