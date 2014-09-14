//
//  IMethod.cs
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
using ZincOxide.Utils.Abstract;
using System.Diagnostics.Contracts;
using ZincOxide.Codegen.Abstract.Imperative;
using System.Collections.Generic;
using ZincOxide.Codegen.Abstract.Typed;

namespace ZincOxide.Codegen.Abstract.OO {

	/// <summary>
	/// An interface describing a method in the object-oriented programming paradigm.
	/// </summary>
	/// <remarks>
	/// A method computes something (based on the state of the instance over which it is defined),
	/// alters the state of an object, or both.
	/// </remarks>
	[ContractClass(typeof(MethodContract))]
	public interface IMethod : IProcedureMember {

		/// <summary>
		/// Generate a class command that can be used as part of a procedure implementation.
		/// </summary>
		/// <returns>A <see cref="ICommand"/> that represents a call to this <see cref="IMethod"/> with the given <paramref name="parameters"/>.</returns>
		/// <param name="instance">The instance on which the command is applied.</param>
		/// <param name="parameters">The given list of expressions with which the call is initialized.</param>
		ICommand CallCommand (IExpression instance, params IExpression[] parameters);

		/// <summary>
		/// Generate a class command that can be used as part of a procedure implementation.
		/// </summary>
		/// <returns>A <see cref="ICommand"/> that represents a call to this <see cref="IMethod"/> with the given <paramref name="parameters"/>.</returns>
		/// <param name="instance">The instance on which the command is applied.</param>
		/// <param name="parameters">The given list of expressions with which the call is initialized.</param>
		ICommand CallCommand (IExpression instance, IEnumerable<IExpression> parameters);
	}
}

