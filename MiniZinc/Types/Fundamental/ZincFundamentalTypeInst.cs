//
//  ZincFundamentalTypeInst.cs
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

namespace ZincOxide.MiniZinc.Types.Fundamental {

	public class ZincFundamentalTypeInst : IZincFundamentalTypeInst {
		public const ZincVarPar DefaultInstantiation = ZincVarPar.Par;
		private ZincVarPar instantiation;
		private IZincFundamentalType typePart;

		public ZincVarPar Instantiation {
			get {
				return this.instantiation;
			}
			set {
				this.instantiation = value;
			}
		}

		public IZincFundamentalType Type {
			get {
				return this.typePart;
			}
			set {
				if (value == null) {
					throw new ArgumentNullException ("value", "The type of a type-instance must be effective.");
				} else {
					this.typePart = value;
				}
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.MiniZinc.Types.Fundamental.ZincFundamentalTypeInst"/> class with a specified
		/// instantiation and fundamental type.
		/// </summary>
		/// <param name="instantiation">The instantiation of the type-instance.</param>
		/// <param name="type">The type of the type-instance.</param>
		/// <exception cref="ArgumentNullException">If <paramref name="type"/> is not effective.</exception>
		public ZincFundamentalTypeInst (ZincVarPar instantiation, IZincFundamentalType type) {
			this.Instantiation = instantiation;
			this.Type = type;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.MiniZinc.Types.Fundamental.ZincFundamentalTypeInst"/> class with
		/// a specified fundamental type.
		/// </summary>
		/// <param name="type">The type of the type-instance.</param>
		/// <exception cref="ArgumentNullException">If <paramref name="type"/> is not effective.</exception>
		public ZincFundamentalTypeInst (IZincFundamentalType type) : this (DefaultInstantiation, type) {
		}
		/*public static ZincFundamentalTypeInst operator & (ZincVarPar instantiation, IZincFundamentalType type) {
			return new ZincFundamentalTypeInst (instantiation, type);
		}*/

		#region IZincFundamentalTypeInst implementation

		public bool CanVarify (IZincFundamentalTypeInst other) {
			throw new NotImplementedException ();
		}

		public bool CanCoerce (IZincFundamentalTypeInst other) {
			throw new NotImplementedException ();
		}

		#endregion

		#region IGenericEquals implementation

		public bool GenericEquals (IZincFundamentalType other) {
			throw new NotImplementedException ();
		}

		#endregion

	}
}

