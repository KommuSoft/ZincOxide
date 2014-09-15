//
//  ExpressionBase.cs
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
	/// A basic implementation of a <see cref="IExpression"/>, used for programming convenience.
	/// </summary>
	public abstract class ExpressionBase : CommandBase, IExpression {

		#region ICommand implementation
		/// <summary>
		/// Check if this <see cref="ICommand"/> is a <see cref="IExpression"/>, an expression is
		/// a command that returns a value that can be used further in the process.
		/// </summary>
		/// <value><c>true</c> if this <see cref="ICommand"/> is an expression; otherwise, <c>false</c>.</value>
		public override bool IsExpression {
			get {
				return true;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ExpressionBase"/> class.
		/// </summary>
		protected ExpressionBase () {
		}
		#endregion
	}
}

