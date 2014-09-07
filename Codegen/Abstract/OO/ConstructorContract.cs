//
//  ConstructorContract.cs
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
using ZincOxide.Codegen.Abstract.Imperative;
using System.Collections.Generic;

namespace ZincOxide.Codegen.Abstract.OO {

	/// <summary>
	/// A contract class for <see cref="IConstructor"/> instances.
	/// </summary>
	[ContractClassFor(typeof(IConstructor))]
	public abstract class ConstructorContract : ProcedureMemberContract, IConstructor {

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ConstructorContract"/> class.
		/// </summary>
		protected ConstructorContract () {
		}
		#endregion
		#region IConstructor implementation
		/// <summary>
		/// Generate a command that creates a new instance of a type using this <see cref="IConstructor"/>.
		/// </summary>
		/// <returns>A <see cref="IExpression"/> that represents a call to this <see cref="IConstructor"/> with the given <paramref name="parameters"/>.</returns>
		/// <param name="parameters">The given list of expressions with which the call is initialized.</param>
		public IExpression CallCommand (params IExpression[] parameters) {
			Contract.Ensures (Contract.Result<IExpression> () != null);
			return default(IExpression);
		}

		/// <summary>
		/// Generate a command that creates a new instance of a type using this <see cref="IConstructor"/>.
		/// </summary>
		/// <returns>A <see cref="IExpression"/> that represents a call to this <see cref="IConstructor"/> with the given <paramref name="parameters"/>.</returns>
		/// <param name="parameters">The given list of expressions with which the call is initialized.</param>
		public IExpression CallCommand (IEnumerable<IExpression> parameters) {
			Contract.Ensures (Contract.Result<IExpression> () != null);
			return default(IExpression);
		}
		#endregion
	}
}

