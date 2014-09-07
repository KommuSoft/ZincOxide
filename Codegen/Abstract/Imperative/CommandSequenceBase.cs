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
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

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
		/// <para><c>null</c> values in the given <paramref name="commands"/> list will not be added to this <see cref="CommandSequenceBase"/>.</para>
		/// </remarks>
		public CommandSequenceBase (IEnumerable<ICommand> commands) {
			if (commands != null) {
				this.CommandList = new LinkedList<ICommand> (commands.SelectMany (deployCommands));
			}
			Contract.Ensures (this.CommandList != null);
		}
		#endregion
		#region Private methods
		/// <summary>
		/// A method that deploys the given <see cref="ICommand"/>.
		/// </summary>
		/// <returns>A list of <see cref="ICommand"/> instances that are equivalent to the given <see cref="ICommand"/> .</returns>
		/// <param name="command">The given <see cref="ICommand"/> to deploy.</param>
		/// <remarks>
		/// <para>By deploying, all <c>null</c> references are removed, if the command is a <see cref="ICommandSequence"/>
		/// the list of <see cref="ICommand"/> instances is returned (this is performed recursively).</para>
		/// </remarks>
		private static IEnumerable<ICommand> deployCommands (ICommand command) {
			if (command != null) {
				ICommandSequence ics = command as ICommandSequence;
				if (ics != null) {
					foreach (ICommand cmd in ics.SelectMany (deployCommands)) {
						yield return cmd;
					}
				} else {
					yield return ics;
				}
			}
		}
		#endregion
		#region IEnumerable implementation
		/// <summary>
		/// Enumerate all the commands that are stored in this <see cref="CommandSequenceBase"/>.
		/// </summary>
		/// <returns>A <see cref="T:IEnumerator`1"/> that emits all the <see cref="ICommand"/> instances stored in this <see cref="CommandSequenceBase"/>.</returns>
		/// <remarks>
		/// <para>It is guaranteed that no <c>null</c> pointers will be enumerated.</para>
		/// </remarks>
		public IEnumerator<ICommand> GetEnumerator () {
			return this.CommandList.GetEnumerator ();
		}
		#endregion
		#region IEnumerable implementation
		/// <summary>
		/// Enumerate all the items, accessed through the <see cref="T:System.Collections.IEnumerable"/> interface.
		/// </summary>
		/// <returns>All the items enumerated by <see cref="M:GetEnumerator"/>, but ungeneric.</returns>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator () {
			return this.GetEnumerator ();
		}
		#endregion
	}
}

