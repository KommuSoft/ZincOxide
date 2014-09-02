//
//  ITypeContract.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2014 Willem Van Onsem
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
using System.Diagnostics.Contracts;
using ZincOxide.Utils.Abstract;

namespace ZincOxide.Codegen.Abstract.OO {

	/// <summary>
	/// A contract class for a <see cref="IType"/>, an interface describing a type in the object-oriented programming
	/// paradigm.
	/// </summary>
	[ContractClassFor(typeof(IType))]
	public class TypeContract : NameShadow, IType {

		#region IName implementation
		/// <summary>
		/// Get the name of the type.
		/// </summary>
		/// <value>The name of the type.</value>
		public override string Name {
			get {
				Contract.Ensures (Contract.Result<string> () != null);
				return default(string);
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="TypeContract"/> class.
		/// </summary>
		protected TypeContract () {
		}
		#endregion
	}
}

