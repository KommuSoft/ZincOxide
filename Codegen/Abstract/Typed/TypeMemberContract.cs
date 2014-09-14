//
//  TypeMemberContract.cs
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

namespace ZincOxide.Codegen.Abstract.Typed {

	/// <summary>
	/// A contract class for <see cref="ITypeMember"/> instances.
	/// </summary>
	[ContractClassFor(typeof(ITypeMember))]
	public abstract class TypeMemberContract : ITypeMember {

		#region ITypeMember implementation
		/// <summary>
		/// The type that contains this <see cref="ITypeMember"/>.
		/// </summary>
		/// <value>A <see cref="IType"/> that contains this <see cref="ITypeMember"/>.</value>
		public IType TypeContainer {
			get {
				return default(IType);
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="TypeMemberContract"/> class.
		/// </summary>
		protected TypeMemberContract () {
		}
		#endregion
	}
}

