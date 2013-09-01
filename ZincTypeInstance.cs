//
//  ZincTypeInstance.cs
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

namespace ZincOxide.MiniZinc {

	public struct ZincTypeInstance {

		private ulong data;

		public ulong Data {
			get {
				return this.data;
			}
		}

		public ZincType ZincType {
			get {
				return new ZincType (this.Data & 0x7fffffffffffffff);
			}
		}

		public ZincInstance ZincInstance {
			get {
				return (ZincInstance)(this.data >> 0x3f);
			}
		}

		public ZincTypeInstance (ZincInstance instance, ZincType type) {
			this.data = (((ulong)instance) << 0x3f) | type.Data;
		}

		public ZincTypeInstance (ZincType type, ZincInstance instance = ZincInstance.Parameter) : this(instance,type) {
		}

		public static ZincTypeInstance Varifiable (ZincTypeInstance input) {
			return new ZincTypeInstance (ZincInstance.Variable, input.ZincType);
		}

		/*public static ZincTypeInstance Coercions (ZincTypeInstance input) {
			return null;
		}*/

		public static ZincTypeInstance operator ! (ZincTypeInstance input) {
			return Varifiable (input);
		}

	}

}