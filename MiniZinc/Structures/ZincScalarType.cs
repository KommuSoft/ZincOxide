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
using ZincOxide.Utils.Designpatterns;
using System.Linq;

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
		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="ZincScalarType"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="ZincScalarType"/>.</returns>
		/// <remarks>
		/// <para>The result is the name of the scalar type (in lower case).</para>
		/// </remarks>
		public override string ToString () {
			return ZincPrintUtils.ScalarLiteral (this.Scalar);
		}
		#endregion
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
		#region IZincIdentReplaceContainer implementation
		/// <summary>
		/// Replaces all the instances stored in the given <see cref="T:IDictionary`1"/>
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
		/// <summary>
		/// Generates a number of error messages that specify what is wrong with this instance.
		/// </summary>
		/// <returns>A <see cref="T:IEumerable`1"/> that contains a list of error messages describing why the instance is invalid.</returns>
		/// <remarks>
		/// <para>If no error messages are generated, the instance is valid, otherwise the instance is invalid.</para>
		/// </remarks>
		public IEnumerable<string> InnerSoftValidate () {
			return EnumerableUtils.Empty<string> ();
		}
		#endregion
		#region IValidateable implementation
		/// <summary>
		/// Checks if the given instance is valid.
		/// </summary>
		/// <returns>True if the instance is valid, otherwise false.</returns>
		public bool Validate () {//TODO: document
			return false;
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
			return EnumerableUtils.Empty<string> ();
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
		public IEnumerable<IZincElement> Children () {
			return EnumerableUtils.Empty<IZincElement> ();
		}
		#endregion
		#region IZincType implementation
		public bool IsSubType (IZincType type) {
			return (!type.Compounded && type.ScalarType == this.ScalarType);
		}
		#endregion
		#region IZincIdentContainer implementation
		/// <summary>
		/// Returns a <see cref="T:IEnumerable`1"/> containing the
		/// involved <see cref="IZincIdent"/> instances of the container.
		/// </summary>
		/// <returns>
		/// A <see cref="T:IEnumerable`1"/> containing the involved
		/// <see cref="IZincIdent"/> instances of the container.
		/// </returns>
		public IEnumerable<IZincIdent> InvolvedIdents () {
			return ZincElementUtils.InvolvedIdents (this);
		}
		#endregion
	}
}