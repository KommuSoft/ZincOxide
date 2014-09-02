//
//  CommandBase.cs
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
	/// A basic implementation of the <see cref="ICommand"/> interface.
	/// </summary>
	/// <remarks>
	/// <para>A command is a unit of computation. Commands can be grouped together or structured in
	/// several conditional statements.</para>
	/// </remarks>
	public abstract class CommandBase {

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="CommandBase"/> class.
		/// </summary>
		public CommandBase () {
		}
		#endregion
	}
}
