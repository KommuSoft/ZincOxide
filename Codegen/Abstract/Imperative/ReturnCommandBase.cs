//
//  ReturnCommandBase.cs
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

namespace ZincOxide.Codegen.Abstract.Imperative {

	/// <summary>
	/// A command that returns an expression as result of a procedure or program.
	/// </summary>
	public class ReturnCommandBase : CommandBase, IReturnCommand {

		#region IReturnCommand implementation
		/// <summary>
		/// Get the expression that will be returned.
		/// </summary>
		/// <value>The expression that determines the value to be returned.</value>
		public IExpression Expression {
			get;
			private set;
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ReturnCommandBase"/> class with the given
		/// expression to be returned.
		/// </summary>
		/// <param name="expression">The expression to be returned by the command.</param>
		public ReturnCommandBase (IExpression expression) {
			this.Expression = expression;
		}
		#endregion
	}
}

