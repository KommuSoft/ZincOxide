//
//  ProcedureMembersBase.cs
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
using ZincOxide.Codegen.Abstract.Imperative;
using System.Collections.Generic;
using ZincOxide.Utils.Abstract;
using ZincOxide.Codegen.Abstract.Typed;

namespace ZincOxide.Codegen.Abstract.OO {

	/// <summary>
	/// A basic implementation of the <see cref="IProcedureMember"/> interface.
	/// </summary>
	public abstract class ProcedureMemberBase : NameShadow, IProcedureMember {

		#region ITypeMember implementation
		/// <summary>
		/// The type that contains this <see cref="ITypeMember"/>.
		/// </summary>
		/// <value>A <see cref="IType"/> that contains this <see cref="ITypeMember"/>.</value>
		public IType TypeContainer {
			get;
			private set;
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ProcedureMemberBase"/> class.
		/// </summary>
		/// <param name="typeContainer">A <see cref="IType"/> that contains this <see cref="ProcedureMemberBase"/>.</param>
		protected ProcedureMemberBase (IType typeContainer) {
			this.TypeContainer = typeContainer;
		}
		#endregion
		#region IProcedureMember implementation
		/// <summary>
		/// Reimplement the procedure member with the given <paramref name="commands"/>.
		/// </summary>
		/// <param name="commands">The list of commands that are the implementation of
		/// the <see cref="IProcedureMember"/>.</param>
		/// <remarks>
		/// <para>if the given <paramref name="commands"/> is not effective, no modifications
		/// is done to the method.</para>
		/// </remarks>
		public abstract void Reimplement (ICommand commands);
		#endregion
	}
}

