//
//  ZincType.cs
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
using System.Text;

namespace ZincOxide.MiniZinc {

	public struct ZincType {

		private ulong data;

		public int Depth {
			get {
				ulong cur = this.data / 0x03;
				int depth = 0x00;
				while (cur > 0x00) {
					depth++;
					cur /= 0x03;
				}
				return depth;
			}
		}

		public bool IsScalar {
			get {
				return (this.data / 0x03) == 0x00;
			}
		}

		public bool IsCompound {
			get {
				return !this.IsScalar;
			}
		}

		public bool IsFinite {
			get {
				return (this.IsScalar && this.Scalar == ZincScalar.Boolean) || (this.IsCompound && this.InnerType.IsFinite);
			}
		}

		public ulong Data {
			get {
				return this.data;
			}
		}

		public ZincScalar Scalar {
			get {
				return (ZincScalar)(this.data % 0x03);
			}
		}

		public ZincType InnerType {
			get {
				ulong val = this.data % 0x03;
				ulong sub = (this.data - val) / 0x03;
				sub -= sub % 0x03;
				return new ZincType (val + sub);
			}
		}

		public ZincCompound OuterCompound {
			get {
				return (ZincCompound)((this.data / 0x03) % 0x03);
			}
		}

		public ZincType (ulong data) {
			this.data = data;
		}

		public ZincType (ZincScalar scalar) {
			this.data = (byte)scalar;
		}

		public ZincType (ZincCompound compound, ZincScalar scalar) {
			this.data = (ulong)(0x03 * (byte)compound + (byte)scalar);
		}

		public ZincType (ZincCompound compound, ZincType type) {
			ulong low = type.data % 0x03;
			this.data = low + 0x03 * (type.data - low + (byte)compound);
		}

		public override bool Equals (object obj) {
			if (obj is ZincType) {
				return ((ZincType)obj).data == this.data;
			} else {
				return false;
			}
		}

		public override int GetHashCode () {
			return this.data.GetHashCode ();
		}

		public override string ToString () {
			StringBuilder sb = new StringBuilder ();
			ulong val = data;
			ulong inner = val % 0x03;
			val /= 0x03;
			int depth = 0x00;
			while (val > 0x00) {
				ulong digit = val % 0x03;
				sb.Append ((ZincCompound)digit);
				sb.Append ('[');
				val /= 0x03;
				depth++;
			}
			sb.Append ((ZincScalar)(inner));
			for (; depth > 0x00; depth--) {
				sb.Append (']');
			}
			return sb.ToString ();
		}

		public static implicit operator ZincType (ZincScalar scalar) {
			return new ZincType (scalar);
		}

		public static ZincType operator & (ZincCompound compound, ZincType innerType) {
			return new ZincType (compound, innerType);
		}

		public static ZincTypeInstance operator & (ZincInstance instance, ZincType zinctype) {
			return new ZincTypeInstance (instance, zinctype);
		}

	}
}

