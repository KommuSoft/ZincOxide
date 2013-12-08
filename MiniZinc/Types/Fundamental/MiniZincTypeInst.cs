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
using System.Collections.Generic;
using System.Linq;

namespace ZincOxide.MiniZinc.Types.Fundamental {

	public class MiniZincTypeInst : IMiniZincTypeInst {
		/// <summary>
		/// The default instantiation of a fundamental type instance. Given if no instantiation is given.
		/// </summary>
		public const ZincVarPar DefaultInstantiation = ZincVarPar.Par;
		private ZincVarPar instantiation;
		private IMiniZincType typePart;

		/// <summary>
		/// The instantiation of the fundamental type instance.
		/// </summary>
		/// <value>The instantiation of the fundamental type instance.</value>
		public ZincVarPar Instantiation {
			get {
				return this.instantiation;
			}
			private set {
				this.instantiation = value;
			}
		}

		/// <summary>
		/// The type of the fundamental type instance.
		/// </summary>
		/// <value>The type of the fundamental type instance.</value>
		/// <exception cref="ArgumentNullException">If the <paramref name="value"/> is not effective.</exception>
		/// <exception cref="ArgumentException">If the given type contains varified types and the type is
		/// specified as a parameter type.</exception>
		public IMiniZincType Type {
			get {
				return this.typePart;
			}
			private set {
				if (value == null) {
					throw new ArgumentNullException ("value", "The type of a type-instance must be effective.");
				} else if (this.Instantiation == ZincVarPar.Par && value.GetDependingTypes ().Any (x => x.Instantiation == ZincVarPar.Var)) {
					throw new ArgumentException ("If the instantiation is a parameterized, no subtypes can be varified.");
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
		public MiniZincTypeInst (ZincVarPar instantiation, IMiniZincType type) {
			this.Instantiation = instantiation;
			this.Type = type;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.MiniZinc.Types.Fundamental.ZincFundamentalTypeInst"/> class with
		/// a specified fundamental type.
		/// </summary>
		/// <param name="type">The type of the type-instance.</param>
		/// <exception cref="ArgumentNullException">If <paramref name="type"/> is not effective.</exception>
		public MiniZincTypeInst (IMiniZincType type) : this (DefaultInstantiation, type) {
		}

		#region IZincFundamentalTypeInst implementation

		public bool CanVarify (IMiniZincTypeInst other) {
			throw new NotImplementedException ();
		}

		public bool CanCoerce (IMiniZincTypeInst other) {
			throw new NotImplementedException ();
		}

		#endregion

		#region IGenericEquals implementation

		public bool GenericEquals (IMiniZincType other) {
			throw new NotImplementedException ();
		}

		#endregion

		public IEnumerable<IMiniZincTypeInst> GetDependingTypes () {
			return this.Type.GetDependingTypes ();
		}
	}
}

