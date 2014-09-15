//
//  ConstructorReference.cs
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
using System.Reflection;
using ZincOxide.Codegen.Abstract.OO;
using System.Diagnostics.Contracts;
using System.CodeDom;

namespace ZincOxide.Codegen.Languages.CSharp {

	/// <summary>
	/// A reference to a predefined constructor in C#.
	/// </summary>
	public class ConstructorReference : ConstructorBase {

		#region Fields
		private readonly ConstructorInfo data;
		#endregion
		#region implemented abstract members of NameShadow
		/// <summary>
		/// Gets the name of this constructor.
		/// </summary>
		/// <value>The name of this constructor.</value>
		public override string Name {
			get {
				return data.Name;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Constructor"/> class with a given <see cref="ConstructorInfo"/>
		/// containing the specifications of the constructor.
		/// </summary>
		/// <param name="data">A <see cref="ConstructorInfo"/> specifying the constructor.</param>
		/// <param name="typeContainer">A <see cref="ICSharpType"/> that represents the type of which this <see cref="IConstructor"/> can create instances.</param>
		/// <exception cref="ArgumentNullException">If the given <paramref name="typeContainer"/> is not effective.</exception>
		internal ConstructorReference (ICSharpType typeContainer, ConstructorInfo data) : base(typeContainer) {
			if (typeContainer == null) {
				throw new ArgumentNullException ("typeContainer");
			}
			Contract.EndContractBlock ();
			this.data = data;
		}
		#endregion
		#region implemented abstract members of ProcedureMemberBase
		/// <summary>
		/// Reimplement the procedure member with the given <paramref name="commands"/>.
		/// </summary>
		/// <param name="commands">The list of commands that are the implementation of
		/// the <see cref="IProcedureMember"/>.</param>
		/// <remarks>
		/// <para>if the given <paramref name="commands"/> is not effective, no modifications
		/// is done to the method.</para>
		/// <para>Predefined constructor cannot be reimplemented, the method call is ignored.</para>
		/// </remarks>
		public override void Reimplement (ICommand commands) {
		}
		#endregion
		#region implemented abstract members of ConstructorBase
		/// <summary>
		/// Generate a command that creates a new instance of a type using this <see cref="IConstructor"/>.
		/// </summary>
		/// <returns>A <see cref="IExpression"/> that represents a call to this <see cref="IConstructor"/> with the given <paramref name="parameters"/>.</returns>
		/// <param name="parameters">The given list of expressions with which the call is initialized.</param>
		/// <remarks>
		/// <para>Items in the <paramref name="parameters"/> that are not effective, or not correctly typed will
		/// be ignored.</para>
		/// </remarks>
		public override IExpression CallCommand (IEnumerable<IExpression> parameters) {
			Contract.Requires (this.TypeContainer is ICSharpType);
			ICSharpType icst = this.TypeContainer as ICSharpType;
			return new Expression (new CodeObjectCreateExpression (icst.Reference));
		}
		#endregion
	}
}

