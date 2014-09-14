//
//  Method.cs
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
using System.CodeDom;
using ZincOxide.Codegen.Abstract.Imperative;
using System.Collections.Generic;
using ZincOxide.Codegen.Abstract.OO;
using System.Diagnostics.Contracts;

namespace ZincOxide.Codegen.Languages.CSharp {

	/// <summary>
	/// The representation of a <see cref="IMethod"/> in C#.
	/// </summary>
	public class Method : MethodBase {

		#region Fields
		internal readonly CodeMemberMethod Data;
		#endregion
		#region implemented abstract members of NameShadow
		/// <summary>
		/// Gets the name of this instance.
		/// </summary>
		/// <value>The name of this instance.</value>
		public override string Name {
			get {
				return Data.Name;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Method"/> class with the given data specifying the
		/// method.
		/// </summary>
		/// <param name="data">The given <see cref="CodeMemberMethod"/> that specifies the method.</param>
		/// <param name="typeContainer">A <see cref="ICSharpType"/> that represents the type of which this <see cref="IConstructor"/> can create instances.</param>
		/// <exception cref="ArgumentNullException">If the given <paramref name="typeContainer"/> is not effective.</exception>
		internal Method (ICSharpType typeContainer, CodeMemberMethod data) : base(typeContainer) {
			if (typeContainer == null) {
				throw new ArgumentNullException ("typeContainer");
			}
			Contract.EndContractBlock ();
			this.Data = data;
		}
		#endregion
		#region implemented abstract members of MethodBase
		/// <summary>
		/// Reimplement the procedure member with the given <paramref name="commands"/>.
		/// </summary>
		/// <param name="commands">The list of commands that are the implementation of
		/// the <see cref="IProcedureMember"/>.</param>
		/// <remarks>
		/// <para>if the given <paramref name="commands"/> is not effective, no modifications
		/// is done to the method.</para>
		/// </remarks>
		public override void Reimplement (ICommand commands) {
			if (commands != null) {
				CodeStatementCollection csc = this.Data.Statements;
				csc.Clear ();
				CSharpUtils.TranslateCommandToStatement (commands, csc);
			}
		}

		/// <summary>
		/// Generate a class command that can be used as part of a procedure implementation.
		/// </summary>
		/// <returns>A <see cref="ICommand"/> that represents a call to this <see cref="IMethod"/> with the given <paramref name="parameters"/>.</returns>
		/// <param name="instance">The instance on which the command is applied.</param>
		/// <param name="parameters">The given list of expressions with which the call is initialized.</param>
		public override ICommand CallCommand (IExpression instance, IEnumerable<IExpression> parameters) {
			throw new NotImplementedException ();
		}
		#endregion
	}
}

