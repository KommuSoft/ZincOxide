//
//  MethodReference.cs
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
using ZincOxide.Utils.Abstract;
using System.Reflection;
using ZincOxide.Codegen.Abstract.Imperative;
using System.Collections.Generic;

namespace ZincOxide.Codegen.Abstract.OO.CSharp {

	/// <summary>
	/// An already defined method in C# (example <see cref="M:StringBuilder.Append"/>).
	/// </summary>
	public class MethodReference : NameShadow, IMethod {

		#region Fields
		private readonly MethodInfo data;
		#endregion
		#region implemented abstract members of NameShadow
		/// <summary>
		/// Gets the name of this method.
		/// </summary>
		/// <value>The name of this method.</value>
		public override string Name {
			get {
				return this.data.Name;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="MethodReference"/> class.
		/// </summary>
		/// <param name="data">The <see cref="MethodInfo"/> that contains the specifications of the method.</param>
		internal MethodReference (MethodInfo data) {
			this.data = data;
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
		/// <para>Already defined method cannot be reimplemented. The reimplementation is ignored.</para>
		/// </remarks>
		public void Reimplement (ICommand commands) {
		}

		/// <summary>
		/// Generate a class command that can be used as part of a procedure implementation.
		/// </summary>
		/// <returns>A <see cref="ICommand"/> that represents a call to this <see cref="IMethod"/> with the given <paramref name="parameters"/>.</returns>
		/// <param name="parameters">The given list of expressions with which the call is initialized.</param>
		public ICommand CallCommand (params IExpression[] parameters) {
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Generate a class command that can be used as part of a procedure implementation.
		/// </summary>
		/// <returns>A <see cref="ICommand"/> that represents a call to this <see cref="IMethod"/> with the given <paramref name="parameters"/>.</returns>
		/// <param name="parameters">The given list of expressions with which the call is initialized.</param>
		public ICommand CallCommand (IEnumerable<IExpression> parameters) {
			throw new NotImplementedException ();
		}
		#endregion
	}
}

