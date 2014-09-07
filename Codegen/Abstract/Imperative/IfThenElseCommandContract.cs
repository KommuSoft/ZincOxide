//
//  IfThenElseCommandContract.cs
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
	/// A contract class for the <see cref="IIfThenElseCommand"/>.
	/// </summary>
	[ContractClassFor(typeof(IIfThenElseCommand))]
	public abstract class IfThenElseCommandContract : CommandContract, IIfThenElseCommand {

		#region IIfThenElseCommand implementation
		/// <summary>
		/// The condition that must be checked and determines which command will be executed.
		/// </summary>
		/// <value>The condition that determines which command will be executed.</value>
		public ICondition Condition {
			get {
				Contract.Ensures (Contract.Result<ICondition> () != null);
				return default(ICondition);
			}
		}

		/// <summary>
		/// The command that must be executed if the condition succeeds.
		/// </summary>
		/// <value>An <see cref="ICommand"/> that is executed if the <see cref="Condition"/> holds.</value>
		public ICommand TrueCommand {
			get {
				Contract.Ensures (Contract.Result<ICommand> () != null);
				return default(ICommand);
			}
		}

		/// <summary>
		/// The command that must be executed if the condition fails.
		/// </summary>
		/// <value>An <see cref="ICommand"/> that is executed if the <see cref="Condition"/> fails.</value>
		public ICommand FalseCommand {
			get {
				Contract.Ensures (Contract.Result<ICommand> () != null);
				return default(ICommand);
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="IfThenElseCommandContract"/> class.
		/// </summary>
		protected IfThenElseCommandContract () {
		}
		#endregion
	}
}

