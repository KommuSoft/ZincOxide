//
//  CommandSequenceContract.cs
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
using System.Collections.Generic;

namespace ZincOxide.Codegen.Abstract.Imperative {

	/// <summary>
	/// A contract class for <see cref="ICommandSequence"/> instances.
	/// </summary>
	[ContractClassForAttribute(typeof(ICommandSequence))]
	public abstract class CommandSequenceContract : CommandContract, ICommandSequence {

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="CommandSequenceContract"/> class.
		/// </summary>
		protected CommandSequenceContract () {
			Contract.Ensures (Contract.ForAll (this, x => x != null));
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
			Contract.Ensures (Contract.Result<IEnumerator<ICommand>> () != null);
			return default(IEnumerator<ICommand>);
		}
		#endregion
		#region IEnumerable implementation
		/// <summary>
		/// Enumerate all the items, accessed through the <see cref="T:System.Collections.IEnumerable"/> interface.
		/// </summary>
		/// <returns>All the items enumerated by <see cref="M:GetEnumerator"/>, but ungeneric.</returns>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator () {
			Contract.Ensures (Contract.Result<System.Collections.IEnumerator> () != null);
			return default(System.Collections.IEnumerator);
		}
		#endregion
	}
}

