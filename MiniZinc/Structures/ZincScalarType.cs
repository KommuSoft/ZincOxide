//
//  ZincScalarType.cs
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

	public sealed class ZincScalarType : IZincType {

		private readonly ZincScalar scalar;

		public ZincScalar Scalar {
			get {
				return this.scalar;
			}
		}
		#region IFinite implementation
		public bool Finite {
			get {
				return this.Scalar == ZincScalar.Bool;
			}
		}
		#endregion
		#region IZincType implementation
		public bool Compounded {
			get {
				return false;
			}
		}

		public ZincScalar ScalarType {
			get {
				return this.scalar;
			}
		}
		#endregion
		public ZincScalarType (ZincScalar scalar) {
			this.scalar = scalar;
		}

		public override string ToString () {
			return ZincPrintUtils.ScalarLiteral (this.Scalar);
		}

		public static implicit operator ZincScalarType (ZincScalar scalar) {
			return new ZincScalarType (scalar);
		}

		public override int GetHashCode () {
			return this.scalar.GetHashCode ();
		}

		public override bool Equals (object obj) {
			if (obj is ZincScalarType) {
				ZincScalarType zst = obj as ZincScalarType;
				return (this.scalar == zst.scalar);
			}
			return false;
		}
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
			yield break;
		}
		#endregion
		#region IZincIdentReplaceContainer implementation
		public IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap) {
			return this;
		}
		#endregion
		#region IInnerSoftValidateable implementation
		public IEnumerable<string> InnerSoftValidate () {
			return EnumerableUtils.Empty<string> ();
		}
		#endregion
		#region IValidateable implementation
		public bool Validate () {
			return false;
		}
		#endregion
		#region ISoftValidateable implementation
		public IEnumerable<string> SoftValidate () {
			return EnumerableUtils.Empty<string> ();
		}
		#endregion
		#region IComposition implementation
		public IEnumerable<IZincElement> Children () {
			return EnumerableUtils.Empty<IZincElement> ();
		}
		#endregion
		#region IZincType implementation
		public bool IsSubType (IZincType type) {
			return (!type.Compounded && type.ScalarType == this.ScalarType);
		}
		#endregion
	}
}