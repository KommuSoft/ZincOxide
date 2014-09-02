//
//  COmmandSequenceBase.cs
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
using System.Collections.Generic;

namespace ZincOxide.Codegen.Abstract.Imperative {

	/// <summary>
	/// A basic implementation of the <see cref="ICommandSequence"/> interface.
	/// </summary>
	public class CommandSequenceBase : CommandBase, ICommandSequence {

		#region Fields
		/// <summary>
		/// A <see cref="T:LinkedList`1"/> that contains the list of commands stored in this <see cref="CommandSequenceBase"/>.
		/// </summary>
		protected readonly LinkedList<ICommand> CommandList = new LinkedList<ICommand> ();
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="CommandSequenceBase"/> class with a given list of commands.
		/// </summary>
		/// <param name="commands">The list of commands that are stored in this <see cref="CommandSequenceBase"/></param>
		/// <remarks>
		/// <para>The commands are flatten out: if one of the commands is a <see cref="ICommandSequence"/>, the commands
		/// are unrolled and stored as single units in this <see cref="CommandSequenceBase"/>.</para>
		/// </remarks>
		public CommandSequenceBase (params ICommand[] commands) : this((IEnumerable<ICommand>) commands) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CommandSequenceBase"/> class with a given list of commands.
		/// </summary>
		/// <param name="commands">The list of commands that are stored in this <see cref="CommandSequenceBase"/></param>
		/// <remarks>
		/// <para>The commands are flatten out: if one of the commands is a <see cref="ICommandSequence"/>, the commands
		/// are unrolled and stored as single units in this <see cref="CommandSequenceBase"/>.</para>
		/// </remarks>
		public CommandSequenceBase (IEnumerable<ICommand> commands) {

		}
		#endregion
	}
}

