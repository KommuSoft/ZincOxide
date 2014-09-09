//
//  IAssignmentCommand.cs
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

namespace ZincOxide.Codegen.Abstract.Imperative {

	/// <summary>
	/// A command that assigns the result of a given expression to a given variable.
	/// </summary>
	[ContractClass(typeof(AssignmentCommandContract))]
	public interface IAssignmentCommand : ICommand {

		/// <summary>
		/// The variable to which the result of the <see cref="Expression"/> will be assigned.
		/// </summary>
		/// <value>A <see cref="IVariable"/> representing the variable to which the result of the <see cref="Expression"/> will
		/// be assigned.</value>
		/// <remarks>
		/// <para>The variable is guaranteed to be effective.</para>
		/// </remarks>
		IVariable Variable {
			get;
		}

		/// <summary>
		/// The expression that determines the value that will be assigned.
		/// </summary>
		/// <value>A <see cref="IExpression"/> that determines the value that will be assigned to the <see cref="Variable"/>.</value>
		/// <remarks>
		/// <para>The expression is guaranteed to be effective.</para>
		/// </remarks>
		IExpression Expression {
			get;
		}
	}
}

